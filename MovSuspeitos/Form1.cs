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
using FaceDetection.Processamento;
using FaceDetection.Janelas;


namespace FaceDetection
{
    public partial class Form1 : Form
    {
        static Size gTamanhoDaImagem;
        ParametrosDinamicos parametros;
        ProcessadorBlob mProcessador;
        public CascadeClassifier Face = new CascadeClassifier("haarcascade_frontalface_default.xml");//Our face detection method 

        public Form1()
        {
            InitializeComponent();
        }

        //Manual
        private void btnIniciarClick(object sender, EventArgs e)
        {
            JanelaDeMonitoramento vJanela = new JanelaDeMonitoramento();
            vJanela.Visible = true;
            ProcessadorManual vProcessadorDeVideo = new ProcessadorManual(ParametrosConstantes.NomeDoArquivo, vJanela);
            vProcessadorDeVideo.processarVideo(parametros);
        }

        //Blob
        private void button1_Click(object sender, EventArgs e)
        {
            parametros = new ParametrosDinamicos();
            if (mProcessador != null)
                parametros = mProcessador.obterParametros();
            JanelaDeMonitoramentoBlob vJanela = new JanelaDeMonitoramentoBlob();
            vJanela.Visible = true;
            mProcessador = new ProcessadorBlob(ParametrosConstantes.NomeDoArquivo, vJanela, parametros);
            mProcessador.mapear();
        }

        //HOG
        private void button2_Click(object sender, EventArgs e)
        {
            JanelaDeMonitoramentoBlob vJanela = new JanelaDeMonitoramentoBlob();
            vJanela.Visible = true;
            ProcessadorHOG vProcessadorDeVideo = new ProcessadorHOG(ParametrosConstantes.NomeDoArquivo);
            vProcessadorDeVideo.processarVideo(parametros);
        }

        //Mapeamento
        private void button3_Click(object sender, EventArgs e)
        {
            if(mProcessador != null)
                parametros = mProcessador.obterParametros();
            if (parametros == null)
                parametros = new ParametrosDinamicos();
            DefinirAreaRestrita vJanela = new DefinirAreaRestrita();
            vJanela.Visible = true;
            mProcessador = new ProcessadorBlob(ParametrosConstantes.NomeDoArquivo, vJanela, parametros);
            mProcessador.mapear();
        }

        //Calibração
        private void calibracao_Click(object sender, EventArgs e)
        {
            JanelaDeCalibracao vJanela = new JanelaDeCalibracao();
            parametros = new ParametrosDinamicos();
            if (mProcessador != null)
                parametros = mProcessador.obterParametros();
            vJanela.Visible = true;
            mProcessador = new ProcessadorBlob(ParametrosConstantes.NomeDoArquivo, vJanela, parametros);
            mProcessador.calibrar();
        }

        //treinar Detector
        private void button2_Click_1(object sender, EventArgs e)
        {
            JanelaTreinarDetector vJanela = new JanelaTreinarDetector();
            vJanela.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string fileName = "lena.jpg";
            Mat imagem = new Mat(fileName, LoadImageType.AnyColor);
            JanelaDetectarFace vJanela = new JanelaDetectarFace(imagem);
            vJanela.Show();
        }
    }
}
