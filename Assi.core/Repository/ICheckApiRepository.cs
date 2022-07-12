using Assignment.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assi.core.Repository
{
    public interface ICheckApiRepository
    {
        public string insert(Checkapi checkapi);
        public string update(Checkapi checkapi);

        public string delete(int id);

        public List<Checkapi> getall();
    }
}
