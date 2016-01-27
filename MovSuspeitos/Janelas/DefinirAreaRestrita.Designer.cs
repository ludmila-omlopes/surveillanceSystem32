namespace FaceDetection.Janelas
{
    partial class DefinirAreaRestrita
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefinirAreaRestrita));
            this.finalizar = new System.Windows.Forms.Button();
            this.dataGridViewBlob = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VelocidadeMetros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VelocidadeKm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TempoEmCena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inversoes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Situacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBlob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // finalizar
            // 
            this.finalizar.Location = new System.Drawing.Point(538, 551);
            this.finalizar.Name = "finalizar";
            this.finalizar.Size = new System.Drawing.Size(98, 51);
            this.finalizar.TabIndex = 1;
            this.finalizar.Text = "Finalizar";
            this.finalizar.UseVisualStyleBackColor = true;
            this.finalizar.Click += new System.EventHandler(this.finalizar_Click);
            // 
            // dataGridViewBlob
            // 
            this.dataGridViewBlob.AllowUserToOrderColumns = true;
            this.dataGridViewBlob.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBlob.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewBlob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBlob.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.VelocidadeMetros,
            this.VelocidadeKm,
            this.TempoEmCena,
            this.inversoes,
            this.Situacao});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBlob.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewBlob.GridColor = System.Drawing.Color.Silver;
            this.dataGridViewBlob.Location = new System.Drawing.Point(12, 420);
            this.dataGridViewBlob.Name = "dataGridViewBlob";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBlob.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewBlob.Size = new System.Drawing.Size(624, 125);
            this.dataGridViewBlob.TabIndex = 10;
            // 
            // Id
            // 
            this.Id.Frozen = true;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 50;
            // 
            // VelocidadeMetros
            // 
            this.VelocidadeMetros.Frozen = true;
            this.VelocidadeMetros.HeaderText = "Velocidade (m/s)";
            this.VelocidadeMetros.Name = "VelocidadeMetros";
            this.VelocidadeMetros.Width = 85;
            // 
            // VelocidadeKm
            // 
            this.VelocidadeKm.Frozen = true;
            this.VelocidadeKm.HeaderText = "Velocidade (Km/h)";
            this.VelocidadeKm.Name = "VelocidadeKm";
            this.VelocidadeKm.Width = 85;
            // 
            // TempoEmCena
            // 
            this.TempoEmCena.Frozen = true;
            this.TempoEmCena.HeaderText = "Tempo em Cena (s)";
            this.TempoEmCena.Name = "TempoEmCena";
            this.TempoEmCena.Width = 85;
            // 
            // inversoes
            // 
            this.inversoes.HeaderText = "Número de Inversões";
            this.inversoes.Name = "inversoes";
            this.inversoes.Width = 85;
            // 
            // Situacao
            // 
            this.Situacao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Situacao.HeaderText = "Situação";
            this.Situacao.Name = "Situacao";
            this.Situacao.ReadOnly = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(623, 402);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            // 
            // DefinirAreaRestrita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(647, 604);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridViewBlob);
            this.Controls.Add(this.finalizar);
            this.Name = "DefinirAreaRestrita";
            this.Text = "DefinirAreaRestrita";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBlob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button finalizar;
        private System.Windows.Forms.DataGridView dataGridViewBlob;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn VelocidadeMetros;
        private System.Windows.Forms.DataGridViewTextBoxColumn VelocidadeKm;
        private System.Windows.Forms.DataGridViewTextBoxColumn TempoEmCena;
        private System.Windows.Forms.DataGridViewTextBoxColumn inversoes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Situacao;
        private Emgu.CV.UI.ImageBox pictureBox1;


    }
}