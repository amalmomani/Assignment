using Assi.core.domain;
using Assi.core.Repository;
using Assignment.Data;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Assi.infra.Repository
{
    public class TaskApiRepository : ITaskApiRepository
    {
        private readonly IDBContext dbContext;
        public TaskApiRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public string delete(int id)
        {
            try
            {
                var parameter = new DynamicParameters();
                parameter.Add("idofTaskApi", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                var result = dbContext.dBConnection.ExecuteAsync("TaskApi_package_api.deleteTaskApi", parameter, commandType: CommandType.StoredProcedure);
                if (result == null)
                    return "Something went wrong";
                else
                    return "Deleted!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Taskapi> getall()
        {
            IEnumerable<Taskapi> result = dbContext.dBConnection.Query<Taskapi>("TaskApi_package_api.getallTaskApi", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public string insert(Taskapi taskapi)
        {
            try
            {
                var paramenter = new DynamicParameters();
                paramenter.Add("idofTaskApi", taskapi.Taskid, dbType: DbType.Int32, direction: ParameterDirection.Input);
                paramenter.Add("nameOfTask", taskapi.Taskname, dbType: DbType.String, direction: ParameterDirection.Input);

                var result = dbContext.dBConnection.ExecuteAsync("TaskApi_package_api.createinsertTaskApi", paramenter, commandType: CommandType.StoredProcedure);
                return "Task: " + taskapi.Taskname + ", inserted!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string update(Taskapi taskapi)
        {
            try
            {
                var paramenter = new DynamicParameters();
                paramenter.Add("idofTaskApi", taskapi.Taskid, dbType: DbType.Int32, direction: ParameterDirection.Input);
                paramenter.Add("nameOfTask", taskapi.Taskname, dbType: DbType.String, direction: ParameterDirection.Input);

                var result = dbContext.dBConnection.ExecuteAsync("TaskApi_package_api.UpdateTaskApi", paramenter, commandType: CommandType.StoredProcedure);
                return "Task: " + taskapi.Taskname + ", updated!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Taskapi getbyid(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofTaskApi", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Taskapi> result = dbContext.dBConnection.Query<Taskapi>("TaskApi_package_api.getById", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
