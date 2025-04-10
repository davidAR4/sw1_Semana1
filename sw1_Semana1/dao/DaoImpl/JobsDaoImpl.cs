using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Management;
using sw1_Semana1.Models;

namespace sw1_Semana1.dao.DaoImpl
{
    public class JobsDaoImpl : IJobsDao
    {
        public List<Jobs> OperacionesLectura(string indicador, Jobs objJobs)
        {
            List<Jobs> listar = new List<Jobs>();

            try
            {   //la conexion de la bd
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxhr0"].ConnectionString))
                {

                   
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("usp_jobs_crud1", conn))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@indicador", indicador);
                            cmd.Parameters.AddWithValue("@job_id", objJobs.job_id);
                            cmd.Parameters.AddWithValue("@job_title", objJobs.job_title);
                            cmd.Parameters.AddWithValue("@min_salary", objJobs.min_salary);
                            cmd.Parameters.AddWithValue("@max_salary", objJobs.max_salary);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    int ordinalJobId = reader.GetOrdinal("job_id");
                                    int ordinalJobTitle = reader.GetOrdinal("job_title");
                                    int ordinalMinSalary = reader.GetOrdinal("min_salary");
                                    int ordinalMaxSalary = reader.GetOrdinal("max_salary");
                                    Jobs job;
                                    while (reader.Read())
                                    {
                                            job = new Jobs();
                                            job.job_id = reader.GetInt32(ordinalJobId);  
                                            job.job_title = reader.GetString(ordinalJobTitle);
                                            job.max_salary = reader.GetDecimal(ordinalMinSalary);
                                            job.min_salary = reader.GetDecimal(ordinalMaxSalary);
                                        
                                        listar.Add(job);
                                    }
                                }
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en OperacionesLectura: " + ex.Message);
            }
            return listar;
        }
    }}