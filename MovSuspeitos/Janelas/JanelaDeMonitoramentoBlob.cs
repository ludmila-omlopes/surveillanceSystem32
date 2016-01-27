using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV.UI;
using Emgu.CV;
using Emgu.CV.CvEnum;
using System.IO;
using System.Drawing.Imaging;

namespace FaceDetection.Janelas
{
    public partial class JanelaDeMonitoramentoBlob : Form
    {
        public JanelaDeMonitoramentoBlob()
        {
            InitializeComponent();
            Text = "Janela de Monitoramento";
        }
        public bool AtualizarParametros = false;
        public bool SalvarImagem = false;
        
        public DataGridView GridPessoasMonitoradas
        {
            get
            {
                return dataGridViewBlob;
            }
        }

        public ImageBox ImagemMonitorada
        {
            get
            {
                return pictureBoxBlob;
            }
        }

        public Double TempoMaximoEmCena
        {
            get
            {
                return Convert.ToDouble(maxEmCena.Text);
            
            }
            set
            {
                maxEmCena.Text = value.ToString();
            }
        }

        public Double VelocidadeMaxima
        {
            get
            {
                return Convert.ToDouble(maxVelocidade.Text);
            }
            set
            {
                maxVelocidade.Text = value.ToString();
            }
        }

        public int NumeroInversoes
        {
            get
            {
                return Convert.ToInt32(this.numInversoes.Text);
            }
            set
            {
                numInversoes.Text = value.ToString();
            }
        }

        public Double AlphaMediaMovel
        {
            get
            {
                return Convert.ToDouble(this.numInversoes.Text);
            }
        }

        private void snapshot_Click(object sender, EventArgs e)
        {
            //SalvarImagem = true;
            //string fileName = "lena.jpg";
            string fileName = salvarImagem();
            Mat imagem = new Mat(Application.StartupPath + "/TrainedFaces/" + fileName, LoadImageType.AnyColor);
            JanelaDetectarFace vJanela = new JanelaDetectarFace(imagem);
            vJanela.Show();
        }

        private void btnAtualizarParametros_Click(object sender, EventArgs e)
        {
            AtualizarParametros = true;
        }

        private string salvarImagem()
        {
            try
            {
                Random rand = new Random();
                bool file_create = true;
                string fileName = "snapshot_" + rand.Next().ToString() + ".jpg";
                while (file_create)
                {

                    if (!File.Exists(Application.StartupPath + "/Snapshots/" + fileName))
                    {
                        file_create = false;
                    }
                    else
                    {
                        fileName = "snapshot_" + rand.Next().ToString() + ".jpg";
                    }
                }


                if (Directory.Exists(Application.StartupPath + "/TrainedFaces/"))
                {

                    ImagemMonitorada.Image.Save(Application.StartupPath + "/TrainedFaces/" + fileName);
                }
                else
                {
                    Directory.CreateDirectory(Application.StartupPath + "/TrainedFaces/");
                    ImagemMonitorada.Image.Save(Application.StartupPath + "/TrainedFaces/" + fileName);
                }
                return fileName;
            }
            catch
            {
                return null;
            }
        }
    }
}
