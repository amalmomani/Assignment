using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment.Data
{
    public partial class Checkapi
    {
        public Checkapi()
        {
            Checkemps = new HashSet<Checkemp>();
        }

        public decimal Checkid { get; set; }
        public DateTime? Checkin { get; set; }
        public DateTime? Checkout { get; set; }

        public virtual ICollection<Checkemp> Checkemps { get; set; }
    }
}
