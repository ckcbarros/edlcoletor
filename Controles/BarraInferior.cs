using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace EDL.Controles
{
    public partial class BarraInferior : UserControl
    {
        public BarraInferior()
        {
            InitializeComponent();
            
            this.pictureBox2.Image = EDL.Properties.Resources.barra2;
            
            this.Refresh();
            TrocaCor();
            this.lblDataHora.Text = "";
            this.lblFilial.Text = "Filial " + Program.Filial.ToString();
            timer1.Enabled = true;
        }

        private void TrocaCor()
        {
            try
            {
                switch (Program.OnLine)
                {
                    case EDL.Dominio.Enumeradores.Enum.TipoSinal.ON:
                        this.picSinal.Image = EDL.Properties.Resources.verde;
                        this.lblSinal.Text = EDL.Dominio.Enumeradores.Enum.TipoSinal.ON.ToString();
                        break;
                    case EDL.Dominio.Enumeradores.Enum.TipoSinal.OFF:
                        this.picSinal.Image = EDL.Properties.Resources.vermelho;
                        this.lblSinal.Text = EDL.Dominio.Enumeradores.Enum.TipoSinal.OFF.ToString();
                        break;
                }
            }
            catch (Exception)
            {
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;

                Util.Bateria bateria = new EDL.Util.Bateria();
                this.picBateria.Image = bateria.BatteryImage();
                bateria = null;

                if (Program.OnLine == EDL.Dominio.Enumeradores.Enum.TipoSinal.ON)
                    this.picSinal.Image = EDL.Properties.Resources.verde;
                else
                    this.picSinal.Image = EDL.Properties.Resources.vermelho;

                TrocaCor();

                lblDataHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                timer1.Enabled = true;
            }
            catch (Exception)
            {
            }
        }

        private void picTeclado_Click(object sender, EventArgs e)
        {
            this.inputPanel1.Enabled = (!this.inputPanel1.Enabled);
        }

    }
}
