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
    public partial class FrmReporteCamiones : Form
    {
        public FrmReporteCamiones()
        {
            InitializeComponent();
        }

        private void FrmReportesCamiones_Load(object sender, EventArgs e)
        {
            DataTable dt = new DBHelper().Consultar("SP_CONSULTAR_CAMIONES");

            this.sPCONSULTARCAMIONESBindingSource.DataSource = dt;

            this.reportViewer1.RefreshReport();
        }
    }
}
