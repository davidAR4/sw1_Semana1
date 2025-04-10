using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net.Configuration;
using System.Web;
using sw1_Semana1.Models;

namespace sw1_Semana1.dao.DaoImpl
{
    public class DepartamentImpl : IDepartamentDao
    {
        public List<Department> operacionesEscritura(string indicador, Department objdepartament)
        {
            List<Department> listar = new List<Department>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxhr0"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_crud_departament1"))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@indicador", indicador);
                        cmd.Parameters.AddWithValue("@department_id", objdepartament.department_id);
                        cmd.Parameters.AddWithValue("@department_name", objdepartament.department_name);
                        cmd.Parameters.AddWithValue("@location_id", objdepartament.location_id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                int ordinalDepartmentId = reader.GetOrdinal("department_id");
                                int ordinalDepartmentName = reader.GetOrdinal("department_bame");
                                int ordinalLocationId = reader.GetOrdinal("location_id");
                                Department depa;
                                while (reader.Read())
                                {
                                    depa = new Department();
                                    depa.department_id = reader.GetInt32(ordinalDepartmentId);
                                    depa.department_name = reader.GetString(ordinalDepartmentName);
                                    depa.location_id = reader.GetInt32(ordinalLocationId);
                                    listar.Add(depa);

                                }

                            }
                        }
                    }
                }

            }
            catch (Exception e) { 
                Debug.WriteLine("operacionesEscritura - Error : " + e.Message);
            }return listar;
        }
    }
}