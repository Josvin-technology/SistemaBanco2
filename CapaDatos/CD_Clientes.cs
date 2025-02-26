using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Clientes
    {
    
        CD_Conexion db_conexion = new CD_Conexion();
        private object cmdUspActualizar;

        public DataTable MtMostrarClientes()
        {
            string QryMostrarClientes = "usp_clientes_mostrar";
            SqlDataAdapter adapter = new SqlDataAdapter(QryMostrarClientes,db_conexion.MtdAbrirConexion());
            DataTable dtMostrarClientes = new DataTable();
            adapter.Fill(dtMostrarClientes);
            db_conexion.MtdCerrarConexion();
            return dtMostrarClientes;
        }
        public void mtdAgregarClientes(string Nombre, string Direccion, string Departamento, string Pais, string Categoria, string Estado)
        {

            
            string usp_crear = "usp_clientes_crear";
            SqlCommand cmd_InsertarClientes = new SqlCommand(usp_crear, db_conexion.MtdAbrirConexion());
            cmd_InsertarClientes.CommandType = CommandType.StoredProcedure;
            cmd_InsertarClientes.Parameters.AddWithValue(@Nombre,Nombre);
            cmd_InsertarClientes.Parameters.AddWithValue(@Direccion, Direccion);
            cmd_InsertarClientes.Parameters.AddWithValue(@Departamento, Departamento);
            cmd_InsertarClientes.Parameters.AddWithValue(@Pais, Pais);
            cmd_InsertarClientes.Parameters.AddWithValue(@Categoria, Categoria);
            cmd_InsertarClientes.Parameters.AddWithValue(@Estado, Estado);
            cmd_InsertarClientes.ExecuteNonQuery();


        }

        public void MtdActualizarCliente (int cod,string Nombre, string Direccion, string Departamento, string Pais, string Categoria, string Estado)
        {
            
            string usp_actualizar = "usp_Clientes_editar";
            SqlCommand cmd_UspActualizar = new SqlCommand(usp_actualizar, db_conexion.MtdAbrirConexion());
            cmd_UspActualizar.CommandType = CommandType.StoredProcedure;
            cmd_UspActualizar.CommandType = CommandType.StoredProcedure;
            cmd_UspActualizar.Parameters.AddWithValue("@Nombre", Nombre);
            cmd_UspActualizar.Parameters.AddWithValue("@Direccion", Direccion);
            cmd_UspActualizar.Parameters.AddWithValue("@Departamento", Departamento);
            cmd_UspActualizar.Parameters.AddWithValue("@Pais", Pais);
            cmd_UspActualizar.Parameters.AddWithValue("@Categoria", Categoria);
            cmd_UspActualizar.Parameters.AddWithValue("@Estado", Estado);
           
            cmd_UspActualizar.ExecuteNonQuery();

            db_conexion.MtdCerrarConexion();
        }


        public void MtdEliminarCliente(int Codigo)
        {
            string usp_eliminar = "usp_clientes_eliminar";
            SqlCommand cmdUspEliminar = new SqlCommand(usp_eliminar, db_conexion.MtdAbrirConexion());
            cmdUspEliminar.CommandType = CommandType.StoredProcedure;
            cmdUspEliminar.Parameters.AddWithValue("@Codigo", Codigo);
            cmdUspEliminar.ExecuteNonQuery();

            db_conexion.MtdCerrarConexion();
        }
    }
}
