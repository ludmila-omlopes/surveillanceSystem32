using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FaceDetection
{
    public class ParametrosConstantes
    {
        public static String NomeDoArquivo
        {
            get
            {
               return @"C:\Users\Tadeu Rahian\Dropbox\Dropbox\UFMG\PFC1\recdigopfc\vai.avi";
                //return @"C:\Users\Tadeu Rahian\Dropbox\Dropbox\UFMG\PFC1\recdigopfc\MVI_1768.avi";
            }
        }

        public static double AlphaMediaMovel
        {
            get 
            {
                //StreamCapture_000.avi
                return 0.01;
            }
        }

        public static double LimiarTransformacaoParaCinza
        {
            get
            {
                //StreamCapture_000.avi
                return 50;
            }
        }

        public static double MaximoLimiarTransformacaoParaCinza
        {
            get
            {
                //StreamCapture_000.avi
                return 255;
            }
        }

        public static int LarguraPessoa 
        {
            get
            {
                //StreamCapture_000.avi
                //return 45;
                return 320;
            }
        }

        public static double FaixaToleranciaTamanhoLargura
        {
            get 
            {
                //StreamCapture_000.avi
                return 0.3;
            }
        }

        public static double FaixaToleranciaTamanhoAltura
        {
            get
            {
                //StreamCapture_000.avi
                return 0.6;
            }
        }

        public static double AlturaPessoa 
        {
            get
            {
                //StreamCapture_000.avi
                //return 50;

                //return 270;
                return 470;
            }
        }

        public static double FramesPorSegundo
        {
            get
            {
                return 14.985;
            }
        }

        public static double ConstanteConversaoVelocidadeMetroPorSegundo
        {
            get
            {
                return 0.07;
            }
        
        }

        public static double ConstanteConversaoVelocidadeKmPorHora
        {
            get
            {
                return ConstanteConversaoVelocidadeMetroPorSegundo * 3.6;
            }

        }

        public static int NumeroMaximoDeInversoesDeRota 
        {
            get 
            {
                return 2;
            }
        }

        public static int TempoMaximoEmCena 
        {
            get
            {
                return 3;
            }
        }

        public static double VelocidadeMaxima 
        { 
            get
            {
                return 8;    
            }
        }
    }
}
