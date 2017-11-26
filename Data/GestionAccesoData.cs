using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;
using System.Threading.Tasks;

namespace Data
{
    public class GestionAccesoData : BD_Conexion
    {
        public GestionAccesoData() { }

        public DataSet Sp_SelectPerfil(Entity.GestionAccesoEntity.PerfilEntity obj)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection(GetConnectionString());
            DataSet ds;

            connection.Open();
            SqlCommand cmd = new SqlCommand("Sp_SelectPerfil", connection);
            cmd.Parameters.AddWithValue("@idPerfil", obj.idPerfil);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                adapter.SelectCommand = cmd;
                ds = new DataSet();
                adapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                var lstrMessage = string.Format("Number: {0} LineNumber: {1} Message: {2} Fecha:{3}\r", ex.Number, ex.LineNumber, ex.Message, DateTime.Now);
                throw new Exception(lstrMessage, new Exception("ERROR"));
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }

            return ds;





        }

        public DataSet Sp_SelectUsuario(Entity.GestionAccesoEntity.UsuarioEntity obj)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection(GetConnectionString());
            DataSet dsProducto;

            connection.Open();
            SqlCommand cmd = new SqlCommand("Sp_SelectUsuario", connection);
            cmd.Parameters.AddWithValue("@idUsuario", obj.idUsuario);
            cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
            cmd.Parameters.AddWithValue("@idPerfil", obj.idPerfil);
            cmd.Parameters.AddWithValue("@idEstatus", obj.idEstatus);
            cmd.Parameters.AddWithValue("@Correo", obj.Correo);
            cmd.Parameters.AddWithValue("@Cedula", obj.Cedula);
            //cmd.Parameters.AddWithValue("@pwd", obj.Pwd);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                adapter.SelectCommand = cmd;
                dsProducto = new DataSet();
                adapter.Fill(dsProducto);
            }
            catch (SqlException ex)
            {
                var lstrMessage = string.Format("Number: {0} LineNumber: {1} Message: {2} Fecha:{3}\r", ex.Number, ex.LineNumber, ex.Message, DateTime.Now);
                throw new Exception(lstrMessage, new Exception("ERROR"));
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }

            return dsProducto;
        }

        public bool Sp_DeleteUsuario(int idUsuario)
        {
            Boolean success = false;
            SqlConnection connection = new SqlConnection(GetConnectionString());
            SqlCommand sqlCommand = new SqlCommand();
            SqlTransaction sqlTrans = null;

            try
            {
                connection.Open();
                sqlTrans = connection.BeginTransaction();
                sqlCommand.Transaction = sqlTrans;
                sqlCommand.Connection = connection;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = "Sp_DeleteUsuario"; //sqlCommand = new SqlCommand("Sp_DeleteUsuario", connection);
                sqlCommand.Parameters.AddWithValue("@idUsuario", idUsuario);

                sqlCommand.ExecuteNonQuery();
                sqlTrans.Commit();
                success = true;
            }
            catch (SqlException ex)
            {
                var lstrMessage = string.Format("Number: {0} LineNumber: {1} Message: {2} Fecha:{3}\r", ex.Number, ex.LineNumber, ex.Message, DateTime.Now);
                throw new Exception(lstrMessage, new Exception("ERROR"));
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }

            return success;
        }

        public int Sp_InsertUpdateUsuario(Entity.GestionAccesoEntity.UsuarioEntity obj)
        {
            int result = 0;
            SqlConnection connection = new SqlConnection(GetConnectionString());
            SqlCommand cmd = new SqlCommand();
            SqlTransaction sqlTrans = null;


            try
            {
                connection.Open();
                sqlTrans = connection.BeginTransaction();
                cmd.Transaction = sqlTrans;
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Sp_InsertUpdateUsuario";
                cmd.Parameters.AddWithValue("@idUsuario", obj.idUsuario);
                cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", obj.Apellido);
                cmd.Parameters.AddWithValue("@Correo", obj.Correo);
                cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                cmd.Parameters.AddWithValue("@Pwd", obj.Pwd);
                cmd.Parameters.AddWithValue("@idPerfil", obj.idPerfil);
                cmd.Parameters.AddWithValue("@idEstatus", obj.idEstatus);


                var returnParameter = cmd.Parameters.Add("@returnvalue", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.Output;


                cmd.ExecuteNonQuery();
                sqlTrans.Commit();
                var fsuccess = returnParameter.Value;
                result = int.Parse(fsuccess.ToString());
            }
            catch (Exception ex)
            {
                //var lstrMessage = string.Format("Number: {0} LineNumber: {1} Message: {2} Fecha:{3}\r", ex.Number, ex.LineNumber, ex.Message, DateTime.Now);
                //throw new Exception(lstrMessage, new Exception("ERROR"));
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }

            return result;
        }
    }
}
