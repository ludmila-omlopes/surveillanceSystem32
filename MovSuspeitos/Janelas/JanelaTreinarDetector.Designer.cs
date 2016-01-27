namespace FaceDetection.Janelas
{
    partial class JanelaTreinarDetector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JanelaTreinarDetector));
            this.detImagem = new System.Windows.Forms.PictureBox();
            this.detFaces = new System.Windows.Forms.PictureBox();
            this.addFace = new System.Windows.Forms.Button();
            this.lblNomePessoa = new System.Windows.Forms.Label();
            this.detNomePessoa = new System.Windows.Forms.TextBox();
            this.lblCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.detImagem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detFaces)).BeginInit();
            this.SuspendLayout();
            // 
            // detImagem
            // 
            this.detImagem.Location = new System.Drawing.Point(12, 12);
            this.detImagem.Name = "detImagem";
            this.detImagem.Size = new System.Drawing.Size(311, 238);
            this.detImagem.TabIndex = 0;
            this.detImagem.TabStop = false;
            this.detImagem.Click += new System.EventHandler(this.detImagem_Click);
            // 
            // detFaces
            // 
            this.detFaces.Location = new System.Drawing.Point(367, 12);
            this.detFaces.Name = "detFaces";
            this.detFaces.Size = new System.Drawing.Size(100, 99);
            this.detFaces.TabIndex = 1;
            this.detFaces.TabStop = false;
            // 
            // addFace
            // 
            this.addFace.BackColor = System.Drawing.Color.Transparent;
            this.addFace.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addFace.BackgroundImage")));
            this.addFace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addFace.Location = new System.Drawing.Point(335, 196);
            this.addFace.Name = "addFace";
            this.addFace.Size = new System.Drawing.Size(59, 54);
            this.addFace.TabIndex = 2;
            this.addFace.UseVisualStyleBackColor = false;
            this.addFace.Click += new System.EventHandler(this.addFace_Click);
            // 
            // lblNomePessoa
            // 
            this.lblNomePessoa.AutoSize = true;
            this.lblNomePessoa.BackColor = System.Drawing.Color.Transparent;
            this.lblNomePessoa.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomePessoa.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNomePessoa.Location = new System.Drawing.Point(331, 127);
            this.lblNomePessoa.Name = "lblNomePessoa";
            this.lblNomePessoa.Size = new System.Drawing.Size(56, 19);
            this.lblNomePessoa.TabIndex = 3;
            this.lblNomePessoa.Text = "Nome:";
            // 
            // detNomePessoa
            // 
            this.detNomePessoa.Location = new System.Drawing.Point(393, 126);
            this.detNomePessoa.Name = "detNomePessoa";
            this.detNomePessoa.Size = new System.Drawing.Size(100, 20);
            this.detNomePessoa.TabIndex = 4;
            this.detNomePessoa.Text = "NOME";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.BackColor = System.Drawing.Color.Transparent;
            this.lblCount.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblCount.Location = new System.Drawing.Point(331, 159);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(69, 19);
            this.lblCount.TabIndex = 15;
            this.lblCount.Text = "Count: 0";
            this.lblCount.Visible = false;
            // 
            // JanelaTreinarDetector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(536, 285);
            this.Controls.Add(this.detNomePessoa);
            this.Controls.Add(this.lblNomePessoa);
            this.Controls.Add(this.addFace);
            this.Controls.Add(this.detFaces);
            this.Controls.Add(this.detImagem);
            this.Controls.Add(this.lblCount);
            this.Name = "JanelaTreinarDetector";
            this.Text = "JanelaTreinarDetector";
            ((System.ComponentModel.ISupportInitialize)(this.detImagem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detFaces)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox detImagem;
        private System.Windows.Forms.PictureBox detFaces;
        private System.Windows.Forms.Button addFace;
        private System.Windows.Forms.Label lblNomePessoa;
        private System.Windows.Forms.TextBox detNomePessoa;
        private System.Windows.Forms.Label lblCount;
    }
}