using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sw1_Semana1.Models
{
    public class Employeds
    {
        public int? employe_id { get; set; }
        public string  first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public DateTime? hire_date { get; set; }
        public int? job_id { get; set; }
        public Decimal? salary { get; set; }
        public int? manager_id { get; set; }
        public int?department_id { get; set; }

        public Employeds()
        {
            this.employe_id = 0;
            this.first_name = "";
            this.last_name = "";
            this.email = "";
            this.phone_number = "";
            this.hire_date = null;
            this.job_id = 0;
            this.salary = 0m;
            this.manager_id = 0;
            this.department_id = 0;
        }


    }
}