namespace FaceDetection.Janelas
{
    partial class JanelaDeMonitoramentoBlob
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JanelaDeMonitoramentoBlob));
            this.dataGridViewBlob = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VelocidadeMetros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VelocidadeKm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TempoEmCena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inversoes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Situacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxEmCena = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.maxVelocidade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numInversoes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.snapshot = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAtualizarParametros = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBoxBlob = new Emgu.CV.UI.ImageBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBlob)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlob)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewBlob
            // 
            this.dataGridViewBlob.AllowUserToOrderColumns = true;
            this.dataGridViewBlob.BackgroundColor = System.Drawing.Color.BlanchedAlmond;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBlob.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewBlob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBlob.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.VelocidadeMetros,
            this.VelocidadeKm,
            this.TempoEmCena,
            this.inversoes,
            this.Situacao});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewBlob.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewBlob.GridColor = System.Drawing.Color.Silver;
            this.dataGridViewBlob.Location = new System.Drawing.Point(658, 247);
            this.dataGridViewBlob.Name = "dataGridViewBlob";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBlob.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewBlob.Size = new System.Drawing.Size(640, 323);
            this.dataGridViewBlob.TabIndex = 9;
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
            // maxEmCena
            // 
            this.maxEmCena.BackColor = System.Drawing.SystemColors.Window;
            this.maxEmCena.Location = new System.Drawing.Point(124, 42);
            this.maxEmCena.Name = "maxEmCena";
            this.maxEmCena.Size = new System.Drawing.Size(52, 20);
            this.maxEmCena.TabIndex = 22;
            this.maxEmCena.Text = "3";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 42);
            this.label5.TabIndex = 21;
            this.label5.Text = "Tempo Máximo em Cena (s)";
            // 
            // maxVelocidade
            // 
            this.maxVelocidade.Location = new System.Drawing.Point(317, 42);
            this.maxVelocidade.Name = "maxVelocidade";
            this.maxVelocidade.Size = new System.Drawing.Size(42, 20);
            this.maxVelocidade.TabIndex = 26;
            this.maxVelocidade.Text = "8";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(208, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 62);
            this.label1.TabIndex = 25;
            this.label1.Text = "Velocidade Máxima (Km/h)";
            // 
            // numInversoes
            // 
            this.numInversoes.Location = new System.Drawing.Point(126, 84);
            this.numInversoes.Name = "numInversoes";
            this.numInversoes.Size = new System.Drawing.Size(50, 20);
            this.numInversoes.TabIndex = 28;
            this.numInversoes.Text = "2";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 33);
            this.label2.TabIndex = 27;
            this.label2.Text = "Número de Inversões";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(658, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(640, 206);
            this.panel1.TabIndex = 31;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.snapshot);
            this.panel3.Location = new System.Drawing.Point(393, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(240, 195);
            this.panel3.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(102, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 18);
            this.label3.TabIndex = 36;
            this.label3.Text = "Ações";
            // 
            // snapshot
            // 
            this.snapshot.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("snapshot.BackgroundImage")));
            this.snapshot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.snapshot.Location = new System.Drawing.Point(96, 84);
            this.snapshot.Name = "snapshot";
            this.snapshot.Size = new System.Drawing.Size(63, 62);
            this.snapshot.TabIndex = 35;
            this.snapshot.UseVisualStyleBackColor = true;
            this.snapshot.Click += new System.EventHandler(this.snapshot_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnAtualizarParametros);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.maxVelocidade);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.numInversoes);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.maxEmCena);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(3, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(383, 195);
            this.panel2.TabIndex = 37;
            // 
            // btnAtualizarParametros
            // 
            this.btnAtualizarParametros.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAtualizarParametros.BackgroundImage")));
            this.btnAtualizarParametros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAtualizarParametros.Location = new System.Drawing.Point(296, 111);
            this.btnAtualizarParametros.Name = "btnAtualizarParametros";
            this.btnAtualizarParametros.Size = new System.Drawing.Size(63, 59);
            this.btnAtualizarParametros.TabIndex = 36;
            this.btnAtualizarParametros.UseVisualStyleBackColor = true;
            this.btnAtualizarParametros.Click += new System.EventHandler(this.btnAtualizarParametros_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(57, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(290, 18);
            this.label8.TabIndex = 34;
            this.label8.Text = "Configuração de Movimentos Suspeitos";
            // 
            // pictureBoxBlob
            // 
            this.pictureBoxBlob.Location = new System.Drawing.Point(12, 35);
            this.pictureBoxBlob.Name = "pictureBoxBlob";
            this.pictureBoxBlob.Size = new System.Drawing.Size(630, 535);
            this.pictureBoxBlob.TabIndex = 2;
            this.pictureBoxBlob.TabStop = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(298, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 14);
            this.label4.TabIndex = 37;
            this.label4.Text = "Atualizar";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(99, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 14);
            this.label6.TabIndex = 38;
            this.label6.Text = "Detectar";
            // 
            // JanelaDeMonitoramentoBlob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1304, 707);
            this.Controls.Add(this.pictureBoxBlob);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridViewBlob);
            this.Name = "JanelaDeMonitoramentoBlob";
            this.Text = "JanelaDeMonitoramento";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBlob)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBlob)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewBlob;
        private System.Windows.Forms.TextBox maxEmCena;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox maxVelocidade;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox numInversoes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn VelocidadeMetros;
        private System.Windows.Forms.DataGridViewTextBoxColumn VelocidadeKm;
        private System.Windows.Forms.DataGridViewTextBoxColumn TempoEmCena;
        private System.Windows.Forms.DataGridViewTextBoxColumn inversoes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Situacao;
        private System.Windows.Forms.Button snapshot;
        private System.Windows.Forms.Button btnAtualizarParametros;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private Emgu.CV.UI.ImageBox pictureBoxBlob;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;

    }
}