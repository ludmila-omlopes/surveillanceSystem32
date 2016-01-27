using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using System.Drawing;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace FaceDetection.Processamento
{
    public class ProcessadorHOG : ProcessadorDeVideo
    {
        HOGDescriptor mHog;
        List<Rectangle> mRetangulosEncontradosFiltrados;

        public ProcessadorHOG(String pNomeDoArquivo)
            : base(pNomeDoArquivo)
        { }


     /*   protected override void inicializarVariaveis()
        {
            base.inicializarVariaveis();
            mHog = new HOGDescriptor();
            mHog.SetSVMDetector(HOGDescriptor.GetDefaultPeopleDetector());
            mRetangulosEncontradosFiltrados = new List<Rectangle>();
        }

        protected override void processarImagem(bool mapeamento)
        {
            if (base.mContadorDeFrames % 10 == 0)
            {
                Rectangle[] vRetangulosEncontrados = mHog.DetectMultiScale(mImagemColorida);
                mRetangulosEncontradosFiltrados = new List<Rectangle>();
                int i, j;
                for (i = 0; i < vRetangulosEncontrados.Length; i++)
                {
                    Rectangle r = vRetangulosEncontrados[i];
                    for (j = 0; j < vRetangulosEncontrados.Length; j++)
                        if (j != i && (r.Equals(vRetangulosEncontrados[j])))
                            break;
                    if (j == vRetangulosEncontrados.Length)
                        mRetangulosEncontradosFiltrados.Add(r);
                }
            }
        }

        protected override void desenharNaImagem(ParametrosDinamicos parametros)
        {
            for (int i = 0; i < mRetangulosEncontradosFiltrados.Count; i++)
            {
                Rectangle r = mRetangulosEncontradosFiltrados[i];
                // the HOG detector returns slightly larger rectangles than the real objects.
                // so we slightly shrink the rectangles to get a nicer output.
                r.X += Convert.ToInt32(r.Width * 0.1);
                r.Width = Convert.ToInt32(r.Width * 0.8);
                r.Y += Convert.ToInt32(r.Height * 0.07);
                r.Height = Convert.ToInt32(r.Height * 0.8);
                CvInvoke.cvRectangle(mImagemColorida, r.Location, new Point(r.Right, r.Bottom), new MCvScalar(0, 255, 0), 3, LINE_TYPE.EIGHT_CONNECTED, 0);
            }
        }*/
    }
}
