using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ZedGraph;
using System.IO.Ports;
using System.Timers;
using System.Globalization;

namespace SerialControlAMCMB96
{
    public partial class FormMain : Form
    {
        string bancoDatosAMC;
        string bancoDatosAAP;
        int amcID = 0;
        int liminf = 0;
        int limsup = 0;
        System.Timers.Timer refreshTimer = new System.Timers.Timer();
        public FormMain()
        {
            InitializeComponent();
                        
        }

        //Rutina que se encarga de abrir el puerto, validar y enviar el comando especificado en cada
        //método asociado a un evento de click y selección de radio en un botón

        
        public void InicializarPuerto(System.IO.Ports.SerialPort Puerto)
        {
            if (Puerto.IsOpen) serialPortMain.Close();
            Puerto.PortName = Properties.Settings.Default.COMPortName;
            Puerto.BaudRate = Properties.Settings.Default.COMBaudRate;
            Puerto.Parity = Properties.Settings.Default.COMParity;
            Puerto.DataBits = Properties.Settings.Default.COMDataBits;
            //Puerto.StopBits = Properties.Settings.Default.COMStopBits;
            Puerto.StopBits = System.IO.Ports.StopBits.One;
            Puerto.Handshake = Properties.Settings.Default.COMHandshake;
            Puerto.ReadTimeout = Properties.Settings.Default.COMReadTimeout;
            Puerto.WriteTimeout = Properties.Settings.Default.COMWriteTimeout;
            
            try
            {
                Puerto.Open();
                Puerto.DtrEnable = true;
                Puerto.RtsEnable = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

        }

        public void EnviarOrden(string comando)
        {
            InicializarPuerto(serialPortMain);
            string inicomando = "[";
            string fincr = "\r";
            serialPortMain.Write(inicomando);
            serialPortMain.Write(comando);
            serialPortMain.Write(fincr);
            //serialPortMain.Close();
            
        }
        //Fin de rutina EnviarOrden(comando);

        public void EnviarOrdenEsperarRespuesta(string comando)
        {
            InicializarPuerto(serialPortMain);
            string inicomando = "[";
            string fincr = "\r";
            serialPortMain.Write(inicomando);
            serialPortMain.Write(comando);
            serialPortMain.Write(fincr);
                      
        }

        public void EnviarOrdenByteEsperarRespuesta(byte[] bytecomando)
        {
            InicializarPuerto(serialPortMain);
            string inicomando = "[";
            string fincr = "\r";
            serialPortMain.Write(inicomando);
            serialPortMain.Write(bytecomando, 0, bytecomando.Length);
            serialPortMain.Write(fincr);

        }

        public void EnviarOrdenByte(byte[] bytecomando)
        {
            InicializarPuerto(serialPortMain);
            string inicomando = "[";
            string fincr = "\r";
            serialPortMain.Write(inicomando);
            serialPortMain.Write(bytecomando, 0, bytecomando.Length);
            serialPortMain.Write(fincr);
            serialPortMain.DiscardInBuffer();
            //serialPortMain.Close();
            
        }

        private void ActualiceID()
        {
            this.Invoke(new EventHandler(DisplayAMCid));            
        }

        private void DisplayAMCid(object sender, EventArgs e)
        {
            labelNumAMC.Text = amcID.ToString();
        }

        private void menuChequeoID_Click(object sender, EventArgs e)
        {
            if (menuChequeoID.Checked == false)
            {
                string comandoID = "?";
                EnviarOrdenEsperarRespuesta(comandoID);
                serialPortMain.DataReceived += new SerialDataReceivedEventHandler(serialPortMain_IDReceived);

                //serialPortMain.Close();
                MenuModoAMC.Enabled = true;
                MenuModoAAP.Enabled = true;
                string dataAMC = "currentAMC_Dev" + amcID.ToString() + ".data";
                string dataAAP = "currentAAP_Dev" + amcID.ToString() + ".data";
                if (!File.Exists(dataAMC) | !File.Exists(dataAAP))
                {
                    File.Create(dataAMC).Dispose();
                    File.Create(dataAAP).Dispose();
                }
            }

        }
        
        void serialPortMain_IDReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int numdatosEntrada;
            numdatosEntrada = serialPortMain.BytesToRead;

            Byte[] datoID = new Byte[numdatosEntrada];
            serialPortMain.Read(datoID, 0, numdatosEntrada);
            string respuestaId = System.Text.Encoding.UTF8.GetString(datoID);
            //MessageBox.Show("Se ha detectado el espectrómetro con ID:" + respuestaId);

                if (respuestaId.Equals("!1", StringComparison.Ordinal))
                {
                    amcID = 1;
                    ActualiceID();
                }
                if (respuestaId.Equals("!2", StringComparison.Ordinal))
                {
                    amcID = 2;
                    ActualiceID();
                }
                if (respuestaId.Equals("!3", StringComparison.Ordinal))
                {
                    amcID = 3;
                    ActualiceID();
                }
                if (respuestaId.Equals("!4", StringComparison.Ordinal))
                {
                    amcID = 4;
                    ActualiceID();
                }
                if (respuestaId.Equals("!5", StringComparison.Ordinal))
                {
                    amcID = 5;
                    ActualiceID();
                }
                if (respuestaId.Equals("!6", StringComparison.Ordinal))
                {
                    amcID = 6;
                    ActualiceID();
                }
                if (respuestaId.Equals("!7", StringComparison.Ordinal))
                {
                    amcID = 7;
                    ActualiceID();
                }
                if (respuestaId.Equals("!8", StringComparison.Ordinal))
                {
                    amcID = 8;
                    ActualiceID();
                }
            serialPortMain.Close();
            serialPortMain.DataReceived -= serialPortMain_IDReceived;
            return;
        }

        
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea salir del programa?", "Salir", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void MenuCOM_Click(object sender, EventArgs e)
        {
            serialPortMain.Close();
            FormCOMOptions opcionesComm = new FormCOMOptions();
            opcionesComm.Show();
        }

