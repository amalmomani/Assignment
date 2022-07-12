using Assignment.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assi.core.Service
{
    public interface IEmpTaskService
    {
        public string insert(Emptask emptask);
        public string update(Emptask emptask);

        public string delete(int id);

        public List<Emptask> getall();
    }
}
