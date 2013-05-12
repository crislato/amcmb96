using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using SerialControlAMCMB96.Properties;
using System.IO;
using System.IO.Ports;

namespace SerialControlAMCMB96
{
    public partial class FormCOMOptions : Form
    {
        string sBuffer = String.Empty;
        List<byte> bBuffer = new List<byte>();
        string RxString;
        string ErrorNoCOM = "Imposible abrir puerto de comunicación";
        public FormCOMOptions()
        {
            InitializeComponent();
            comboBoxPortName.Items.Clear();
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                comboBoxPortName.Items.Add(s);
            }
        
        //Establecimiento de valores por defecto para la inicialización del puerto

        comboBoxPortName.Text = Properties.Settings.Default.COMPortName;
        comboBoxBaudrate.Text = Convert.ToString(Properties.Settings.Default.COMBaudRate);
        comboBoxParity.SelectedIndex = 0;
        comboBoxStopBits.SelectedIndex = 0;
        comboBoxDataBits.Text = Convert.ToString(Properties.Settings.Default.COMDataBits);
        comboBoxHandshake.SelectedIndex = 3;
        textBoxReadTimeout.Text = Convert.ToString(Properties.Settings.Default.COMReadTimeout);
        textBoxWriteTimeout.Text = Convert.ToString(Properties.Settings.Default.COMWriteTimeout);
        comboBoxPortName.Enabled = true;
        comboBoxBaudrate.Enabled = false;
        comboBoxParity.Enabled = false;
        comboBoxStopBits.Enabled = false;
        comboBoxDataBits.Enabled = false;
        comboBoxHandshake.Enabled = false;
        textBoxReadTimeout.Enabled = false;
        textBoxWriteTimeout.Enabled = false;
        }

        
        private void buttonIniciar_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = comboBoxPortName.Text;
            serialPort1.BaudRate = int.Parse(comboBoxBaudrate.Text);
            if (comboBoxParity.SelectedIndex == -1)
            {
                MessageBox.Show("Paridad Inválida");
                return;
            }
            if (comboBoxParity.SelectedIndex == 0)
            {
                serialPort1.Parity = System.IO.Ports.Parity.None;
            }
            if (comboBoxParity.SelectedIndex == 1)
            {
                serialPort1.Parity = System.IO.Ports.Parity.Odd;
            }
            if (comboBoxParity.SelectedIndex == 2)
            {
                serialPort1.Parity = System.IO.Ports.Parity.Even;
            }
            if (comboBoxParity.SelectedIndex == 3)
            {
                serialPort1.Parity = System.IO.Ports.Parity.Mark;
            }
            if (comboBoxParity.SelectedIndex == 4)
            {
                serialPort1.Parity = System.IO.Ports.Parity.Space;
            } 
            
            serialPort1.DataBits = int.Parse(comboBoxDataBits.Text);
                        
            if (comboBoxStopBits.SelectedIndex == -1)
            {
                MessageBox.Show("Imposible definir Bits de parada");
                return;
            }
            if (comboBoxStopBits.SelectedIndex == 1)
            {
                serialPort1.StopBits = System.IO.Ports.StopBits.One;
            }
            if (comboBoxStopBits.SelectedIndex == 2)
            {
                serialPort1.StopBits = System.IO.Ports.StopBits.None;
            }
            if (comboBoxStopBits.SelectedIndex == 3)
            {
                serialPort1.StopBits = System.IO.Ports.StopBits.Two;
            }

            if (comboBoxHandshake.SelectedIndex == -1)
            {
                MessageBox.Show("Imposible definir modo de negociación");
                return;
            }
            if (comboBoxHandshake.SelectedIndex == 1)
            {
                serialPort1.Handshake = System.IO.Ports.Handshake.None;
            }
            if (comboBoxHandshake.SelectedIndex == 2)
            {
                serialPort1.Handshake = System.IO.Ports.Handshake.XOnXOff;
            }
            if (comboBoxHandshake.SelectedIndex == 3)
            {
                serialPort1.Handshake = System.IO.Ports.Handshake.RequestToSend;
            }
            if (comboBoxHandshake.SelectedIndex == 4)
            {
                serialPort1.Handshake = System.IO.Ports.Handshake.RequestToSendXOnXOff;
            }
            
            serialPort1.ReadTimeout = int.Parse(textBoxReadTimeout.Text);
            serialPort1.WriteTimeout = int.Parse(textBoxWriteTimeout.Text);

