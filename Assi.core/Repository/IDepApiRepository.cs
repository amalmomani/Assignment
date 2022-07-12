using Assignment.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assi.core.Repository
{
    public interface IDepApiRepository
    {
        public bool insert(Depapi depapi);
        public bool update(Depapi depapi);

        public bool delete(int id);

        public List<Depapi> getall();
    }
}
