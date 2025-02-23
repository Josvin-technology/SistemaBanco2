using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Cuentas
    {
        CD_Conexion db_conexion = new CD_Conexion();

        public DataTable MtMostrarCuentas()
        {
            string QryMostrar = "usp_Cuentas_Mostrar";
            SqlDataAdapter adapter = new SqlDataAdapter(QryMostrar, db_conexion.MtdAbrirConexion());
            DataTable dtMostrar = new DataTable();
            adapter.Fill(dtMostrar);
            db_conexion.MtdCerrarConexion();
            return dtMostrar;
        }

        public void MtAgregarCuentas(int CodCliente, String NumeroCuenta, String TipoCuenta,
      decimal Saldo, DateTime FechaAp, String Estado)
        {
            string usp_Insertar = "usp_cuentas_crear";
            SqlCommand cmd_Insertar = new SqlCommand(usp_Insertar, db_conexion.MtdAbrirConexion());

            cmd_Insertar.CommandType = CommandType.StoredProcedure;
            cmd_Insertar.Parameters.AddWithValue("@CodigoCliente", CodCliente);
            cmd_Insertar.Parameters.AddWithValue("@NumeroCuenta", NumeroCuenta);
            cmd_Insertar.Parameters.AddWithValue("@TipoCuenta", TipoCuenta);
            cmd_Insertar.Parameters.AddWithValue("@Saldo", Saldo);
            cmd_Insertar.Parameters.AddWithValue("@FechaApertura", FechaAp);
            cmd_Insertar.Parameters.AddWithValue("@Estado", Estado);
            cmd_Insertar.ExecuteNonQuery();
        }
    }
}
