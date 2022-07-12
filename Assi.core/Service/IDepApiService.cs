using Assignment.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assi.core.Service
{
    public interface IDepApiService
    {
        public string insert(Depapi depapi);
        public string update(Depapi depapi);

        public string delete(int id);

        public List<Depapi> getall();
    }
}
