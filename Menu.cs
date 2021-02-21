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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void lsvOpcoes_ItemActivate(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            this.barraSuperior1.lblTitulo.Text = "PRINCIPAL";
            this.barraInferior1.Top = this.barraInferior1.Top - (325 - Screen.PrimaryScreen.Bounds.Height);

            ListViewItem item;

            imlMenu.Images.Add(EDL.Properties.Resources.entrada);
            imlMenu.Images.Add(EDL.Properties.Resources.devolucao);

            item = new ListViewItem();
            item.ImageIndex = 0;
            item.Text = "NFe";
            lsvOpcoes.Items.Add(item);

            item = new ListViewItem();
            item.ImageIndex = 1;
            item.Text = "Devolução";
            lsvOpcoes.Items.Add(item);

            lsvOpcoes.View = View.LargeIcon;

            item = null;

            Util.MostraCursor.CursorAguarde(false);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Util.MostraCursor.CursorAguarde(true);
            
            Program.FormularioAtivo = "Login";
            this.Close();
        }

        private void lsvOpcoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.barraInferior1.inputPanel1.Enabled = false;

            if (this.lsvOpcoes.FocusedItem != null)
            {
                switch (lsvOpcoes.FocusedItem.Index)
                {
                    case 0:
                        Util.MostraCursor.CursorAguarde(true);
                        Program.FormularioAtivo = "NFe";
                        this.Close();
                        break;
                    case 1:
                        Util.MostraCursor.CursorAguarde(true);
                        Program.FormularioAtivo = "devolucao";
                        this.Close();
                        break;
                }
            }
        }
    }
}