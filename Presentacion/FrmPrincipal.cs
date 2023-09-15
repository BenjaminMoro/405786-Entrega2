using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Camiones.Presentacion
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void nuevoCamionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmCamiones().ShowDialog();
        }

        private void subirCargaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmCargas().ShowDialog();
        }

        private void consToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmConsulta().ShowDialog();
        }
    }
}
