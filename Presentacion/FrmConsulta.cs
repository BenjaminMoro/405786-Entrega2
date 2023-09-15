﻿using Camiones.Entidades;
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
    public partial class FrmConsulta : Form
    {
        DBHelper dbHelper;
        List<Camion> lCamiones;
        public FrmConsulta()
        {
            InitializeComponent();
            dbHelper = new DBHelper();
            lCamiones = new List<Camion>();
        }

        private void FrmConsulta_Load(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            List<Parametro> lstP = new List<Parametro>();
            lstP.Add(new Parametro(@"patente", txtPatente.Text));

            DataTable tabla = dbHelper.Consultar("SP_CONSULTA_CAMIONES", lstP);
            dgvCamiones.Rows.Clear();

            foreach (DataRow dt in tabla.Rows)
            {
                dgvCamiones.Rows.Add(new object[] { dt["id_camion".ToString()],
                                                            dt["patente".ToString()],
                                                            dt["estado".ToString()],
                                                            dt["peso_maximo".ToString()],
                                                            dt["Peso Ocupado".ToString()]
                    });
            }

        }

        private void dgvCamiones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCamiones.CurrentCell.ColumnIndex == 5)
            {
                DataGridViewRow selectedRow = dgvCamiones.Rows[e.RowIndex];

                int id = Convert.ToInt32(selectedRow.Cells["ColID"].Value);
                string pat = selectedRow.Cells["ColPatente"].Value.ToString();
                string est = selectedRow.Cells["ColEstado"].Value.ToString();
                int max = Convert.ToInt32(selectedRow.Cells["ColPesoMax"].Value);
                int ocu = Convert.ToInt32(selectedRow.Cells["ColPesoOcu"].Value);

                new FrmDetalleConsulta(id,pat,est,max,ocu, lCamiones).ShowDialog();
            }
        }
    }
}
