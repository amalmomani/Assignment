using Assignment.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assi.core.Service
{
    public interface IEmpTaskService
    {
        public bool insert(Emptask emptask);
        public bool update(Emptask emptask);

        public bool delete(int id);

        public List<Emptask> getall();
    }
}
