using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sw1_Semana1.Models;

namespace sw1_Semana1.dao
{
    internal interface IEmployedsDao
    {
        int operacionesEscritura(string indicador, Employeds objEmployeds);
        List<Employeds> OperacionesLectura(string indicador, Employeds objEmployeds);
    }
}
