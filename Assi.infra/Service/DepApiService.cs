using Assi.core.Repository;
using Assi.core.Service;
using Assignment.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assi.infra.Service
{
    public class DepApiService : IDepApiService
    {
        private readonly IDepApiRepository repo;
        public DepApiService(IDepApiRepository repo)
        {
            this.repo = repo;
        }
        public string delete(int id)
        {
            return repo.delete(id);
        }

        public List<Depapi> getall()
        {
            return repo.getall();
        }

        public string insert(Depapi depapi)
        {
            return repo.insert(depapi);
        }

        public string update(Depapi depapi)
        {
            return repo.update(depapi);
        }
    }
}
