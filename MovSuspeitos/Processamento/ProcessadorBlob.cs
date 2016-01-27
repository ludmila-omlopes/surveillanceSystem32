using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV.VideoSurveillance;
using Emgu.CV.Structure;
using Emgu.CV;
using Emgu.CV.CvEnum;
using System.Drawing;
using System.Windows.Forms;
using FaceDetection.Janelas;
using FaceDetection.Util;
using Emgu.CV.Cvb;

namespace FaceDetection.Processamento
{
    public class ProcessadorBlob : ProcessadorDeVideo
    {
        CvBlobs mblobs;
        static CvBlobDetector mBlobDetector;
        Kalman kal;
        Matrix<float> medidaKalman;
        private static BackgroundSubtractorMOG2 mDetector;
        public JanelaDeMonitoramentoBlob mJanelaMonitoramento;
        public DefinirAreaRestrita mJanelaAreaRestrita;
        public JanelaDeCalibracao mJanelaCalibracao;
        private int mContadorDeBlobs = 1;
        public int mEtapa = 0;

        Mat mImagemCinzaSemPlanoDeFundo;
        Mat mImagemDoPlanoDeFundo;
        Mat mImagemSemPlanoDeFundo;
        Mat mCopiaImagemPlanoDeFundo;
        IntPtr mHistoricoDoMovimento;
        Mat mImagemBinariaSemPlanoDeFundo;
        IntPtr mImagemBinariaSemPlanoDeFundo2;
        IntPtr mMemStorage;
        bool mPrimeiraExecucao = true;
        Emgu.CV.UI.HistogramBox vHist;

        private Capture _capture = null;
        private bool _captureInProgress;

       // Dictionary<int, MonitorDePessoa> dicionarioMonitores = new Dictionary<int, MonitorDePessoa>();

        public ProcessadorBlob(String pNomeDoArquivo, JanelaDeMonitoramentoBlob pJanelaMonitoramento, ParametrosDinamicos pParametros)
            : base(pNomeDoArquivo)
        {
            mJanelaMonitoramento = pJanelaMonitoramento;
            mEtapa = 2;
            parametros = pParametros;
        }

        public ProcessadorBlob(String pNomeDoArquivo, DefinirAreaRestrita pJanelaMonitoramento, ParametrosDinamicos pParametros)
            : base(pNomeDoArquivo)
        {
            mJanelaAreaRestrita = pJanelaMonitoramento;
            parametros = pParametros;
            mEtapa = 1; //indica que é Mapeamento
        }

        public ProcessadorBlob(String pNomeDoArquivo, JanelaDeCalibracao pJanelaCalibracao, ParametrosDinamicos pParametros)
            : base(pNomeDoArquivo)
        {
            mJanelaCalibracao = pJanelaCalibracao;
            parametros = pParametros;
        }

        protected override void processarImagem(bool mapeamento)
        {
            preencherImagemPlanoDeFundo();
            preencherImagemBinariaSemPlanoDeFundo();
            Mat imagemCinza = ConverterParaCinzas(mImagemBinariaSemPlanoDeFundo);
            if (mapeamento)
            {
                //Image<Bgr, byte> mCopiaMenorPlanoFundo = mCopiaImagemPlanoDeFundo.Resize(0.7, Inter.Area);
                Mat mCopiaMenorPlanoFundo = new Mat();
                CvInvoke.Resize(mCopiaImagemPlanoDeFundo, mCopiaMenorPlanoFundo, mCopiaImagemPlanoDeFundo.Size, 0.7, 0.7);
               // Image<Gray, byte> mCopiaMenorImagemCinza = imagemCinza.Resize(0.7, Inter.Area);
               // Image<Gray, byte> mCopiaMenorImagemCinza = imagemCinza.Clone();
                //imagemCinza = imagemCinza.Resize(0.7, Inter.Area);
                mJanelaCalibracao.PlanoDeFundo.Image = mCopiaMenorPlanoFundo;
                //mJanelaCalibracao.Objetos.Image = imagemCinza;
            }
            //mTracker.Process(mImagemColorida, ConverterParaCinzas(mImagemBinariaSemPlanoDeFundo));
            mblobs = new CvBlobs();
            mBlobDetector.Detect(imagemCinza.ToImage<Gray, byte>(), mblobs);
            mblobs.FilterByArea(100, int.MaxValue);
        }

