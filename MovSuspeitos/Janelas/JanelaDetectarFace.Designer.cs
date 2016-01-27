namespace FaceDetection.Janelas
{
    partial class JanelaDetectarFace
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JanelaDetectarFace));
            this.imagemDetect = new System.Windows.Forms.PictureBox();
            this.enviarEmail = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imagemDetect)).BeginInit();
            this.SuspendLayout();
            // 
            // imagemDetect
            // 
            this.imagemDetect.Location = new System.Drawing.Point(12, 12);
            this.imagemDetect.Name = "imagemDetect";
            this.imagemDetect.Size = new System.Drawing.Size(780, 540);
            this.imagemDetect.TabIndex = 0;
            this.imagemDetect.TabStop = false;
            // 
            // enviarEmail
            // 
            this.enviarEmail.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("enviarEmail.BackgroundImage")));
            this.enviarEmail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.enviarEmail.Location = new System.Drawing.Point(815, 12);
            this.enviarEmail.Name = "enviarEmail";
            this.enviarEmail.Size = new System.Drawing.Size(75, 75);
            this.enviarEmail.TabIndex = 1;
            this.enviarEmail.UseVisualStyleBackColor = true;
            this.enviarEmail.Click += new System.EventHandler(this.enviarEmail_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(834, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 14);
            this.label6.TabIndex = 39;
            this.label6.Text = "Enviar";
            // 
            // JanelaDetectarFace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ClientSize = new System.Drawing.Size(919, 582);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.enviarEmail);
            this.Controls.Add(this.imagemDetect);
            this.Name = "JanelaDetectarFace";
            this.Text = "JanelaDetectarFace";
            ((System.ComponentModel.ISupportInitialize)(this.imagemDetect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imagemDetect;
        private System.Windows.Forms.Button enviarEmail;
        private System.Windows.Forms.Label label6;
    }
}