namespace SerialControlAMCMB96
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEditar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuHerramientas = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCOM = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuModoAMC = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuModoAAP = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOpciones = new System.Windows.Forms.ToolStripMenuItem();
            this.menuChequeoID = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeMossCommToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panelModoAMC = new System.Windows.Forms.Panel();
            this.buttonLimpiarBancoAMC = new System.Windows.Forms.Button();
            this.labelseconds = new System.Windows.Forms.Label();
            this.numericUpDownAMCRate = new System.Windows.Forms.NumericUpDown();
            this.checkBoxRefreshAMC = new System.Windows.Forms.CheckBox();
            this.buttonLeerEspecAMC = new System.Windows.Forms.Button();
            this.comboBoxAMCMode = new System.Windows.Forms.ComboBox();
            this.radioButtonAMCContinue = new System.Windows.Forms.RadioButton();
            this.radioButtonAMCInit = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonActivarAMC = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonEnviarControlInt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonControlIntAct = new System.Windows.Forms.RadioButton();
            this.radioButtonControlIntDesact = new System.Windows.Forms.RadioButton();
            this.serialPortMain = new System.IO.Ports.SerialPort(this.components);
            this.panelModoAAP = new System.Windows.Forms.Panel();
            this.buttonLimpiarBancoAAP = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownAAPRate = new System.Windows.Forms.NumericUpDown();
            this.checkBoxRefreshAAP = new System.Windows.Forms.CheckBox();
            this.buttonLeerDatosAAP = new System.Windows.Forms.Button();
            this.comboBoxModoAAP = new System.Windows.Forms.ComboBox();
            this.radioButtonAAPContinue = new System.Windows.Forms.RadioButton();
            this.radioButtonAAPInit = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonActivarAAP = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButtonControlIntAAPAct = new System.Windows.Forms.RadioButton();
            this.radioButtonControlIntAAPDesact = new System.Windows.Forms.RadioButton();
            this.zedGraphControlMain = new ZedGraph.ZedGraphControl();
            this.labelAMCActivo = new System.Windows.Forms.Label();
            this.labelNumAMC = new System.Windows.Forms.Label();
            this.labelLimInf = new System.Windows.Forms.Label();
            this.labelLimSup = new System.Windows.Forms.Label();
            this.labelLimInfValue = new System.Windows.Forms.Label();
            this.labelLimSupValue = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelLims1 = new System.Windows.Forms.Label();
            this.labelLims2 = new System.Windows.Forms.Label();
            this.numericUpDownLimInf = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLimSup = new System.Windows.Forms.NumericUpDown();
            this.buttonPonerLimites = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panelModoAMC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAMCRate)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelModoAAP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAAPRate)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLimInf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLimSup)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuArchivo,
            this.MenuEditar,
            this.MenuHerramientas,
            this.MenuAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuArchivo
            // 
            this.MenuArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.guardarComoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.salirToolStripMenuItem});
            this.MenuArchivo.Name = "MenuArchivo";
            this.MenuArchivo.Size = new System.Drawing.Size(55, 20);
            this.MenuArchivo.Text = "&Archivo";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.nuevoToolStripMenuItem.Text = "&Nuevo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.abrirToolStripMenuItem.Text = "&Abrir";
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.guardarToolStripMenuItem.Text = "&Guardar";
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.guardarComoToolStripMenuItem.Text = "G&uardar como...";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(161, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.salirToolStripMenuItem.Text = "&Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // MenuEditar
            // 
            this.MenuEditar.Name = "MenuEditar";
            this.MenuEditar.Size = new System.Drawing.Size(47, 20);
            this.MenuEditar.Text = "&Editar";
            // 
            // MenuHerramientas
            // 
            this.MenuHerramientas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuCOM,
            this.MenuModoAMC,
            this.MenuModoAAP,
            this.MenuOpciones,
            this.menuChequeoID});
            this.MenuHerramientas.Name = "MenuHerramientas";
            this.MenuHerramientas.Size = new System.Drawing.Size(83, 20);
            this.MenuHerramientas.Text = "&Herramientas";
            // 
            // MenuCOM
            // 
            this.MenuCOM.Name = "MenuCOM";
            this.MenuCOM.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F5)));
            this.MenuCOM.Size = new System.Drawing.Size(226, 22);
            this.MenuCOM.Text = "Configuración COM";
            this.MenuCOM.Click += new System.EventHandler(this.MenuCOM_Click);
            // 
            // MenuModoAMC
            // 
            this.MenuModoAMC.Name = "MenuModoAMC";
            this.MenuModoAMC.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F9)));
            this.MenuModoAMC.Size = new System.Drawing.Size(226, 22);
            this.MenuModoAMC.Text = "Modo AMC";
            this.MenuModoAMC.Click += new System.EventHandler(this.MenuModoAMC_Click);
            // 
            // MenuModoAAP
            // 
            this.MenuModoAAP.Name = "MenuModoAAP";
            this.MenuModoAAP.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F10)));
            this.MenuModoAAP.Size = new System.Drawing.Size(226, 22);
            this.MenuModoAAP.Text = "Modo AAP";
            this.MenuModoAAP.Click += new System.EventHandler(this.MenuModoAAP_Click);
            // 
            // MenuOpciones
            // 
            this.MenuOpciones.Name = "MenuOpciones";
            this.MenuOpciones.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F12)));
            this.MenuOpciones.Size = new System.Drawing.Size(226, 22);
            this.MenuOpciones.Text = "Opciones";
            // 
            // menuChequeoID
            // 
            this.menuChequeoID.Name = "menuChequeoID";
            this.menuChequeoID.Size = new System.Drawing.Size(226, 22);
            this.menuChequeoID.Text = "Chequear ID";
            this.menuChequeoID.Click += new System.EventHandler(this.menuChequeoID_Click);
            // 
            // MenuAbout
            // 
            this.MenuAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeMossCommToolStripMenuItem});
            this.MenuAbout.Name = "MenuAbout";
            this.MenuAbout.Size = new System.Drawing.Size(79, 20);
            this.MenuAbout.Text = "Acerca &de...";
            // 
            // acercaDeMossCommToolStripMenuItem
            // 
            this.acercaDeMossCommToolStripMenuItem.Name = "acercaDeMossCommToolStripMenuItem";
            this.acercaDeMossCommToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.acercaDeMossCommToolStripMenuItem.Text = "Acerca de MossComm";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1008, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // panelModoAMC
            // 
            this.panelModoAMC.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelModoAMC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelModoAMC.Controls.Add(this.buttonLimpiarBancoAMC);
            this.panelModoAMC.Controls.Add(this.labelseconds);
            this.panelModoAMC.Controls.Add(this.numericUpDownAMCRate);
            this.panelModoAMC.Controls.Add(this.checkBoxRefreshAMC);
            this.panelModoAMC.Controls.Add(this.buttonLeerEspecAMC);
            this.panelModoAMC.Controls.Add(this.comboBoxAMCMode);
            this.panelModoAMC.Controls.Add(this.radioButtonAMCContinue);
            this.panelModoAMC.Controls.Add(this.radioButtonAMCInit);
            this.panelModoAMC.Controls.Add(this.label1);
            this.panelModoAMC.Controls.Add(this.buttonActivarAMC);
            this.panelModoAMC.Controls.Add(this.panel1);
            this.panelModoAMC.Location = new System.Drawing.Point(0, 44);
            this.panelModoAMC.Name = "panelModoAMC";
            this.panelModoAMC.Size = new System.Drawing.Size(221, 686);
            this.panelModoAMC.TabIndex = 2;
            this.panelModoAMC.Visible = false;
            // 
            // buttonLimpiarBancoAMC
            // 
            this.buttonLimpiarBancoAMC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonLimpiarBancoAMC.Location = new System.Drawing.Point(34, 338);
            this.buttonLimpiarBancoAMC.Name = "buttonLimpiarBancoAMC";
            this.buttonLimpiarBancoAMC.Size = new System.Drawing.Size(148, 23);
            this.buttonLimpiarBancoAMC.TabIndex = 14;
            this.buttonLimpiarBancoAMC.Text = "Limpiar banco de datos";
            this.buttonLimpiarBancoAMC.UseVisualStyleBackColor = true;
            this.buttonLimpiarBancoAMC.Click += new System.EventHandler(this.buttonLimpiarBancoAMC_Click);
            // 
            // labelseconds
            // 
            this.labelseconds.AutoSize = true;
            this.labelseconds.Location = new System.Drawing.Point(172, 302);
            this.labelseconds.Name = "labelseconds";
            this.labelseconds.Size = new System.Drawing.Size(18, 13);
            this.labelseconds.TabIndex = 13;
            this.labelseconds.Text = "(s)";
            // 
            // numericUpDownAMCRate
            // 
            this.numericUpDownAMCRate.Location = new System.Drawing.Point(117, 300);
            this.numericUpDownAMCRate.Name = "numericUpDownAMCRate";
            this.numericUpDownAMCRate.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownAMCRate.TabIndex = 12;
            // 
            // checkBoxRefreshAMC
            // 
            this.checkBoxRefreshAMC.AutoSize = true;
            this.checkBoxRefreshAMC.Location = new System.Drawing.Point(12, 301);
            this.checkBoxRefreshAMC.Name = "checkBoxRefreshAMC";
            this.checkBoxRefreshAMC.Size = new System.Drawing.Size(99, 17);
            this.checkBoxRefreshAMC.TabIndex = 11;
            this.checkBoxRefreshAMC.Text = "Refrescar cada";
            this.checkBoxRefreshAMC.UseVisualStyleBackColor = true;
            // 
            // buttonLeerEspecAMC
            // 
            this.buttonLeerEspecAMC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonLeerEspecAMC.Location = new System.Drawing.Point(34, 271);
            this.buttonLeerEspecAMC.Name = "buttonLeerEspecAMC";
            this.buttonLeerEspecAMC.Size = new System.Drawing.Size(148, 23);
            this.buttonLeerEspecAMC.TabIndex = 10;
            this.buttonLeerEspecAMC.Text = "Leer datos espectro";
            this.buttonLeerEspecAMC.UseVisualStyleBackColor = true;
            this.buttonLeerEspecAMC.Click += new System.EventHandler(this.buttonLeerEspecAMC_Click);
            // 
            // comboBoxAMCMode
            // 
            this.comboBoxAMCMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAMCMode.FormattingEnabled = true;
            this.comboBoxAMCMode.Items.AddRange(new object[] {
            "Modo AMC (Muestreos Cortos)",
            "Modo AMC (Muestreos Largos)"});
            this.comboBoxAMCMode.Location = new System.Drawing.Point(11, 43);
            this.comboBoxAMCMode.Name = "comboBoxAMCMode";
            this.comboBoxAMCMode.Size = new System.Drawing.Size(171, 21);
            this.comboBoxAMCMode.TabIndex = 8;
            // 
            // radioButtonAMCContinue
            // 
            this.radioButtonAMCContinue.AutoSize = true;
            this.radioButtonAMCContinue.Location = new System.Drawing.Point(11, 93);
            this.radioButtonAMCContinue.Name = "radioButtonAMCContinue";
            this.radioButtonAMCContinue.Size = new System.Drawing.Size(115, 17);
            this.radioButtonAMCContinue.TabIndex = 3;
            this.radioButtonAMCContinue.TabStop = true;
            this.radioButtonAMCContinue.Text = "Continuar medición";
            this.radioButtonAMCContinue.UseVisualStyleBackColor = true;
            // 
            // radioButtonAMCInit
            // 
            this.radioButtonAMCInit.AutoSize = true;
            this.radioButtonAMCInit.Location = new System.Drawing.Point(11, 70);
            this.radioButtonAMCInit.Name = "radioButtonAMCInit";
            this.radioButtonAMCInit.Size = new System.Drawing.Size(131, 17);
            this.radioButtonAMCInit.TabIndex = 2;
            this.radioButtonAMCInit.TabStop = true;
            this.radioButtonAMCInit.Text = "Iniciar nueva medición";
            this.radioButtonAMCInit.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Opciones del modo AMC";
            // 
            // buttonActivarAMC
            // 
            this.buttonActivarAMC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonActivarAMC.Location = new System.Drawing.Point(34, 116);
            this.buttonActivarAMC.Name = "buttonActivarAMC";
            this.buttonActivarAMC.Size = new System.Drawing.Size(148, 23);
            this.buttonActivarAMC.TabIndex = 0;
            this.buttonActivarAMC.Text = "Activar Modo";
            this.buttonActivarAMC.UseVisualStyleBackColor = true;
            this.buttonActivarAMC.Click += new System.EventHandler(this.buttonActivarAMC_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.buttonEnviarControlInt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.radioButtonControlIntAct);
            this.panel1.Controls.Add(this.radioButtonControlIntDesact);
            this.panel1.Location = new System.Drawing.Point(-1, 145);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 120);
            this.panel1.TabIndex = 9;
            // 
            // buttonEnviarControlInt
            // 
            this.buttonEnviarControlInt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonEnviarControlInt.Location = new System.Drawing.Point(35, 82);
            this.buttonEnviarControlInt.Name = "buttonEnviarControlInt";
            this.buttonEnviarControlInt.Size = new System.Drawing.Size(148, 23);
            this.buttonEnviarControlInt.TabIndex = 7;
            this.buttonEnviarControlInt.Text = "Enviar Comando";
            this.buttonEnviarControlInt.UseVisualStyleBackColor = true;
            this.buttonEnviarControlInt.Click += new System.EventHandler(this.buttonEnviarControlInt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Location = new System.Drawing.Point(12, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 15);
            this.label2.TabIndex = 4;
            this.label2.Tag = "Control del mecanismo de interrupción del modo";
            this.label2.Text = "Control de interrupción";
            // 
            // radioButtonControlIntAct
            // 
            this.radioButtonControlIntAct.AutoSize = true;
            this.radioButtonControlIntAct.Location = new System.Drawing.Point(12, 36);
            this.radioButtonControlIntAct.Name = "radioButtonControlIntAct";
            this.radioButtonControlIntAct.Size = new System.Drawing.Size(67, 17);
            this.radioButtonControlIntAct.TabIndex = 5;
            this.radioButtonControlIntAct.TabStop = true;
            this.radioButtonControlIntAct.Text = "Activado";
            this.radioButtonControlIntAct.UseVisualStyleBackColor = true;
            // 
            // radioButtonControlIntDesact
            // 
            this.radioButtonControlIntDesact.AutoSize = true;
            this.radioButtonControlIntDesact.Location = new System.Drawing.Point(12, 59);
            this.radioButtonControlIntDesact.Name = "radioButtonControlIntDesact";
            this.radioButtonControlIntDesact.Size = new System.Drawing.Size(85, 17);
            this.radioButtonControlIntDesact.TabIndex = 6;
            this.radioButtonControlIntDesact.TabStop = true;
            this.radioButtonControlIntDesact.Text = "Desactivado";
            this.radioButtonControlIntDesact.UseVisualStyleBackColor = true;
            // 
            // panelModoAAP
            // 
            this.panelModoAAP.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelModoAAP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelModoAAP.Controls.Add(this.panel2);
            this.panelModoAAP.Controls.Add(this.labelLimSupValue);
            this.panelModoAAP.Controls.Add(this.labelLimInfValue);
            this.panelModoAAP.Controls.Add(this.labelLimSup);
            this.panelModoAAP.Controls.Add(this.labelLimInf);
            this.panelModoAAP.Controls.Add(this.buttonLimpiarBancoAAP);
            this.panelModoAAP.Controls.Add(this.label3);
            this.panelModoAAP.Controls.Add(this.numericUpDownAAPRate);
            this.panelModoAAP.Controls.Add(this.checkBoxRefreshAAP);
            this.panelModoAAP.Controls.Add(this.buttonLeerDatosAAP);
            this.panelModoAAP.Controls.Add(this.comboBoxModoAAP);
            this.panelModoAAP.Controls.Add(this.radioButtonAAPContinue);
            this.panelModoAAP.Controls.Add(this.radioButtonAAPInit);
            this.panelModoAAP.Controls.Add(this.label5);
            this.panelModoAAP.Controls.Add(this.buttonActivarAAP);
            this.panelModoAAP.Controls.Add(this.panel3);
            this.panelModoAAP.Location = new System.Drawing.Point(227, 44);
            this.panelModoAAP.Name = "panelModoAAP";
            this.panelModoAAP.Size = new System.Drawing.Size(221, 686);
            this.panelModoAAP.TabIndex = 3;
            this.panelModoAAP.Visible = false;
            // 
            // buttonLimpiarBancoAAP
            // 
            this.buttonLimpiarBancoAAP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonLimpiarBancoAAP.Location = new System.Drawing.Point(34, 338);
            this.buttonLimpiarBancoAAP.Name = "buttonLimpiarBancoAAP";
            this.buttonLimpiarBancoAAP.Size = new System.Drawing.Size(148, 23);
            this.buttonLimpiarBancoAAP.TabIndex = 15;
            this.buttonLimpiarBancoAAP.Text = "Limpiar banco de datos";
            this.buttonLimpiarBancoAAP.UseVisualStyleBackColor = true;
            this.buttonLimpiarBancoAAP.Click += new System.EventHandler(this.buttonLimpiarBancoAAP_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "(s)";
            // 
            // numericUpDownAAPRate
            // 
            this.numericUpDownAAPRate.Location = new System.Drawing.Point(117, 300);
            this.numericUpDownAAPRate.Name = "numericUpDownAAPRate";
            this.numericUpDownAAPRate.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownAAPRate.TabIndex = 12;
            // 
            // checkBoxRefreshAAP
            // 
            this.checkBoxRefreshAAP.AutoSize = true;
            this.checkBoxRefreshAAP.Location = new System.Drawing.Point(12, 301);
            this.checkBoxRefreshAAP.Name = "checkBoxRefreshAAP";
            this.checkBoxRefreshAAP.Size = new System.Drawing.Size(99, 17);
            this.checkBoxRefreshAAP.TabIndex = 11;
            this.checkBoxRefreshAAP.Text = "Refrescar cada";
            this.checkBoxRefreshAAP.UseVisualStyleBackColor = true;
            // 
            // buttonLeerDatosAAP
            // 
            this.buttonLeerDatosAAP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonLeerDatosAAP.Location = new System.Drawing.Point(34, 271);
            this.buttonLeerDatosAAP.Name = "buttonLeerDatosAAP";
            this.buttonLeerDatosAAP.Size = new System.Drawing.Size(148, 23);
            this.buttonLeerDatosAAP.TabIndex = 10;
            this.buttonLeerDatosAAP.Text = "Leer datos AAP";
            this.buttonLeerDatosAAP.UseVisualStyleBackColor = true;
            this.buttonLeerDatosAAP.Click += new System.EventHandler(this.buttonLeerDatosAAP_Click);
            // 
            // comboBoxModoAAP
            // 
            this.comboBoxModoAAP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModoAAP.FormattingEnabled = true;
            this.comboBoxModoAAP.Items.AddRange(new object[] {
            "Modo AAP"});
            this.comboBoxModoAAP.Location = new System.Drawing.Point(11, 43);
            this.comboBoxModoAAP.Name = "comboBoxModoAAP";
            this.comboBoxModoAAP.Size = new System.Drawing.Size(171, 21);
            this.comboBoxModoAAP.TabIndex = 8;
            // 
            // radioButtonAAPContinue
            // 
            this.radioButtonAAPContinue.AutoSize = true;
            this.radioButtonAAPContinue.Location = new System.Drawing.Point(11, 93);
            this.radioButtonAAPContinue.Name = "radioButtonAAPContinue";
            this.radioButtonAAPContinue.Size = new System.Drawing.Size(115, 17);
            this.radioButtonAAPContinue.TabIndex = 3;
            this.radioButtonAAPContinue.TabStop = true;
            this.radioButtonAAPContinue.Text = "Continuar medición";
            this.radioButtonAAPContinue.UseVisualStyleBackColor = true;
            // 
            // radioButtonAAPInit
            // 
            this.radioButtonAAPInit.AutoSize = true;
            this.radioButtonAAPInit.Location = new System.Drawing.Point(11, 70);
            this.radioButtonAAPInit.Name = "radioButtonAAPInit";
            this.radioButtonAAPInit.Size = new System.Drawing.Size(131, 17);
            this.radioButtonAAPInit.TabIndex = 2;
            this.radioButtonAAPInit.TabStop = true;
            this.radioButtonAAPInit.Text = "Iniciar nueva medición";
            this.radioButtonAAPInit.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.Location = new System.Drawing.Point(11, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Opciones del modo AAP";
            // 
            // buttonActivarAAP
            // 
            this.buttonActivarAAP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonActivarAAP.Location = new System.Drawing.Point(34, 116);
            this.buttonActivarAAP.Name = "buttonActivarAAP";
            this.buttonActivarAAP.Size = new System.Drawing.Size(148, 23);
            this.buttonActivarAAP.TabIndex = 0;
            this.buttonActivarAAP.Text = "Activar Modo";
            this.buttonActivarAAP.UseVisualStyleBackColor = true;
            this.buttonActivarAAP.Click += new System.EventHandler(this.buttonActivarAAP_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.radioButtonControlIntAAPAct);
            this.panel3.Controls.Add(this.radioButtonControlIntAAPDesact);
            this.panel3.Location = new System.Drawing.Point(-1, 145);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(220, 105);
            this.panel3.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Location = new System.Drawing.Point(12, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 15);
            this.label4.TabIndex = 4;
            this.label4.Tag = "Control del mecanismo de interrupción del modo";
            this.label4.Text = "Activar/Desactivar Medición";
            // 
            // radioButtonControlIntAAPAct
            // 
            this.radioButtonControlIntAAPAct.AutoEllipsis = true;
            this.radioButtonControlIntAAPAct.AutoSize = true;
            this.radioButtonControlIntAAPAct.BackColor = System.Drawing.SystemColors.ControlLight;
            this.radioButtonControlIntAAPAct.Location = new System.Drawing.Point(12, 36);
            this.radioButtonControlIntAAPAct.Name = "radioButtonControlIntAAPAct";
            this.radioButtonControlIntAAPAct.Size = new System.Drawing.Size(58, 17);
            this.radioButtonControlIntAAPAct.TabIndex = 5;
            this.radioButtonControlIntAAPAct.TabStop = true;
            this.radioButtonControlIntAAPAct.Text = "Activar";
            this.radioButtonControlIntAAPAct.UseVisualStyleBackColor = false;
            this.radioButtonControlIntAAPAct.CheckedChanged += new System.EventHandler(this.radioButtonControlIntAAPAct_CheckedChanged);
            // 
            // radioButtonControlIntAAPDesact
            // 
            this.radioButtonControlIntAAPDesact.AutoSize = true;
            this.radioButtonControlIntAAPDesact.Location = new System.Drawing.Point(12, 59);
            this.radioButtonControlIntAAPDesact.Name = "radioButtonControlIntAAPDesact";
            this.radioButtonControlIntAAPDesact.Size = new System.Drawing.Size(76, 17);
            this.radioButtonControlIntAAPDesact.TabIndex = 6;
            this.radioButtonControlIntAAPDesact.TabStop = true;
            this.radioButtonControlIntAAPDesact.Text = "Desactivar";
            this.radioButtonControlIntAAPDesact.UseVisualStyleBackColor = true;
            this.radioButtonControlIntAAPDesact.CheckedChanged += new System.EventHandler(this.radioButtonControlIntAAPDesact_CheckedChanged);
            // 
            // zedGraphControlMain
            // 
            this.zedGraphControlMain.Location = new System.Drawing.Point(227, 44);
            this.zedGraphControlMain.Name = "zedGraphControlMain";
            this.zedGraphControlMain.ScrollGrace = 0D;
            this.zedGraphControlMain.ScrollMaxX = 0D;
            this.zedGraphControlMain.ScrollMaxY = 0D;
            this.zedGraphControlMain.ScrollMaxY2 = 0D;
            this.zedGraphControlMain.ScrollMinX = 0D;
            this.zedGraphControlMain.ScrollMinY = 0D;
            this.zedGraphControlMain.ScrollMinY2 = 0D;
            this.zedGraphControlMain.Size = new System.Drawing.Size(781, 686);
            this.zedGraphControlMain.TabIndex = 4;
            // 
            // labelAMCActivo
            // 
            this.labelAMCActivo.AutoSize = true;
            this.labelAMCActivo.Location = new System.Drawing.Point(12, 28);
            this.labelAMCActivo.Name = "labelAMCActivo";
            this.labelAMCActivo.Size = new System.Drawing.Size(114, 13);
            this.labelAMCActivo.TabIndex = 5;
            this.labelAMCActivo.Text = "Espectrómetro Activo: ";
            // 
            // labelNumAMC
            // 
            this.labelNumAMC.AutoSize = true;
            this.labelNumAMC.Location = new System.Drawing.Point(133, 28);
            this.labelNumAMC.Name = "labelNumAMC";
            this.labelNumAMC.Size = new System.Drawing.Size(92, 13);
            this.labelNumAMC.TabIndex = 6;
            this.labelNumAMC.Text = "NO DETECTADO";
            // 
            // labelLimInf
            // 
            this.labelLimInf.AutoSize = true;
            this.labelLimInf.Location = new System.Drawing.Point(8, 610);
            this.labelLimInf.Name = "labelLimInf";
            this.labelLimInf.Size = new System.Drawing.Size(132, 13);
            this.labelLimInf.TabIndex = 16;
            this.labelLimInf.Text = "Límite Inferior de Ventana:";
            // 
            // labelLimSup
            // 
            this.labelLimSup.AutoSize = true;
            this.labelLimSup.Location = new System.Drawing.Point(8, 623);
            this.labelLimSup.Name = "labelLimSup";
            this.labelLimSup.Size = new System.Drawing.Size(139, 13);
            this.labelLimSup.TabIndex = 17;
            this.labelLimSup.Text = "Límite Superior de Ventana:";
            // 
            // labelLimInfValue
            // 
            this.labelLimInfValue.AutoSize = true;
            this.labelLimInfValue.Location = new System.Drawing.Point(145, 610);
            this.labelLimInfValue.Name = "labelLimInfValue";
            this.labelLimInfValue.Size = new System.Drawing.Size(19, 13);
            this.labelLimInfValue.TabIndex = 18;
            this.labelLimInfValue.Text = "00";
            this.labelLimInfValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelLimSupValue
            // 
            this.labelLimSupValue.AutoSize = true;
            this.labelLimSupValue.Location = new System.Drawing.Point(145, 623);
            this.labelLimSupValue.Name = "labelLimSupValue";
            this.labelLimSupValue.Size = new System.Drawing.Size(25, 13);
            this.labelLimSupValue.TabIndex = 19;
            this.labelLimSupValue.Text = "256";
            this.labelLimSupValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonPonerLimites);
            this.panel2.Controls.Add(this.numericUpDownLimSup);
            this.panel2.Controls.Add(this.numericUpDownLimInf);
            this.panel2.Controls.Add(this.labelLims2);
            this.panel2.Controls.Add(this.labelLims1);
            this.panel2.Location = new System.Drawing.Point(-1, 367);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(221, 135);
            this.panel2.TabIndex = 20;
            // 
            // labelLims1
            // 
            this.labelLims1.AutoSize = true;
            this.labelLims1.Location = new System.Drawing.Point(10, 21);
            this.labelLims1.Name = "labelLims1";
            this.labelLims1.Size = new System.Drawing.Size(132, 13);
            this.labelLims1.TabIndex = 17;
            this.labelLims1.Text = "Límite Inferior de Ventana:";
            // 
            // labelLims2
            // 
            this.labelLims2.AutoSize = true;
            this.labelLims2.Location = new System.Drawing.Point(9, 46);
            this.labelLims2.Name = "labelLims2";
            this.labelLims2.Size = new System.Drawing.Size(139, 13);
            this.labelLims2.TabIndex = 18;
            this.labelLims2.Text = "Límite Superior de Ventana:";
            // 
            // numericUpDownLimInf
            // 
            this.numericUpDownLimInf.Location = new System.Drawing.Point(155, 19);
            this.numericUpDownLimInf.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numericUpDownLimInf.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownLimInf.Name = "numericUpDownLimInf";
            this.numericUpDownLimInf.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownLimInf.TabIndex = 19;
            this.numericUpDownLimInf.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // numericUpDownLimSup
            // 
            this.numericUpDownLimSup.Location = new System.Drawing.Point(155, 44);
            this.numericUpDownLimSup.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownLimSup.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownLimSup.Name = "numericUpDownLimSup";
            this.numericUpDownLimSup.Size = new System.Drawing.Size(49, 20);
            this.numericUpDownLimSup.TabIndex = 20;
            this.numericUpDownLimSup.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // buttonPonerLimites
            // 
            this.buttonPonerLimites.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonPonerLimites.Location = new System.Drawing.Point(35, 70);
            this.buttonPonerLimites.Name = "buttonPonerLimites";
            this.buttonPonerLimites.Size = new System.Drawing.Size(148, 23);
            this.buttonPonerLimites.TabIndex = 21;
            this.buttonPonerLimites.Text = "Establecer límites";
            this.buttonPonerLimites.UseVisualStyleBackColor = true;
            this.buttonPonerLimites.Click += new System.EventHandler(this.buttonPonerLimites_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.labelNumAMC);
            this.Controls.Add(this.labelAMCActivo);
            this.Controls.Add(this.panelModoAAP);
            this.Controls.Add(this.panelModoAMC);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.zedGraphControlMain);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "MossComm v1.0";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelModoAMC.ResumeLayout(false);
            this.panelModoAMC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAMCRate)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelModoAAP.ResumeLayout(false);
            this.panelModoAAP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAAPRate)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLimInf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLimSup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuArchivo;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuEditar;
        private System.Windows.Forms.ToolStripMenuItem MenuHerramientas;
        private System.Windows.Forms.ToolStripMenuItem MenuOpciones;
        private System.Windows.Forms.ToolStripMenuItem MenuAbout;
        private System.Windows.Forms.ToolStripMenuItem acercaDeMossCommToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuCOM;
        private System.Windows.Forms.ToolStripMenuItem MenuModoAMC;
        private System.Windows.Forms.ToolStripMenuItem MenuModoAAP;
        private System.Windows.Forms.Panel panelModoAMC;
        private System.Windows.Forms.Button buttonActivarAMC;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort serialPortMain;
        private System.Windows.Forms.RadioButton radioButtonAMCContinue;
        private System.Windows.Forms.RadioButton radioButtonAMCInit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonEnviarControlInt;
        private System.Windows.Forms.RadioButton radioButtonControlIntDesact;
        private System.Windows.Forms.RadioButton radioButtonControlIntAct;
        private System.Windows.Forms.ComboBox comboBoxAMCMode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBoxRefreshAMC;
        private System.Windows.Forms.Button buttonLeerEspecAMC;
        private System.Windows.Forms.Label labelseconds;
        private System.Windows.Forms.NumericUpDown numericUpDownAMCRate;
        private System.Windows.Forms.Panel panelModoAAP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownAAPRate;
        private System.Windows.Forms.CheckBox checkBoxRefreshAAP;
        private System.Windows.Forms.Button buttonLeerDatosAAP;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButtonControlIntAAPAct;
        private System.Windows.Forms.RadioButton radioButtonControlIntAAPDesact;
        private System.Windows.Forms.ComboBox comboBoxModoAAP;
        private System.Windows.Forms.RadioButton radioButtonAAPContinue;
        private System.Windows.Forms.RadioButton radioButtonAAPInit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonActivarAAP;
        private System.Windows.Forms.Button buttonLimpiarBancoAMC;
        private System.Windows.Forms.Button buttonLimpiarBancoAAP;
        private ZedGraph.ZedGraphControl zedGraphControlMain;
        private System.Windows.Forms.ToolStripMenuItem menuChequeoID;
        private System.Windows.Forms.Label labelAMCActivo;
        private System.Windows.Forms.Label labelNumAMC;
        private System.Windows.Forms.Label labelLimSupValue;
        private System.Windows.Forms.Label labelLimInfValue;
        private System.Windows.Forms.Label labelLimSup;
        private System.Windows.Forms.Label labelLimInf;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonPonerLimites;
        private System.Windows.Forms.NumericUpDown numericUpDownLimSup;
        private System.Windows.Forms.NumericUpDown numericUpDownLimInf;
        private System.Windows.Forms.Label labelLims2;
        private System.Windows.Forms.Label labelLims1;
    }
}