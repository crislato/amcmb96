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
        /*Variables de configuración del puerto, guardadas en principio por el programa.
          DTR y RTS deben ir a Enable TRUE (Control por hardware)       
        */
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
        //Envío de un comando. Cadena de inicialización empieza con "[". 
        //El fin de comando se considera con el terminador \r. El \n es agregado por el SO.
        //En la rutina se inicializa el puerto, se envía el iniciador, la cadena argumento y el terminador.
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
        //Envío de un comando. Cadena de inicialización empieza con "[". 
        //El fin de comando se considera con el terminador \r. El \n es agregado por el SO.
        //En la rutina se inicializa el puerto, se envía el iniciador, la cadena argumento y el terminador.
        //En esta rutina se espera respuesta por parte del AMCMB96, por eso no se cierra el puerto.
        //Si el puerto no existe se presenta una excepción
        {
            InicializarPuerto(serialPortMain);
            string inicomando = "[";
            string fincr = "\r";
            serialPortMain.Write(inicomando);
            serialPortMain.Write(comando);
            serialPortMain.Write(fincr);
                      
        }

        public void EnviarOrdenByteEsperarRespuesta(byte[] bytecomando)
        //Rutina para enviar comandos en formato byte (requisición de espectros)
        //El programa espera respuesta por parte del AMCMB96
        {
            InicializarPuerto(serialPortMain);
            string inicomando = "[";
            string fincr = "\r";
            serialPortMain.Write(inicomando);
            serialPortMain.Write(bytecomando, 0, bytecomando.Length);
            serialPortMain.Write(fincr);

        }

        public void EnviarOrdenByte(byte[] bytecomando)
        //Rutina para enviar comandos en formato byte (requisición de espectros)
        //El programa NO espera respuesta por parte del AMCMB96
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
        /*
         * Cuando se da click en el menú de chequear el ID del espectrómetro activo se procede
         * a enviar el comando "?", el cual debe esperar como respuesta el ID.
         * El handler espera la respuesta y crea los archivos de datos necesarios para la adquisición
         * de la información del espectrómetro y el guardado de sus parámetros de funcionamiento.
         * El Handler se activa al recibir el ID y luego es invocado para actualizar el mismo ID en 
         * el hilo correspondiente a las rutinas DisplayAMCid() y ActualiceID()
         */
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
        /*
         * Este es el handler que se activa al recibir el ID del espectrómetro. 
         * El dato es leído por la rutina y de inmediato se invoca el manejador del handler
         * contenido en ActualiceID(), el cual a su vez invoca a DisplayAMCid para actualizar 
         * el valor del ID que es visible al usuario.
         * El handler se desuscribe del evento de datos de puerto serial al terminar su ejecución.
         */
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
        //Pregunta de confirmación para salir del programa.
        {
            if (MessageBox.Show("Desea salir del programa?", "Salir", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void MenuCOM_Click(object sender, EventArgs e)
            //Opciones de comunicación. Se despliega el formulario de opciones.
        {
            serialPortMain.Close();
            FormCOMOptions opcionesComm = new FormCOMOptions();
            opcionesComm.Show();
        }

        private void MenuModoAMC_Click(object sender, EventArgs e)
            /*Rutina que inicia el despliegue gráfico del modo AMC.
             * Cuando se pone check en este ítem, se deshabilitan las opciones de modo AAP
             * y se hacen visibles los paneles y gráficos del modo AMC.
             * El modo gráfico más importante es el correspondiente a ZedGraph,
             * invocado en CreateGraphAMC() y ActualiceGraficoAMC()
             */
        {
            MenuModoAMC.Checked = !MenuModoAMC.Checked;
            if (MenuModoAMC.Checked == true)
            {
                MenuModoAAP.Checked = false;
                MenuModoAAP.Enabled = false;
                panelModoAMC.Enabled = true;
                panelModoAMC.Visible = true;
                CreateGraphAMC(zedGraphControlMainAMC);
                ActualiceGraficoAMC();
                //zedGraphControlMainAMC.Show();
                buttonActivarAMC.Enabled = true;
                buttonActivarAMC.Show();
                Properties.Settings.Default.ModoManejo = 1;
                Properties.Settings.Default.FrecuenciaBarrido = 10;
                Properties.Settings.Default.TiempoMuerto = 20;
                Properties.Settings.Default.Resolucion = 256;
                Properties.Settings.Default.MaxVelocidad = 8;
                Properties.Settings.Default.FactorEscala = 1;
                Properties.Settings.Default.SignoVelocidad = 0;
                Properties.Settings.Default.ModoAvance = Convert.ToChar("I");
                MessageBox.Show("ATENCIÓN:"
                + Environment.NewLine
                + "Si no modifica los parámetros de trabajo, se usarán los siguientes:" 
                + Environment.NewLine
                + Environment.NewLine + "Modo de manejo:" + Properties.Settings.Default.ModoManejo.ToString()
                + Environment.NewLine + "Frecuencia de barrido:" + Properties.Settings.Default.FrecuenciaBarrido.ToString() + " Hz"
                + Environment.NewLine + "Resolución:" + Properties.Settings.Default.Resolucion.ToString() + " Canales"
                + Environment.NewLine + "Factor de escala:" + Properties.Settings.Default.FactorEscala.ToString()
                + Environment.NewLine + "Signo de velocidad:" + Properties.Settings.Default.SignoVelocidad.ToString()
                + Environment.NewLine + "Modo de avance:" + Properties.Settings.Default.ModoAvance.ToString()
                );
                zedGraphControlMainAMC.Show();

            }
            if (MenuModoAMC.Checked == false)
            {
                MenuModoAAP.Enabled = true;
                panelModoAMC.Enabled = false;
                panelModoAMC.Visible = false;
                //buttonActivarAMC.Enabled = true;
                zedGraphControlMainAMC.Hide();
            }
        }

        public struct Parametros_AMC
        {
            public char num_identif;
            public double frec_barrido;
            public double tiempo_muerto;
            public char avance_canal;
            public char fin_canal;
            public int barridos;
            public double max_velocidad;
            public int signo_velocidad;
            public int resolucion;
            public int modo_manejo; //1:Triangular; 2:DienteSierra; 3:Sinusoidal
        }

        public struct Variables_Manejo_AMC
        {
            public int modo;
            public char avance;
            public int longitud;
            public int canales;
            public int tiempo_muestreo;
            public int mb_barridos;
            public double numero_ti_muestreo;
        }

        public void InicieAMC()
        {
            double z, z1;
            int i, i1, i2, j, k, n;
            int maxresol_1 = 1024;
            int maxresol_2 = 512;
            int fact_vel = Properties.Settings.Default.FactorEscala;
            int[] senal = new int[1024];
            double[] senaldouble = new double[1024];
            double frecu = 4915200;
            double pi = 3.141592;
            Parametros_AMC prms_amc;
            prms_amc.modo_manejo = Properties.Settings.Default.ModoManejo;
            prms_amc.frec_barrido = Properties.Settings.Default.FrecuenciaBarrido;
            prms_amc.tiempo_muerto = Properties.Settings.Default.TiempoMuerto;
            prms_amc.resolucion = Properties.Settings.Default.Resolucion;
            prms_amc.max_velocidad = Properties.Settings.Default.MaxVelocidad;
            prms_amc.signo_velocidad = Properties.Settings.Default.SignoVelocidad;
            prms_amc.avance_canal = Properties.Settings.Default.ModoAvance;

            Variables_Manejo_AMC vrmanejo = default(Variables_Manejo_AMC); //poner a default, sino aparece como unassigned
            vrmanejo.avance = prms_amc.avance_canal;
            switch (prms_amc.modo_manejo)
            {
                case 1:
                    k = maxresol_1 / prms_amc.resolucion; //esto es el quotient res 256 => k=4; 512 => k=2, 1024 => k=1
                    j = (maxresol_1 - (k * prms_amc.resolucion)) / 2; //esto es el quotient j (siempre es 0)
                    vrmanejo.canales = 2 * prms_amc.resolucion;
                    vrmanejo.longitud = 3 * vrmanejo.canales;
                    senal = new int[1024];
                    for (i = 0; i < prms_amc.resolucion; i++)
                    {
                        senal[i] = j;
                        j += k; //256 => 0,4,8,12... 512 => 0,2,4,6,8... 1024 => 0,1,2,3,4....
                    }
                    fact_vel = Properties.Settings.Default.FactorEscala;
                    switch (fact_vel)
                    {
                        case 1:
                            j = 0;
                            break;
                        case 2:
                            j = 256;
                            break;
                        case 4:
                            j = 384;
                            break;
                        default:
                            j = 0;
                            break;
                    }

                    for (i = 0; i < prms_amc.resolucion; i++)
                    {
                        //Rampa dividida entre 4 para res 256=>0,1,2... res 512=>0,0.5,1,1.5... res 1024=>0,0.25,0.5,0.75...
                        int xquot = senal[i] / fact_vel;
                        //Para fact_vel = 1 Rampa es res 256=>0,1,2... res 512=>0,0.5,1,1.5... res 1024=>0,0.25,0.5,0.75...
                        //Para fact_vel = 2 Rampa es res 256=>256,257,258... res 512=>256,256.5,257,257.5... res 1024=>256,256.25,256.5,256.75...
                        //Para fact_vel = 4 Rampa es res 256=>384,385,386... res 512=>384,384.5,385,385.5... res 1024=>384,384.25,384.5,384.75...
                        senal[i] = xquot + j;
                        //simetria de la señal. senal[255] == senal[1], senal[254] == senal[2], senal[253] == senal[3]....
                        senal[vrmanejo.canales - 1 - i] = senal[i];
                    }
                    z = frecu / (vrmanejo.canales * prms_amc.frec_barrido);
                    vrmanejo.tiempo_muestreo = CalculaTiempos(z, vrmanejo, out n);
                    vrmanejo.numero_ti_muestreo = n;
                    if (vrmanejo.numero_ti_muestreo == 1) vrmanejo.modo = 1; //buffer corto
                    else vrmanejo.modo = 2; //buffer largo
                    break;
                /////////CASO DIENTE DE SIERRA/////////
                case 2:
                    k = maxresol_1 / prms_amc.resolucion; //esto es el quotient
                    j = (maxresol_1 - (k * prms_amc.resolucion)) / 2; //esto es el quotient j (siempre es 0)
                    vrmanejo.canales = (int)(prms_amc.resolucion*(1 + prms_amc.tiempo_muerto/100));
                    i1 = vrmanejo.canales - prms_amc.resolucion;
                    vrmanejo.longitud = 3 * vrmanejo.canales;
                    senal = new int[1024];
                    for (i = 0; i < prms_amc.resolucion; i++)
                    {
                        senal[i] = j+(i*k); 
                    }
                    k = (prms_amc.resolucion - 1) * (k / (i1 + 1));
                    for (i = 0; i < i1; i++)
                    {
                        senal[vrmanejo.canales - 1 - i]  = j + (k * i);
                    }
                    if (prms_amc.signo_velocidad == -1)
                    {
                        for (i = 0; i < vrmanejo.canales; i++)
                        {
                            senal[i] = maxresol_1 - 1 - senal[i];
                        }
                    }
                    switch (fact_vel)
                    {
                        case 1:
                            j = 0;
                            break;
                        case 2:
                            j = 256;
                            break;
                        case 4:
                            j = 384;
                            break;
                        default:
                            j = 0;
                            break;
                    }
                    for (i = 0; i < vrmanejo.canales; i++)
                    {
                        int xquot = senal[i] / fact_vel;
                        senal[i] = xquot + j;
                    }
                    z = frecu / (vrmanejo.canales * prms_amc.frec_barrido);
                    vrmanejo.tiempo_muestreo = CalculaTiempos(z, vrmanejo, out n);
                    vrmanejo.numero_ti_muestreo = n;
                    if (vrmanejo.numero_ti_muestreo == 1) vrmanejo.modo = 1; //buffer corto
                    else vrmanejo.modo = 2; //buffer largo
                    break;

                    ///////////////CASO SINUSOIDAL////////////////
                case 3:
                    z1 = pi / prms_amc.resolucion;
                    vrmanejo.canales = 2 * prms_amc.resolucion;
                    i1 = vrmanejo.canales / 4;
                    vrmanejo.longitud = 3 * vrmanejo.canales;
                    for (i = 0; i < prms_amc.resolucion; i++)
                    {
                        senaldouble[i] = 511*(1.0 - Math.Cos(z1*(i+0.5))); 
                    }
                    MessageBox.Show("La señal es:" + string.Join(",", senaldouble));
                    switch (fact_vel)
                    {
                        case 1:
                            j = 0;
                            break;
                        case 2:
                            j = 256;
                            break;
                        case 4:
                            j = 384;
                            break;
                        default:
                            j = 0;
                            break;
                    }
                    for (i = 0; i < prms_amc.resolucion; i++)
                    {
                        double xquot = (double)senaldouble[i] / fact_vel;
                        senaldouble[i] = xquot + j;
                        senaldouble[vrmanejo.canales - 1 - i]  = senaldouble[i];
                    }
                    z = frecu / (vrmanejo.canales * prms_amc.frec_barrido);
                    vrmanejo.tiempo_muestreo = CalculaTiempos(z, vrmanejo, out n);
                    vrmanejo.numero_ti_muestreo = n;
                    if (vrmanejo.numero_ti_muestreo == 1) vrmanejo.modo = 1; //buffer corto
                    else vrmanejo.modo = 2; //buffer largo
                    break;
            }
            MessageBox.Show("Voy a enviar los siguientes datos:"
                + Environment.NewLine + vrmanejo.avance.ToString()
                + Environment.NewLine + vrmanejo.longitud.ToString()
                + Environment.NewLine + vrmanejo.canales.ToString()
                + Environment.NewLine + vrmanejo.mb_barridos.ToString()
                + Environment.NewLine + vrmanejo.tiempo_muestreo.ToString()
                + Environment.NewLine + vrmanejo.numero_ti_muestreo.ToString()
                );

            EnviarDatosOperacionAMC(vrmanejo);
            System.Threading.Thread.Sleep(1000);
            if (prms_amc.modo_manejo == 1 || prms_amc.modo_manejo == 2)
            {
                EnviarSenal(vrmanejo, senal);
            }
            else EnviarSenalDouble(vrmanejo, senaldouble);

            System.Threading.Thread.Sleep(5000);
            string modo_oper = vrmanejo.modo.ToString();
            string amcIniciar = modo_oper + "I";
            //string amcIniciar = "1I";
            MessageBox.Show("Comando enviado para iniciar: " + amcIniciar);
            EnviarOrden(amcIniciar);
            MessageBox.Show("Flag iniciar");
            serialPortMain.DataReceived += new SerialDataReceivedEventHandler(serialPortMain_ConfirmParamsReceived);
            //Byte[] confirmacion = new Byte[1];
            //serialPortMain.Read(confirmacion, 0, 1);
            
            
        }

        public void EnviarDatosOperacionAMC(Variables_Manejo_AMC manejo)
        {
            manejo.mb_barridos = 0;
            byte[] avance = BitConverter.GetBytes(manejo.avance);
            byte[] longi = BitConverter.GetBytes(Convert.ToInt16(manejo.longitud));
            byte[] canales = BitConverter.GetBytes(Convert.ToInt16(manejo.canales));
            byte[] barridos = BitConverter.GetBytes(Convert.ToInt16(manejo.mb_barridos));
            byte[] tiempo_muestreo = BitConverter.GetBytes(Convert.ToInt16(manejo.tiempo_muestreo));
            byte[] numero_ti_muestreo = BitConverter.GetBytes(Convert.ToInt16(manejo.numero_ti_muestreo)); 
            //Estructura del comando = 0x44 (D), 0x00, 0x49 (I), 0x00, 0x00, 0x00 (3 campos de 1 byte a 0), 0x00, 0x00 (campo 2 bytes a 0), longitud (2 bytes), 
            //canales (2 bytes), barridos (2 bytes), tiempo_muestreo (2 bytes / z), numero_ti_muestreo (2 bytes) 
            //byte[] datos_oper_byte = new byte[18] { 0x44, 0x00, 0x49, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x06, 0x00, 0x02, 0x00, 0x00, 0xC0, 0x03, 0x01, 0x00 };
            byte[] datos_oper_byte = new byte[18] { 0x44, 0x00, avance[0], 0x00, 0x00, 0x00, 0x00, 0x00, longi[0], longi[1], canales[0], canales[1], barridos[0], barridos[1], tiempo_muestreo[0], tiempo_muestreo[1], numero_ti_muestreo[0], numero_ti_muestreo[1] };
            InicializarPuerto(serialPortMain);
            string inicomando = "[";
            serialPortMain.Write(inicomando);
            for (int i = 0; i < datos_oper_byte.Length; i++)
            {
                byte[] chain = new byte[1] { datos_oper_byte[i] };
                serialPortMain.Write(chain, 0, chain.Length);
                System.Threading.Thread.Sleep(300);

            }
            string fincr = "\r";
            serialPortMain.Write(fincr);
            MessageBox.Show("Flag envio datos");
            serialPortMain.DataReceived += new SerialDataReceivedEventHandler(serialPortMain_ConfirmParamsReceived);
        }

        public void EnviarSenal(Variables_Manejo_AMC manejo, int[] senal)
        {
            int i, j;
            int xquot, xrem;
            int[] senalalta = new int[1024];
            int[] senalbaja = new int[1024];
            int chks = 0;
            string alta, baja;
            byte[] altabyte, bajabyte;

            for (i = 0; i < manejo.canales; i++)
            {
                xquot = Math.DivRem(senal[i], 4, out xrem);
                senalalta[i] = xquot;
                chks += senalalta[i];
                senalbaja[i] = xrem;
                chks += senalbaja[i];
                //Ver operación de CHKS (sumas de chequeo, bitwise comparison chks = ~chks +1)
            }
            chks += chks;
            chks = (~chks) + 1;

            instanciarRecepcionBDatos(manejo);
            System.Threading.Thread.Sleep(2000);
            //InicializarPuerto(serialPortMain);
            
            for (i = 0; i < manejo.canales; i++)
            {
                alta = senalalta[i].ToString();
                baja = senalbaja[i].ToString();
                altabyte = new byte[] { Convert.ToByte(senalalta[i]) };
                bajabyte = new byte[] { Convert.ToByte(senalbaja[i]) };

                serialPortMain.Write(altabyte, 0, 1);
                serialPortMain.Write(bajabyte, 0 ,1);
                 
                
            }
            //MessageBox.Show("Escribí:" + string.Join(",", senalalta));
            //MessageBox.Show("Escribí:" + string.Join(",", senalbaja));
            //byte[] chksbyte = new byte[] { Convert.ToByte(chks)};
            byte[] chkszero = new byte[1] { 0x00 };
            serialPortMain.Write(chkszero,0,1);
            //serialPortMain.Close();
            //serialPortMain.ReadByte();
        }

        public void EnviarSenalDouble(Variables_Manejo_AMC manejo, double[] senaldouble)
        {
            int i, j;
            int xquot;
            double xrem;
            int[] senalalta = new int[1024];
            double[] senalbaja = new double[1024];
            int chks = 0;
            string alta, baja;
            byte[] altabyte, bajabyte;

            for (i = 0; i < manejo.canales; i++)
            {
                xquot = Convert.ToInt32(senaldouble[i]) / 4;
                senalalta[i] = xquot;
                chks += senalalta[i];
                xrem = senaldouble[i] % 4;
                senalbaja[i] = xrem;
                chks += Convert.ToInt32(senalbaja[i]);
                //Ver operación de CHKS (sumas de chequeo, bitwise comparison chks = ~chks +1)
            }
            //MessageBox.Show("La señal es:" + string.Join(",", senalalta));
            //MessageBox.Show("Escribí:" + string.Join(",", senalbaja));
            
            chks += chks;
            chks = (~chks) + 1;

            instanciarRecepcionBDatos(manejo);
            System.Threading.Thread.Sleep(2000);
            //InicializarPuerto(serialPortMain);

            for (i = 0; i < manejo.canales; i++)
            {
                alta = senalalta[i].ToString();
                baja = senalbaja[i].ToString();
                altabyte = new byte[] { Convert.ToByte(senalalta[i]) };
                bajabyte = new byte[] { Convert.ToByte(senalbaja[i]) };

                serialPortMain.Write(altabyte, 0, 1);
                serialPortMain.Write(bajabyte, 0, 1);


            }
            //MessageBox.Show("Valor CHKS Final:" + chks.ToString());
            byte[] chkszero = new byte[1] { 0x00 };
            serialPortMain.Write(chkszero, 0, 1);
            //serialPortMain.Close();
            //serialPortMain.ReadByte();
        }

        public int CalculaTiempos( double zz, Variables_Manejo_AMC manejo, out int numerotimuestreo)
        {
            double origvalue = zz / (double)65536;
            double intpart = Math.Floor(origvalue);
            manejo.numero_ti_muestreo = 1 + intpart;
            numerotimuestreo = (int)manejo.numero_ti_muestreo;
            if ((zz / (double)manejo.numero_ti_muestreo) > 65536)
            {
        double origvalue2 = (zz / (double)manejo.numero_ti_muestreo) - 65536;
                manejo.tiempo_muestreo = (int)Math.Floor(origvalue2);
                //MessageBox.Show("Bucle 1 CalculaTiempo, tiempo_muestreo:" + manejo.tiempo_muestreo);
                return manejo.tiempo_muestreo;
            }
            else
            {
                double origvalue2 = (zz / (double)manejo.numero_ti_muestreo); //10Hz => 960 /1 = 960
                manejo.tiempo_muestreo = (int)Math.Floor(origvalue2);
                //MessageBox.Show("Bucle 2 CalculaTiempo, tiempo_muestreo:" + manejo.tiempo_muestreo);
                return manejo.tiempo_muestreo;
            }
        }

        private void MenuModoAAP_Click(object sender, EventArgs e)
        /*Rutina que inicia el despliegue gráfico del modo AAP.
         * Cuando se pone check en este ítem, se deshabilitan las opciones de modo AMC
         * y se hacen visibles los paneles y gráficos del modo AAP.
         * El modo gráfico más importante es el correspondiente a ZedGraph,
         * invocado en CreateGraphAMC() y ActualiceGraficoAMC()
         */
        {
            MenuModoAAP.Checked = !MenuModoAAP.Checked;
            if (MenuModoAAP.Checked == true)
            {
                MenuModoAMC.Checked = false;
                MenuModoAMC.Enabled = false;
                panelModoAAP.Enabled = true;
                panelModoAAP.Location = new Point(0, 44);
                panelModoAAP.Visible = true;
                CreateGraphAAP(graphMain);
                ActualiceGraficoAAP();
                graphMain.Show();
            }

            if (MenuModoAAP.Checked == false)
            {
                MenuModoAMC.Enabled = true;
                panelModoAAP.Enabled = false;
                panelModoAAP.Visible = false;
                buttonActivarAAP.Enabled = true;
                graphMain.Hide();
            }
        }

        private void buttonActivarAMC_Click(object sender, EventArgs e)
        {
            if (radioButtonAMCInit.Checked == true)
            {
                string limbuf = "LM";
                EnviarOrden(limbuf);
                InicieAMC();
                //InicializarPuerto(serialPortMain);
                //byte[] control_interrumpir = new byte[3] { 0x43, 0x4D, 0x41 };
                //string inicomando = "[";
                //serialPortMain.Write(inicomando);
                //for (int i = 0; i < control_interrumpir.Length; i++)
                //{
                //    byte[] chain = new byte[1] { control_interrumpir[i] };
                //    serialPortMain.Write(chain, 0, chain.Length);
                //    System.Threading.Thread.Sleep(50);

                //}
                //string fincr = "\r";
                //serialPortMain.Write(fincr);
                
                
                
            }
            if (radioButtonAMCContinue.Checked == true)
            {
                string amcCortoSeguir = "1G";
                EnviarOrden(amcCortoSeguir);
            }

/*            if (comboBoxAMCMode.SelectedIndex == 0 & radioButtonAMCInit.Checked == true)
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
 */
            buttonActivarAMC.Enabled = true;
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
            buttonActivarAAP.Enabled = true;
        }

        //Comando de control de interrupción, rutina que en este momento no hace nada
        //debe ponerse un botón más amigable y/o eliminar para poner una forma más entendible
        //de pausa y reanudación de las mediciones 
        private void buttonEnviarComandoIntAAP_Click(object sender, EventArgs e)
        {
            if (radioButtonControlIntAAPAct.Checked == true)
            {
                            }
            if (radioButtonControlIntAAPDesact.Checked == true)
            {
                
            }
        }

        //Limpieza de buffer. Esta rutina debe usarse con cuidado, escribe ceros en el banco de memoria.
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

        //Limpieza de buffer. Esta rutina debe usarse con cuidado, escribe ceros en el banco de memoria.
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
            /*
             * Si el menú de un modo está activo, se envía la orden para recibir el espectro
             * del respectivo modo. Los modos son excluyentes así que la rutina es segura.
             * Se envía la orden, se espera el buffer y con el evento de recepción de datos
             * se invocan los Handlers para procesar los buffers y escribirlos en los respectivos 
             * archivos.
             * Por el motivo anterior se declaran aquí los nombres de los archivos.
             */
        {
            string archivoAMC = "currentAMC_Dev" + amcID.ToString() + ".data";
            string archivoAAP = "currentAAP_Dev" + amcID.ToString() + ".data";

            if (MenuModoAMC.Checked == true)
            {
                InicializarPuerto(serialPortMain);
                byte[] control_interrumpir = new byte[3] { 0x43, 0x4D, 0x41 };
                string inicomando = "[";
                serialPortMain.Write(inicomando);
                for (int i = 0; i < control_interrumpir.Length; i++)
                {
                    byte[] chain = new byte[1] { control_interrumpir[i] };
                    serialPortMain.Write(chain, 0, chain.Length);
                    System.Threading.Thread.Sleep(300);

                }
                string fincr = "\r";
                serialPortMain.Write(fincr);
                byte[] bufamc = new byte[10] { 0x45, 0x4D, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x06 };
                //byte[] buflargo = new byte[11] { 0x45, 0x4D, 0x00, 0x00, 0x00, 0x00, 0x00, 0x31, 0x35, 0x33, 0x37 };
                serialPortMain.Write(inicomando);
                
                for (int i = 0; i < bufamc.Length; i++)
                {
                    byte[] chain = new byte[1] { bufamc[i] };
                    serialPortMain.Write(chain, 0, chain.Length);
                    System.Threading.Thread.Sleep(500);

                }
                serialPortMain.Write(fincr);
                //Envía [EM000001537 (1536/3 = 512 = N, y 3N + 1 = 1537)
                //Envía ( 0x45 (E), 0x4D (M), 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 (4 campos de 1 byte, uno de 2 bytes), 0x0601 (Longitud)
                //El handler serialPortMain_BuffAMCReceived maneja el retorno de los datos del espectro.
                //serialPortMain.Close();
                
                //EnviarOrdenByteEsperarRespuesta(buflargo);
                serialPortMain.DataReceived += new SerialDataReceivedEventHandler(serialPortMain_BuffAMCReceived);
                //System.Threading.Thread.Sleep(1000);
                //byte[] control_reanudar = new byte[3] { 0x43, 0x4D, 0x41 };
                //serialPortMain.Write(inicomando);
                //for (int i = 0; i < control_reanudar.Length; i++)
                //{
                //    byte[] chain = new byte[1] { control_reanudar[i] };
                //    serialPortMain.Write(chain, 0, chain.Length);
                //    System.Threading.Thread.Sleep(100);

                //}
                //serialPortMain.Write(fincr);
                
            }
            if (MenuModoAAP.Checked == true)
            {
                string bufaap = "EP";
                EnviarOrdenEsperarRespuesta(bufaap);
                serialPortMain.DataReceived += new SerialDataReceivedEventHandler(serialPortMain_BuffAAPReceived);
                //envia [EP (envío único del modo PHA/AAP) 
                //El handler serialPortMain_BuffAAPReceived maneja el retorno de los datos PHA/AAP. 
                //serialPortMain.Close();
                
            }
        }


        public void instanciarRecepcionBDatos(Variables_Manejo_AMC manejo)
        {
                int longitud = 2*manejo.canales + 1;
                string longi = longitud.ToString();
                string prepbdatos = "RS00000" + longi;
                MessageBox.Show("Comando enviado recepcion señal datos:" + prepbdatos);
                
                byte[] datos_senal_byte = new byte[10] { 0x52, 0x53, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x04};
                InicializarPuerto(serialPortMain);
                string inicomando = "[";
                serialPortMain.Write(inicomando);
                for (int i = 0; i < datos_senal_byte.Length; i++)
                {
                    byte[] chain = new byte[1] { datos_senal_byte[i] };
                    serialPortMain.Write(chain, 0, chain.Length);

                }
                string fincr = "\r";
                serialPortMain.Write(fincr);
                serialPortMain.DataReceived += new SerialDataReceivedEventHandler(serialPortMain_ConfirmBDReceived);
            //Recepción del banco de datos. 
            //Por ahora, se espera confirmación del banco y se pasan los datos recibidos por evento
            //hacia el handler serialPortMain_ConfirmBDReceived
                //serialPortMain.Close();

        }

        

        private void parametrosAMCMenuItem_Click(object sender, EventArgs e)
        {
            FormParamAMC parametrosAMC = new FormParamAMC();
            parametrosAMC.Show();
        }


        private void buttonPonerLimites_Click(object sender, EventArgs e)
        {
            byte liminferior = (byte)numericUpDownLimInf.Value;
            byte limsuperior = (byte)numericUpDownLimSup.Value;
            byte[] comventana = new byte[6] { 0x56, 0x52, 0x30, 0x30, liminferior, limsuperior};
            //Envía [VR00XY (X = valor byte del límite inferior, Y = valor byte límite superior
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
            //Envía [VE y espera la respuesta. El flujo de datos de respuesta es manejado por 
            //el handler serialPortMain_LimsReceived, que invoca una rutina para escribir los lims en la GUI.
                        
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
            //Desuscripción al hilo de eventos.
        }

        private void ActualiceLimites()
        {
            this.Invoke(new EventHandler(DisplayAAPLims));
        }

        private void DisplayAAPLims(object sender, EventArgs e)
        {
            labelLimInfValue.Text = liminf.ToString();
            labelLimSupValue.Text = limsup.ToString();
            //este handler es invocado por ActualiceLimites(), y es el que modifica los valores en la GUI
        }

        void serialPortMain_ConfirmParamsReceived(object sender, SerialDataReceivedEventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            int numdatosEntrada;
            numdatosEntrada = serialPortMain.BytesToRead;

            Byte[] datoOK = new Byte[numdatosEntrada];
            serialPortMain.Read(datoOK, 0, numdatosEntrada);
            string respuestaOK = System.Text.Encoding.UTF8.GetString(datoOK);
            //MessageBox.Show("Respuesta Params:" + respuestaOK);
            
            /*if (respuestaOK.Equals("!", StringComparison.Ordinal))
            {
                MessageBox.Show("Correcta la respuesta Params");
            }
            */
            serialPortMain.DataReceived -= new SerialDataReceivedEventHandler(serialPortMain_ConfirmParamsReceived);
        }

        void serialPortMain_ConfirmBDReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //System.Threading.Thread.Sleep(1000);
            int numdatosEntrada;
            numdatosEntrada = serialPortMain.BytesToRead;
            Byte[] datoOK = new Byte[numdatosEntrada];
            serialPortMain.Read(datoOK, 0, numdatosEntrada);
            string respuestaOK = System.Text.Encoding.UTF8.GetString(datoOK);
            //MessageBox.Show("Respuesta BDatos:" + respuestaOK);
            
            /*if (respuestaOK.Equals("!", StringComparison.Ordinal) || respuestaOK.Equals("@", StringComparison.Ordinal))
            {
                MessageBox.Show("Correcta la respuesta Bdatos");
            }
            */
            serialPortMain.DataReceived -= new SerialDataReceivedEventHandler(serialPortMain_ConfirmBDReceived);
        }

        void serialPortMain_BuffAMCReceived(object sender, SerialDataReceivedEventArgs e)
        
        {   
            System.Threading.Thread.Sleep(4000);
            int numdatosEntrada;
            int numdatosEntradabtr = serialPortMain.BytesToRead;
            numdatosEntrada = 1548;
            MessageBox.Show("Tengo para leer estos datos: "+ numdatosEntradabtr);
            Byte[] datoBuffAMCReal = new Byte[numdatosEntradabtr];
            serialPortMain.Read(datoBuffAMCReal, 0, numdatosEntradabtr);
            
            //Actualiza.
            string respuestaBuffAMCReal = System.Text.Encoding.UTF8.GetString(datoBuffAMCReal);
            MessageBox.Show("Toma tus datos:" + String.Join(",", respuestaBuffAMCReal));
            Byte[] datoBuffAMC = new Byte[1540];
            long[] datoEspecAMC = new long[512];
            //serialPortMain.Read(datoBuffAMC, 0, numdatosEntrada);
            int i = 0;
            int j = 0;
            Array.Clear(datoEspecAMC, 0, datoEspecAMC.Length);
            for (i = 2, j = 0; i < (512 * 3); j++, i += 3)
            {
                long dato1n = Int64.Parse(datoBuffAMCReal[i].ToString(), NumberStyles.HexNumber);
                long dato2n = Int64.Parse(datoBuffAMCReal[i + 1].ToString(), NumberStyles.HexNumber);
                long dato3n = Int64.Parse(datoBuffAMCReal[i + 2].ToString(), NumberStyles.HexNumber);
                datoEspecAMC[j] = dato1n + 256 * dato2n + 65536 * dato3n;
                dato1n = 0;
                dato2n = 0;
                dato3n = 0;
            }
            string respuestaBuffAMC = BitConverter.ToString(datoBuffAMCReal).Replace("-", " ");
            string arrayLong = String.Join(",", datoEspecAMC.Select(p => p.ToString()).ToArray());
            MessageBox.Show("Toma tus datos:" + respuestaBuffAMC);
            MessageBox.Show("Vector de datos:" + arrayLong);
            string archivoAMCdraw = "currentAMC_Dev" + amcID.ToString() + ".data";
            StreamWriter espeamc = new System.IO.StreamWriter(archivoAMCdraw);
            long numbarridos = datoEspecAMC[datoEspecAMC.Length - 1];
            for (i = 1; i < datoEspecAMC.Length - 1; i++)
            {
                espeamc.WriteLine(datoEspecAMC[i].ToString());
            }
            espeamc.WriteLine(datoEspecAMC[509].ToString());
            espeamc.WriteLine(datoEspecAMC[510].ToString());
            espeamc.Close();
            serialPortMain.DataReceived -= new SerialDataReceivedEventHandler(serialPortMain_BuffAMCReceived);
            
            //serialPortMain.Close();
            CreateGraphAMC(zedGraphControlMainAMC);
            ActualiceGraficoAMC();

             
        
        }

        /* Esta rutina procesa el evento de recepción de datos del modo PHA/AAP para luego invocar el 
         * modo gráfico.
         * Primero se recibe el buffer, se genera un vector de tipo long, 256 componentes. 
         * Se hace un bucle doble hasta el final del vector de datos original proveniente del AMCMB96,
         * que tiene 770 bytes (256*3 de datos + la confirmación "!"). De acuerdo con esta operación 
         * se genera el vector de pulsos del buffer AAP.
         * Se escriben los datos en el archivo del buffer, se invoca la desuscripción al evento y se 
         * llama la ejecución del despliegue de la gráfica del espectro.
         * 
         */ 
        public void serialPortMain_BuffAAPReceived(object sender, SerialDataReceivedEventArgs e)
        {
            System.Threading.Thread.Sleep(6000);
            int numdatosBuferEntrada;
            numdatosBuferEntrada = serialPortMain.BytesToRead;
            //MessageBox.Show("Tengo para leer estos datos: " + numdatosBuferEntrada);
            Byte[] datoBuffAAP = new Byte[numdatosBuferEntrada];//770

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
            CreateGraphAAP(graphMain);
            ActualiceGraficoAAP();
            
        }

        //Como es una actualización del componente gráfico, debe invocarse un EventHandler.
        private void ActualiceGraficoAAP()
        {
            this.Invoke(new EventHandler(DisplayAAPGraph));
        }

        //Este handler es invocado por ActualiceGraficoAAP.
        private void DisplayAAPGraph(object sender, EventArgs e)
        {
            graphMain.Location = new Point(227, 44);
            // Leave a small margin around the outside of the control
            graphMain.Size = new Size(ClientRectangle.Width - 250,
                                    ClientRectangle.Height - 100);
            //graphMain.Show();
        }

        //Como es una actualización del componente gráfico, debe invocarse un EventHandler.
        private void ActualiceGraficoAMC()
        {
            this.Invoke(new EventHandler(DisplayAMCGraph));
        }

        //Handler idéntico al de PHA/AAP, pero para AMC.
        private void DisplayAMCGraph(object sender, EventArgs e)
        {
            zedGraphControlMainAMC.Location = new Point(227, 44);
            // Leave a small margin around the outside of the control
            zedGraphControlMainAMC.Size = new Size(ClientRectangle.Width - 250,
                                    ClientRectangle.Height - 100);
        }

        private void buttonLeerEspecAMC_Click(object sender, EventArgs e)
        {
            instanciarPuertoSerial();
        }

        private void refreshTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            instanciarPuertoSerial();
            graphMain.Refresh();
            CreateGraphAAP(graphMain);
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

        private void CreateGraphAAP(ZedGraphControl graphMainAAP)
        {
            // get a reference to the GraphPane
            GraphPane PaneAAP = graphMainAAP.GraphPane;
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
            // Generar la curvaa
            PaneAAP.CurveList.Clear();

            LineItem myCurve = PaneAAP.AddCurve("Espectro", list1, Color.DarkBlue, SymbolType.Diamond);
            
            myCurve.Symbol.Size = 3.0F;
            myCurve.Symbol.Fill = new Fill(Color.DarkRed);
            myCurve.Line.IsVisible = true;

            // Tell ZedGraph to refigure the
            // axes since the data have changed
            graphMainAAP.AxisChange();
            graphMainAAP.Invalidate();
        }

        private void CreateGraphAMC(ZedGraphControl graphMainAMC)
        {
            // get a reference to the GraphPane
            GraphPane PaneAMC = graphMainAMC.GraphPane;
            // Titulos y ejes
            PaneAMC.Title.Text = "Espectro Mossbauer en adquisición";
            //PaneAAP.Title.FontSpec.Family = 
            PaneAMC.XAxis.Title.Text = "Número de Canal";
            PaneAMC.YAxis.Title.Text = "Cuentas de Canal";
            PaneAMC.XAxis.MajorGrid.IsVisible = true;
            PaneAMC.YAxis.MajorGrid.IsVisible = true;
            PaneAMC.XAxis.MajorGrid.Color = Color.DarkGray;
            PaneAMC.YAxis.MajorGrid.Color = Color.DarkGray;
            PaneAMC.XAxis.MinorGrid.IsVisible = true;
            PaneAMC.YAxis.MinorGrid.IsVisible = true;
            PaneAMC.XAxis.MinorGrid.Color = Color.LightGray;
            PaneAMC.YAxis.MinorGrid.Color = Color.LightGray;
            PaneAMC.Legend.Position = ZedGraph.LegendPos.Bottom;
            PaneAMC.XAxis.Scale.MaxGrace = 0.01;
            PaneAMC.XAxis.Scale.MinGrace = 0.01;
            PaneAMC.YAxis.Scale.MaxGrace = 0.05;
            PaneAMC.YAxis.Scale.MinGrace = 0.05;
            PaneAMC.XAxis.Scale.Max = 512;
            
            int x, y1;
            int i = 1;
            string cuenta;
            string archivoAMCdraw = "currentAMC_Dev" + amcID.ToString() + ".data";
            string amcplotfile_current = archivoAMCdraw + "plot";
            File.Copy(archivoAMCdraw, amcplotfile_current, true);
            StreamReader archivoActualAMC = new StreamReader(amcplotfile_current);
            PointPairList list1 = new PointPairList();
            while ((cuenta = archivoActualAMC.ReadLine()) != null)
            {
                x = i;
                y1 = int.Parse(cuenta);
                list1.Add(x, y1);
                y1++;
                i++;
            }

            archivoActualAMC.Close();
            // Agregar un handler para cuando se detecte que el archivo cambia, y asi ejecutar de nuevo 
            // la generacion de la gráfica.
            // Generar la curva
            PaneAMC.CurveList.Clear();

            LineItem myCurve = PaneAMC.AddCurve("Espectro", list1, Color.DarkBlue, SymbolType.Diamond);
                
            myCurve.Symbol.Size = 1.0F;
            myCurve.Symbol.Fill = new Fill(Color.DarkRed);
            myCurve.Line.IsVisible = false;
            myCurve.Line.Fill = new Fill(Color.Blue, Color.White, 45F);

            // Tell ZedGraph to refigure the
            // axes since the data have changed
            graphMainAMC.AxisChange();
            graphMainAMC.Invalidate();
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            InicializarPuerto(serialPortMain);
            //MenuModoAAP.Enabled = false;
            //  MenuModoAMC.Enabled = false;
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

        private void radioButtonControlIntAct_CheckedChanged(object sender, EventArgs e)
        {
            {
                string activarMedAMC = "CMA";
                EnviarOrden(activarMedAMC);
            }
        }

        private void radioButtonControlIntDesact_CheckedChanged(object sender, EventArgs e)
        {
            {
                string desactivarMedAMC = "CMD";
                EnviarOrden(desactivarMedAMC);
            }
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string datafile;
            SaveFileDialog guardarEspecDialog = new SaveFileDialog();
            if (MenuModoAAP.Checked == true && MenuModoAMC.Checked == false)
            {
                guardarEspecDialog.Filter = "Archivo de altura de pulsos|*.aap";
                guardarEspecDialog.Title = "Guardar archivo de altura de pulsos";
                datafile = @"currentAAP_Dev" + amcID.ToString() + ".dataplot";
            }
            else
            {
                if (MenuModoAMC.Checked == true && MenuModoAAP.Checked == false)
                {
                    guardarEspecDialog.Filter = "Archivo de espectro Mössbauer|*.amc|Todos los archivos |*.txt";
                    guardarEspecDialog.Title = "Guardar archivo de espectro Mössbauer";
                    datafile = @"currentAMC_Dev" + amcID.ToString() + ".dataplot";
                }
                else
                {
                    MessageBox.Show("No se detectó el modo de operación para guardar archivo");
                    return;
                }
            }

            guardarEspecDialog.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (guardarEspecDialog.FileName != "")
            {
                using (FileStream fsout = (FileStream)guardarEspecDialog.OpenFile(), input = File.OpenRead(datafile))
                {               

                switch (guardarEspecDialog.FilterIndex)
                {
                    case 1:
                        int read = -1;
                        byte[] buffer = new byte[4096];
                        while (read != 0)
                        {
                            read = input.Read(buffer, 0, buffer.Length);
                            fsout.Write(buffer, 0, read);
                        }
                    break;

                    case 2:
                        read = -1;
                        buffer = new byte[4096];
                        while (read != 0)
                        {
                            read = input.Read(buffer, 0, buffer.Length);
                            fsout.Write(buffer, 0, read);
                        }
                        break;
                }

                fsout.Close();
                }
            }


        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

       

        
    }
}