        public virtual Mat ConverterParaCinzas(Mat pImagem)
        {
            Mat grayFrame = new Mat();
            if (pImagem.NumberOfChannels >= 3)
            {
                CvInvoke.CvtColor(pImagem, grayFrame, ColorConversion.Bgr2Gray);
            }
            else
            {
                grayFrame = pImagem;
            }
            return grayFrame;
        }

        private void preencherImagemBinariaSemPlanoDeFundo()
        {
            mCopiaImagemPlanoDeFundo = mImagemDoPlanoDeFundo.Clone();
            CvInvoke.AbsDiff(mImagemColorida, mCopiaImagemPlanoDeFundo, mImagemSemPlanoDeFundo);
            CvInvoke.CvtColor(mImagemSemPlanoDeFundo, mImagemCinzaSemPlanoDeFundo, ColorConversion.Rgb2Gray);
           // CvInvoke.Threshold(mImagemCinzaSemPlanoDeFundo, mImagemBinariaSemPlanoDeFundo, ParametrosConstantes.LimiarTransformacaoParaCinza,
            //ParametrosConstantes.MaximoLimiarTransformacaoParaCinza, ThresholdType.Binary);
            CvInvoke.AdaptiveThreshold(mImagemCinzaSemPlanoDeFundo, mImagemBinariaSemPlanoDeFundo, ParametrosConstantes.MaximoLimiarTransformacaoParaCinza,
               AdaptiveThresholdType.GaussianC, ThresholdType.Binary, 11, 3);
        }

        private void preencherImagemPlanoDeFundo()
        {
            if (mPrimeiraExecucao)
            {
                mImagemSemPlanoDeFundo = mImagemColorida.Clone();
                mCopiaImagemPlanoDeFundo = mImagemColorida.Clone();
                mImagemDoPlanoDeFundo = mImagemColorida.Clone();
                mPrimeiraExecucao = false;
            }
            else
            {
                double alpha = parametros == null ? 0.5 : parametros.AlphaMediaMovel; //TODO: passar o valor padrão para a classe ParametrosDinamicos
                CvInvoke.AccumulateWeighted(mImagemColorida, mImagemDoPlanoDeFundo, alpha);
            }
        }

        protected override void exibirImagem(bool mapeamento)
        {
            if (mapeamento)
            {
                if(mJanelaCalibracao != null)
                    mJanelaCalibracao.Imagem.Image = mImagemColorida;
                else
                    mJanelaAreaRestrita.Imagem.Image = mImagemColorida;
            }
            else
            {
                mJanelaMonitoramento.ImagemMonitorada.Image = mImagemColorida;
                //mJanelaMonitoramento.ImagemPlanoDeFundo.Image = mImagemSemPlanoDeFundo.ToBitmap();
            }         
        }

        protected override void inicializarVariaveis()
        {
            base.inicializarVariaveis();
            mDetector = new Emgu.CV.VideoSurveillance.BackgroundSubtractorMOG2();
             mBlobDetector = new CvBlobDetector();

             Size vTamanhoDasImagens = mImagemColorida.Size;
            mImagemCinzaSemPlanoDeFundo = new Mat();
            mImagemDoPlanoDeFundo = new Mat(vTamanhoDasImagens.Width, vTamanhoDasImagens.Height, DepthType.Cv32F, 3);
            mImagemSemPlanoDeFundo = null;// = cvCreateImage(gTamanhoDaImagem, IPL_DEPTH_32F, 3);;
            mCopiaImagemPlanoDeFundo = null;
            mImagemBinariaSemPlanoDeFundo = new Mat();
            vHist = new Emgu.CV.UI.HistogramBox();
            vHist.Show();
            vHist.Visible = true;
            mPrimeiraExecucao = true;
            dicionarioMonitores = new Dictionary<int, MonitorDePessoa>();
            dicionarioBlobs = new Dictionary<int, MCvBlob>();
        }
        
