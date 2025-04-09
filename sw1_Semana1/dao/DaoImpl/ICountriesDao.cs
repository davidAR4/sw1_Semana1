using sw1_Semana1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sw1_Semana1.dao.DaoImpl
{
    internal interface ICountriesDao
    {
        int operacionesEscritura(string indicador, Countries objCountries);
        List<Countries> operacionesLectura(string indicador, Countries objCountries);
    }
}
