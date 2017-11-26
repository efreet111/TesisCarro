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
    public class MaterialesDataAccess  : BD_Conexion
    {
        //public MaterialesData() { }

        public DataSet sp_SelectMateriales(Entity.InventarioEntity.MaterialEntity obj)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection(GetConnectionString());
            DataSet ds;

            connection.Open();
            SqlCommand cmd = new SqlCommand("sp_SelectMateriales", connection);
            cmd.Parameters.AddWithValue("@id", obj.id);
            cmd.Parameters.AddWithValue("@idUsuarioCamrio", obj.idUsuarioCambio);
            cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
            cmd.Parameters.AddWithValue("@Codigo", obj.Codigo);
            cmd.Parameters.AddWithValue("@idTipo", obj.idTipo);
            cmd.Parameters.AddWithValue("@Estatus", obj.Estatus);
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



        public bool sp_DeleteMateriales(int id)
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
                sqlCommand.CommandText = "sp_DeleteMateriales"; //sqlCommand = new SqlCommand("Sp_DeleteUsuario", connection);
                sqlCommand.Parameters.AddWithValue("@id", id);
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


        public int sp_InsertEditMateriales(Entity.InventarioEntity.MaterialEntity obj)
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
                cmd.CommandText = "sp_InsertEditMateriales";
                cmd.Parameters.AddWithValue("@id", obj.id);
                cmd.Parameters.AddWithValue("@idUsuarioCamrio", obj.idUsuarioCambio);
                cmd.Parameters.AddWithValue("@nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@Codigo", obj.Codigo);
                cmd.Parameters.AddWithValue("@idTipo", obj.idTipo);
                cmd.Parameters.AddWithValue("@Estatus", obj.Estatus);
                cmd.Parameters.AddWithValue("@cantidad", obj.cantidad);


                //var returnParameter = sqlCommand.Parameters.Add("@return_value", SqlDbType.Int);
                var returnParameter = cmd.Parameters.Add("@return_value", SqlDbType.Int);
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


        public DataSet sp_SelectTipo(Entity.InventarioEntity.TipoEntity obj)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection(GetConnectionString());
            DataSet ds;

            connection.Open();
            SqlCommand cmd = new SqlCommand("sp_SelectTipo", connection);
            cmd.Parameters.AddWithValue("@idTipo", obj.idTipo);
            cmd.Parameters.AddWithValue("@idTipoPadre", obj.idTipoPadre);
            cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
            cmd.Parameters.AddWithValue("@Estatus", obj.Estatus);
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

        public bool sp_DeleteTipo(int idTipo)
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
                sqlCommand.CommandText = "[sp_DeleteTipo]"; //sqlCommand = new SqlCommand("Sp_DeleteUsuario", connection);
                sqlCommand.Parameters.AddWithValue("@idTipo", idTipo);
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

        public int sp_InsertEditTipo(Entity.InventarioEntity.TipoEntity obj)
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
                cmd.CommandText = "sp_InsertEditTipo";
                cmd.Parameters.AddWithValue("@idTipo", obj.idTipo);
                cmd.Parameters.AddWithValue("@idTipoPadre", obj.idTipoPadre);
                cmd.Parameters.AddWithValue("@idUsuarioCambio", obj.idUsuarioCambio);
                cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                cmd.Parameters.AddWithValue("@Estatus", obj.Estatus);

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



        public DataSet sp_SelectColores(Entity.InventarioEntity.coloresEntity obj)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlConnection connection = new SqlConnection(GetConnectionString());
            DataSet ds;

            connection.Open();
            SqlCommand cmd = new SqlCommand("sp_SelectColor", connection);
            cmd.Parameters.AddWithValue("@idColor", obj.idColor);
           //    cmd.Parameters.AddWithValue("@idUsuarioCamrio", obj.idUsuarioCambio);
            cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
            cmd.Parameters.AddWithValue("@Codigo", obj.codigo);
            cmd.Parameters.AddWithValue("@codigoPaleta", obj.codigoPaleta);
            cmd.Parameters.AddWithValue("@Estatus", obj.Estatus);
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

        public bool sp_DeleteColor(int idColor)
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
                sqlCommand.CommandText = "[sp_DeleteColores]"; //sqlCommand = new SqlCommand("Sp_DeleteUsuario", connection);
                sqlCommand.Parameters.AddWithValue("@idColor", idColor);
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

        public int sp_InsertEditColor(Entity.InventarioEntity.coloresEntity obj)
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
                cmd.CommandText = "sp_InsertEditColores";
                cmd.Parameters.AddWithValue("@idColor", obj.idColor);
                cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                cmd.Parameters.AddWithValue("@Codigo", obj.codigo);
                cmd.Parameters.AddWithValue("@CodigoPaleta", obj.codigoPaleta);
                cmd.Parameters.AddWithValue("@Estatus", obj.Estatus);
                cmd.Parameters.AddWithValue("@Amarillo", obj.Amarillo);
                cmd.Parameters.AddWithValue("@Magenta", obj.Magenta);
                cmd.Parameters.AddWithValue("@Cian", obj.Cian);
                cmd.Parameters.AddWithValue("@Rojo", obj.Rojo);
                cmd.Parameters.AddWithValue("@Azul", obj.Azul);
                cmd.Parameters.AddWithValue("@Verde", obj.Verde);
                cmd.Parameters.AddWithValue("@Blanco", obj.Blanco);
                cmd.Parameters.AddWithValue("@Negro", obj.Negro);
                cmd.Parameters.AddWithValue("@Plateado", obj.Plateado);
                cmd.Parameters.AddWithValue("@Dorado", obj.Dorado);
                cmd.Parameters.AddWithValue("@idUsuarioCambio", obj.idUsuarioCambio);

                var returnParameter = cmd.Parameters.Add("@return_value", SqlDbType.Int);
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
