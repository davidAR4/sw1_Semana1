using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sw1_Semana1.Models;

namespace sw1_Semana1.dao
{
    internal interface IDepartamentDao
    {
        List<Department> operacionesEscritura(string indicador, Department  objdepartament);
    }
}
