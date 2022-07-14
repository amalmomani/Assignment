using Assi.core.Repository;
using Assi.core.Service;
using Assignment.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assi.infra.Service
{
    public class CheckEmpService : ICheckEmpService
    {
        private readonly ICheckEmpRepository repo;
        public CheckEmpService(ICheckEmpRepository repo)
        {
            this.repo = repo;
        }
        public string delete(int id)
        {
            return repo.delete(id);
        }

        public List<Checkemp> getall()
        {
            return repo.getall();
        }

        public string insert(Checkemp checkemp)
        {
            return repo.insert(checkemp);
        }

        public string update(Checkemp checkemp)
        {
            return repo.update(checkemp);
        }
        public List<string> FilterDate(Checkapi checkapi)
        {
            return repo.FilterDate(checkapi);
        } 
    }
}
