using Assignment.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assi.core.Repository
{
    public interface ITaskApiRepository
    {
        public string insert(Taskapi taskapi);
        public string update(Taskapi taskapi );

        public string delete(int id);

        public List<Taskapi> getall();
    }
}
