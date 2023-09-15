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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Camiones.Presentacion
{
    public partial class FrmCargas : Form
    {
        DBHelper dbHelper;
        List<Camion> lCamiones;

        TipoCarga pack = new TipoCarga("Packing", 1);
        TipoCarga caja = new TipoCarga("Cajas", 2);
        TipoCarga bidon = new TipoCarga("Bidones", 3);
        public FrmCargas()
        {
            InitializeComponent();
            dbHelper = new DBHelper();
            lCamiones = new List<Camion>();
        }

        private void FrmCargas_Load(object sender, EventArgs e)
        {
            CargarCamiones();
            CargarTipos();
        }

        private void CargarTipos()
        {
            DataTable tabla = dbHelper.Consultar("SP_CONSULTAR_TIPOS_CARGA");
            cboTipo.DataSource = tabla;
            cboTipo.ValueMember = "id_tipo_carga";
            cboTipo.DisplayMember = "nombre";
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipo.SelectedIndex = -1;
        }

        private void CargarCamiones()
        {
            lstCamiones.Items.Clear();
            lCamiones.Clear();
            DataTable tabla = dbHelper.Consultar("SP_CONSULTAR_CAMIONES");
            foreach (DataRow row in tabla.Rows)
            {
                int id = Convert.ToInt32(row[0]);
                string patente = row[1].ToString();
                int pesomax = Convert.ToInt32(row[3]);
                EstadoCamion estado = new EstadoCamion(0); ;
                if (row[2].ToString() == "De Viaje")
                {
                    estado.Estado = 2;
                }
                if (row[2].ToString() == "En Reparacion")
                {
                    estado.Estado = 1;
                }

                Camion oCamion = new Camion(id, patente, pesomax, estado);
                lCamiones.Add(oCamion);
            }

            lstCamiones.Items.AddRange(lCamiones.ToArray());
        }

        private void lstCamiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarCargas();
            txtPeso.Text = "";
            cboTipo.SelectedIndex = -1;
            label1.Text = "Administrar Cargas";
            txtPeso.Enabled = true;
            cboTipo.Enabled = true;
            btnSubir.Enabled = true;
            dgvCargas.Enabled = true;
            if (Convert.ToInt32(lCamiones[lstCamiones.SelectedIndex].EstadoCamion.Estado) != 0)
            {
                txtPeso.Enabled = false;
                cboTipo.Enabled = false;
                btnSubir.Enabled = false;
                dgvCargas.Enabled = false;
                label1.Text =  "Administrar Cargas - ESTE CAMION NO ESTA DISPONIBLE";
            }

        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            if (ValidarSubida())
            {
                Carga oCarga = new Carga();
                oCarga.Peso = Convert.ToInt32(txtPeso.Text);
                //oCarga.Id = Convert.ToInt32(dgvCargas.SelectedRows[0]);
                oCarga.IdCamion = lCamiones[lstCamiones.SelectedIndex].Id;
                if(cboTipo.SelectedIndex == 0)
                {
                    oCarga.TipoCarga = pack;
                }
                if (cboTipo.SelectedIndex == 1)
                {
                    oCarga.TipoCarga = caja;
                }
                if (cboTipo.SelectedIndex == 2)
                {
                    oCarga.TipoCarga = bidon;
                }

                if (dbHelper.AgregarCarga(oCarga))
                {
                    MessageBox.Show("Se subio la carga con exito!", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ActualizarCargas();
                    txtPeso.Text = "";
                    cboTipo.SelectedIndex = -1;

                }
                else
                {
                    MessageBox.Show("NO se pudo agregar la carga!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private bool ValidarSubida()
        {
            if(string.IsNullOrEmpty(txtPeso.Text) || !int.TryParse(txtPeso.Text, out _))
            {
                MessageBox.Show("Debe ingresar un peso valido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cboTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe ingresar un tipo valido!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            int ocupado = CalcularPeso();
            if (ocupado + Convert.ToInt32(txtPeso.Text) > Convert.ToInt32(txtTotal.Text))
            {
                MessageBox.Show("Esta pasando el limite de peso!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private int CalcularPeso()
        {
            List<Parametro> lstP = new List<Parametro>();
            lstP.Add(new Parametro(@"id", lCamiones[lstCamiones.SelectedIndex].Id));

            DataTable tabla = dbHelper.Consultar("SP_CONSULTAR_CARGAS", lstP);

            int ocupado = 0;

            foreach (DataRow dt in tabla.Rows)
            {

                ocupado = ocupado + Convert.ToInt32(dt["peso"]);
            }

            return ocupado;
        }

        private void ActualizarCargas()
        {
            txtTotal.Text = lCamiones[lstCamiones.SelectedIndex].PesoMaximo.ToString();
            List<Parametro> lstP = new List<Parametro>();
            lstP.Add(new Parametro(@"id", lCamiones[lstCamiones.SelectedIndex].Id));

            DataTable tabla = dbHelper.Consultar("SP_CONSULTAR_CARGAS", lstP);
            dgvCargas.Rows.Clear();

            int ocupado = 0;

            foreach (DataRow dt in tabla.Rows)
            {
                dgvCargas.Rows.Add(new object[] { dt["id_carga".ToString()],
                                                            dt["peso".ToString()],
                                                            dt["nombre".ToString()],
                    });

                ocupado = ocupado + Convert.ToInt32(dt["peso"]);
            }

            txtOcupado.Text = ocupado.ToString();
        }

        private void dgvCargas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCargas.CurrentCell.ColumnIndex == 3)
            {
                if(MessageBox.Show("Esta seguro que quiere dar de baja la carga?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvCargas.Rows[e.RowIndex].Cells[0].Value);
                    dbHelper.EliminarCarga(id);
                    ActualizarCargas();
                }
            }
        }
    }
}
