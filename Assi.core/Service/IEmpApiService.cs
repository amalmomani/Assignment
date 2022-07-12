using Assignment.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assi.core.Service
{
    public interface IEmpApiService
    {
        public string insert(Empapi empapi);
        public string update(Empapi empapi);

        public string delete(int id);

        public List<Empapi> getall();
    }
}
