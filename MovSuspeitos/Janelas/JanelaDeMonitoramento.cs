using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FaceDetection.Janelas
{
    public partial class JanelaDeMonitoramento : Form
    {
        public JanelaDeMonitoramento()
        {
            InitializeComponent();
            Text = "Janela de Monitoramento";
        }
        
        public DataGridView GridPessoasMonitoradas
        {
            get
            {
                return dataGridView1;
            }
        }

        public PictureBox ImagemMonitorada
        {
            get
            {
                return pictureBox1;
            }
        }

        public PictureBox ImagemPlanoDeFundo1
        {
            get
            {
                return pictureBox2;
            }
        }

        public PictureBox ImagemPlanoDeFundo5
        {
            get
            {
                return pictureBox3;
            }
        }

        public PictureBox ImagemPlanoDeFundo10
        {
            get
            {
                return pictureBox4;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
