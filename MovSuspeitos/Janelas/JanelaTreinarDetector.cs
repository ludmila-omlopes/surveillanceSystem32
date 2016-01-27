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
using System.Drawing.Imaging;
using System.Xml;
using System.IO;
using System.Threading;
using FaceDetection;

namespace FaceDetection.Janelas
{
    public partial class JanelaTreinarDetector : Form
    {
        #region Variables
        //Camera specific
        Capture grabber;

        //Images for finding face
        Image<Bgr, Byte> currentFrame;
        Image<Gray, byte> result = null;
        Image<Gray, byte> gray_frame = null;

        //Classifier
        CascadeClassifier Face;

        //For aquiring 10 images in a row
        List<Image<Gray, byte>> resultImages = new List<Image<Gray, byte>>();
        int results_list_pos = 0;
        int num_faces_to_aquire = 10;
        bool RECORD = false;

        //Saving Jpg
        List<Image<Gray, byte>> ImagestoWrite = new List<Image<Gray, byte>>();
        EncoderParameters ENC_Parameters = new EncoderParameters(1);
        EncoderParameter ENC = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100);
        ImageCodecInfo Image_Encoder_JPG;

        //Saving XAML Data file
        List<string> NamestoWrite = new List<string>();
        List<string> NamesforFile = new List<string>();
        XmlDocument docu = new XmlDocument();

        //Variables
        Form1 Parent;
        #endregion

        public JanelaTreinarDetector()
        {
            InitializeComponent();
            CvInvoke.UseOpenCL = false;
            //Parent = _Parent;
            //Face = Parent.Face;
            Face = new CascadeClassifier("haarcascade_frontalface_default.xml");//Our face detection method 
          
            ENC_Parameters.Param[0] = ENC;
            Image_Encoder_JPG = GetEncoder(ImageFormat.Jpeg);
            initialise_capture();
        }

        private void detImagem_Click(object sender, EventArgs e)
        {

        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        //Camera Start Stop
        public void initialise_capture()
        {
            grabber = new Capture();
            grabber.QueryFrame();
            CvInvoke.UseOpenCL = true && CvInvoke.HaveOpenCLCompatibleGpuDevice;


            //Initialize the FrameGraber event
            Application.Idle += new EventHandler(FrameGrabber);
        }
        private void stop_capture()
        {
            Application.Idle -= new EventHandler(FrameGrabber);
            if (grabber != null)
            {
                grabber.Dispose();
            }
            //Initialize the FrameGraber event
        }
        //Process Frame
        void FrameGrabber(object sender, EventArgs e)
        {
            //Get the current frame form capture device
            currentFrame = new Image<Bgr, byte>(new Size(320, 240));
            CvInvoke.Resize(grabber.QueryFrame(), currentFrame, new Size(320, 240), 0, 0, Emgu.CV.CvEnum.Inter.Cubic);

            //Convert it to Grayscale
            if (currentFrame != null)
            {
                gray_frame = currentFrame.Convert<Gray, Byte>();

                //Face Detector
                //MCvAvgComp[][] facesDetected = gray_frame.DetectHaarCascade(Face, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20)); //old method
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
                    detFaces.Image = result.ToBitmap();
                    //draw the face detected in the 0th (gray) channel with blue color
                    currentFrame.Draw(facesDetected[i], new Bgr(Color.Red), 2);

                }
                if (RECORD && facesDetected.Length > 0 && resultImages.Count < num_faces_to_aquire)
                {
                    resultImages.Add(result);
                    lblCount.Text = "Count: " + resultImages.Count.ToString();
                    if (resultImages.Count == num_faces_to_aquire)
                    {
                        //ADD_BTN.Enabled = true;
                        //NEXT_BTN.Visible = true;
                        //PREV_btn.Visible = true;
                        lblCount.Visible = false;
                        addFace.Visible = true;
                        RECORD = false;
                        Application.Idle -= new EventHandler(FrameGrabber);
                    }
                }

                detImagem.Image = currentFrame.ToBitmap();
            }
        }

        //Saving The Data
        private bool save_training_data(Image face_data)
        {
            try
            {
                Random rand = new Random();
                bool file_create = true;
                string facename = "face_" + detNomePessoa.Text + "_" + rand.Next().ToString() + ".jpg";
                while (file_create)
                {

                    if (!File.Exists(Application.StartupPath + "/TrainedFaces/" + facename))
                    {
                        file_create = false;
                    }
                    else
                    {
                        facename = "face_" + detNomePessoa.Text + "_" + rand.Next().ToString() + ".jpg";
                    }
                }


                if (Directory.Exists(Application.StartupPath + "/TrainedFaces/"))
                {
                    face_data.Save(Application.StartupPath + "/TrainedFaces/" + facename, ImageFormat.Jpeg);
                }
                else
                {
                    Directory.CreateDirectory(Application.StartupPath + "/TrainedFaces/");
                    face_data.Save(Application.StartupPath + "/TrainedFaces/" + facename, ImageFormat.Jpeg);
                }
                if (File.Exists(Application.StartupPath + "/TrainedFaces/TrainedLabels.xml"))
                {
                    //File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", NAME_PERSON.Text + "\n\r");
                    bool loading = true;
                    while (loading)
                    {
                        try
                        {
                            docu.Load(Application.StartupPath + "/TrainedFaces/TrainedLabels.xml");
                            loading = false;
                        }
                        catch
                        {
                            docu = null;
                            docu = new XmlDocument();
                            Thread.Sleep(10);
                        }
                    }

                    //Get the root element
                    XmlElement root = docu.DocumentElement;

                    XmlElement face_D = docu.CreateElement("FACE");
                    XmlElement name_D = docu.CreateElement("NAME");
                    XmlElement file_D = docu.CreateElement("FILE");

                    //Add the values for each nodes
                    //name.Value = textBoxName.Text;
                    //age.InnerText = textBoxAge.Text;
                    //gender.InnerText = textBoxGender.Text;
                    name_D.InnerText = detNomePessoa.Text;
                    file_D.InnerText = facename;

                    //Construct the Person element
                    //person.Attributes.Append(name);
                    face_D.AppendChild(name_D);
                    face_D.AppendChild(file_D);

                    //Add the New person element to the end of the root element
                    root.AppendChild(face_D);

                    //Save the document
                    docu.Save(Application.StartupPath + "/TrainedFaces/TrainedLabels.xml");
                    //XmlElement child_element = docu.CreateElement("FACE");
                    //docu.AppendChild(child_element);
                    //docu.Save("TrainedLabels.xml");
                }
                else
                {
                    FileStream FS_Face = File.OpenWrite(Application.StartupPath + "/TrainedFaces/TrainedLabels.xml");
                    using (XmlWriter writer = XmlWriter.Create(FS_Face))
                    {
                        writer.WriteStartDocument();
                        writer.WriteStartElement("Faces_For_Training");

                        writer.WriteStartElement("FACE");
                        writer.WriteElementString("NAME", detNomePessoa.Text);
                        writer.WriteElementString("FILE", facename);
                        writer.WriteEndElement();

                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                    }
                    FS_Face.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        private void addFace_Click(object sender, EventArgs e)
        {
            if (resultImages.Count == num_faces_to_aquire)
            {
                if (!save_training_data(detFaces.Image)) MessageBox.Show("Error", "Error in saving file info. Training data not saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                stop_capture();
                if (!save_training_data(detFaces.Image)) MessageBox.Show("Error", "Error in saving file info. Training data not saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
                initialise_capture();
            }
        }

        private void Single_btn_Click(object sender, EventArgs e)
        {

        }
    }
}