        protected override void desenharNaImagem(ParametrosDinamicos parametros)
        {
            if (parametros.PontosAreaRestrita != null && parametros.PontosAreaRestrita.Count > 0)
            {
                for (int i = 1; i < parametros.PontosAreaRestrita.Count; i++)
                {
                    //CvInvoke.cvLine(mImagemColorida, parametros.PontosAreaRestrita[i - 1], parametros.PontosAreaRestrita[i], new MCvScalar(255, 0, 0, 0), 1, LINE_TYPE.CV_AA, 0);
                    CvInvoke.Line(mImagemColorida, parametros.PontosAreaRestrita[i - 1], parametros.PontosAreaRestrita[i], new MCvScalar(255, 0, 0, 0), 1, LineType.AntiAlias , 0);
                }
            }

            List<MonitorDePessoa> vPessoasEmCena = new List<MonitorDePessoa>();
            foreach (CvBlob blob2 in mblobs.Values)
            {
                MCvBlob blob = new MCvBlob();
                blob.Center = blob2.Centroid;
                blob.Size = blob2.BoundingBox.Size;
                
                if (blob.Size.Height > blob.Size.Width && blob.Center.X > 70 && blob.Center.X < 565 || dicionarioMonitores.ContainsKey(blob.ID))//verificarSeEhTamanhoDePessoa(blob.Size.Height, blob.Size.Width, blob.Center.X, blob.Center.Y))
                {
                    MonitorDePessoa vMonitorAtual = obterMonitorDePessoa(blob);
                    vMonitorAtual.adicionarNovoBlob(blob, base.mContadorDeFrames);
                    List<Point> vPontos = vMonitorAtual.obterPontos();
                   // desenharCaminho(vPontos);
                    Point p1 = new Point((int)((blob.Center.X - blob.Size.Width/2)*0.98), (int)((blob.Center.Y - blob.Size.Height/2)*0.98));
                    Point p2 = new Point((int)((blob.Center.X + blob.Size.Width/2)*1.08), (int)((blob.Center.Y + blob.Size.Height/2)*1.08));
                    MCvScalar corTexto;
                    parametros.RetanguloPessoa = new Rectangle(new Point(p1.X, p2.Y), new Size(p2.X-p1.X, p2.Y-p1.Y));
                    if (vMonitorAtual.verificarSePossuiComportamentoSuspeito(parametros).Suspeito)
                        corTexto = new MCvScalar(0, 0, 255, 0);
                    else
                        corTexto = new MCvScalar(0, 255, 0, 0);

                    //CvInvoke.cvRectangle(mImagemColorida, p1, p2, corTexto, 1, LINE_TYPE.CV_AA, 0);                    
                    CvInvoke.Rectangle(mImagemColorida, blob2.BoundingBox, new MCvScalar(255.0, 255.0, 255.0), 2);
                    p1.Y = p1.Y - 10;
                    escreverId(blob.ID.ToString(), p1, corTexto);
                    vPessoasEmCena.Add(vMonitorAtual);
                }
            }
            mJanelaMonitoramento.GridPessoasMonitoradas.Rows.Clear();
            foreach(MonitorDePessoa vPessoa in vPessoasEmCena)
            {
                RespostaVerificacao resposta = vPessoa.verificarSePossuiComportamentoSuspeito(parametros);
                DataGridViewRow vNovaLinha = new DataGridViewRow();
                vNovaLinha.CreateCells(mJanelaMonitoramento.GridPessoasMonitoradas, new String[]{vPessoa.obterIdentificador().ToString(), vPessoa.obterVelocidadeMetroPorSegundo().ToString(),
                    vPessoa.obterVelocidadeKmPorHora().ToString(), vPessoa.obterTempoEmCena().ToString(), vPessoa.obterNumeroDeInversoes().ToString(),
                    resposta.Mensagem});
                vNovaLinha.DefaultCellStyle.BackColor = resposta.Suspeito ? Color.Red : Color.Green;
                vNovaLinha.DefaultCellStyle.SelectionBackColor = vNovaLinha.DefaultCellStyle.BackColor;
                mJanelaMonitoramento.GridPessoasMonitoradas.Rows.Add(vNovaLinha);
            }

            mSalvarImagem = mJanelaMonitoramento.SalvarImagem;
            mJanelaMonitoramento.SalvarImagem = false;
        }

        private void escreverId(String pBlobID, Point pPoint, MCvScalar pCorTexto)
        {
            //MCvFont font = new MCvFont();
            //CvInvoke.f(ref font, FONT.CV_FONT_HERSHEY_SIMPLEX, 1.0, 1.0, 0, 1, LineType.AntiAlias);
            CvInvoke.PutText(mImagemColorida, pBlobID, pPoint, FontFace.HersheyDuplex, 1, pCorTexto);
        }

        private void desenharCaminho(List<Point> pPontos, MCvScalar cor)
        {
            if (pPontos != null && pPontos.Count > 1)
            {
                for (int i = 1; i < pPontos.Count; i++)
                {
                    CvInvoke.Line(mImagemColorida, pPontos[i], pPontos[i - 1], cor, 2, LineType.FourConnected, 0);
                }
            }
        }

