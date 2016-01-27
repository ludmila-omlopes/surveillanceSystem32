using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;

namespace SistemaSeguranca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CvInvoke.UseOpenCL = false;
            string file = @"C:\Users\Tadeu Rahian\Dropbox\Dropbox\UFMG\PFC1\Código 2010 - Final\MovimentosSuspeitosDotNet\MovimentosSuspeitosDotNet\bin\Debug\Cascades\haarcascade_eye.xml";
            CascadeClassifier cascade = new CascadeClassifier(file);
        }
    }
}
