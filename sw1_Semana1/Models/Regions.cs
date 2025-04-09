using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sw1_Semana1.Models
{
    public class Regions
    {
        public int region_id { get; set; }
        public string region_name { get; set; }



        public Regions()
        {
               this.region_id = 0;
               this.region_name = "";

        }
    }

}