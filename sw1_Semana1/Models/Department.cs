using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sw1_Semana1.Models
{
    public class Department
    {
        public int department_id { get; set; }
        public string department_name { get; set; }
        public int location_id { get; set; }
        public Department()
        {
            this.department_id = 0;
            this.department_name = "";
            this.location_id = 0;
        }
    }
}