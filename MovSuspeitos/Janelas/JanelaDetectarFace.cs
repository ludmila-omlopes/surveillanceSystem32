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
using FaceDetection.processamento;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace FaceDetection.Janelas
{
    public partial class JanelaDetectarFace : Form
    {
        #region variables
        Image<Bgr, Byte> currentFrame; //current image aquired from webcam for display
        Image<Gray, byte> result, TrainedFace = null; //used to store the result image and trained face
        Image<Gray, byte> gray_frame = null; //grayscale current image aquired from webcam for processing

        //Capture grabber; //This is our capture variable
        Mat mImagem;

        public CascadeClassifier Face = new CascadeClassifier("haarcascade_frontalface_default.xml");//Our face detection method 

        Font font = new Font(FontFamily.GenericSansSerif, 11); //Our fount for writing within the frame

        int NumLabels;

        //Classifier with default training location
        Classifier_Train Eigen_Recog = new Classifier_Train();

        #endregion

        public JanelaDetectarFace(Mat pImagem)
        {
            InitializeComponent();
            mImagem = pImagem;
          //  currentFrame = new Image<Bgr, byte>(new Size(320, 240));
          //  CvInvoke.Resize(mImagem, currentFrame, new Size(320, 240), 0, 0, Emgu.CV.CvEnum.Inter.Cubic);
           // imagemDetect.Image = currentFrame.ToBitmap();
            if (Eigen_Recog.IsTrained)
            {
               // message_bar.Text = "Training Data loaded";
            }
            else
            {
                //message_bar.Text = "No training data found, please train program using Train menu option";
            }
            currentFrame = new Image<Bgr, byte>(new Size(820, 780));
            CvInvoke.Resize(mImagem, currentFrame, new Size(820, 780), 0, 0, Emgu.CV.CvEnum.Inter.Cubic);


            //Convert it to Grayscale
            if (currentFrame != null)
            {
                gray_frame = currentFrame.Convert<Gray, Byte>();

                //Face Detector
                Rectangle[] facesDetected = Face.DetectMultiScale(gray_frame, 1.2, 10, new Size(50, 50), Size.Empty);

                //Action for each element detected
                for (int i = 0; i < facesDetected.Length; i++)// (Rectangle face_found in facesDetected)
                {
                    //This will focus in on the face from the haar results its not perfect but it will remove a majoriy
                    //of the background noise
                    facesDetected[i].X += (int)(facesDetected[i].Height * 0.15);
                    facesDetected[i].Y += (int)(facesDetected[i].Width * 0.22);
                    facesDetected[i].Height -= (int)(facesDetected[i].Height * 0.3);
                    facesDetected[i].Width -= (int)(facesDetected[i].Width * 0.35);

                    result = currentFrame.Copy(facesDetected[i]).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);
                    result._EqualizeHist();
                    //draw the face detected in the 0th (gray) channel with blue color
                    currentFrame.Draw(facesDetected[i], new Bgr(Color.Red), 2);

                    if (Eigen_Recog.IsTrained)
                    {
                        string name = Eigen_Recog.Recognise(result);
                        int match_value = (int)Eigen_Recog.Get_Eigen_Distance;

                        //Draw the label for each face detected and recognized
                        currentFrame.Draw(name + "", new Point(facesDetected[i].X - 2, facesDetected[i].Y - 2), Emgu.CV.CvEnum.FontFace.HersheyDuplex, 1, new Bgr(Color.LightGreen));
                        // currentFrame.Draw(name + " ", ref font, new Point(facesDetected[i].X - 2, facesDetected[i].Y - 2), new Bgr(Color.LightGreen));
                        //  ADD_Face_Found(result, name, match_value);
                    }
                }
                //Show the faces procesed and recognized
                imagemDetect.Image = currentFrame.ToBitmap();
            }
        }

        void detectarFace_Click(object sender, EventArgs e)
        {
            
        }

        void FrameGrabber_Parrellel(object sender, EventArgs e)
        {
            //Get the current frame form capture device
            currentFrame = new Image<Bgr, byte>(new Size(320, 240));
            CvInvoke.Resize(mImagem, currentFrame, new Size(320, 240), 0, 0, Emgu.CV.CvEnum.Inter.Cubic);

            //Convert it to Grayscale
            //Clear_Faces_Found();

            if (currentFrame != null)
            {
                gray_frame = currentFrame.Convert<Gray, Byte>();
                //Face Detector
                Rectangle[] facesDetected = Face.DetectMultiScale(gray_frame, 1.2, 10, new Size(50, 50), Size.Empty);

                //Action for each element detected
                Parallel.For(0, facesDetected.Length, i =>
                {
                    try
                    {
                        facesDetected[i].X += (int)(facesDetected[i].Height * 0.15);
                        facesDetected[i].Y += (int)(facesDetected[i].Width * 0.22);
                        facesDetected[i].Height -= (int)(facesDetected[i].Height * 0.3);
                        facesDetected[i].Width -= (int)(facesDetected[i].Width * 0.35);

                        result = currentFrame.Copy(facesDetected[i]).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.Inter.Cubic);
                        result._EqualizeHist();
                        //draw the face detected in the 0th (gray) channel with blue color
                        currentFrame.Draw(facesDetected[i], new Bgr(Color.Red), 2);

                        if (Eigen_Recog.IsTrained)
                        {
                            string name = Eigen_Recog.Recognise(result);
                            int match_value = (int)Eigen_Recog.Get_Eigen_Distance;

                            //Draw the label for each face detected and recognized
                            //currentFrame.Draw(name + " ", ref font, new Point(facesDetected[i].X - 2, facesDetected[i].Y - 2), new Bgr(Color.LightGreen));
                            currentFrame.Draw(name + "", new Point(facesDetected[i].X - 2, facesDetected[i].Y - 2), Emgu.CV.CvEnum.FontFace.HersheyDuplex, 1, new Bgr(Color.LightGreen));
                           // ADD_Face_Found(result, name, match_value);
                        }

                    }
                    catch
                    {
                        //do nothing as parrellel loop buggy
                        //No action as the error is useless, it is simply an error in 
                        //no data being there to process and this occurss sporadically 
                    }
                });
                //Show the faces procesed and recognized
                imagemDetect.Image = currentFrame.ToBitmap();
            }
        }

        //ADD Picture box and label to a panel for each face
       // int faces_count = 0;
       // int faces_panel_Y = 0;
       // int faces_panel_X = 0;

       /* void Clear_Faces_Found()
        {
            this.Faces_Found_Panel.Controls.Clear();
            faces_count = 0;
            faces_panel_Y = 0;
            faces_panel_X = 0;
        }*/
       /* void ADD_Face_Found(Image<Gray, Byte> img_found, string name_person, int match_value)
        {
            PictureBox PI = new PictureBox();
            PI.Location = new Point(faces_panel_X, faces_panel_Y);
            PI.Height = 80;
            PI.Width = 80;
            PI.SizeMode = PictureBoxSizeMode.StretchImage;
            PI.Image = img_found.ToBitmap();
            Label LB = new Label();
            LB.Text = name_person + " " + match_value.ToString();
            LB.Location = new Point(faces_panel_X, faces_panel_Y + 80);
            //LB.Width = 80;
            LB.Height = 15;

            this.Faces_Found_Panel.Controls.Add(PI);
            this.Faces_Found_Panel.Controls.Add(LB);
            faces_count++;
            if (faces_count == 2)
            {
                faces_panel_X = 0;
                faces_panel_Y += 100;
                faces_count = 0;
            }
            else faces_panel_X += 85;

            if (Faces_Found_Panel.Controls.Count > 10)
            {
                Clear_Faces_Found();
            }

        }*/

        private void EnviarImagensEmail(Attachment anexo)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("ludmila.omlopes@gmail.com", "bus215188");

            MailMessage message = new MailMessage();
            message.Sender = new MailAddress("ludmila.omlopes@gmail.com");
            message.From = new MailAddress("ludmila.omlopes@gmail.com", "Sistema de Vigilância");
            message.To.Add(new MailAddress("ludmila.omlopes@gmail.com"));
            message.Subject = "ALERTA - SISTEMA DE VIGILÂNCIA";
            message.Body = "Observar a seguinte imagem enviada pelo sistema de segurança. DATA:" + DateTime.Now;
            message.IsBodyHtml = false;
            message.Priority = MailPriority.High;
            message.Attachments.Add(anexo);

            client.Send(message);
        }

        private void enviarEmail_Click(object sender, EventArgs e)
        {
            string vDataTempo = DateTime.Now.Minute.ToString();
            Bitmap vAnexo = new Bitmap(imagemDetect.Image, new Size(360, 240));
            vAnexo.Save(String.Format(@"C:\Users\Tadeu Rahian\Dropbox\Dropbox\UFMG\PFC1\Imagens\Imagem_{0}.jpg", vDataTempo));
            EnviarImagensEmail(new Attachment(String.Format(@"C:\Users\Tadeu Rahian\Dropbox\Dropbox\UFMG\PFC1\Imagens\Imagem_{0}.jpg", vDataTempo)));
        }
    }
}
