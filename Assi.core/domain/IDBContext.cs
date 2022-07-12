using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Assi.core.domain
{
    public interface IDBContext
    {
        public DbConnection dBConnection { get; }
    }
}