        private MonitorDePessoa obterMonitorDePessoa(MCvBlob blob)
        {
            MonitorDePessoa vRetorno;
            int id = verificarExistenciaBlob(blob);
            if(id == 0)
            {
                vRetorno = new MonitorDePessoa();
                blob.ID = mContadorDeBlobs;
                mContadorDeBlobs++;
                vRetorno.ID = blob.ID;
                dicionarioBlobs.Add(blob.ID, blob);
                dicionarioMonitores.Add(blob.ID, vRetorno);
            }
            else
            {
                vRetorno = dicionarioMonitores[id];
            }
            return vRetorno;
        }

        private int verificarExistenciaBlob(MCvBlob pBlob)
        {
            foreach (MonitorDePessoa monitor in dicionarioMonitores.Values)
            {
                MCvBlob blobAtual = monitor.mListaBlobsENumeroFrame.Last().mBlob;
                Point pontoPrevisto = monitor.mPontosKalman.Last();

                if(pBlob.Size.Height > blobAtual.Size.Height*0.6 &&
                    pBlob.Size.Width > blobAtual.Size.Width * 0.6 &&
                    pBlob.Size.Height < blobAtual.Size.Height * 1.4 &&
                    pBlob.Size.Width < blobAtual.Size.Width * 1.4 &&
                    Math.Abs(pBlob.Center.X - pontoPrevisto.X) < 160 &&
                    Math.Abs(pBlob.Center.Y - pontoPrevisto.Y) < 160)
                    return blobAtual.ID;
            }
            return 0;
        }

        

        protected override void atualizarParametros(ParametrosDinamicos parametros)
        {
            if (mJanelaMonitoramento.AtualizarParametros)
            {
                mJanelaMonitoramento.AtualizarParametros = false;
                parametros.TempoMaximoEmCena = Convert.ToInt32(mJanelaMonitoramento.TempoMaximoEmCena);
                parametros.NumeroMaximoDeInversoesDeRota = mJanelaMonitoramento.NumeroInversoes;
                parametros.VelocidadeMaxima = mJanelaMonitoramento.VelocidadeMaxima;

            }
        }

        protected override void carregarParametrosNaTela(ParametrosDinamicos parametros)
        {
            if (parametros == null)
                parametros = new ParametrosDinamicos();
            mJanelaMonitoramento.NumeroInversoes = parametros.NumeroMaximoDeInversoesDeRota;
            mJanelaMonitoramento.VelocidadeMaxima = parametros.VelocidadeMaxima;
            mJanelaMonitoramento.TempoMaximoEmCena = parametros.TempoMaximoEmCena;
        }

        public void calibrar()
        {
            mDetector = new Emgu.CV.VideoSurveillance.BackgroundSubtractorMOG2();
            mBlobDetector = new CvBlobDetector();
            _capture = new Capture(mNomeDoArquivo);
            //_capture = new Capture();
            inicializarKalman();
            Application.Idle += ProcessFrame;
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            Mat frame = _capture.QueryFrame();
            if (frame == null)
            {
                if (mEtapa == 1)
                    preencherParametrosMapeamento();
                _capture.Dispose();
                return;
            }
            mContadorDeFrames++;
            if (mEtapa == 0)
            {
                verificarEatualizarParametrosCalibracao();
            }
            _capture.Retrieve(frame, 0);

            Image<Bgr, Byte> smoothedFrame = new Image<Bgr, byte>(frame.Size);
            CvInvoke.GaussianBlur(frame, smoothedFrame, new Size(parametros.AlphaMediaMovel, parametros.AlphaMediaMovel), parametros.AlphaMediaMovel); //filter out noises

            // use the BG/FG detector to find the forground mask
            Mat forgroundMask = new Mat();
            mDetector.Apply(smoothedFrame, forgroundMask);
            //CvInvoke.AbsDiff(smoothedFrame, forgroundMask.ToImage<Bgr, byte>(), vPlanoFundo);

            mblobs = new CvBlobs();
            mBlobDetector.Detect(forgroundMask.ToImage<Gray, byte>(), mblobs);
            mblobs.FilterByArea(100, int.MaxValue);
            if (mEtapa == 0)
            {
                mJanelaCalibracao.Imagem.Image = frame;
                Mat vCopiaMenorBinaria = new Mat();
                CvInvoke.Resize(forgroundMask, vCopiaMenorBinaria, new Size(0, 0), 0.7, 0.7, Inter.Area);
                mJanelaCalibracao.PlanoDeFundo.Image = smoothedFrame;
                mJanelaCalibracao.Objetos.Image = vCopiaMenorBinaria;
            }
            if (mEtapa == 1)
            {
                mJanelaAreaRestrita.Imagem.Image = frame;
            }
            if (mEtapa == 2)
            {
                mJanelaMonitoramento.ImagemMonitorada.Image = frame;
            }
            mImagemColorida = frame;
            if (mEtapa == 0)
            {
                desenharParametroTamanhoPessoa();
                desenharRetanguloPessoa();
            }
            if (mEtapa == 1)
            {
                desenharEMapear();
            }
            if(mEtapa == 2)
            {
                atualizarParametros(parametros);
                desenharEprocessar();
            }
        }