        private void MenuModoAMC_Click(object sender, EventArgs e)
        {
            MenuModoAMC.Checked = !MenuModoAMC.Checked;
            if (MenuModoAMC.Checked == true)
            {
                MenuModoAAP.Checked = false;
                MenuModoAAP.Enabled = false;
                panelModoAMC.Enabled = true;
                panelModoAMC.Visible = true;
                CreateGraphAAP(zedGraphControlMain);
                ActualiceGraficoAAP();
                zedGraphControlMain.Show();
                buttonActivarAMC.Enabled = false;
            }
            if (MenuModoAMC.Checked == false)
            {
                MenuModoAAP.Enabled = true;
                panelModoAMC.Enabled = false;
                panelModoAMC.Visible = false;
                buttonActivarAMC.Enabled = true;
                zedGraphControlMain.Hide();
            }
        }

        private void MenuModoAAP_Click(object sender, EventArgs e)
        {
            MenuModoAAP.Checked = !MenuModoAAP.Checked;
            if (MenuModoAAP.Checked == true)
            {
                MenuModoAMC.Checked = false;
                MenuModoAMC.Enabled = false;
                panelModoAAP.Enabled = true;
                panelModoAAP.Location = new Point(0, 44);
                panelModoAAP.Visible = true;
            }

            if (MenuModoAAP.Checked == false)
            {
                MenuModoAMC.Enabled = true;
                panelModoAAP.Enabled = false;
                panelModoAAP.Visible = false;
                buttonActivarAAP.Enabled = true;
            }
        }

        private void buttonActivarAMC_Click(object sender, EventArgs e)
        {
            if (comboBoxAMCMode.SelectedIndex == 0 & radioButtonAMCInit.Checked == true)
            {
                string amcCortoIniciar = "1I";
                string limbuf = "LM";
                EnviarOrden(limbuf);
                EnviarOrden(amcCortoIniciar);
            }
            if (comboBoxAMCMode.SelectedIndex == 0 & radioButtonAMCContinue.Checked == true)
            {
                string amcCortoSeguir = "1G";
                EnviarOrden(amcCortoSeguir);
            }
            if (comboBoxAMCMode.SelectedIndex == 1 & radioButtonAMCInit.Checked == true)
            {
                string amcLargoIniciar = "2I";
                string limbuf = "LM";
                EnviarOrden(limbuf);
                EnviarOrden(amcLargoIniciar);
            }
            if (comboBoxAMCMode.SelectedIndex == 1 & radioButtonAMCContinue.Checked == true)
            {
                string amcLargoSeguir = "2G";
                EnviarOrden(amcLargoSeguir);
            }
            buttonActivarAMC.Enabled = false;
        }

