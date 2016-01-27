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
    public partial class DefinirAreaRestrita : Form
    {
        List<Point> pontos = new List<Point>();

        public DefinirAreaRestrita()
        {
            InitializeComponent();
        }

        public ImageBox Imagem
        {
            get
            {
                return pictureBox1;
            }
        }

        public DataGridView GridPessoasMonitoradas
        {
            get
            {
                return dataGridViewBlob;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDoubleClick(Object sender, MouseEventArgs e)
        {
            pontos.Add(new Point(e.X, e.Y));
        }

        private void finalizar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public List<Point> obterPontos()
        {
            return pontos;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
