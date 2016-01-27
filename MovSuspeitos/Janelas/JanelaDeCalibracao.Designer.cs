namespace FaceDetection.Janelas
{
    partial class JanelaDeCalibracao
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JanelaDeCalibracao));
            this.alturaP = new System.Windows.Forms.TrackBar();
            this.larguraP = new System.Windows.Forms.TrackBar();
            this.toleranciaA = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.toleranciaL = new System.Windows.Forms.TrackBar();
            this.finalizar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imagem = new Emgu.CV.UI.ImageBox();
            this.planoFundo = new Emgu.CV.UI.ImageBox();
            this.objetos = new Emgu.CV.UI.ImageBox();
            this.label9 = new System.Windows.Forms.Label();
            this.alpha = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.alturaP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.larguraP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toleranciaA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toleranciaL)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planoFundo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objetos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alpha)).BeginInit();
            this.SuspendLayout();
            // 
            // alturaP
            // 
            this.alturaP.BackColor = System.Drawing.Color.LavenderBlush;
            this.alturaP.Location = new System.Drawing.Point(114, 71);
            this.alturaP.Maximum = 1000;
            this.alturaP.Name = "alturaP";
            this.alturaP.Size = new System.Drawing.Size(104, 45);
            this.alturaP.TabIndex = 5;
            this.alturaP.Scroll += new System.EventHandler(this.alturaP_Scroll);
            // 
            // larguraP
            // 
            this.larguraP.BackColor = System.Drawing.Color.LavenderBlush;
            this.larguraP.Location = new System.Drawing.Point(240, 71);
            this.larguraP.Maximum = 1000;
            this.larguraP.Name = "larguraP";
            this.larguraP.Size = new System.Drawing.Size(104, 45);
            this.larguraP.TabIndex = 6;
            this.larguraP.Scroll += new System.EventHandler(this.larguraP_Scroll);
            // 
            // toleranciaA
            // 
            this.toleranciaA.BackColor = System.Drawing.Color.LavenderBlush;
            this.toleranciaA.Location = new System.Drawing.Point(114, 121);
            this.toleranciaA.Name = "toleranciaA";
            this.toleranciaA.Size = new System.Drawing.Size(104, 45);
            this.toleranciaA.TabIndex = 7;
            this.toleranciaA.Scroll += new System.EventHandler(this.toleranciaA_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(19, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "PESSOAS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(139, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Altura";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(263, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Largura";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(19, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "TOLERÂNCIA";
            // 
            // toleranciaL
            // 
            this.toleranciaL.BackColor = System.Drawing.Color.LavenderBlush;
            this.toleranciaL.Location = new System.Drawing.Point(243, 122);
            this.toleranciaL.Name = "toleranciaL";
            this.toleranciaL.Size = new System.Drawing.Size(104, 45);
            this.toleranciaL.TabIndex = 13;
            this.toleranciaL.Scroll += new System.EventHandler(this.toleranciaL_Scroll);
            // 
            // finalizar
            // 
            this.finalizar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("finalizar.BackgroundImage")));
            this.finalizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.finalizar.Location = new System.Drawing.Point(491, 51);
            this.finalizar.Name = "finalizar";
            this.finalizar.Size = new System.Drawing.Size(76, 69);
            this.finalizar.TabIndex = 14;
            this.finalizar.UseVisualStyleBackColor = true;
            this.finalizar.Click += new System.EventHandler(this.finalizar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.LavenderBlush;
            this.label6.Location = new System.Drawing.Point(822, 373);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "IMAGEM BINÁRIA";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.LavenderBlush;
            this.label7.Location = new System.Drawing.Point(855, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "IMAGEM DESFOCADA";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.LavenderBlush;
            this.label8.Location = new System.Drawing.Point(268, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 15);
            this.label8.TabIndex = 17;
            this.label8.Text = "IMAGEM ORIGINAL";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel1.Controls.Add(this.alpha);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.alturaP);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.larguraP);
            this.panel1.Controls.Add(this.toleranciaA);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.finalizar);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.toleranciaL);
            this.panel1.Controls.Add(this.label5);
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(3, 508);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(637, 188);
            this.panel1.TabIndex = 21;
            // 
            // imagem
            // 
            this.imagem.Location = new System.Drawing.Point(12, 25);
            this.imagem.Name = "imagem";
            this.imagem.Size = new System.Drawing.Size(609, 462);
            this.imagem.TabIndex = 2;
            this.imagem.TabStop = false;
            // 
            // planoFundo
            // 
            this.planoFundo.Location = new System.Drawing.Point(646, 25);
            this.planoFundo.Name = "planoFundo";
            this.planoFundo.Size = new System.Drawing.Size(442, 345);
            this.planoFundo.TabIndex = 2;
            this.planoFundo.TabStop = false;
            // 
            // objetos
            // 
            this.objetos.Location = new System.Drawing.Point(646, 399);
            this.objetos.Name = "objetos";
            this.objetos.Size = new System.Drawing.Size(442, 291);
            this.objetos.TabIndex = 2;
            this.objetos.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(87, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 15);
            this.label9.TabIndex = 19;
            this.label9.Text = "1";
            // 
            // alpha
            // 
            this.alpha.BackColor = System.Drawing.Color.LavenderBlush;
            this.alpha.LargeChange = 2;
            this.alpha.Location = new System.Drawing.Point(114, 3);
            this.alpha.Maximum = 11;
            this.alpha.Minimum = 1;
            this.alpha.Name = "alpha";
            this.alpha.Size = new System.Drawing.Size(230, 45);
            this.alpha.SmallChange = 2;
            this.alpha.TabIndex = 4;
            this.alpha.TickFrequency = 2;
            this.alpha.Value = 1;
            this.alpha.Scroll += new System.EventHandler(this.alpha_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(19, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "SIGMA";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label10.Location = new System.Drawing.Point(350, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 15);
            this.label10.TabIndex = 20;
            this.label10.Text = "11";
            // 
            // JanelaDeCalibracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1118, 702);
            this.Controls.Add(this.objetos);
            this.Controls.Add(this.planoFundo);
            this.Controls.Add(this.imagem);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Name = "JanelaDeCalibracao";
            this.Text = "JanelaDeCalibracao";
            ((System.ComponentModel.ISupportInitialize)(this.alturaP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.larguraP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toleranciaA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toleranciaL)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planoFundo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objetos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alpha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar alturaP;
        private System.Windows.Forms.TrackBar larguraP;
        private System.Windows.Forms.TrackBar toleranciaA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar toleranciaL;
        private System.Windows.Forms.Button finalizar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private Emgu.CV.UI.ImageBox imagem;
        private Emgu.CV.UI.ImageBox planoFundo;
        private Emgu.CV.UI.ImageBox objetos;
        private System.Windows.Forms.TrackBar alpha;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
    }
}