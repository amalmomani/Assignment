using Assi.core.Repository;
using Assi.core.Service;
using Assignment.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assi.infra.Service
{
    public class CheckApiService : ICheckapiService
    {
        private readonly ICheckApiRepository repo;
        public CheckApiService(ICheckApiRepository repo)
        {
            this.repo = repo;
        }
        public string delete(int id)
        {
            return repo.delete(id);
        }

        public List<Checkapi> getall()
        {
            return repo.getall();
        }

        public string insert(Checkapi checkapi)
        {
            return repo.insert(checkapi);
        }

        public string update(Checkapi checkapi)
        {
            return repo.update(checkapi);
        }
    }
}