        private void buttonActivarAAP_Click(object sender, EventArgs e)
        {
            if (comboBoxModoAAP.SelectedIndex == 0 & radioButtonAAPInit.Checked == true)
            {
                string aapIniciar = "0I";
                string limbuf = "LP";
                EnviarOrden(limbuf);
                EnviarOrden(aapIniciar);
            }
            if (comboBoxModoAAP.SelectedIndex == 0 & radioButtonAAPContinue.Checked == true)
            {
                string aapSeguir = "0G";
                EnviarOrden(aapSeguir);
            }
            buttonActivarAAP.Enabled = false;
        }

        private void buttonEnviarControlInt_Click(object sender, EventArgs e)
        {
            if (radioButtonControlIntAct.Checked == true)
            {
                string activarMedAMC = "CMA";
                EnviarOrden(activarMedAMC);
                buttonActivarAMC.Enabled = true;
            }
            if (radioButtonControlIntDesact.Checked == true)
            {
                string desactivarMedAMC = "CMD";
                EnviarOrden(desactivarMedAMC);
                buttonActivarAMC.Enabled = false;
            }
        }

        private void buttonEnviarComandoIntAAP_Click(object sender, EventArgs e)
        {
            if (radioButtonControlIntAAPAct.Checked == true)
            {
                            }
            if (radioButtonControlIntAAPDesact.Checked == true)
            {
                
            }
        }

        private void buttonLimpiarBancoAMC_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("La limpieza del banco de datos eliminará cualquier dato no guardado"
                + Environment.NewLine + "Está seguro de ejecutar la limpieza del banco de datos AMC?",
                "Precaución - Posible pérdida de Información", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string limbufamc = "LM";
                EnviarOrden(limbufamc);
                return;
            }
            else return;
        }

