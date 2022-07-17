using Assi.core.domain;
using Assi.core.DTO;
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
    public class EmpTaskRepository : IEmpTaskRepository
    {
        private readonly IDBContext dbContext;
        public EmpTaskRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public string delete(int id)
        {
            try
            {
                var parameter = new DynamicParameters();
                parameter.Add("idofEmpTask", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                var result = dbContext.dBConnection.ExecuteAsync("EmpTask_package_api.deleteEmpTask", parameter, commandType: CommandType.StoredProcedure);
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

        public List<Emptask> getall()
        {
            IEnumerable<Emptask> result = dbContext.dBConnection.Query<Emptask>("EmpTask_package_api.getallEmpTask", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public string insert(Emptask emptask)
        {
            try
            {
                var paramenter = new DynamicParameters();
                paramenter.Add("emp", emptask.Empid, dbType: DbType.Int32, direction: ParameterDirection.Input);
                paramenter.Add("task", emptask.Taskid, dbType: DbType.Int32, direction: ParameterDirection.Input);

                var result = dbContext.dBConnection.ExecuteAsync("EmpTask_package_api.createinsertEmpTask", paramenter, commandType: CommandType.StoredProcedure);
                return "Employee: " + emptask.Empid + "|| Task: " + emptask.Taskid + ", inserted!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string update(Emptask emptask)
        {
            try
            {
                var paramenter = new DynamicParameters();
                paramenter.Add("emp", emptask.Empid, dbType: DbType.Int32, direction: ParameterDirection.Input);
                paramenter.Add("task", emptask.Taskid, dbType: DbType.Int32, direction: ParameterDirection.Input);

                var result = dbContext.dBConnection.ExecuteAsync("EmpTask_package_api.UpdateEmpTask", paramenter, commandType: CommandType.StoredProcedure);
                return "Employee: " + emptask.Empid + "|| Task: " + emptask.Taskid + ", updated!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public List<string> CountNameTask()
        {
            try
            {
                IEnumerable<EmpTaskDTO> result = dbContext.dBConnection.Query<EmpTaskDTO>("getInfo.CountEmpTask", commandType: System.Data.CommandType.StoredProcedure);
                List<string> r = new List<string>();
                List<EmpTaskDTO> resultt = result.ToList();
                foreach (var item in resultt)
                {
                    r.Add("Name: " + item.Name + " || Task: " + item.task + ". ");
                }
                return r;
            }
            catch (Exception ex)
            {
                List<string> e = new List<string>() { "Something went wrong" };
                return e;
            }
        }
    }
}
