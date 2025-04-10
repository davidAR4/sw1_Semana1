using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sw1_Semana1.Models
{
    public class Jobs
    {
        public int job_id { get; set; }
        public string job_title { get; set; }
        public Decimal min_salary { get; set; }
        public Decimal max_salary { get; set; }
        public Jobs()
        {
            this.job_id = 0;
            this.job_title = "";
            this.min_salary = 0;
            this.max_salary = 0;
        }
    }
}