using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FaceDetection
{
    public class ParametrosDinamicos
    {
        public ParametrosDinamicos()
        {
            numeroMaximoDeInversoesDeRota = 0;
            tempoMaximoEmCena = 0;
            velocidadeMaxima = 0;
            alturaPessoa = 70;
            larguraPessoa = 50;
            faixaToleranciaTamanhoAltura = 0.8;
            faixaToleranciaTamanhoLargura = 0.8;
            alphaMediaMovel = 3;
        }
        private int numeroMaximoDeInversoesDeRota;
        public int NumeroMaximoDeInversoesDeRota
        {
            get
            {
                return numeroMaximoDeInversoesDeRota;
            }

            set
            {
                numeroMaximoDeInversoesDeRota = value;
            }
        }

        private int tempoMaximoEmCena;
        public int TempoMaximoEmCena
        {
            get
            {
                return tempoMaximoEmCena;
            }
            set
            {
                tempoMaximoEmCena = value;
            }
        }

        private double velocidadeMaxima;
        public double VelocidadeMaxima
        {
            get
            {
                return velocidadeMaxima;
            }
            set
            {
                velocidadeMaxima = value;
            }
        }

        private List<Point> pontosAreaRestrita;
        public List<Point> PontosAreaRestrita
        {
            get
            {
                return pontosAreaRestrita;
            }
            set
            {
                pontosAreaRestrita = value;
            }
        }

        private Region regiaoAreaRestrita;
        public Region RegiaoAreaRestrita
        {
            get
            {
                return regiaoAreaRestrita;
            }
            set
            {
                regiaoAreaRestrita = value;
            }
        }

        private Rectangle retanguloPessoa;
        public Rectangle RetanguloPessoa
        {
            get
            {
                return retanguloPessoa;
            }
            set
            {
                retanguloPessoa = value;
            }
        }

        private int alphaMediaMovel;
        public int AlphaMediaMovel
        {
            get
            {
                return alphaMediaMovel;
            }
            set
            {
                alphaMediaMovel = value;
            }
        }

        private int larguraPessoa;
        public int LarguraPessoa
        {
            get
            {
                return larguraPessoa;
            }
            set
            {
                larguraPessoa = value;
            }
        }

        private double faixaToleranciaTamanhoLargura;
        public double FaixaToleranciaTamanhoLargura
        {
            get
            {
                return faixaToleranciaTamanhoLargura;
            }
            set
            {
                faixaToleranciaTamanhoLargura = value;
            }
        }

        private double faixaToleranciaTamanhoAltura;
        public double FaixaToleranciaTamanhoAltura
        {
            get
            {
                return faixaToleranciaTamanhoAltura;
            }
            set
            {
                faixaToleranciaTamanhoAltura = value;
            }
        }

        private double alturaPessoa;
        public double AlturaPessoa
        {
            get
            {
                return alturaPessoa;
            }
            set
            {
                alturaPessoa = value;
            }
        }
    }
}
