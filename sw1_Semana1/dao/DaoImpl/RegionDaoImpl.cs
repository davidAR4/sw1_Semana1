using sw1_Semana1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace sw1_Semana1.dao.DaoImpl
{
    public class RegionDaoImpl : IRegionDao
    {
        public int operacionesEscritura(string indicador, Regions reg)
        {
            int procesar = -1;

            try { 
            string cxd = ConfigurationManager.ConnectionStrings["cnxhr0"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cxd)) 
            { 
                con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_regions_crud4", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@indicador", indicador);
                        cmd.Parameters.AddWithValue("@region_id", reg.region_id);
                        cmd.Parameters.AddWithValue("@region_name", reg.region_name);
                        procesar = cmd.ExecuteNonQuery();
                    }    
                }
            } catch (Exception ex) {
                Debug.WriteLine("OperacionEscritura - Error : " + ex.Message);
                Debug.WriteLine("OperacionEscritura - Error : " + ex.ToString());
            }
            return procesar;


        }

        public List<Regions> OperacionesLectura(string indicador, Regions reg)
        {
            List<Regions> lista = new List<Regions>();
            try
            {
                string cadConexion = ConfigurationManager.ConnectionStrings["cnxhr0"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cadConexion))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_regions_crud4",con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@indicador", indicador);
                        cmd.Parameters.AddWithValue("@region_id", reg.region_id);
                        cmd.Parameters.AddWithValue("@region_name", reg.region_name);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            if (reader.HasRows)
                            {
                                int ordinalRegionId = reader.GetOrdinal("region_id");
                                int ordinalRegionName = reader.GetOrdinal("region_name");
                                Regions objregion;

                                while (reader.Read())
                                {
                                    objregion = new Regions();
                                    objregion.region_id = reader.GetInt32(ordinalRegionId);
                                    objregion.region_name = reader.GetString(ordinalRegionName);
                                    lista.Add(objregion);
                                }

                            }

                        }
                    }
                }

            }catch(Exception ex)
            {
                Debug.WriteLine("operacionesLectura-Error: " + ex.Message);
                Debug.WriteLine("operacionesLectura-Error: " + ex.ToString());

            }
            return lista;
        }
    }
}