        private void verificarEatualizarParametrosCalibracao()
        {
            if (mJanelaCalibracao.evento == true)
            {
                if (mJanelaCalibracao.Alpha.Value % 2 == 0)
                    parametros.AlphaMediaMovel = mJanelaCalibracao.Alpha.Value - 1;
                else
                    parametros.AlphaMediaMovel = mJanelaCalibracao.Alpha.Value;
                parametros.AlturaPessoa = mJanelaCalibracao.Altura.Value;
                parametros.LarguraPessoa = mJanelaCalibracao.Lagura.Value;
                parametros.FaixaToleranciaTamanhoAltura = mJanelaCalibracao.ToleranciaAltura.Value/10.0;
                parametros.FaixaToleranciaTamanhoLargura = mJanelaCalibracao.ToleranciaLargura.Value/10.0;
                mJanelaCalibracao.evento = false;
            }
            if (!mJanelaCalibracao.Visible)
                mFinalizar = true;
        }

        private void desenharRetanguloPessoa()
        {
            List<MonitorDePessoa> vPessoasEmCena = new List<MonitorDePessoa>();
            foreach (var blob2 in mblobs.Values)
            {
                MCvBlob blob = new MCvBlob();
                blob.Center = blob2.Centroid;
                blob.Size = blob2.BoundingBox.Size;
             
                if (verificarSeEhTamanhoDePessoa(blob.Size.Height, blob.Size.Width, blob.Center.X, blob.Center.Y))
                {
                    MonitorDePessoa vMonitorAtual = obterMonitorDePessoa(blob);
                    blob.ID = vMonitorAtual.obterIdentificador();
                    vMonitorAtual.adicionarNovoBlob(blob, base.mContadorDeFrames);
                    
                    List<Point> vPontos = vMonitorAtual.obterPontos();
                    desenharCaminho(vPontos, new MCvScalar(0, 0, 255.0, 0));
                    desenharCaminho(vMonitorAtual.obterPontosKalman(), new MCvScalar(0, 0, 255.0, 0));
                    Point p1 = new Point((int)((blob.Center.X - blob.Size.Width / 2) * 0.98), (int)((blob.Center.Y - blob.Size.Height / 2) * 0.98));
                    Point p2 = new Point((int)((blob.Center.X + blob.Size.Width / 2) * 1.08), (int)((blob.Center.Y + blob.Size.Height / 2) * 1.08));
                    MCvScalar corTexto;
                    parametros.RetanguloPessoa = new Rectangle(new Point(p1.X, p2.Y), new Size(p2.X - p1.X, p2.Y - p1.Y));
                   // if (verificarSeEhTamanhoDePessoa(parametros.RetanguloPessoa))
                    if(true)
                    {
                        Point[] pontosKalman = aplicarFiltroKalman(blob);
                        corTexto = new MCvScalar(255, 0, 0, 0);
                        vMonitorAtual.adicionarPontoKalman(pontosKalman[1]);
                        CvInvoke.Rectangle(mImagemColorida, blob2.BoundingBox, new MCvScalar(255.0, 255.0, 255.0), 2);
                        CvInvoke.Line(mImagemColorida, pontosKalman[0], pontosKalman[0], new MCvScalar(255.0, 0, 0, 0), 3);
                        CvInvoke.Line(mImagemColorida, pontosKalman[1], pontosKalman[1], new MCvScalar(0, 0, 255.0, 0), 3);
                        p1.Y = p1.Y - 10;
                        escreverId(blob.ID.ToString(), p1, corTexto);
                        vPessoasEmCena.Add(vMonitorAtual);
                    }
                }
            }
        }

