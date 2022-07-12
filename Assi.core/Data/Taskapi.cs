using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment.Data
{
    public partial class Taskapi
    {
        public Taskapi()
        {
            Emptasks = new HashSet<Emptask>();
        }

        public decimal Taskid { get; set; }
        public string Taskname { get; set; }

        public virtual ICollection<Emptask> Emptasks { get; set; }
    }
}
