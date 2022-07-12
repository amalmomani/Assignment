using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment.Data
{
    public partial class Depapi
    {
        public Depapi()
        {
            Empapis = new HashSet<Empapi>();
        }

        public decimal Depid { get; set; }
        public string Depname { get; set; }
        public decimal? Depphone { get; set; }

        public virtual ICollection<Empapi> Empapis { get; set; }
    }
}
