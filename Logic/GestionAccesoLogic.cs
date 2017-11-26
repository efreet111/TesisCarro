using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;

namespace Logic
{
    public class GestionAccesoLogic
    {
        Data.GestionAccesoData dac;

        public GestionAccesoLogic()
        {
            dac = new Data.GestionAccesoData();
        }



        public List<Entity.GestionAccesoEntity.PerfilEntity> ObtenerPerfilLogic(Entity.GestionAccesoEntity.PerfilEntity obj )
        {
            List<Entity.GestionAccesoEntity.PerfilEntity> result = null;
            DataSet ds = null;
            Entity.GestionAccesoEntity.PerfilEntity item = null;

            try
            {
                ds = dac.Sp_SelectPerfil(obj);

                result = new List<Entity.GestionAccesoEntity.PerfilEntity>();

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        item = new Entity.GestionAccesoEntity.PerfilEntity();

                        item.idPerfil = (dr["idPerfil"] != DBNull.Value) ? Convert.ToInt32(dr["idPerfil"]) : (int?)null;
                        item.Nombre = (dr["Nombre"] != DBNull.Value) ? dr["Nombre"].ToString() : String.Empty;
                        item.Activo = (dr["Activo"].ToString() == "1") ? true : false;
                        item.nomActivo = (dr["nomActivo"] != DBNull.Value) ? dr["nomActivo"].ToString() : String.Empty;
                        result.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public List<Entity.GestionAccesoEntity.UsuarioEntity> ObtenerUsuarioLogic(Entity.GestionAccesoEntity.UsuarioEntity obj)
        {
            List<Entity.GestionAccesoEntity.UsuarioEntity> result = null;
            DataSet ds = null;
            Entity.GestionAccesoEntity.UsuarioEntity item = null;

            try
            {
                ds = dac.Sp_SelectUsuario(obj);

                result = new List<Entity.GestionAccesoEntity.UsuarioEntity>();

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        item = new Entity.GestionAccesoEntity.UsuarioEntity();

                        item.idEstatus = (dr["idEstatus"] != DBNull.Value) ? Convert.ToInt32(dr["idEstatus"]) : (int?)null;
                        //item.Correo = (dr["Correo"] != DBNull.Value) ? dr["Correo"].ToString() : String.Empty;
                        //item.idPerfil = (dr["idPerfil"] != DBNull.Value) ? Convert.ToInt32(dr["idPerfil"]) : (int?)null;
                        //item.idUsuario = (dr["idUsuario"] != DBNull.Value) ? Convert.ToInt32(dr["idUsuario"]) : (int?)null;
                        //item.Nombre = (dr["NombreUsuario"] != DBNull.Value) ? dr["NombreUsuario"].ToString() : String.Empty;
                        //item.Pwd = (dr["Pwd"] != DBNull.Value) ? dr["Pwd"].ToString() : String.Empty;
                        //item.nomEstatus = (dr["nomEstatus"] != DBNull.Value) ? dr["nomEstatus"].ToString() : String.Empty;
                        //item.NombrePerfil = (dr["NombrePerfil"] != DBNull.Value) ? dr["NombrePerfil"].ToString() : String.Empty;
                        result.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public Boolean EliminarUsuario(int idUsuario)
        {
            Boolean result = false;

            try
            {
                result = dac.Sp_DeleteUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int InsertUpdateUsuario(Entity.GestionAccesoEntity.UsuarioEntity obj)
        {
            int result = 0;

            try
            {
                result = dac.Sp_InsertUpdateUsuario(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }




    }
}
