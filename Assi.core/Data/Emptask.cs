using System;
using System.Collections.Generic;

#nullable disable

namespace Assignment.Data
{
    public partial class Emptask
    {
        public decimal Id { get; set; }
        public decimal? Empid { get; set; }
        public decimal? Taskid { get; set; }

        public virtual Empapi Emp { get; set; }
        public virtual Taskapi Task { get; set; }
    }
}
