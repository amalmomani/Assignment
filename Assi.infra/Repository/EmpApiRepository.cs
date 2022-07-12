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
    public class EmpApiRepository : IEmpApiRepository
    {
        private readonly IDBContext dbContext;
        public EmpApiRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public string delete(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofEmpApi", id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.dBConnection.ExecuteAsync("EmpApi_package_api.deleteEmpApi", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
                return "Something went wrong";
            else
                return "Deleted!";
        }

        public List<Empapi> getall()
        {
            IEnumerable<Empapi> result = dbContext.dBConnection.Query<Empapi>("EmpApi_package_api.getallEmpApi", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public string insert(Empapi empapi)
        {
            var paramenter = new DynamicParameters();
            paramenter.Add("idofEmpApi", empapi.Empid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            paramenter.Add("nameofEmpApi", empapi.Empname, dbType: DbType.String, direction: ParameterDirection.Input);
            paramenter.Add("emailOfEmpApi", empapi.Empemail, dbType: DbType.String, direction: ParameterDirection.Input);
            paramenter.Add("empSalary", empapi.Salary, dbType: DbType.Int32, direction: ParameterDirection.Input);
            paramenter.Add("dep", empapi.Depid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.dBConnection.ExecuteAsync("EmpApi_package_api.createinsertEmpApi", paramenter, commandType: CommandType.StoredProcedure);
            return "Name: " + empapi.Empname + "|| Email: " + empapi.Empemail + "|| Salary: "+ empapi.Salary +"|| Department: "+ empapi.Depid+", inserted!";

        }

        public string update(Empapi empapi)
        {
            var paramenter = new DynamicParameters();
            paramenter.Add("idofEmpApi", empapi.Empid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            paramenter.Add("nameofEmpApi", empapi.Empname, dbType: DbType.String, direction: ParameterDirection.Input);
            paramenter.Add("emailOfEmpApi", empapi.Empemail, dbType: DbType.String, direction: ParameterDirection.Input);
            paramenter.Add("empSalary", empapi.Salary, dbType: DbType.Int32, direction: ParameterDirection.Input);
            paramenter.Add("dep", empapi.Depid, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.dBConnection.ExecuteAsync("EmpApi_package_api.UpdateEmpApi", paramenter, commandType: CommandType.StoredProcedure);
            return "Name: " + empapi.Empname + "|| Email: " + empapi.Empemail + "|| Salary: " + empapi.Salary + "|| Department: " + empapi.Depid + ", updated!";
        }
    }
}
