using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sw1_Semana1.Models
{
    public class Countries
    {
        public string country_id { get; set; }

        public string country_name { get; set; }

        public int region_id { get; set; }



      
        public Countries()
        {
            this.country_id = "";
            this.country_name = "";
            this.region_id = 0;
        }
    }
}