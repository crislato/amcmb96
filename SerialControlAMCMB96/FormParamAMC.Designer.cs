namespace SerialControlAMCMB96
{
    partial class FormParamAMC
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
            this.buttonSaveConf = new System.Windows.Forms.Button();
            this.tableLayoutPanelConfig = new System.Windows.Forms.TableLayoutPanel();
            this.labelModoAvance = new System.Windows.Forms.Label();
            this.labelSignoVelocidad = new System.Windows.Forms.Label();
            this.labelFactorVelocidad = new System.Windows.Forms.Label();
            this.labelVelocidadMaxima = new System.Windows.Forms.Label();
            this.labelResolucion = new System.Windows.Forms.Label();
            this.labelTiempoMuerto = new System.Windows.Forms.Label();
            this.labelFrecuenciaBarrido = new System.Windows.Forms.Label();
            this.labelModoManejo = new System.Windows.Forms.Label();
            this.comboBoxModoManejo = new System.Windows.Forms.ComboBox();
            this.comboBoxFactorEscala = new System.Windows.Forms.ComboBox();
            this.comboBoxMaxVel = new System.Windows.Forms.ComboBox();
            this.comboBoxResolucion = new System.Windows.Forms.ComboBox();
            this.comboBoxTiempoMuerto = new System.Windows.Forms.ComboBox();
            this.comboBoxSignoVelocidad = new System.Windows.Forms.ComboBox();
            this.comboBoxModoAvance = new System.Windows.Forms.ComboBox();
            this.numericUpDownFrecuencia = new System.Windows.Forms.NumericUpDown();
            this.labelConfig = new System.Windows.Forms.Label();
            this.toolTipModoManejo = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanelConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrecuencia)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSaveConf
            // 
            this.buttonSaveConf.Location = new System.Drawing.Point(144, 337);
            this.buttonSaveConf.Name = "buttonSaveConf";
            this.buttonSaveConf.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveConf.TabIndex = 10;
            this.buttonSaveConf.Text = "Guardar";
            this.buttonSaveConf.UseVisualStyleBackColor = true;
            this.buttonSaveConf.Click += new System.EventHandler(this.buttonSaveConf_Click);
            // 
            // tableLayoutPanelConfig
            // 
            this.tableLayoutPanelConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelConfig.ColumnCount = 2;
            this.tableLayoutPanelConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.7037F));
            this.tableLayoutPanelConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.2963F));
            this.tableLayoutPanelConfig.Controls.Add(this.labelModoAvance, 0, 7);
            this.tableLayoutPanelConfig.Controls.Add(this.labelSignoVelocidad, 0, 6);
            this.tableLayoutPanelConfig.Controls.Add(this.labelFactorVelocidad, 0, 5);
            this.tableLayoutPanelConfig.Controls.Add(this.labelVelocidadMaxima, 0, 4);
            this.tableLayoutPanelConfig.Controls.Add(this.labelResolucion, 0, 3);
            this.tableLayoutPanelConfig.Controls.Add(this.labelTiempoMuerto, 0, 2);
            this.tableLayoutPanelConfig.Controls.Add(this.labelFrecuenciaBarrido, 0, 1);
            this.tableLayoutPanelConfig.Controls.Add(this.labelModoManejo, 0, 0);
            this.tableLayoutPanelConfig.Controls.Add(this.comboBoxModoManejo, 1, 0);
            this.tableLayoutPanelConfig.Controls.Add(this.comboBoxFactorEscala, 1, 5);
            this.tableLayoutPanelConfig.Controls.Add(this.comboBoxMaxVel, 1, 4);
            this.tableLayoutPanelConfig.Controls.Add(this.comboBoxResolucion, 1, 3);
            this.tableLayoutPanelConfig.Controls.Add(this.comboBoxTiempoMuerto, 1, 2);
            this.tableLayoutPanelConfig.Controls.Add(this.comboBoxSignoVelocidad, 1, 6);
            this.tableLayoutPanelConfig.Controls.Add(this.comboBoxModoAvance, 1, 7);
            this.tableLayoutPanelConfig.Controls.Add(this.numericUpDownFrecuencia, 1, 1);
            this.tableLayoutPanelConfig.Location = new System.Drawing.Point(12, 40);
            this.tableLayoutPanelConfig.Name = "tableLayoutPanelConfig";
            this.tableLayoutPanelConfig.RowCount = 8;
            this.tableLayoutPanelConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanelConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanelConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanelConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanelConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanelConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanelConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanelConfig.Size = new System.Drawing.Size(299, 278);
            this.tableLayoutPanelConfig.TabIndex = 9;
            this.toolTipModoManejo.SetToolTip(this.tableLayoutPanelConfig, "Esta es una prueba\r\n");
            // 
            // labelModoAvance
            // 
            this.labelModoAvance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelModoAvance.AutoSize = true;
            this.labelModoAvance.Location = new System.Drawing.Point(35, 253);
            this.labelModoAvance.Name = "labelModoAvance";
            this.labelModoAvance.Size = new System.Drawing.Size(89, 13);
            this.labelModoAvance.TabIndex = 30;
            this.labelModoAvance.Text = "Modo de Avance";
            // 
            // labelSignoVelocidad
            // 
            this.labelSignoVelocidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelSignoVelocidad.AutoSize = true;
            this.labelSignoVelocidad.Location = new System.Drawing.Point(31, 183);
            this.labelSignoVelocidad.Name = "labelSignoVelocidad";
            this.labelSignoVelocidad.Size = new System.Drawing.Size(98, 13);
            this.labelSignoVelocidad.TabIndex = 14;
            this.labelSignoVelocidad.Text = "Signo de velocidad";
            // 
            // labelFactorVelocidad
            // 
            this.labelFactorVelocidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelFactorVelocidad.AutoSize = true;
            this.labelFactorVelocidad.Location = new System.Drawing.Point(14, 153);
            this.labelFactorVelocidad.Name = "labelFactorVelocidad";
            this.labelFactorVelocidad.Size = new System.Drawing.Size(131, 13);
            this.labelFactorVelocidad.TabIndex = 13;
            this.labelFactorVelocidad.Text = "Escala de señal analógica";
            // 
            // labelVelocidadMaxima
            // 
            this.labelVelocidadMaxima.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelVelocidadMaxima.AutoSize = true;
            this.labelVelocidadMaxima.Location = new System.Drawing.Point(33, 124);
            this.labelVelocidadMaxima.Name = "labelVelocidadMaxima";
            this.labelVelocidadMaxima.Size = new System.Drawing.Size(93, 13);
            this.labelVelocidadMaxima.TabIndex = 12;
            this.labelVelocidadMaxima.Text = "Velocidad Máxima";
            // 
            // labelResolucion
            // 
            this.labelResolucion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelResolucion.AutoSize = true;
            this.labelResolucion.Location = new System.Drawing.Point(50, 96);
            this.labelResolucion.Name = "labelResolucion";
            this.labelResolucion.Size = new System.Drawing.Size(60, 13);
            this.labelResolucion.TabIndex = 11;
            this.labelResolucion.Text = "Resolución";
            // 
            // labelTiempoMuerto
            // 
            this.labelTiempoMuerto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTiempoMuerto.AutoSize = true;
            this.labelTiempoMuerto.Location = new System.Drawing.Point(11, 67);
            this.labelTiempoMuerto.Name = "labelTiempoMuerto";
            this.labelTiempoMuerto.Size = new System.Drawing.Size(137, 13);
            this.labelTiempoMuerto.TabIndex = 10;
            this.labelTiempoMuerto.Text = "Intervalo de Tiempo Muerto";
            // 
            // labelFrecuenciaBarrido
            // 
            this.labelFrecuenciaBarrido.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelFrecuenciaBarrido.AutoSize = true;
            this.labelFrecuenciaBarrido.Location = new System.Drawing.Point(13, 35);
            this.labelFrecuenciaBarrido.Name = "labelFrecuenciaBarrido";
            this.labelFrecuenciaBarrido.Size = new System.Drawing.Size(133, 13);
            this.labelFrecuenciaBarrido.TabIndex = 9;
            this.labelFrecuenciaBarrido.Text = "Frecuencia de Barrido (Hz)";
            // 
            // labelModoManejo
            // 
            this.labelModoManejo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelModoManejo.AutoSize = true;
            this.labelModoManejo.Location = new System.Drawing.Point(36, 6);
            this.labelModoManejo.Name = "labelModoManejo";
            this.labelModoManejo.Size = new System.Drawing.Size(87, 13);
            this.labelModoManejo.TabIndex = 8;
            this.labelModoManejo.Text = "Modo de Manejo";
            this.toolTipModoManejo.SetToolTip(this.labelModoManejo, "El modo de manejo puede ser:\r\n- 1 para señal Triangular \r\n- 2 para señal Diente d" +
                    "e Sierra\r\n- 3 para señal sinusoidal");
            // 
            // comboBoxModoManejo
            // 
            this.comboBoxModoManejo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxModoManejo.FormattingEnabled = true;
            this.comboBoxModoManejo.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.comboBoxModoManejo.Location = new System.Drawing.Point(169, 3);
            this.comboBoxModoManejo.Name = "comboBoxModoManejo";
            this.comboBoxModoManejo.Size = new System.Drawing.Size(121, 21);
            this.comboBoxModoManejo.TabIndex = 23;
            this.toolTipModoManejo.SetToolTip(this.comboBoxModoManejo, "El modo de manejo puede ser:\r\n- 1 para señal Triangular \r\n- 2 para señal Diente d" +
                    "e Sierra\r\n- 3 para señal sinusoidal");
            // 
            // comboBoxFactorEscala
            // 
            this.comboBoxFactorEscala.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxFactorEscala.FormattingEnabled = true;
            this.comboBoxFactorEscala.Items.AddRange(new object[] {
            "1",
            "2",
            "4"});
            this.comboBoxFactorEscala.Location = new System.Drawing.Point(169, 149);
            this.comboBoxFactorEscala.Name = "comboBoxFactorEscala";
            this.comboBoxFactorEscala.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFactorEscala.TabIndex = 26;
            // 
            // comboBoxMaxVel
            // 
            this.comboBoxMaxVel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxMaxVel.FormattingEnabled = true;
            this.comboBoxMaxVel.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.comboBoxMaxVel.Location = new System.Drawing.Point(169, 120);
            this.comboBoxMaxVel.Name = "comboBoxMaxVel";
            this.comboBoxMaxVel.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMaxVel.TabIndex = 27;
            // 
            // comboBoxResolucion
            // 
            this.comboBoxResolucion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxResolucion.FormattingEnabled = true;
            this.comboBoxResolucion.Items.AddRange(new object[] {
            "256",
            "128",
            "512"});
            this.comboBoxResolucion.Location = new System.Drawing.Point(169, 92);
            this.comboBoxResolucion.Name = "comboBoxResolucion";
            this.comboBoxResolucion.Size = new System.Drawing.Size(121, 21);
            this.comboBoxResolucion.TabIndex = 25;
            // 
            // comboBoxTiempoMuerto
            // 
            this.comboBoxTiempoMuerto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxTiempoMuerto.FormattingEnabled = true;
            this.comboBoxTiempoMuerto.Items.AddRange(new object[] {
            "20",
            "10",
            "30"});
            this.comboBoxTiempoMuerto.Location = new System.Drawing.Point(169, 63);
            this.comboBoxTiempoMuerto.Name = "comboBoxTiempoMuerto";
            this.comboBoxTiempoMuerto.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTiempoMuerto.TabIndex = 28;
            // 
            // comboBoxSignoVelocidad
            // 
            this.comboBoxSignoVelocidad.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxSignoVelocidad.FormattingEnabled = true;
            this.comboBoxSignoVelocidad.Items.AddRange(new object[] {
            "0",
            "-1",
            "1"});
            this.comboBoxSignoVelocidad.Location = new System.Drawing.Point(169, 179);
            this.comboBoxSignoVelocidad.Name = "comboBoxSignoVelocidad";
            this.comboBoxSignoVelocidad.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSignoVelocidad.TabIndex = 31;
            // 
            // comboBoxModoAvance
            // 
            this.comboBoxModoAvance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxModoAvance.FormattingEnabled = true;
            this.comboBoxModoAvance.Items.AddRange(new object[] {
            "I",
            "E"});
            this.comboBoxModoAvance.Location = new System.Drawing.Point(169, 249);
            this.comboBoxModoAvance.Name = "comboBoxModoAvance";
            this.comboBoxModoAvance.Size = new System.Drawing.Size(121, 21);
            this.comboBoxModoAvance.TabIndex = 32;
            // 
            // numericUpDownFrecuencia
            // 
            this.numericUpDownFrecuencia.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownFrecuencia.Location = new System.Drawing.Point(210, 35);
            this.numericUpDownFrecuencia.Margin = new System.Windows.Forms.Padding(50, 10, 45, 5);
            this.numericUpDownFrecuencia.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDownFrecuencia.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownFrecuencia.Name = "numericUpDownFrecuencia";
            this.numericUpDownFrecuencia.Size = new System.Drawing.Size(44, 20);
            this.numericUpDownFrecuencia.TabIndex = 29;
            this.numericUpDownFrecuencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownFrecuencia.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // labelConfig
            // 
            this.labelConfig.AutoSize = true;
            this.labelConfig.Location = new System.Drawing.Point(9, 15);
            this.labelConfig.Name = "labelConfig";
            this.labelConfig.Size = new System.Drawing.Size(169, 13);
            this.labelConfig.TabIndex = 8;
            this.labelConfig.Text = "Configuración de Parámetros AMC";
            // 
            // toolTipModoManejo
            // 
            this.toolTipModoManejo.ToolTipTitle = "Modos de manejo";
            // 
            // FormParamAMC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 403);
            this.Controls.Add(this.buttonSaveConf);
            this.Controls.Add(this.tableLayoutPanelConfig);
            this.Controls.Add(this.labelConfig);
            this.Name = "FormParamAMC";
            this.Text = "MossComm - Parámetros AMC";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanelConfig.ResumeLayout(false);
            this.tableLayoutPanelConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFrecuencia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSaveConf;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelConfig;
        private System.Windows.Forms.Label labelSignoVelocidad;
        private System.Windows.Forms.Label labelFactorVelocidad;
        private System.Windows.Forms.Label labelVelocidadMaxima;
        private System.Windows.Forms.Label labelResolucion;
        private System.Windows.Forms.Label labelTiempoMuerto;
        private System.Windows.Forms.Label labelFrecuenciaBarrido;
        private System.Windows.Forms.Label labelModoManejo;
        private System.Windows.Forms.ComboBox comboBoxModoManejo;
        private System.Windows.Forms.ComboBox comboBoxResolucion;
        private System.Windows.Forms.ComboBox comboBoxFactorEscala;
        private System.Windows.Forms.ComboBox comboBoxMaxVel;
        private System.Windows.Forms.ComboBox comboBoxTiempoMuerto;
        private System.Windows.Forms.Label labelConfig;
        private System.Windows.Forms.NumericUpDown numericUpDownFrecuencia;
        private System.Windows.Forms.ComboBox comboBoxSignoVelocidad;
        private System.Windows.Forms.Label labelModoAvance;
        private System.Windows.Forms.ComboBox comboBoxModoAvance;
        private System.Windows.Forms.ToolTip toolTipModoManejo;

    }
}