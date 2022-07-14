using Assi.core.Repository;
using Assi.core.Service;
using Assignment.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assi.infra.Service
{
    public class EmpApiService : IEmpApiService
    {
        private readonly IEmpApiRepository repo;
        public EmpApiService(IEmpApiRepository repo)
        {
            this.repo = repo;
        }
        public string delete(int id)
        {
            return repo.delete(id);
        }

        public List<Empapi> getall()
        {
            return repo.getall();
        }

        public List<string> getNameSalarydep()
        {
            return repo.getNameSalarydep();
        }
        public List<string> getNameTask()
        {
            return repo.getNameTask();
        }

        public string insert(Empapi empapi)
        {
            return repo.insert(empapi);
        }

        public string update(Empapi empapi)
        {
            return repo.update(empapi);
        }
        public string count()
        {
            return repo.count();
        }
        public string sum()
        {
            return repo.sum();
        }
        public string avg()
        {
            return repo.avg();
        }
    }
}
