using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EDL
{
    public partial class Divergencias : Form
    {
        public string[] Ocorrencias;

        public Divergencias()
        {
            InitializeComponent();
            Program.PercorreTodosCampos(this);
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Divergencias_Load(object sender, EventArgs e)
        {
            this.barraSuperior1.lblTitulo.Text = "DIVERGÊNCIAS";
            this.barraInferior1.Top = this.barraInferior1.Top - (325 - Screen.PrimaryScreen.Bounds.Height);

            StringBuilder texto = new StringBuilder();

            foreach (String item in Ocorrencias)
            {
                texto.AppendLine(item);
                texto.AppendLine("");
            }
            textBox1.Text = texto.ToString();

            Util.MostraCursor.CursorAguarde(false);
        }

     
    }
}