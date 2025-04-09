using sw1_Semana1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace sw1_Semana1.dao.DaoImpl
{
    public class CountriesDaoImpl : ICountriesDao
    {
        public int operacionesEscritura(string indicador, Countries objCountries)
        {
                                
            int procesar = -1; //sirve para que cuando se registre un nuevo valor te rediriga a la pagina,
                               //en cambio si no registra se queda en la misma pagina de registrar, por una restriccion de la bd o algo parecido
            try
            {       //el using se usa para poder abrir y cerrar conexion automaticamente
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxhr0"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_paises_crud", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@indicador", indicador);
                        cmd.Parameters.AddWithValue("@country_id", objCountries.country_id);
                        cmd.Parameters.AddWithValue("@country_name", objCountries.country_name);
                        cmd.Parameters.AddWithValue("@region_id", objCountries.region_id);
                        procesar = cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("operacionesEscritura - Error : " + ex.ToString());
            }
            return procesar;

        }


        public List<Countries> operacionesLectura(string indicador, Countries objCountries)
        {
            List<Countries> listar = new List<Countries>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxhr0"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_paises_crud", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@indicador", indicador);
                        cmd.Parameters.AddWithValue("@country_id", objCountries.country_id);
                        cmd.Parameters.AddWithValue("@country_name", objCountries.country_name);
                        cmd.Parameters.AddWithValue("@region_id", objCountries.region_id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if(reader.HasRows) //sirve para verificar que la lista o tabla no este vacia
                            {
                                int ordinalCodigo = reader.GetOrdinal("country_id");
                                int ordinalNombre = reader.GetOrdinal("country_name");
                                int ordinalRegion = reader.GetOrdinal("region_id");
                                Countries pais;
                                while(reader.Read())  //lee toda la tabla y lo reccorre con el while
                                {
                                    pais = new Countries();
                                    pais.country_id = reader.GetString(ordinalCodigo);
                                    pais.country_name = reader.GetString(ordinalNombre);
                                    pais.region_id = reader.GetInt32(ordinalRegion);
                                    listar.Add(pais);

                                }
                            }


                        }
                    
                    }

                }
            }
            catch (Exception e) { 
                Debug.WriteLine("operacionesLectura - Error : " + e.ToString());
            }
            return listar;
        }   
    }
}