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
    public class CheckEmpRepository : ICheckEmpRepository
    {
        private readonly IDBContext dbContext;
        public CheckEmpRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public string delete(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idOfCheckEmp", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.dBConnection.ExecuteAsync("CheckEmp_package_api.deleteCheckEmp", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
                return "Something went wrong";
            else
                return "Deleted!";
        }

        public List<Checkemp> getall()
        {
            IEnumerable<Checkemp> result = dbContext.dBConnection.Query<Checkemp>("CheckEmp_package_api.getallCheckEmp", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public string insert(Checkemp checkemp)
        {
            var paramenter = new DynamicParameters();
            paramenter.Add("idOfCheckEmp", checkemp.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            paramenter.Add("emp", checkemp.Empid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            paramenter.Add("checkk", checkemp.Checkid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.dBConnection.ExecuteAsync("CheckEmp_package_api.createinsertCheckEmp", paramenter, commandType: CommandType.StoredProcedure);
            return "EmpId: " + checkemp.Empid + " CheckId: " + checkemp.Checkid +" inserted!";

        }

        public string update(Checkemp checkemp)
        {
            var paramenter = new DynamicParameters();
            paramenter.Add("idOfCheckEmp", checkemp.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            paramenter.Add("emp", checkemp.Empid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            paramenter.Add("checkk", checkemp.Checkid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.dBConnection.ExecuteAsync("CheckEmp_package_api.UpdateCheckEmp", paramenter, commandType: CommandType.StoredProcedure);
            return "EmpId: " + checkemp.Empid + " CheckId: " + checkemp.Checkid + " updated!";
        }
    }
}
