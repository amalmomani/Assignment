using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment.Data
{
    public partial class Empapi
    {
        public Empapi()
        {
            Emptasks = new HashSet<Emptask>();
        }

        public decimal Empid { get; set; }
        public string Empname { get; set; }
        public string Empemail { get; set; }
        public decimal? Salary { get; set; }
        public decimal? Depid { get; set; }

        public virtual Depapi Dep { get; set; }
        public virtual ICollection<Emptask> Emptasks { get; set; }
    }
}
