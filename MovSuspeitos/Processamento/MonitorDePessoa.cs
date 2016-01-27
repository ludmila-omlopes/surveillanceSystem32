using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV.Structure;
using Emgu.CV;
using System.Drawing;
using FaceDetection.Util;

namespace FaceDetection
{
    public class MonitorDePessoa
    {

        public class BlobENumeroDoFrame
        {
            public MCvBlob mBlob;
            public int mNumeroDoFrame;

            public BlobENumeroDoFrame(MCvBlob pBlob, int pNumeroDoFrame)
            {
                mBlob = pBlob;
                mNumeroDoFrame = pNumeroDoFrame;
            }

        }
        public List<BlobENumeroDoFrame> mListaBlobsENumeroFrame = new List<BlobENumeroDoFrame>();
        double? mVelocidadeAnterior = null;
        RespostaVerificacao mPossuiMovimentoSuspeito = null;
        public List<Point> mPontosKalman = new List<Point>();
        public int ID;

        public RespostaVerificacao PossuiMovimentoSuspeito
        {
            get
            { 
                if(!mPossuiMovimentoSuspeito.Suspeito)
                    mPossuiMovimentoSuspeito = verificarSePossuiComportamentoSuspeito(null);
                return mPossuiMovimentoSuspeito;
            }
        }

        public MonitorDePessoa()
        { 
        
        }

        internal RespostaVerificacao verificarSePossuiComportamentoSuspeito(ParametrosDinamicos parametros)
        {
            RespostaVerificacao resposta = new RespostaVerificacao();
            resposta.Suspeito = true;
            if (parametros == null)
                parametros = new ParametrosDinamicos();

            if (verificarSeEstaEmAreaProibida(parametros.RegiaoAreaRestrita))
            {
                resposta.Mensagem = "ATENÇÃO - PERMANÊNCIA EM ÁREA PROIBIDA";
                return resposta;
            }
            if (verificarSeNaoEstaEmPe(parametros.RetanguloPessoa))
            {
                resposta.Mensagem = "ATENÇÃO - PESSOA EM POSIÇÃO SUSPEITA";
                return resposta;
            }
            if (obterVelocidadeKmPorHora() > parametros.VelocidadeMaxima)
            {
                resposta.Mensagem = "ATENÇÃO - VELOCIDADE ACIMA DO NORMAL";
                return resposta;
            }
            if (verificarSePossuiRotaSuspeita(parametros.NumeroMaximoDeInversoesDeRota))
            {
                resposta.Mensagem = "ATENÇÃO - MOVIMENTAÇÃO SUSPEITA";
                return resposta;
            }
            if (obterTempoEmCena() > parametros.TempoMaximoEmCena)
            {
                resposta.Mensagem = "ATENÇÃO - TEMPO EM CENA ACIMA DO NORMAL";
                return resposta;
            }
            resposta.Suspeito = false;
            resposta.Mensagem = "NORMAL";
            return resposta;
        }

        private bool verificarSePossuiRotaSuspeita(int parametro)
        {
            return obterNumeroDeInversoes() > parametro;
        }

        public int obterNumeroDeInversoes()
        {
            int numeroInversoes = 0;
            if (mListaBlobsENumeroFrame.Count > 1)
            {
                bool indoParaDireita = (mListaBlobsENumeroFrame[1].mBlob.Center.X - mListaBlobsENumeroFrame[0].mBlob.Center.X) > 0;
                for (int i = 2; i < mListaBlobsENumeroFrame.Count; i++)
                {
                    if ((mListaBlobsENumeroFrame[i].mBlob.Center.X - mListaBlobsENumeroFrame[i - 1].mBlob.Center.X) > 0 != indoParaDireita)
                    {
                        numeroInversoes++;
                        indoParaDireita = !indoParaDireita;
                    }
                }
            }
            return numeroInversoes;
        }

        internal List<Point> obterPontos()
        {
            return mListaBlobsENumeroFrame.Select(vBlobENumeroFrame => new Point(Convert.ToInt32(vBlobENumeroFrame.mBlob.Center.X), 
                Convert.ToInt32(vBlobENumeroFrame.mBlob.Center.Y))).ToList();
        }

        internal List<Point> obterPontosKalman()
        {
            return mPontosKalman;
        }

        internal void adicionarPontoKalman(Point ponto)
        {
            mPontosKalman.Add(ponto);
        }

        internal int obterIdentificador()
        {
            return ID;
        }

        internal double obterVelocidade()
        {
            double vVelocidade = 0;
            int j = 0;
            for (int i = mListaBlobsENumeroFrame.Count - 1; i > mListaBlobsENumeroFrame.Count - 15 && i > 0; i--)
            {
                j++;
                vVelocidade = vVelocidade + Math.Sqrt(Math.Pow((mListaBlobsENumeroFrame[i].mBlob.Center.X - mListaBlobsENumeroFrame[i - 1].mBlob.Center.X), 2) +
                    Math.Pow((mListaBlobsENumeroFrame[i].mBlob.Center.Y - mListaBlobsENumeroFrame[i - 1].mBlob.Center.Y), 2));
            }
            return (j > 0) ? vVelocidade / j : vVelocidade;
        }

        internal double obterTempoEmCena()
        {
            if (mListaBlobsENumeroFrame.Count > 1)
                return Math.Round((mListaBlobsENumeroFrame[mListaBlobsENumeroFrame.Count - 1].mNumeroDoFrame - mListaBlobsENumeroFrame[0].mNumeroDoFrame) / ParametrosConstantes.FramesPorSegundo, 2);
            else
                return Math.Round(1 / ParametrosConstantes.FramesPorSegundo, 2);
        }

        internal void adicionarNovoBlob(MCvBlob pBlob, int pNumeroDoFrame)
        {
            mListaBlobsENumeroFrame.Add(new BlobENumeroDoFrame(pBlob, pNumeroDoFrame));
            mPossuiMovimentoSuspeito = null;
        }

        internal double obterVelocidadeMetroPorSegundo()
        {
            return Math.Round(obterVelocidade() * ParametrosConstantes.ConstanteConversaoVelocidadeMetroPorSegundo, 2);
        }

        internal double obterVelocidadeKmPorHora()
        {
            return Math.Round(obterVelocidade() * ParametrosConstantes.ConstanteConversaoVelocidadeKmPorHora, 2);
        }

        internal bool verificarSeEstaEmAreaProibida(Region regiao)
        {
            if (mListaBlobsENumeroFrame.Count > 0 && regiao != null)
            {
                int ultimoBlob = mListaBlobsENumeroFrame.Count-1;
                Point ponto = new Point(Convert.ToInt32(mListaBlobsENumeroFrame[ultimoBlob].mBlob.Center.X), 
                    Convert.ToInt32(mListaBlobsENumeroFrame[ultimoBlob].mBlob.Center.Y));

                return regiao.IsVisible(ponto);
            }
            return false;
        }

        internal bool verificarSeNaoEstaEmPe(Rectangle retanguloPessoa)
        {
            if (retanguloPessoa.Width >= retanguloPessoa.Height)
                return true;
            return false;
        }
    }
}
