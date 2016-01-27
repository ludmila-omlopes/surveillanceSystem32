using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using Emgu.CV.VideoSurveillance;
using FaceDetection.Janelas;
using System.Drawing.Drawing2D;
using System.Net.Mail;
using System.Net;

namespace FaceDetection
{
    public class ProcessadorDeVideo
    {
        public string mNomeDoArquivo = null;
        public Capture mCapture;
        public Mat mImagemColorida;
        public int mContadorDeFrames = 0;
        public Seq<Point> mPontosContorno;
        protected bool mFinalizar = false;
        protected bool mSalvarImagem = false;

        public ParametrosDinamicos parametros;
        protected Dictionary<int, MonitorDePessoa> dicionarioMonitores = new Dictionary<int, MonitorDePessoa>();
        protected Dictionary<int, MCvBlob> dicionarioBlobs = new Dictionary<int, MCvBlob>();

        public ProcessadorDeVideo(string pNomeDoArquivo)
        {
            mNomeDoArquivo = pNomeDoArquivo;
        }

        public void processarVideo(ParametrosDinamicos parametros)
        {
            mCapture = new Capture(mNomeDoArquivo);

            inicializarVariaveis();
            carregarParametrosNaTela(parametros);

            while (mImagemColorida != null)
            {
                atualizarParametros(parametros);
                mContadorDeFrames++;
                processarImagem(false);
                CvInvoke.WaitKey(100);
               // CvInvoke.cvShowImage("Imagem", mImagemColorida);
                desenharNaImagem(parametros);
                exibirImagem(false);

                if (mSalvarImagem)
                {
                    /*CvInvoke.SaveImage(String.Format(@"C:\Users\Tadeu Rahian\Dropbox\Dropbox\UFMG\PFC1\Imagens\mImagemColorida{0}.jpg", mContadorDeFrames), mImagemColorida);
                    EnviarImagensEmail(new Attachment(String.Format(@"C:\Users\Tadeu Rahian\Dropbox\Dropbox\UFMG\PFC1\Imagens\mImagemColorida{0}.jpg", mContadorDeFrames)));
                    mSalvarImagem = false;*/
                }
                mImagemColorida = mCapture.QueryFrame();
            }

            mCapture.Dispose();
        }

        protected virtual void carregarParametrosNaTela(ParametrosDinamicos parametros)
        {

        }

        protected virtual void atualizarParametros(ParametrosDinamicos parametros)
        {

        }

        public ParametrosDinamicos mapearVideo()
        {
            return null;
           /* mCapture = new Capture(mNomeDoArquivo);
            //mCapture = new Capture();
            inicializarVariaveis();


            while (mImagemColorida != null)
            {
                mContadorDeFrames++;
                processarImagem(false);
                CvInvoke.WaitKey(100);
                //CvInvoke.cvShowImage("Imagem", mImagemColorida);
                desenharEMapear();
                exibirImagem(true);
                mImagemColorida = mFinalizar ? null : mCapture.QueryFrame();
            }
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

            if(mCapture != null)
                mCapture.Dispose();

            return parametros;*/
        }

        protected virtual void exibirImagem(bool mapeamento)
        {}

        protected virtual void processarImagem(bool mapeamento)
        { }

        protected virtual void desenharNaImagem(ParametrosDinamicos parametros)
        { }

        protected virtual void desenharEMapear()
        { }

        protected virtual void inicializarVariaveis()
        {
            mImagemColorida = mCapture.QueryFrame();
            mContadorDeFrames = 0;
        }

        protected bool verificarSeEhTamanhoDePessoa(float pAltura, float pLargura, float pXCentro, float pYCentro)
        {
            return verificarSeEhTamanhoDePessoa(new Rectangle(Convert.ToInt32(pXCentro - (pLargura / 2)), 
                Convert.ToInt32(pYCentro - (pAltura / 2)), Convert.ToInt32(pLargura), Convert.ToInt32(pAltura)));
        }

        protected bool verificarSeEhTamanhoDePessoa(Rectangle vRetanguloDaEnvoltoria)
        {
            if (parametros == null)
                parametros = new ParametrosDinamicos();
            
            return vRetanguloDaEnvoltoria.Width > (parametros.LarguraPessoa * (1 - parametros.FaixaToleranciaTamanhoLargura))
                && vRetanguloDaEnvoltoria.Width < (parametros.LarguraPessoa * (1 + parametros.FaixaToleranciaTamanhoLargura))
                && vRetanguloDaEnvoltoria.Height > (parametros.AlturaPessoa * (1 - parametros.FaixaToleranciaTamanhoAltura))
                && vRetanguloDaEnvoltoria.Height < (parametros.AlturaPessoa * (1 + parametros.FaixaToleranciaTamanhoAltura));
                
        }

        protected Region determinarRegiaoPorPontos(List<Point> pontos)
        {
            if (pontos.Count() > 0)
            {
                GraphicsPath myPath = new GraphicsPath();
                myPath.AddPolygon(pontos.ToArray());
                Region myRegion = new Region(myPath);
                return myRegion;
            }
            return null;
        }
    }
}