        protected override void desenharEMapear()
        {
            List<MonitorDePessoa> vPessoasEmCena = new List<MonitorDePessoa>();

            foreach (var blob2 in mblobs.Values)
            {
                MCvBlob blob = new MCvBlob();
                blob.Center = blob2.Centroid;
                blob.Size = blob2.BoundingBox.Size;

                if (verificarSeEhTamanhoDePessoa(blob.Size.Height, blob.Size.Width, blob.Center.X, blob.Center.Y))
                {
                    MonitorDePessoa vMonitorAtual = obterMonitorDePessoa(blob);
                    blob.ID = vMonitorAtual.obterIdentificador();
                    vMonitorAtual.adicionarNovoBlob(blob, base.mContadorDeFrames);

                    List<Point> vPontos = vMonitorAtual.obterPontos();
                    //desenharCaminho(vPontos);
                    Point p1 = new Point((int)((blob.Center.X - blob.Size.Width / 2) * 0.98), (int)((blob.Center.Y - blob.Size.Height / 2) * 0.98));
                    Point p2 = new Point((int)((blob.Center.X + blob.Size.Width / 2) * 1.08), (int)((blob.Center.Y + blob.Size.Height / 2) * 1.08));
                    MCvScalar corTexto = new MCvScalar(0, 255, 0, 0);

                    Point[] pontosKalman = aplicarFiltroKalman(blob);
                    corTexto = new MCvScalar(255, 0, 0, 0);
                    vMonitorAtual.adicionarPontoKalman(pontosKalman[1]);
                    //CvInvoke.cvRectangle(mImagemColorida, p1, p2, corTexto, 1, LINE_TYPE.CV_AA, 0);
                    CvInvoke.Rectangle(mImagemColorida, blob2.BoundingBox, new MCvScalar(255.0, 255.0, 255.0), 2);
                    p1.Y = p1.Y - 10;
                    escreverId(blob.ID.ToString(), p1, corTexto);
                    vPessoasEmCena.Add(vMonitorAtual);
                }
            }

            parametros.PontosAreaRestrita = mJanelaAreaRestrita.obterPontos();
            desenharCaminho(parametros.PontosAreaRestrita, new MCvScalar(0, 0, 255.0, 0));
            mJanelaAreaRestrita.GridPessoasMonitoradas.Rows.Clear();
            foreach (MonitorDePessoa vPessoa in vPessoasEmCena)
            {
                DataGridViewRow vNovaLinha = new DataGridViewRow();
                vNovaLinha.CreateCells(mJanelaAreaRestrita.GridPessoasMonitoradas, new String[]{vPessoa.obterIdentificador().ToString(), vPessoa.obterVelocidadeMetroPorSegundo().ToString(),
                    vPessoa.obterVelocidadeKmPorHora().ToString(), vPessoa.obterTempoEmCena().ToString(), vPessoa.obterNumeroDeInversoes().ToString(),
                   "MAPEANDO..."
                });
                vNovaLinha.DefaultCellStyle.BackColor = Color.Green;
                vNovaLinha.DefaultCellStyle.SelectionBackColor = vNovaLinha.DefaultCellStyle.BackColor;
                if (mJanelaAreaRestrita.GridPessoasMonitoradas.ColumnCount > 0)
                {
                    mJanelaAreaRestrita.GridPessoasMonitoradas.Rows.Add(vNovaLinha);
                }
            }

            if (!mJanelaAreaRestrita.Visible)
                mFinalizar = true;
        }

