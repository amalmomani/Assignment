using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment.Data
{
    public partial class Checkemp
    {
        public decimal Id { get; set; }
        public decimal? Empid { get; set; }
        public decimal? Checkid { get; set; }

        public virtual Checkapi Check { get; set; }
    }
}
