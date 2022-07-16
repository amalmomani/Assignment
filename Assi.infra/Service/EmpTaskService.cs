using Assi.core.Repository;
using Assi.core.Service;
using Assignment.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assi.infra.Service
{
    public class EmpTaskService : IEmpTaskService
    {
        private readonly IEmpTaskRepository repo;
        public EmpTaskService(IEmpTaskRepository repo)
        {
            this.repo = repo;
        }
        public string delete(int id)
        {
            return repo.delete(id);
        }

        public List<Emptask> getall()
        {
            return repo.getall();
        }

        public string insert(Emptask emptask)
        {
            return repo.insert(emptask);
        }

        public string update(Emptask emptask)
        {
            return repo.update(emptask);
        }
        public List<string> CountNameTask()
        {
            return repo.CountNameTask();
        }
    }
}