        private void desenharParametroTamanhoPessoa()
        {
            if (mImagemColorida == null)
                return;
            int[] pontoInicial = { 80, 80};

            Rectangle retangulo = new Rectangle(new Point(pontoInicial[0], pontoInicial[1]), new Size(parametros.LarguraPessoa, (int)parametros.AlturaPessoa));
            
            Rectangle retanguloMaior = new Rectangle(new Point(Convert.ToInt32(pontoInicial[0]-(parametros.FaixaToleranciaTamanhoLargura/2*parametros.LarguraPessoa)), 
                Convert.ToInt32(pontoInicial[1]-(parametros.FaixaToleranciaTamanhoAltura/2*parametros.LarguraPessoa))), new Size(Convert.ToInt32(parametros.LarguraPessoa*(1+parametros.FaixaToleranciaTamanhoLargura)),
                    Convert.ToInt32(parametros.AlturaPessoa*(1+parametros.FaixaToleranciaTamanhoAltura))));

            Rectangle retanguloMenor = new Rectangle(new Point(Convert.ToInt32(pontoInicial[0]+(parametros.FaixaToleranciaTamanhoLargura/2*parametros.LarguraPessoa)),
                Convert.ToInt32(pontoInicial[1]+(parametros.FaixaToleranciaTamanhoAltura/2*parametros.AlturaPessoa))), new Size(Convert.ToInt32(parametros.LarguraPessoa *(1-parametros.FaixaToleranciaTamanhoLargura)),
                    Convert.ToInt32(parametros.AlturaPessoa *(1-parametros.FaixaToleranciaTamanhoAltura))));

            CvInvoke.Rectangle(mImagemColorida,retangulo, new MCvScalar(0, 255, 0, 0), 1, LineType.AntiAlias, 0);
            CvInvoke.Rectangle(mImagemColorida, retanguloMaior, new MCvScalar(0, 0, 255, 0), 1);
            CvInvoke.Rectangle(mImagemColorida, retanguloMenor, new MCvScalar(0, 0, 255, 0), 1);
        }

        private Point[] aplicarFiltroKalman(MCvBlob blob)
        {
            if (mPrimeiraExecucao)
            {
                kal.PredictedState = new Matrix<float>(new float[4, 1] { {blob.Center.X}, {blob.Center.Y}, {0}, {0} });
            }

            Matrix<float> prediction = kal.Predict();
             Point predictPt = new Point((int)prediction[0,0], (int)prediction[1,0]);
              
         // Get blob point
           
            medidaKalman[0,0] = blob.Center.X;
            medidaKalman[1,0] = blob.Center.Y;
  
         // The update phase 

            Matrix<float> estimado = kal.Correct(medidaKalman);
            
            Point estadoPt = new Point((int)estimado[0,0], (int)estimado[1,0]);
            Point medidoPt = new Point((int)medidaKalman[0,0], (int)medidaKalman[1,0]);

            Point[] retorno = { estadoPt, medidoPt};
            CvInvoke.WaitKey(10);

            return retorno;
        }

        private void inicializarKalman()
        {
            kal = new Kalman(4, 2, 0);
            kal.TransitionMatrix = new Matrix<float>(new float[4, 4] { {1, 0, 1, 0}, {0, 1, 0, 1}, {0, 0, 1, 0}, {0, 0, 0, 1} });

            kal.MeasurementMatrix.SetIdentity();
            kal.ProcessNoiseCovariance.SetIdentity(new MCvScalar(1e-4));
            kal.MeasurementNoiseCovariance.SetIdentity(new MCvScalar(1e-4));
            kal.ErrorCovariancePost.SetIdentity(new MCvScalar(1e-4));

            medidaKalman = new Matrix<float>(2, 1);
        }

        public ParametrosDinamicos obterParametros()
        {
            return parametros;
        }

        public void mapear()
        {
            mDetector = new Emgu.CV.VideoSurveillance.BackgroundSubtractorMOG2();
            mBlobDetector = new CvBlobDetector();
            _capture = new Capture(mNomeDoArquivo);
            //_capture = new Capture();
            inicializarKalman();
            Application.Idle += ProcessFrame;
        }

        public void preencherParametrosMapeamento()
        {
            int pessoas = dicionarioMonitores.Count() > 0 ? dicionarioMonitores.Count() : 1;
            foreach (MonitorDePessoa vPessoa in dicionarioMonitores.Values)
            {
                parametros.NumeroMaximoDeInversoesDeRota += vPessoa.obterNumeroDeInversoes();
                parametros.VelocidadeMaxima += vPessoa.obterVelocidadeKmPorHora();
                parametros.TempoMaximoEmCena += Convert.ToInt32(vPessoa.obterTempoEmCena());
            }
            parametros.NumeroMaximoDeInversoesDeRota = parametros.NumeroMaximoDeInversoesDeRota / pessoas;
            parametros.VelocidadeMaxima = parametros.VelocidadeMaxima / pessoas;
            parametros.TempoMaximoEmCena = parametros.TempoMaximoEmCena / pessoas;
            parametros.RegiaoAreaRestrita = determinarRegiaoPorPontos(parametros.PontosAreaRestrita);
        }

