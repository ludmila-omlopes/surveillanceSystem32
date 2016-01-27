using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using System.Drawing;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.Windows.Forms;
using FaceDetection.Janelas;

namespace FaceDetection.Processamento
{
    public class ProcessadorManual : ProcessadorDeVideo
    {
        IntPtr mImagemCinzaSemPlanoDeFundo;
        IntPtr mImagemDoPlanoDeFundo1;
        IntPtr mImagemDoPlanoDeFundo5;
        IntPtr mImagemDoPlanoDeFundo10;
        Image<Bgr, byte> mImagemSemPlanoDeFundo;
        Image<Bgr, byte> mCopiaImagemPlanoDeFundo;
        Image<Bgr, byte> mCopiaImagemPlanoDeFundo5;
        Image<Bgr, byte> mCopiaImagemPlanoDeFundo10;
        IntPtr mHistoricoDoMovimento;
        IntPtr mImagemBinariaSemPlanoDeFundo;
        IntPtr mMemStorage;
        bool mPrimeiraExecucao = true;
        IntPtr mContorno;
        JanelaDeMonitoramento mJanelaMonitoramento;

        public ProcessadorManual(String pNomeDoArquivo, JanelaDeMonitoramento pJanelaMonitoramento)
            : base(pNomeDoArquivo)
        {
            mJanelaMonitoramento = pJanelaMonitoramento;
        }
        /*
        protected override void inicializarVariaveis()
        {
            base.inicializarVariaveis();

            Size vTamanhoDasImagens = CvInvoke.cvGetSize(base.mImagemColorida);
            mImagemCinzaSemPlanoDeFundo = CvInvoke.cvCreateImage(vTamanhoDasImagens, IPL_DEPTH.IPL_DEPTH_8U, 1);
            mImagemDoPlanoDeFundo1 = CvInvoke.cvCreateImage(vTamanhoDasImagens, IPL_DEPTH.IPL_DEPTH_32F, 3);
            mImagemDoPlanoDeFundo5 = CvInvoke.cvCreateImage(vTamanhoDasImagens, IPL_DEPTH.IPL_DEPTH_32F, 3);
            mImagemDoPlanoDeFundo10 = CvInvoke.cvCreateImage(vTamanhoDasImagens, IPL_DEPTH.IPL_DEPTH_32F, 3);
            mImagemSemPlanoDeFundo = null;// = cvCreateImage(gTamanhoDaImagem, IPL_DEPTH_32F, 3);;
            mCopiaImagemPlanoDeFundo = null;
            mCopiaImagemPlanoDeFundo5 = null;
            mCopiaImagemPlanoDeFundo10 = null;
            mHistoricoDoMovimento = CvInvoke.cvCreateImage(vTamanhoDasImagens, IPL_DEPTH.IPL_DEPTH_8U, 3);
            mImagemBinariaSemPlanoDeFundo = CvInvoke.cvCreateImage(vTamanhoDasImagens, IPL_DEPTH.IPL_DEPTH_8U, 1);

            mMemStorage = CvInvoke.cvCreateMemStorage(0);
            mPrimeiraExecucao = true;
            mContorno = new IntPtr();
        }

        protected override void processarImagem(bool mapeamento)
        {
            preencherImagemPlanoDeFundo();
            preencherImagemBinariaSemPlanoDeFundo();
            efetuarDilatacoesEErosoesNaImagemBinariaSemPlanoDeFundo();
            preencherPontosContornoDaImagemBinaria();
        }

        private void preencherImagemPlanoDeFundo()
        {
            if (mPrimeiraExecucao)
            {
                mImagemSemPlanoDeFundo = mImagemColorida.Clone();
                mCopiaImagemPlanoDeFundo = mImagemColorida.Clone();
                mCopiaImagemPlanoDeFundo5 = mImagemColorida.Clone();
                mCopiaImagemPlanoDeFundo10 = mImagemColorida.Clone();
                CvInvoke.cvConvert(mImagemColorida, mImagemDoPlanoDeFundo1);
                CvInvoke.cvConvert(mImagemColorida, mImagemDoPlanoDeFundo5);
                CvInvoke.cvConvert(mImagemColorida, mImagemDoPlanoDeFundo10);
                mPrimeiraExecucao = false;
            }
            else
            {
                CvInvoke.cvRunningAvg(mImagemColorida, mImagemDoPlanoDeFundo1, ParametrosConstantes.AlphaMediaMovel, (IntPtr)null);
                CvInvoke.cvRunningAvg(mImagemColorida, mImagemDoPlanoDeFundo5, ParametrosConstantes.AlphaMediaMovel*5, (IntPtr)null);
                CvInvoke.cvRunningAvg(mImagemColorida, mImagemDoPlanoDeFundo10, ParametrosConstantes.AlphaMediaMovel*10, (IntPtr)null);
            }
        }


        private void efetuarDilatacoesEErosoesNaImagemBinariaSemPlanoDeFundo()
        {
            //CvInvoke.cvShowImage("mImagemBinariaSemPlanoDeFundoAntes", mImagemBinariaSemPlanoDeFundo);
            CvInvoke.cvDilate(mImagemBinariaSemPlanoDeFundo, mImagemBinariaSemPlanoDeFundo, IntPtr.Zero, 1);
            //CvInvoke.cvShowImage("mImagemBinariaSemPlanoDeFundo", mImagemBinariaSemPlanoDeFundo);
            CvInvoke.cvErode(mImagemBinariaSemPlanoDeFundo, mImagemBinariaSemPlanoDeFundo, IntPtr.Zero, 1);
            //CvInvoke.cvShowImage("mImagemBinariaSemPlanoDeFundo0", mImagemBinariaSemPlanoDeFundo);
            CvInvoke.cvDilate(mImagemBinariaSemPlanoDeFundo, mImagemBinariaSemPlanoDeFundo, IntPtr.Zero, 5);
            //CvInvoke.cvShowImage("mImagemBinariaSemPlanoDeFundo1", mImagemBinariaSemPlanoDeFundo);
            CvInvoke.cvErode(mImagemBinariaSemPlanoDeFundo, mImagemBinariaSemPlanoDeFundo, IntPtr.Zero, 3);
            //CvInvoke.cvShowImage("mImagemBinariaSemPlanoDeFundo2", mImagemBinariaSemPlanoDeFundo);
            //CvInvoke.cvDilate(mImagemBinariaSemPlanoDeFundo, mImagemBinariaSemPlanoDeFundo, IntPtr.Zero, 7);
            //CvInvoke.cvShowImage("mImagemBinariaSemPlanoDeFundo3", mImagemBinariaSemPlanoDeFundo);
            //CvInvoke.cvMatchTemplate
        }

        private void preencherImagemBinariaSemPlanoDeFundo()
        {
            CvInvoke.cvConvert(mImagemDoPlanoDeFundo1, mCopiaImagemPlanoDeFundo);
            CvInvoke.cvConvert(mImagemDoPlanoDeFundo5, mCopiaImagemPlanoDeFundo5);
            CvInvoke.cvConvert(mImagemDoPlanoDeFundo10, mCopiaImagemPlanoDeFundo10);
            //CvInvoke.cvShowImage("Plano de Fundo", mCopiaImagemPlanoDeFundo);
            mJanelaMonitoramento.ImagemPlanoDeFundo1.Image = mCopiaImagemPlanoDeFundo.ToBitmap();
            mJanelaMonitoramento.ImagemPlanoDeFundo5.Image = mCopiaImagemPlanoDeFundo5.ToBitmap();
            mJanelaMonitoramento.ImagemPlanoDeFundo10.Image = mCopiaImagemPlanoDeFundo10.ToBitmap();

            CvInvoke.cvAbsDiff(mImagemColorida, mCopiaImagemPlanoDeFundo, mImagemSemPlanoDeFundo);
            CvInvoke.cvCvtColor(mImagemSemPlanoDeFundo, mImagemCinzaSemPlanoDeFundo, COLOR_CONVERSION.CV_RGB2GRAY);
            CvInvoke.cvThreshold(mImagemCinzaSemPlanoDeFundo, mImagemBinariaSemPlanoDeFundo, ParametrosConstantes.LimiarTransformacaoParaCinza,
                ParametrosConstantes.MaximoLimiarTransformacaoParaCinza, THRESH.CV_THRESH_BINARY);
        }

        protected override void exibirImagem(bool mapeamento)
        {
            mJanelaMonitoramento.ImagemMonitorada.Image = mImagemColorida.ToBitmap();
        }

        private void preencherPontosContornoDaImagemBinaria()
        {
            CvInvoke.cvFindContours(mImagemBinariaSemPlanoDeFundo, mMemStorage, ref mContorno, StructSize.MCvContour,
                RETR_TYPE.CV_RETR_CCOMP, CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, new Point(0, 0));
            mPontosContorno = new Seq<Point>(mContorno, null);
        }

        protected override void desenharNaImagem(ParametrosDinamicos parametros)
        {
            for (; mPontosContorno != null && mPontosContorno.Ptr.ToInt32() != 0; mPontosContorno = mPontosContorno.HNext)
            {
                //bndRect = CvInvoke.cvBoundingRect(contour, 0);
                Rectangle vRetanguloDaEnvoltoria = CvInvoke.cvBoundingRect(mPontosContorno, 0);
                if (verificarSeEhTamanhoDePessoa(vRetanguloDaEnvoltoria))
                {
                    CvInvoke.cvRectangle(mImagemColorida, new Point(vRetanguloDaEnvoltoria.X, vRetanguloDaEnvoltoria.Y),
                        new Point(vRetanguloDaEnvoltoria.X + vRetanguloDaEnvoltoria.Width, vRetanguloDaEnvoltoria.Y + vRetanguloDaEnvoltoria.Height),
                        new MCvScalar(255, 0, 0, 0), 1, LINE_TYPE.FOUR_CONNECTED, 0);
                }
                //else
                //{
                //    CvInvoke.cvRectangle(mImagemColorida, new Point(vRetanguloDaEnvoltoria.X, vRetanguloDaEnvoltoria.Y),
                //                            new Point(vRetanguloDaEnvoltoria.X + vRetanguloDaEnvoltoria.Width, vRetanguloDaEnvoltoria.Y + vRetanguloDaEnvoltoria.Height),
                //                            new MCvScalar(255, 255, 0, 0), 1, LINE_TYPE.FOUR_CONNECTED, 0);
                //}
            }
        }*/
    }
}
