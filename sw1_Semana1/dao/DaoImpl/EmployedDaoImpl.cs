using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using sw1_Semana1.Models;

namespace sw1_Semana1.dao.DaoImpl
{
    // Clase que implementa la interfaz IEmployedsDao para operaciones con empleados
    public class EmployedDaoImpl : IEmployedsDao
    {
        // Método de escritura, actualmente no implementado
        public int operacionesEscritura(string indicador, Employeds objEmployeds)
        {
            int procesar = -1; //sirve para ver si se registro un nuevo valor o no, si no se registra se queda en la misma pagina de registrar, por una restriccion de la bd o algo parecido
            try {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxhr0"].ConnectionString))
                   
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_employeds_crud3", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                  
                        cmd.Parameters.AddWithValue("@indicador", indicador);
                        cmd.Parameters.AddWithValue("@employe_id", objEmployeds.employe_id ?? (object)DBNull.Value); // Asignación de nulos de manera segura
                        cmd.Parameters.AddWithValue("@first_name", objEmployeds.first_name ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@last_name", objEmployeds.last_name ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@email", objEmployeds.email ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@phone_number", objEmployeds.phone_number ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@hire_date", objEmployeds.hire_date ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@job_id", objEmployeds.job_id ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@salary", objEmployeds.salary.HasValue ? objEmployeds.salary.Value : (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@manager_id", objEmployeds.manager_id ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@departament_id", objEmployeds.department_id ?? (object)DBNull.Value);
                        procesar = cmd.ExecuteNonQuery(); // Ejecuta el comando y si funciona redirige a la vista que le corresponde
                    }
                }
            }
            catch (Exception e)
            {
                // Si ocurre algún error, lo imprimimos en la consola de depuración
                Debug.WriteLine("OperacionesEscritura - Error : " + e.Message);
            } return procesar; // Devolvemos el resultado de la operación
        }

        // Método para realizar operaciones de lectura (consulta) de empleados
        public List<Employeds> OperacionesLectura(string indicador, Employeds objEmployeds)
        {
          
            List<Employeds> lista = new List<Employeds>();

            try
            {
   
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxhr0"].ConnectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("usp_employeds_crud3", conn))
                    {
                    
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Clear();

                    
                        cmd.Parameters.AddWithValue("@indicador", indicador);
                        cmd.Parameters.AddWithValue("@employe_id", objEmployeds.employe_id ?? (object)DBNull.Value); // Asignación de nulos de manera segura
                        cmd.Parameters.AddWithValue("@first_name", objEmployeds.first_name ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@last_name", objEmployeds.last_name ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@email", objEmployeds.email ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@phone_number", objEmployeds.phone_number ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@hire_date", objEmployeds.hire_date ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@job_id", objEmployeds.job_id ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@salary", objEmployeds.salary ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@manager_id", objEmployeds.manager_id ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@departament_id", objEmployeds.department_id ?? (object)DBNull.Value);

                     
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Verifica si hay filas en los resultados
                            if (reader.HasRows)
                            {
                              
                                int ordinalEmployeId = reader.GetOrdinal("employee_id");
                                int ordinalFirstName = reader.GetOrdinal("first_name");
                                int ordinalLastName = reader.GetOrdinal("last_name");
                                int ordinalEmail = reader.GetOrdinal("email");
                                int ordinalPhoneNumber = reader.GetOrdinal("phone_number");
                                int ordinalHireDate = reader.GetOrdinal("hire_date");
                                int ordinalJobId = reader.GetOrdinal("job_id");
                                int ordinalSalary = reader.GetOrdinal("salary");
                                int ordinalManagerId = reader.GetOrdinal("manager_id");
                                int ordinalDepartmentId = reader.GetOrdinal("department_id");

                                while (reader.Read())
                                {
                               
                                    Employeds emp = new Employeds();

                                   
                                    emp.employe_id = reader.IsDBNull(ordinalEmployeId) ? (int?)null : reader.GetInt32(ordinalEmployeId);
                                    emp.first_name = reader.IsDBNull(ordinalFirstName) ? null : reader.GetString(ordinalFirstName);
                                    emp.last_name = reader.IsDBNull(ordinalLastName) ? null : reader.GetString(ordinalLastName);
                                    emp.email = reader.IsDBNull(ordinalEmail) ? null : reader.GetString(ordinalEmail);
                                    emp.phone_number = reader.IsDBNull(ordinalPhoneNumber) ? null : reader.GetString(ordinalPhoneNumber);
                                    emp.hire_date = reader.IsDBNull(ordinalHireDate) ? (DateTime?)null : reader.GetDateTime(ordinalHireDate);
                                    emp.job_id = reader.IsDBNull(ordinalJobId) ? (int?)null : reader.GetInt32(ordinalJobId);
                                    emp.salary = reader.IsDBNull(ordinalSalary) ? (decimal?)null : reader.GetDecimal(ordinalSalary);
                                    emp.manager_id = reader.IsDBNull(ordinalManagerId) ? (int?)null : reader.GetInt32(ordinalManagerId);
                                    emp.department_id = reader.IsDBNull(ordinalDepartmentId) ? (int?)null : reader.GetInt32(ordinalDepartmentId);

                                
                                    lista.Add(emp);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("OperacionesLectura - Error : " + e.Message);
            }

            return lista;
        }
    }
}
