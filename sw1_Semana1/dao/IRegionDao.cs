using sw1_Semana1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sw1_Semana1.dao
{
    internal interface IRegionDao
    {
        int operacionesEscritura(string indicador, Regions reg);
        List<Regions> OperacionesLectura(string indicador, Regions reg);
    }
}
