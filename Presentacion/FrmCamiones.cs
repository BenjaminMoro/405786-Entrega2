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
    public partial class FrmCamiones : Form
    {
        Camion camionNuevo;
        DBHelper dbHelper;
        List<Camion> lCamiones;
        enum Tipo
        {
            Nuevo,
            Editar
        }
        Tipo tipo;
        public FrmCamiones()
        {
            InitializeComponent();
            dbHelper = new DBHelper();
            camionNuevo = new Camion();
            lCamiones = new List<Camion>();
        }

        private void FrmNuevoCamion_Load(object sender, EventArgs e)
        {
            CargarEstados();
            CargarCamiones();
            Habilitar(false);
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

        private void Habilitar(bool v)
        {
            txtPatente.Text = "";
            txtPesoMaximo.Text = "";
            cboEstado.SelectedIndex = 0;
            txtPatente.Enabled = v;
            txtPesoMaximo.Enabled = v;
            lstCamiones.Enabled = v;
            cboEstado.Enabled = v;
            btnAceptar.Enabled = v;
            btnEditar.Enabled = !v;
            btnNuevo.Enabled = !v;
        }

        private void CargarEstados()
        {
            DataTable tabla = dbHelper.Consultar("SP_CONSULTAR_ESTADOS");
            cboEstado.DataSource = tabla;
            cboEstado.ValueMember = "id_estado_camion";
            cboEstado.DisplayMember = "estado";
            cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstado.SelectedIndex = 0;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                camionNuevo.Patente = txtPatente.Text;
                EstadoCamion ec = new EstadoCamion(Convert.ToInt32(cboEstado.SelectedValue));
                camionNuevo.EstadoCamion = ec;
                camionNuevo.PesoMaximo = Convert.ToInt32(txtPesoMaximo.Text);
                if (tipo == Tipo.Nuevo)
                {
                    if (dbHelper.CrearCamion(camionNuevo))
                    {
                        MessageBox.Show("Se registro el camion con exito", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarCamiones();
                        Habilitar(false);
                    }
                    else
                    {
                        MessageBox.Show("NO se pudo registrar el camion!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if(tipo == Tipo.Editar)
                {
                    if(MessageBox.Show("Al editar el camion se eliminaran sus cargas!!", "CUIDADO!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        camionNuevo.Id = Convert.ToInt32(lCamiones[lstCamiones.SelectedIndex].Id.ToString());

                        if (dbHelper.ActualizarCamion(camionNuevo))
                        {
                            MessageBox.Show("Se ACTUALIZO el camion con exito", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarCamiones();
                            Habilitar(false);
                        }
                        else
                        {
                            MessageBox.Show("NO se pudo ACTUALIZAR el camion!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private bool Validar()
        {
            if (string.IsNullOrEmpty(txtPatente.Text))
            {
                MessageBox.Show("Debe ingresar una patente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtPesoMaximo.Text))
            {
                MessageBox.Show("Debe ingresar una peso maximo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Habilitar(true);
            lblCamion.Text = "Camion N°: " + dbHelper.ProximoCamion().ToString();
            tipo = Tipo.Nuevo;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Habilitar(true);
            lstCamiones.Enabled = true;
            tipo = Tipo.Editar;
        }

        private void lstCamiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstCamiones.SelectedIndex != -1)
            {
                lblCamion.Text = "Camion N°: "+ lCamiones[lstCamiones.SelectedIndex].Id.ToString();
                txtPatente.Text = lCamiones[lstCamiones.SelectedIndex].Patente.ToString();
                txtPesoMaximo.Text = lCamiones[lstCamiones.SelectedIndex].PesoMaximo.ToString();
                cboEstado.SelectedIndex = Convert.ToInt32(lCamiones[lstCamiones.SelectedIndex].EstadoCamion.ToString());

            }
        }
    }
}
