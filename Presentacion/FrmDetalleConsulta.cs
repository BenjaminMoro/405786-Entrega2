using Camiones.Entidades;
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
    public partial class FrmDetalleConsulta : Form
    {
        List<Camion> lCamiones;
        DBHelper dbHelper;
        int id;
        public FrmDetalleConsulta(int idCam, string patente, string estado, int pesoMax, int PesoOcu, List<Camion> lCam)
        {
            InitializeComponent();
            lblID.Text = lblID.Text + id;
            txtPatente.Text = patente;
            txtEstado.Text = estado;
            txtMax.Text = pesoMax.ToString();
            txtOcu.Text = PesoOcu.ToString();
            lCamiones = lCam.ToList();
            id = idCam;
            dbHelper = new DBHelper();
        }

        private void FrmDetalleConsulta_Load(object sender, EventArgs e)
        {
            List<Parametro> lstP = new List<Parametro>();
            lstP.Add(new Parametro(@"id", id));

            DataTable tabla = dbHelper.Consultar("SP_CONSULTAR_CARGAS", lstP);
            dgvCargas.Rows.Clear();

            foreach (DataRow dt in tabla.Rows)
            {
                dgvCargas.Rows.Add(new object[] { dt["id_carga".ToString()],
                                                            dt["peso".ToString()],
                                                            dt["nombre".ToString()],
                    });

            }
        }
    }
}