        private void buttonLimpiarBancoAAP_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("La limpieza del banco de datos eliminará cualquier dato no guardado"
                + Environment.NewLine + "Está seguro de ejecutar la limpieza del banco de datos AAP?",
                "Precaución - Posible pérdida de Información", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string limbufaap = "LP";
                EnviarOrden(limbufaap);
                return;
            }
            else return;
        }

        public void instanciarPuertoSerial()
        {
            string archivoAMC = "currentAMC_Dev" + amcID.ToString() + ".data";
            string archivoAAP = "currentAAP_Dev" + amcID.ToString() + ".data";

            if (MenuModoAMC.Checked == true)
            {
                byte[] buflargo = new byte[10] { 0x45, 0x4D, 0x30, 0x30, 0x30, 0x30, 0x30, 0x37, 0x36, 0x39 };
                EnviarOrdenByteEsperarRespuesta(buflargo);
                serialPortMain.DataReceived += new SerialDataReceivedEventHandler(serialPortMain_BuffAMCReceived);
                //serialPortMain.Close();
                
            }
            if (MenuModoAAP.Checked == true)
            {
                string bufaap = "EP";
                EnviarOrdenEsperarRespuesta(bufaap);
                serialPortMain.DataReceived += new SerialDataReceivedEventHandler(serialPortMain_BuffAAPReceived);
                //serialPortMain.Close();
                
            }
        }


        private void buttonPonerLimites_Click(object sender, EventArgs e)
        {
            byte liminferior = (byte)numericUpDownLimInf.Value;
            byte limsuperior = (byte)numericUpDownLimSup.Value;
            byte[] comventana = new byte[6] { 0x56, 0x52, 0x30, 0x30, liminferior, limsuperior};
            InicializarPuerto(serialPortMain);
            string inicomando = "[";
            serialPortMain.Write(inicomando);
            for (int i = 0; i < comventana.Length; i++)
            {
                byte[] chain = new byte[1] { comventana[i] };
                serialPortMain.Write(chain, 0, chain.Length);
                System.Threading.Thread.Sleep(300);
                
            }
            string fincr = "\r";
            serialPortMain.Write(fincr);
            string verventana = "VE";
            EnviarOrdenEsperarRespuesta(verventana);
            serialPortMain.DataReceived +=new SerialDataReceivedEventHandler(serialPortMain_LimsReceived);
                        
        }

        void serialPortMain_LimsReceived(object sender, SerialDataReceivedEventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            int numdatosEntrada;
            numdatosEntrada = serialPortMain.BytesToRead - 1;
            //MessageBox.Show("Tengo para leer estos datos: " + numdatosEntrada);
            Byte[] datoLims = new Byte[numdatosEntrada];
            serialPortMain.ReadByte();
            serialPortMain.Read(datoLims, 0, numdatosEntrada);
            //string respuestaLims = BitConverter.ToString(datoLims).Replace("-", " ");
            //MessageBox.Show("Toma tus datos:" + respuestaLims);
            byte[] limsupbyte = BitConverter.GetBytes(datoLims[0]);
            byte[] liminfbyte = BitConverter.GetBytes(datoLims[1]);
            liminf = BitConverter.ToInt16(limsupbyte, 0);
            limsup = BitConverter.ToInt16(liminfbyte, 0);
            ActualiceLimites();
            serialPortMain.DataReceived -=new SerialDataReceivedEventHandler(serialPortMain_LimsReceived);
        }

        private void ActualiceLimites()
        {
            this.Invoke(new EventHandler(DisplayAAPLims));
        }

        private void DisplayAAPLims(object sender, EventArgs e)
        {
            labelLimInfValue.Text = liminf.ToString();
            labelLimSupValue.Text = limsup.ToString();
        }

        void serialPortMain_BuffAMCReceived(object sender, SerialDataReceivedEventArgs e)
        
        {
            int numdatosEntrada;
            numdatosEntrada = serialPortMain.BytesToRead;
            MessageBox.Show("Tengo para leer estos datos: "+ numdatosEntrada);
            Byte[] datoBuffAMC = new Byte[numdatosEntrada];
            serialPortMain.Read(datoBuffAMC, 0, numdatosEntrada);
            string respuestaBuff = System.Text.Encoding.UTF8.GetString(datoBuffAMC);
            MessageBox.Show("Toma tus datos:" + respuestaBuff);
        }

        public void serialPortMain_BuffAAPReceived(object sender, SerialDataReceivedEventArgs e)
        {
            System.Threading.Thread.Sleep(6000);
            int numdatosBuferEntrada;
            numdatosBuferEntrada = serialPortMain.BytesToRead;
            MessageBox.Show("Tengo para leer estos datos: " + numdatosBuferEntrada);
            Byte[] datoBuffAAP = new Byte[770];
            long[] datoPulsosBufAAP = new long[256];
            serialPortMain.Read(datoBuffAAP, 0, numdatosBuferEntrada);
            int i = 0;
            int j = 0;
            Array.Clear(datoPulsosBufAAP, 0, datoPulsosBufAAP.Length);
            for (i = 1, j = 0; i < (256 * 3); j++, i += 3)
            {
                long dato1n = Int64.Parse(datoBuffAAP[i].ToString(), NumberStyles.HexNumber);
                long dato2n = Int64.Parse(datoBuffAAP[i + 1].ToString(), NumberStyles.HexNumber);
                long dato3n = Int64.Parse(datoBuffAAP[i + 2].ToString(), NumberStyles.HexNumber);
                datoPulsosBufAAP[j] = dato1n + 256 * dato2n + 65536 * dato3n;
                dato1n = 0;
                dato2n = 0;
                dato3n = 0;
            }
            string respuestaBuff = BitConverter.ToString(datoBuffAAP).Replace("-", " ");
            string arrayLong = String.Join(",", datoPulsosBufAAP.Select(p=>p.ToString()).ToArray());
            //MessageBox.Show("Toma tus datos:" + respuestaBuff);
            //MessageBox.Show("Vector de datos:" + arrayLong);
            string archivoAAPdraw = "currentAAP_Dev" + amcID.ToString() + ".data";
            StreamWriter espeaap = new System.IO.StreamWriter(archivoAAPdraw);
            for (i = 1; i < datoPulsosBufAAP.Length; i++)
            {
                espeaap.WriteLine(datoPulsosBufAAP[i].ToString());
            }
            espeaap.Close();
            serialPortMain.DataReceived -= new SerialDataReceivedEventHandler(serialPortMain_BuffAAPReceived);
            //serialPortMain.Close();
            CreateGraphAAP(zedGraphControlMain);
            ActualiceGraficoAAP();
            
        }

        private void ActualiceGraficoAAP()
        {
            this.Invoke(new EventHandler(DisplayAAPGraph));
        }

        private void DisplayAAPGraph(object sender, EventArgs e)
        {
            zedGraphControlMain.Location = new Point(227, 44);
            // Leave a small margin around the outside of the control
            zedGraphControlMain.Size = new Size(ClientRectangle.Width - 250,
                                    ClientRectangle.Height - 100);
        }

        private void buttonLeerEspecAMC_Click(object sender, EventArgs e)
        {
            instanciarPuertoSerial();
            //CreateGraph(zedGraphControlMain);
            //SetSize();
            /*while (checkBoxRefreshAMC.Checked == true)
            {
                refreshTimer.Interval = (double)1000 * (double)numericUpDownAMCRate.Value;
                refreshTimer.Start();
                refreshTimer.AutoReset = true; 
                refreshTimer.Elapsed += new ElapsedEventHandler(refreshTimer_Elapsed);
            }
             */
        }

        private void refreshTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            instanciarPuertoSerial();
            zedGraphControlMain.Refresh();
            CreateGraphAAP(zedGraphControlMain);
            ActualiceGraficoAAP();
        }

               
        private void buttonLeerDatosAAP_Click(object sender, EventArgs e)
        {
            instanciarPuertoSerial();
        }


        private void FormMain_Resize(object sender, EventArgs e)
        {
            ActualiceGraficoAAP();
        }

        /*
        private void SetSize()
        {
            zedGraphControlMain.Location = new Point(227, 44);
            // Leave a small margin around the outside of the control
            zedGraphControlMain.Size = new Size(ClientRectangle.Width - 250,
                                    ClientRectangle.Height - 100);
        }
        */

        private void CreateGraphAAP(ZedGraphControl graphMain)
        {
            // get a reference to the GraphPane
            GraphPane PaneAAP = graphMain.GraphPane;
            // Titulos y ejes
            PaneAAP.Title.Text = "Espectro de Pulsos en adquisición";
            //PaneAAP.Title.FontSpec.Family = 
            PaneAAP.XAxis.Title.Text = "Número de Canal";
            PaneAAP.YAxis.Title.Text = "Cuentas de Canal";
            PaneAAP.XAxis.MajorGrid.IsVisible = true;
            PaneAAP.YAxis.MajorGrid.IsVisible = true;
            PaneAAP.XAxis.MajorGrid.Color = Color.DarkGray;
            PaneAAP.YAxis.MajorGrid.Color = Color.DarkGray;
            PaneAAP.XAxis.MinorGrid.IsVisible = true;
            PaneAAP.YAxis.MinorGrid.IsVisible = true;
            PaneAAP.XAxis.MinorGrid.Color = Color.LightGray;
            PaneAAP.YAxis.MinorGrid.Color = Color.LightGray;
            PaneAAP.Legend.Position = ZedGraph.LegendPos.Bottom;
            PaneAAP.XAxis.Scale.MaxGrace = 0.01;
            PaneAAP.XAxis.Scale.MinGrace = 0.01;
            PaneAAP.YAxis.Scale.MaxGrace = 0.05;
            PaneAAP.YAxis.Scale.MinGrace = 0.05;
            // Make up some data arrays based on the Sine function
            int x, y1;
            int i = 1;
            string cuenta;
            string archivoAAPdraw = "currentAAP_Dev" + amcID.ToString() + ".data";
            string aaplotfile_current = archivoAAPdraw + "plot";
            File.Copy(archivoAAPdraw, aaplotfile_current, true);
            StreamReader archivoActualAAP = new StreamReader(aaplotfile_current);
            PointPairList list1 = new PointPairList();
            
            while ((cuenta = archivoActualAAP.ReadLine()) != null)
            {
                x = i;
                y1 = int.Parse(cuenta);
                list1.Add(x, y1);
                y1++;
                i++;
            }

            archivoActualAAP.Close();
            // Agregar un handler para cuando se detecte que el archivo cambia, y asi ejecutar de nuevo 
            // la generacion de la gráfica.
            // Generar la curva
            PaneAAP.CurveList.Clear();

            LineItem myCurve = PaneAAP.AddCurve("Espectro", list1, Color.DarkBlue, SymbolType.Diamond);
            
            myCurve.Symbol.Size = 3.0F;
            myCurve.Symbol.Fill = new Fill(Color.DarkRed);
            myCurve.Line.IsVisible = true;

            // Tell ZedGraph to refigure the
            // axes since the data have changed
            graphMain.AxisChange();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            InicializarPuerto(serialPortMain);
            MenuModoAAP.Enabled = false;
            MenuModoAMC.Enabled = false;
        }

        private void radioButtonControlIntAAPAct_CheckedChanged(object sender, EventArgs e)
        {
            string activarMedAAP = "CPA";
            EnviarOrden(activarMedAAP);

        }

        private void radioButtonControlIntAAPDesact_CheckedChanged(object sender, EventArgs e)
        {
            string desactivarMedAAP = "CPD";
            EnviarOrden(desactivarMedAAP);
        }

        

        
    }
}
