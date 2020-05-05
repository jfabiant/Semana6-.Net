using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DCategoria
    {
        public List<Categoria> Get()
        {
            string comandText = string.Empty;
            List<Categoria> categoriaList = null;

            try
            {
                comandText = "USP_GetCategoria";
                categoriaList = new List<Categoria>();
                using (SqlDataReader reader = SQLHelper.ExecuteReader(SQLHelper.Connection, comandText, CommandType.StoredProcedure))
                {
                    while (reader.Read())
                    {
                        categoriaList.Add(new Categoria
                        {
                            IdCategoria = reader["idcategoria"] != null ? Convert.ToInt32(reader["idcategoria"]) : 0,
                            NombreCategoria = reader["nombrecategoria"] != null ? Convert.ToString(reader["nombrecategoria"]) : string.Empty,
                            Descripcion = reader["descripcion"] != null ? Convert.ToString(reader["descripcion"]) : string.Empty
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return categoriaList;
        }

        public void Insert(Categoria categoria)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            try
            {
                comandText = "USP_InsCategoria";
                parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@idcategoria", SqlDbType.Int);
                parameters[0].Value = categoria.IdCategoria;
                parameters[1] = new SqlParameter("@nombrecategoria", SqlDbType.VarChar);
                parameters[1].Value = categoria.NombreCategoria;
                parameters[2] = new SqlParameter("@descripcion", SqlDbType.VarChar);
                parameters[2].Value = categoria.Descripcion;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, comandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Categoria categoria)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            try
            {
                comandText = "USP_UpdCategoria";
                parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@idcategoria", SqlDbType.Int);
                parameters[0].Value = categoria.IdCategoria;
                parameters[1] = new SqlParameter("@nombrecategoria", SqlDbType.VarChar);
                parameters[1].Value = categoria.NombreCategoria;
                parameters[2] = new SqlParameter("@descripcion", SqlDbType.VarChar);
                parameters[2].Value = categoria.Descripcion;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, comandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int idcategoria)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            try
            {
                comandText = "USP_DelCategoria";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idcategoria", SqlDbType.Int);
                parameters[0].Value = idcategoria;
                SQLHelper.ExecuteNonQuery(SQLHelper.Connection, comandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}