        public void desenharEprocessar()
        {
            if (parametros.PontosAreaRestrita != null && parametros.PontosAreaRestrita.Count > 0)
            {
                for (int i = 1; i < parametros.PontosAreaRestrita.Count; i++)
                {
                    //CvInvoke.cvLine(mImagemColorida, parametros.PontosAreaRestrita[i - 1], parametros.PontosAreaRestrita[i], new MCvScalar(255, 0, 0, 0), 1, LINE_TYPE.CV_AA, 0);
                    CvInvoke.Line(mImagemColorida, parametros.PontosAreaRestrita[i - 1], parametros.PontosAreaRestrita[i], new MCvScalar(255, 0, 0, 0), 1, LineType.AntiAlias, 0);
                }
            }

            List<MonitorDePessoa> vPessoasEmCena = new List<MonitorDePessoa>();
            foreach (CvBlob blob2 in mblobs.Values)
            {
                MCvBlob blob = new MCvBlob();
                blob.Center = blob2.Centroid;
                blob.Size = blob2.BoundingBox.Size;

                if (verificarSeEhTamanhoDePessoa(blob.Size.Height, blob.Size.Width, blob.Center.X, blob.Center.Y) || verificarExistenciaBlob(blob) != 0)
                {
                    MonitorDePessoa vMonitorAtual = obterMonitorDePessoa(blob);
                    blob.ID = vMonitorAtual.obterIdentificador();
                    vMonitorAtual.adicionarNovoBlob(blob, base.mContadorDeFrames);
                    List<Point> vPontos = vMonitorAtual.obterPontos();
                    // desenharCaminho(vPontos);
                    Point p1 = new Point((int)((blob.Center.X - blob.Size.Width / 2) * 0.98), (int)((blob.Center.Y - blob.Size.Height / 2) * 0.98));
                    Point p2 = new Point((int)((blob.Center.X + blob.Size.Width / 2) * 1.08), (int)((blob.Center.Y + blob.Size.Height / 2) * 1.08));
                    MCvScalar corTexto;
                    parametros.RetanguloPessoa = new Rectangle(new Point(p1.X, p2.Y), new Size(p2.X - p1.X, p2.Y - p1.Y));
                    if (vMonitorAtual.verificarSePossuiComportamentoSuspeito(parametros).Suspeito)
                        corTexto = new MCvScalar(0, 0, 255, 0);
                    else
                        corTexto = new MCvScalar(0, 255, 0, 0);

                    Point[] pontosKalman = aplicarFiltroKalman(blob);
                    corTexto = new MCvScalar(255, 0, 0, 0);
                    vMonitorAtual.adicionarPontoKalman(pontosKalman[1]);
                    //CvInvoke.cvRectangle(mImagemColorida, p1, p2, corTexto, 1, LINE_TYPE.CV_AA, 0);                    
                    CvInvoke.Rectangle(mImagemColorida, blob2.BoundingBox, new MCvScalar(255.0, 255.0, 255.0), 2);
                    p1.Y = p1.Y - 10;
                    escreverId(blob.ID.ToString(), p1, corTexto);
                    vPessoasEmCena.Add(vMonitorAtual);
                }
            }
            mJanelaMonitoramento.GridPessoasMonitoradas.Rows.Clear();
            foreach (MonitorDePessoa vPessoa in vPessoasEmCena)
            {
                if (!mJanelaMonitoramento.Visible)
                    return;
                RespostaVerificacao resposta = vPessoa.verificarSePossuiComportamentoSuspeito(parametros);
                DataGridViewRow vNovaLinha = new DataGridViewRow();
                vNovaLinha.CreateCells(mJanelaMonitoramento.GridPessoasMonitoradas, new String[]{vPessoa.obterIdentificador().ToString(), vPessoa.obterVelocidadeMetroPorSegundo().ToString(),
                    vPessoa.obterVelocidadeKmPorHora().ToString(), vPessoa.obterTempoEmCena().ToString(), vPessoa.obterNumeroDeInversoes().ToString(),
                    resposta.Mensagem});
                vNovaLinha.DefaultCellStyle.BackColor = resposta.Suspeito ? Color.Red : Color.Green;
                vNovaLinha.DefaultCellStyle.SelectionBackColor = vNovaLinha.DefaultCellStyle.BackColor;
                mJanelaMonitoramento.GridPessoasMonitoradas.Rows.Add(vNovaLinha);
            }

            mSalvarImagem = mJanelaMonitoramento.SalvarImagem;
            mJanelaMonitoramento.SalvarImagem = false;
        }
    }
}
