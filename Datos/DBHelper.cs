using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Camiones.Entidades;

namespace Camiones.Presentacion
{
    internal class DBHelper
    {
        SqlConnection conexion;

        public DBHelper()
        {
            conexion = new SqlConnection(@"Data Source=DESKTOP-B5Q8CSC\SQLEXPRESS;Initial Catalog=405786_Problema1.6;Integrated Security=True");
        }

        public int ProximoCamion()
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_PROXIMO_CAMION";
            SqlParameter param = new SqlParameter();
            param.Direction = ParameterDirection.Output;
            param.ParameterName = "@next";
            param.DbType = DbType.Int32;
            comando.Parameters.Add(param);
            comando.ExecuteNonQuery();
            conexion.Close();

            return Convert.ToInt32(param.Value);
        }

        public DataTable Consultar(string nombreSP)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            conexion.Close();

            return tabla;
        }

        public DataTable Consultar(string nombreSP, List<Parametro> lParametros)
        {
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = nombreSP;
            comando.Parameters.Clear(); // Eliminamos los parametros anteriores por si acaso
            // Cargamos la lista de parametros
            foreach(Parametro param in lParametros)
            {
                comando.Parameters.AddWithValue(param.Nombre, param.Valor);
            }

            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
            conexion.Close();

            return tabla;
        }

        public bool CrearCamion(Camion oCamion)
        {

            bool resultado = true;

            // Creamos la transaccion
            SqlTransaction t = null;

            try
            {
                conexion.Open();

                SqlCommand comandoMaestro = new SqlCommand();
                // Ponemos a la conexion bajo transaccion
                t = conexion.BeginTransaction(); // Aca la estariamos iniciando
                comandoMaestro.Connection = conexion;

                comandoMaestro.Transaction = t;
                comandoMaestro.CommandType = CommandType.StoredProcedure;
                comandoMaestro.CommandText = "SP_INSERTAR_CAMION";
                // Agregamos los parametros de entrada
                comandoMaestro.Parameters.AddWithValue("@patente", oCamion.Patente);
                comandoMaestro.Parameters.AddWithValue("@estadoCamion", oCamion.EstadoCamion.Estado);
                comandoMaestro.Parameters.AddWithValue("@pesoMax", oCamion.PesoMaximo);

                SqlParameter param = new SqlParameter();
                param.Direction = ParameterDirection.Output;
                param.ParameterName = "@proxCamion";
                param.DbType = DbType.Int32;
                comandoMaestro.Parameters.Add(param);

                comandoMaestro.ExecuteNonQuery();

                t.Commit(); // Confirmamos la transaccion
            }
            catch
            {
                if (t != null)
                {
                    t.Rollback(); // "Desconfirmamos" la transaccion
                }

                resultado = false;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open) // Si la conexion no esta vacia, y en este momento esta abierta
                {
                    conexion.Close(); // Cerramos la conexion

                }
            }
            return resultado;
        }

        public bool ActualizarCamion(Camion oCamion)
        {

            bool resultado = true;

            // Creamos la transaccion
            SqlTransaction t = null;

            try
            {
                conexion.Open();

                SqlCommand comandoMaestro = new SqlCommand();
                // Ponemos a la conexion bajo transaccion
                t = conexion.BeginTransaction(); // Aca la estariamos iniciando
                comandoMaestro.Connection = conexion;

                comandoMaestro.Transaction = t;
                comandoMaestro.CommandType = CommandType.StoredProcedure;
                comandoMaestro.CommandText = "SP_ACTUALIZAR_CAMION";
                // Agregamos los parametros de entrada
                comandoMaestro.Parameters.AddWithValue("@id", oCamion.Id);
                comandoMaestro.Parameters.AddWithValue("@patente", oCamion.Patente);
                comandoMaestro.Parameters.AddWithValue("@estado", oCamion.EstadoCamion.Estado);
                comandoMaestro.Parameters.AddWithValue("@peso", oCamion.PesoMaximo);

                comandoMaestro.ExecuteNonQuery();

                SqlCommand comandoDetalle = new SqlCommand();
                comandoDetalle.Connection = conexion;
                comandoDetalle.Transaction = t;
                comandoDetalle.CommandType = CommandType.StoredProcedure;
                comandoDetalle.CommandText = "SP_ELIMINAR_CARGAS";
                comandoDetalle.Parameters.AddWithValue("@idCamion", oCamion.Id);

                comandoDetalle.ExecuteNonQuery();

                t.Commit(); // Confirmamos la transaccion
            }
            catch
            {
                if (t != null)
                {
                    t.Rollback(); // "Desconfirmamos" la transaccion
                }

                resultado = false;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open) // Si la conexion no esta vacia, y en este momento esta abierta
                {
                    conexion.Close(); // Cerramos la conexion

                }
            }
            return resultado;
        }

        public bool AgregarCarga(Carga oCarga)
        {

            bool resultado = true;

            // Creamos la transaccion
            SqlTransaction t = null;

            try
            {
                conexion.Open();

                SqlCommand comandoMaestro = new SqlCommand();
                // Ponemos a la conexion bajo transaccion
                t = conexion.BeginTransaction(); // Aca la estariamos iniciando
                comandoMaestro.Connection = conexion;

                comandoMaestro.Transaction = t;
                comandoMaestro.CommandType = CommandType.StoredProcedure;
                comandoMaestro.CommandText = "SP_INSERTAR_CARGA";
                // Agregamos los parametros de entrada
                comandoMaestro.Parameters.AddWithValue("@peso", oCarga.Peso);
                comandoMaestro.Parameters.AddWithValue("@tipo", oCarga.TipoCarga.Id);
                comandoMaestro.Parameters.AddWithValue("@id_camion", oCarga.IdCamion);

                comandoMaestro.ExecuteNonQuery();

                t.Commit(); // Confirmamos la transaccion
            }
            catch
            {
                if (t != null)
                {
                    t.Rollback(); // "Desconfirmamos" la transaccion
                }

                resultado = false;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open) // Si la conexion no esta vacia, y en este momento esta abierta
                {
                    conexion.Close(); // Cerramos la conexion

                }
            }
            return resultado;
        }

        public bool EliminarCarga(int id)
        {

            bool resultado = true;

            // Creamos la transaccion
            SqlTransaction t = null;

            try
            {
                conexion.Open();

                SqlCommand comandoMaestro = new SqlCommand();
                // Ponemos a la conexion bajo transaccion
                t = conexion.BeginTransaction(); // Aca la estariamos iniciando
                comandoMaestro.Connection = conexion;

                comandoMaestro.Transaction = t;
                comandoMaestro.CommandType = CommandType.StoredProcedure;
                comandoMaestro.CommandText = "SP_ELIMINAR_CARGA";
                // Agregamos los parametros de entrada
                comandoMaestro.Parameters.AddWithValue("@idCarga", id);

                comandoMaestro.ExecuteNonQuery();

                t.Commit(); // Confirmamos la transaccion
            }
            catch
            {
                if (t != null)
                {
                    t.Rollback(); // "Desconfirmamos" la transaccion
                }

                resultado = false;
            }
            finally
            {
                if (conexion != null && conexion.State == ConnectionState.Open) // Si la conexion no esta vacia, y en este momento esta abierta
                {
                    conexion.Close(); // Cerramos la conexion

                }
            }
            return resultado;
        }
    }
}
