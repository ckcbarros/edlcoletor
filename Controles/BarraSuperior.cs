using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace EDL.Controles
{
    public partial class BarraSuperior : UserControl
    {
        public BarraSuperior()
        {
            InitializeComponent();
            pictureBox1.Image = EDL.Properties.Resources.drogariaaraujo;
            pictureBox2.Image = EDL.Properties.Resources.barra;
        }
    }
}
