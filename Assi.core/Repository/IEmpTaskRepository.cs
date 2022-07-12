using Assignment.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assi.core.Repository
{
    public interface IEmpTaskRepository
    {
        public bool insert(Emptask emptask);
        public bool update(Emptask emptask);

        public bool delete(int id);

        public List<Emptask> getall();
    }
}
