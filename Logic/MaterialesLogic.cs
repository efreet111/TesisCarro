using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;

namespace Logic
{
    public class MaterialesLogic
    {
        Data.MaterialesDataAccess dac;

        public MaterialesLogic()
        {
            dac = new Data.MaterialesDataAccess();
        }


        public List<Entity.InventarioEntity.MaterialEntity> ObtenerMateriales(Entity.InventarioEntity.MaterialEntity obj)
        {
            List<Entity.InventarioEntity.MaterialEntity> result = null;
            DataSet ds = null;
            Entity.InventarioEntity.MaterialEntity item = null;

            try
            {
                ds = dac.sp_SelectMateriales(obj);

                result = new List<Entity.InventarioEntity.MaterialEntity>();

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        item = new Entity.InventarioEntity.MaterialEntity();

                        item.id = (dr["id"] != DBNull.Value) ? Convert.ToInt32(dr["id"]) : (int?)null;
                        //item.idUsuarioCambio = (dr["idUsuarioCambio"] != DBNull.Value) ? Convert.ToInt32(dr["idUsuarioCambio"]) : (int?)null;
                        item.Nombre = (dr["Nombre"] != DBNull.Value) ? dr["Nombre"].ToString() : String.Empty;
                        item.Estatus = (dr["Estatus"] != DBNull.Value) ? dr["Estatus"].ToString() : String.Empty;
                        item.cantidad = (dr["cantidad"] != DBNull.Value) ? Convert.ToInt32(dr["cantidad"]) : (int?)null;
                        item.idTipo = (dr["idTipo"] != DBNull.Value) ? Convert.ToInt32(dr["idTipo"]) : (int?)null;
                        item.Codigo = (dr["Codigo"] != DBNull.Value) ? dr["Codigo"].ToString() : String.Empty;
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

        public Boolean EliminarMateriales(int id)
        {
            Boolean result = false;

            try
            {
                result = dac.sp_DeleteMateriales(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int InsertUpdateMateriales(Entity.InventarioEntity.MaterialEntity obj)
        {
            int result = 0;
           
            try
            {
                result = dac.sp_InsertEditMateriales(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


        public List<Entity.InventarioEntity.TipoEntity> Obtenertipo(Entity.InventarioEntity.TipoEntity obj)
        {
            List<Entity.InventarioEntity.TipoEntity> result = null;
            DataSet ds = null;
            Entity.InventarioEntity.TipoEntity item = null;

            try
            {
                ds = dac.sp_SelectTipo(obj);

                result = new List<Entity.InventarioEntity.TipoEntity>();

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        item = new Entity.InventarioEntity.TipoEntity();

                        item.idTipo = (dr["idTipo"] != DBNull.Value) ? Convert.ToInt32(dr["id"]) : (int?)null;
                        item.idUsuarioCambio = (dr["idUsuarioCambio"] != DBNull.Value) ? Convert.ToInt32(dr["idUsuarioCambio"]) : (int?)null;
                        item.Nombre = (dr["Nombre"] != DBNull.Value) ? dr["Nombre"].ToString() : String.Empty;
                        item.Estatus = (dr["Estatus"] != DBNull.Value) ? dr["Estatus"].ToString() : String.Empty;
                        item.Descripcion = (dr["Descripcion"] != DBNull.Value) ? dr["Codigo"].ToString() : String.Empty;
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

        public Boolean EliminarTipo(int id)
        {
            Boolean result = false;

            try
            {
                result = dac.sp_DeleteTipo(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public int InsertUpdateTipo(Entity.InventarioEntity.TipoEntity obj)
        {
            int result = 0;

            try
            {
                result = dac.sp_InsertEditTipo(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

    }
}
