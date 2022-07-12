using Assignment.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assi.core.Repository
{
    public interface IEmpApiRepository
    {
        public bool insert(Empapi empapi);
        public bool update(Empapi empapi);

        public bool delete(int id);

        public List<Empapi> getall();
    }
}