            textBox1.AppendText("Abriendo Puerto COM" + Environment.NewLine);
            textBox1.AppendText("PortName Puerto COM:" + serialPort1.PortName + Environment.NewLine);
            textBox1.AppendText("BaudRate Puerto COM:" + serialPort1.BaudRate + Environment.NewLine);
            textBox1.AppendText("Parity Puerto COM:" + serialPort1.Parity + Environment.NewLine);
            textBox1.AppendText("DataBits Puerto COM:" + serialPort1.DataBits + Environment.NewLine);
            textBox1.AppendText("StopBits Puerto COM:" + serialPort1.StopBits + Environment.NewLine);
            textBox1.AppendText("Handshake Puerto COM:" + serialPort1.Handshake + Environment.NewLine);
            textBox1.AppendText("ReadTimeOut Puerto COM:" + serialPort1.ReadTimeout + Environment.NewLine);
            textBox1.AppendText("WriteTimeOut Puerto COM:" + serialPort1.WriteTimeout + Environment.NewLine);

            try
            {
                serialPort1.Open();
                //serialPort1.RtsEnable = true;
                serialPort1.DtrEnable = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (serialPort1.IsOpen)
            {
                buttonIniciar.Enabled = false;
                buttonStop.Enabled = true;
                textBox1.ReadOnly = false;
            }
            else
            {
                textBox1.AppendText(ErrorNoCOM);
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                buttonIniciar.Enabled = true;
                buttonStop.Enabled = false;
                textBox1.AppendText("Cerrando puerto COM" + Environment.NewLine);
                textBox1.ReadOnly = true;
            }
        }

        public void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int numdatosEntrada;
            numdatosEntrada = serialPort1.BytesToRead;
            Byte[] dato = new Byte[numdatosEntrada];
            serialPort1.Read(dato, 0, numdatosEntrada);
            RxString = BitConverter.ToString(dato).Replace("-", " ");
            this.Invoke(new EventHandler(DisplayText));
        }
       

        private void ProcessBuffer(List<byte> bBuffer, int len)
        {
            // Create a byte array buffer to hold the incoming data
            byte[] buffer = bBuffer.ToArray();

            // Show the user the incoming data // Display mode
            for (int i = 0; i < buffer.Length; i++)
            {
                textBox1.AppendText("Dato: " + (bBuffer[i].ToString()));
            }
/*            string Data1 = "";
            string sData = "";
            int i = 0;
            while (i < len)
            {
                //Data1 = String.Format("{0:X}", buf[i++]); //no joy, doesn't pad
                Data1 = bBuffer[i++].ToString("X").PadLeft(2, '0'); //same as "%02X" in C
                sData += Data1;
                
            }
            return sData;
            // Look in the byte array for useful information
*/            // then remove the useful data from the buffer
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If the port is closed, don't try to send a character.

            if (!serialPort1.IsOpen) return;

            // If the port is Open, declare a char[] array with one element.
            char[] buff = new char[1];

            // Load element 0 with the key character.

            buff[0] = e.KeyChar;

            // Send the one character buffer.
            serialPort1.Write(buff, 0, 1);
            serialPort1.DataReceived +=new SerialDataReceivedEventHandler(serialPort1_DataReceived);

            // Set the KeyPress event as handled so the character won't
            // display locally. If you want it to display, omit the next line.
            //e.Handled = true;
        }

        private void DisplayText(object sender, EventArgs e)
        {
            textBox1.AppendText("\n" + RxString);
        }

        private void FormCOMOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonSaveConf_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.COMPortName = comboBoxPortName.Text;
            Properties.Settings.Default.COMBaudRate = int.Parse(comboBoxBaudrate.Text);
            if (comboBoxParity.SelectedIndex == 0)
            {
                Properties.Settings.Default.COMParity = System.IO.Ports.Parity.None;
            }
            if (comboBoxParity.SelectedIndex == 1)
            {
                Properties.Settings.Default.COMParity = System.IO.Ports.Parity.Odd;
            }
            if (comboBoxParity.SelectedIndex == 2)
            {
                Properties.Settings.Default.COMParity = System.IO.Ports.Parity.Even;
            }
            if (comboBoxParity.SelectedIndex == 3)
            {
                Properties.Settings.Default.COMParity = System.IO.Ports.Parity.Mark;
            }
            if (comboBoxParity.SelectedIndex == 4)
            {
                Properties.Settings.Default.COMParity = System.IO.Ports.Parity.Space;
            }
            Properties.Settings.Default.COMDataBits = int.Parse(comboBoxDataBits.Text);
            Properties.Settings.Default.COMStopBits = serialPort1.StopBits;
            Properties.Settings.Default.COMHandshake = serialPort1.Handshake;
            Properties.Settings.Default.COMReadTimeout = int.Parse(textBoxReadTimeout.Text);
            Properties.Settings.Default.COMWriteTimeout = int.Parse(textBoxWriteTimeout.Text);
            Properties.Settings.Default.Save();
            this.Close();
        }

    }
}
