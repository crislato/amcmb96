namespace SerialControlAMCMB96
{
    partial class FormCOMOptions
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
            this.buttonIniciar = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.labelConfig = new System.Windows.Forms.Label();
            this.tableLayoutPanelConfig = new System.Windows.Forms.TableLayoutPanel();
            this.labelWriteTimeout = new System.Windows.Forms.Label();
            this.labelReadTimeout = new System.Windows.Forms.Label();
            this.labelHandshake = new System.Windows.Forms.Label();
            this.labelStopBits = new System.Windows.Forms.Label();
            this.labelPortDataBits = new System.Windows.Forms.Label();
            this.labelParity = new System.Windows.Forms.Label();
            this.labelBaudRate = new System.Windows.Forms.Label();
            this.labelPortName = new System.Windows.Forms.Label();
            this.textBoxReadTimeout = new System.Windows.Forms.TextBox();
            this.textBoxWriteTimeout = new System.Windows.Forms.TextBox();
            this.comboBoxPortName = new System.Windows.Forms.ComboBox();
            this.comboBoxBaudrate = new System.Windows.Forms.ComboBox();
            this.comboBoxParity = new System.Windows.Forms.ComboBox();
            this.comboBoxHandshake = new System.Windows.Forms.ComboBox();
            this.comboBoxStopBits = new System.Windows.Forms.ComboBox();
            this.comboBoxDataBits = new System.Windows.Forms.ComboBox();
            this.buttonSaveConf = new System.Windows.Forms.Button();
            this.tableLayoutPanelConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonIniciar
            // 
            this.buttonIniciar.Location = new System.Drawing.Point(110, 413);
            this.buttonIniciar.Name = "buttonIniciar";
            this.buttonIniciar.Size = new System.Drawing.Size(86, 23);
            this.buttonIniciar.TabIndex = 0;
            this.buttonIniciar.Text = "Iniciar debug";
            this.buttonIniciar.UseVisualStyleBackColor = true;
            this.buttonIniciar.Click += new System.EventHandler(this.buttonIniciar_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Enabled = false;
            this.buttonStop.Location = new System.Drawing.Point(215, 413);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(92, 23);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Detener debug";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(330, 20);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(404, 413);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // labelConfig
            // 
            this.labelConfig.AutoSize = true;
            this.labelConfig.Location = new System.Drawing.Point(12, 23);
            this.labelConfig.Name = "labelConfig";
            this.labelConfig.Size = new System.Drawing.Size(152, 13);
            this.labelConfig.TabIndex = 3;
            this.labelConfig.Text = "Configuración del Puerto Serial";
            // 
            // tableLayoutPanelConfig
            // 
            this.tableLayoutPanelConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelConfig.ColumnCount = 2;
            this.tableLayoutPanelConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelConfig.Controls.Add(this.labelWriteTimeout, 0, 7);
            this.tableLayoutPanelConfig.Controls.Add(this.labelReadTimeout, 0, 6);
            this.tableLayoutPanelConfig.Controls.Add(this.labelHandshake, 0, 5);
            this.tableLayoutPanelConfig.Controls.Add(this.labelStopBits, 0, 4);
            this.tableLayoutPanelConfig.Controls.Add(this.labelPortDataBits, 0, 3);
            this.tableLayoutPanelConfig.Controls.Add(this.labelParity, 0, 2);
            this.tableLayoutPanelConfig.Controls.Add(this.labelBaudRate, 0, 1);
            this.tableLayoutPanelConfig.Controls.Add(this.labelPortName, 0, 0);
            this.tableLayoutPanelConfig.Controls.Add(this.textBoxReadTimeout, 1, 6);
            this.tableLayoutPanelConfig.Controls.Add(this.textBoxWriteTimeout, 1, 7);
            this.tableLayoutPanelConfig.Controls.Add(this.comboBoxPortName, 1, 0);
            this.tableLayoutPanelConfig.Controls.Add(this.comboBoxBaudrate, 1, 1);
            this.tableLayoutPanelConfig.Controls.Add(this.comboBoxParity, 1, 2);
            this.tableLayoutPanelConfig.Controls.Add(this.comboBoxHandshake, 1, 5);
            this.tableLayoutPanelConfig.Controls.Add(this.comboBoxStopBits, 1, 4);
            this.tableLayoutPanelConfig.Controls.Add(this.comboBoxDataBits, 1, 3);
            this.tableLayoutPanelConfig.Location = new System.Drawing.Point(15, 48);
            this.tableLayoutPanelConfig.Name = "tableLayoutPanelConfig";
            this.tableLayoutPanelConfig.RowCount = 8;
            this.tableLayoutPanelConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanelConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelConfig.Size = new System.Drawing.Size(292, 318);
            this.tableLayoutPanelConfig.TabIndex = 4;
            // 
            // labelWriteTimeout
            // 
            this.labelWriteTimeout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelWriteTimeout.AutoSize = true;
            this.labelWriteTimeout.Location = new System.Drawing.Point(21, 293);
            this.labelWriteTimeout.Name = "labelWriteTimeout";
            this.labelWriteTimeout.Size = new System.Drawing.Size(103, 13);
            this.labelWriteTimeout.TabIndex = 15;
            this.labelWriteTimeout.Text = "Timeout de escritura";
            // 
            // labelReadTimeout
            // 
            this.labelReadTimeout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelReadTimeout.AutoSize = true;
            this.labelReadTimeout.Location = new System.Drawing.Point(25, 253);
            this.labelReadTimeout.Name = "labelReadTimeout";
            this.labelReadTimeout.Size = new System.Drawing.Size(95, 13);
            this.labelReadTimeout.TabIndex = 14;
            this.labelReadTimeout.Text = "Timeout de lectura";
            // 
            // labelHandshake
            // 
            this.labelHandshake.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelHandshake.AutoSize = true;
            this.labelHandshake.Location = new System.Drawing.Point(39, 213);
            this.labelHandshake.Name = "labelHandshake";
            this.labelHandshake.Size = new System.Drawing.Size(67, 13);
            this.labelHandshake.TabIndex = 13;
            this.labelHandshake.Text = "Negociación";
            // 
            // labelStopBits
            // 
            this.labelStopBits.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelStopBits.AutoSize = true;
            this.labelStopBits.Location = new System.Drawing.Point(35, 173);
            this.labelStopBits.Name = "labelStopBits";
            this.labelStopBits.Size = new System.Drawing.Size(75, 13);
            this.labelStopBits.TabIndex = 12;
            this.labelStopBits.Text = "Bits de parada";
            // 
            // labelPortDataBits
            // 
            this.labelPortDataBits.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPortDataBits.AutoSize = true;
            this.labelPortDataBits.Location = new System.Drawing.Point(39, 133);
            this.labelPortDataBits.Name = "labelPortDataBits";
            this.labelPortDataBits.Size = new System.Drawing.Size(68, 13);
            this.labelPortDataBits.TabIndex = 11;
            this.labelPortDataBits.Text = "Bits de datos";
            // 
            // labelParity
            // 
            this.labelParity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelParity.AutoSize = true;
            this.labelParity.Location = new System.Drawing.Point(51, 93);
            this.labelParity.Name = "labelParity";
            this.labelParity.Size = new System.Drawing.Size(43, 13);
            this.labelParity.TabIndex = 10;
            this.labelParity.Text = "Paridad";
            // 
            // labelBaudRate
            // 
            this.labelBaudRate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelBaudRate.AutoSize = true;
            this.labelBaudRate.Location = new System.Drawing.Point(29, 53);
            this.labelBaudRate.Name = "labelBaudRate";
            this.labelBaudRate.Size = new System.Drawing.Size(87, 13);
            this.labelBaudRate.TabIndex = 9;
            this.labelBaudRate.Text = "Tasa de Baudios";
            // 
            // labelPortName
            // 
            this.labelPortName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPortName.AutoSize = true;
            this.labelPortName.Location = new System.Drawing.Point(25, 13);
            this.labelPortName.Name = "labelPortName";
            this.labelPortName.Size = new System.Drawing.Size(95, 13);
            this.labelPortName.TabIndex = 8;
            this.labelPortName.Text = "Nombre del Puerto";
            // 
            // textBoxReadTimeout
            // 
            this.textBoxReadTimeout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxReadTimeout.Location = new System.Drawing.Point(157, 250);
            this.textBoxReadTimeout.Name = "textBoxReadTimeout";
            this.textBoxReadTimeout.Size = new System.Drawing.Size(123, 20);
            this.textBoxReadTimeout.TabIndex = 21;
            this.textBoxReadTimeout.Text = "500";
            // 
            // textBoxWriteTimeout
            // 
            this.textBoxWriteTimeout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxWriteTimeout.Location = new System.Drawing.Point(157, 290);
            this.textBoxWriteTimeout.Name = "textBoxWriteTimeout";
            this.textBoxWriteTimeout.Size = new System.Drawing.Size(123, 20);
            this.textBoxWriteTimeout.TabIndex = 22;
            this.textBoxWriteTimeout.Text = "500";
            // 
            // comboBoxPortName
            // 
            this.comboBoxPortName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxPortName.FormattingEnabled = true;
            this.comboBoxPortName.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9"});
            this.comboBoxPortName.Location = new System.Drawing.Point(158, 9);
            this.comboBoxPortName.Name = "comboBoxPortName";
            this.comboBoxPortName.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPortName.TabIndex = 23;
            // 
            // comboBoxBaudrate
            // 
            this.comboBoxBaudrate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxBaudrate.FormattingEnabled = true;
            this.comboBoxBaudrate.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.comboBoxBaudrate.Location = new System.Drawing.Point(158, 49);
            this.comboBoxBaudrate.Name = "comboBoxBaudrate";
            this.comboBoxBaudrate.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBaudrate.TabIndex = 24;
            // 
            // comboBoxParity
            // 
            this.comboBoxParity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxParity.FormattingEnabled = true;
            this.comboBoxParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.comboBoxParity.Location = new System.Drawing.Point(158, 89);
            this.comboBoxParity.Name = "comboBoxParity";
            this.comboBoxParity.Size = new System.Drawing.Size(121, 21);
            this.comboBoxParity.TabIndex = 25;
            // 
            // comboBoxHandshake
            // 
            this.comboBoxHandshake.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxHandshake.FormattingEnabled = true;
            this.comboBoxHandshake.Items.AddRange(new object[] {
            "None",
            "XON/XOFF",
            "RTS/CTS",
            "DSR/DTR"});
            this.comboBoxHandshake.Location = new System.Drawing.Point(158, 209);
            this.comboBoxHandshake.Name = "comboBoxHandshake";
            this.comboBoxHandshake.Size = new System.Drawing.Size(121, 21);
            this.comboBoxHandshake.TabIndex = 26;
            // 
            // comboBoxStopBits
            // 
            this.comboBoxStopBits.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxStopBits.FormattingEnabled = true;
            this.comboBoxStopBits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.comboBoxStopBits.Location = new System.Drawing.Point(158, 169);
            this.comboBoxStopBits.Name = "comboBoxStopBits";
            this.comboBoxStopBits.Size = new System.Drawing.Size(121, 21);
            this.comboBoxStopBits.TabIndex = 27;
            // 
            // comboBoxDataBits
            // 
            this.comboBoxDataBits.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxDataBits.FormattingEnabled = true;
            this.comboBoxDataBits.Items.AddRange(new object[] {
            "8",
            "5",
            "6",
            "7"});
            this.comboBoxDataBits.Location = new System.Drawing.Point(158, 129);
            this.comboBoxDataBits.Name = "comboBoxDataBits";
            this.comboBoxDataBits.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDataBits.TabIndex = 28;
            // 
            // buttonSaveConf
            // 
            this.buttonSaveConf.Location = new System.Drawing.Point(15, 413);
            this.buttonSaveConf.Name = "buttonSaveConf";
            this.buttonSaveConf.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveConf.TabIndex = 5;
            this.buttonSaveConf.Text = "Guardar";
            this.buttonSaveConf.UseVisualStyleBackColor = true;
            this.buttonSaveConf.Click += new System.EventHandler(this.buttonSaveConf_Click);
            // 
            // FormCOMOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 448);
            this.Controls.Add(this.buttonSaveConf);
            this.Controls.Add(this.tableLayoutPanelConfig);
            this.Controls.Add(this.labelConfig);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonIniciar);
            this.Name = "FormCOMOptions";
            this.Text = "MossComm - Configuración";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCOMOptions_FormClosing);
            this.tableLayoutPanelConfig.ResumeLayout(false);
            this.tableLayoutPanelConfig.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonIniciar;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TextBox textBox1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label labelConfig;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelConfig;
        private System.Windows.Forms.Label labelWriteTimeout;
        private System.Windows.Forms.Label labelReadTimeout;
        private System.Windows.Forms.Label labelHandshake;
        private System.Windows.Forms.Label labelStopBits;
        private System.Windows.Forms.Label labelPortDataBits;
        private System.Windows.Forms.Label labelParity;
        private System.Windows.Forms.Label labelBaudRate;
        private System.Windows.Forms.Label labelPortName;
        private System.Windows.Forms.TextBox textBoxReadTimeout;
        private System.Windows.Forms.TextBox textBoxWriteTimeout;
        private System.Windows.Forms.ComboBox comboBoxPortName;
        private System.Windows.Forms.ComboBox comboBoxBaudrate;
        private System.Windows.Forms.ComboBox comboBoxParity;
        private System.Windows.Forms.ComboBox comboBoxHandshake;
        private System.Windows.Forms.ComboBox comboBoxStopBits;
        private System.Windows.Forms.ComboBox comboBoxDataBits;
        private System.Windows.Forms.Button buttonSaveConf;
    }
}

