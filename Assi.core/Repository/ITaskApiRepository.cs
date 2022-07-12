using Assignment.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assi.core.Repository
{
    public interface ITaskApiRepository
    {
        public bool insert(Taskapi taskapi);
        public bool update(Taskapi taskapi );

        public bool delete(int id);

        public List<Taskapi> getall();
    }
}
