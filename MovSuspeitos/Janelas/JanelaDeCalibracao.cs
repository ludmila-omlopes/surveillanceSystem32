using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV.UI;

namespace FaceDetection.Janelas
{
    public partial class JanelaDeCalibracao : Form
    {
        public bool evento = false;

        public JanelaDeCalibracao()
        {
            InitializeComponent();
        }
        public ImageBox Imagem
        {
            get
            {
                return imagem;
            }
        }
        public ImageBox PlanoDeFundo
        {
            get
            {
                return planoFundo;
            }
        }
        public ImageBox Objetos
        {
            get
            {
                return objetos;
            }
        }
        public TrackBar Alpha
        {
            get
            {
                return alpha;
            }
        }
        public TrackBar Altura
        {
            get
            {
                return alturaP;
            }
        }
        public TrackBar Lagura
        {
            get
            {
                return larguraP;
            }
        }
        public TrackBar ToleranciaAltura
        {
            get
            {
                return toleranciaA;
            }
        }
        public TrackBar ToleranciaLargura
        {
            get
            {
                return toleranciaL;
            }
        }

        private void alpha_Scroll(object sender, EventArgs e)
        {
            evento = true;
        }

        private void alturaP_Scroll(object sender, EventArgs e)
        {
            evento = true;
        }

        private void larguraP_Scroll(object sender, EventArgs e)
        {
            evento = true;
        }

        private void toleranciaA_Scroll(object sender, EventArgs e)
        {
            evento = true;
        }

        private void toleranciaL_Scroll(object sender, EventArgs e)
        {
            evento = true;
        }

        private void finalizar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
