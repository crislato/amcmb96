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
    public partial class FormParamAMC : Form
    {
        public FormParamAMC()
        {
            InitializeComponent();

            comboBoxModoManejo.SelectedIndex = 0;
            numericUpDownFrecuencia.DecimalPlaces = 1;
            comboBoxTiempoMuerto.SelectedIndex = 0;
            comboBoxResolucion.SelectedIndex = 0;
            comboBoxMaxVel.SelectedIndex = 0;
            comboBoxFactorEscala.SelectedIndex = 0;
            comboBoxSignoVelocidad.SelectedIndex = 0;
            comboBoxModoAvance.SelectedIndex = 0;
            numericUpDownFrecuencia.Value = 10.0M;

            //Properties.Settings.Default.ModoManejo = comboBoxModoManejo.SelectedText;
            /*Properties.Settings.Default.ModoManejo = 1;
            Properties.Settings.Default.FrecuenciaBarrido = 10;
            Properties.Settings.Default.TiempoMuerto = 20;
            Properties.Settings.Default.Resolucion = 256;
            Properties.Settings.Default.MaxVelocidad = 10;
            Properties.Settings.Default.FactorEscala = 1;
            //Properties.Settings.Default.SignoVelocidad = comboBoxSignoVelocidad.SelectedText;
            //Properties.Settings.Default.ModoAvance = comboBoxModoAvance.SelectedText;
            Properties.Settings.Default.SignoVelocidad = 0;
            Properties.Settings.Default.ModoAvance = Convert.ToChar("I");
            */
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonSaveConf_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ModoManejo = Convert.ToInt16(comboBoxModoManejo.SelectedValue);
            Properties.Settings.Default.FrecuenciaBarrido = Convert.ToDouble(numericUpDownFrecuencia.Value);
            Properties.Settings.Default.TiempoMuerto = Convert.ToInt16(comboBoxTiempoMuerto.SelectedValue);
            Properties.Settings.Default.Resolucion = Convert.ToInt16(comboBoxResolucion.SelectedValue);
            Properties.Settings.Default.MaxVelocidad = Convert.ToInt16(comboBoxMaxVel.SelectedValue);
            Properties.Settings.Default.FactorEscala = Convert.ToInt16(comboBoxFactorEscala.SelectedValue);
            Properties.Settings.Default.SignoVelocidad = Convert.ToInt16(comboBoxSignoVelocidad.SelectedValue);
            Properties.Settings.Default.ModoAvance = Convert.ToChar(comboBoxModoAvance.SelectedValue);
            Properties.Settings.Default.Save();
            this.Close();
        }

       
       

        
    }
}
