using System;
using System.Collections.Generic;
using System.Text;

namespace Assi.core.DTO
{
    public class CheckDateDTO
    {
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public string Employee { get; set; }
        public string Email { get; set; }
    }
}
