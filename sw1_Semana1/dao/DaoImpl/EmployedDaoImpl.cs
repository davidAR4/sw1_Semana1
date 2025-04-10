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
            throw new NotImplementedException();
        }

        // Método para realizar operaciones de lectura (consulta) de empleados
        public List<Employeds> OperacionesLectura(string indicador, Employeds objEmployeds)
        {
            // Lista para almacenar los empleados obtenidos de la base de datos
            List<Employeds> lista = new List<Employeds>();

            try
            {
                // Establece la conexión con la base de datos usando la cadena de conexión
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnxhr0"].ConnectionString))
                {
                    conn.Open();

                    // Comando SQL para ejecutar el procedimiento almacenado 'usp_employeds_crud2'
                    using (SqlCommand cmd = new SqlCommand("usp_employeds_crud2", conn))
                    {
                        // Definimos el tipo de comando como procedimiento almacenado
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Clear();

                        // Asignación de parámetros a los valores recibidos en el objeto `objEmployeds`
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

                        // Ejecuta el lector de datos para obtener los resultados
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Verifica si hay filas en los resultados
                            if (reader.HasRows)
                            {
                                // Obtención de los índices de las columnas para mapear los datos
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

                                // Mientras haya filas que leer, se crea un objeto Employeds por cada fila
                                while (reader.Read())
                                {
                                    // Creamos un nuevo objeto Employeds para cada fila
                                    Employeds emp = new Employeds();

                                    // Asignamos los valores a las propiedades del objeto, manejando valores nulos con IsDBNull
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

                                    // Agregamos el objeto empleado a la lista
                                    lista.Add(emp);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Si ocurre algún error, lo imprimimos en la consola de depuración
                Debug.WriteLine("OperacionesLectura - Error : " + e.Message);
            }

            // Devolvemos la lista de empleados obtenida
            return lista;
        }
    }
}
