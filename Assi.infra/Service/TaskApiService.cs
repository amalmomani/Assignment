using Assi.core.Repository;
using Assi.core.Service;
using Assignment.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assi.infra.Service
{
    public class TaskApiService : ITaskApiService
    {
        private readonly ITaskApiRepository repo;
        public TaskApiService(ITaskApiRepository repo)
        {
            this.repo = repo;
        }
        public string delete(int id)
        {
            return repo.delete(id);
        }

        public List<Taskapi> getall()
        {
            return repo.getall();
        }

        public string insert(Taskapi taskapi)
        {
            return repo.insert(taskapi);
        }

        public string update(Taskapi taskapi)
        {
            return repo.update(taskapi);
        }
        public Taskapi getbyid(int id)
        {
            return repo.getbyid(id);
        }
    }
}
