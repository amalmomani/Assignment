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
        public List<string> getNameSalarydep()
        {
            IEnumerable<EmpDTO> result = dbContext.dBConnection.Query<EmpDTO>("getInfo.getNameSalaryDep", commandType: System.Data.CommandType.StoredProcedure);
            List<string> r = new List<string>();
            List<EmpDTO> resultt = result.ToList();
            foreach (var item in resultt)
            {
                r.Add("Name: " + item.Name + " || Salary: " + item.salary + "|| Department: " + item.dep + ". ");
            }
            return r;
        }
        public string Salary()
        {
            IEnumerable<SalaryDTO> result = dbContext.dBConnection.Query<SalaryDTO>("getInfo.salaries", commandType: System.Data.CommandType.StoredProcedure);
            List<string> r = new List<string>();
            List<SalaryDTO> resultt = result.ToList();
            foreach (var item in resultt)
            {
                r.Add("Count: " + item.count + " || Sum: " + item.sum + "|| Average: " + item.avg + ". ");
            }
            return r.FirstOrDefault();
        }
        public List<string> getNameTask()
        {
            IEnumerable<EmpTaskDTO> result = dbContext.dBConnection.Query<EmpTaskDTO>("getInfo.getNameTask", commandType: System.Data.CommandType.StoredProcedure);
            List<string> r = new List<string>();
            List<EmpTaskDTO> resultt = result.ToList();
            foreach (var item in resultt)
            {
                r.Add("Name: " + item.Name + " || Task: "+ item.task+ ". ");
            }
            return r;
        }
        public string count()
        {
            IEnumerable<Empapi> result = dbContext.dBConnection.Query<Empapi>("EmpApi_package_api.getallEmpApi", commandType: CommandType.StoredProcedure);
            List<Empapi> r = result.ToList();
            return "Employee Count= " + r.Count();
        }
        public string sum()
        {
            IEnumerable<Empapi> result = dbContext.dBConnection.Query<Empapi>("EmpApi_package_api.getallEmpApi", commandType: CommandType.StoredProcedure);
            List<Empapi> r = result.ToList();
            int sum = 0;
            foreach(var item in r)
            {
                sum += (int)item.Salary;
            }
            return "Employees salaries= "+ sum ;
        }
        public string avg()
        {
            IEnumerable<Empapi> result = dbContext.dBConnection.Query<Empapi>("EmpApi_package_api.getallEmpApi", commandType: CommandType.StoredProcedure);
            List<Empapi> r = result.ToList();
            int sum = 0;
            foreach (var item in r)
            {
                sum += (int)item.Salary;
            }
            return "Employees salaries average= " + sum/r.Count();
        }
        public List<string> FilterName(string name)
        {
            var paramenter = new DynamicParameters();
            paramenter.Add("name", name, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<Empapi> result = dbContext.dBConnection.Query<Empapi>("EmpApi_package_api.FilterName",paramenter, commandType: System.Data.CommandType.StoredProcedure);
            List<string> r = new List<string>();
            List<Empapi> resultt = result.ToList();
            foreach (var item in resultt)
            {
                r.Add("Name: " + item.Empname + " || Salary: " + item.Salary +". ");
            }
            return r;
        }
        public string EmailExist(string email)
        {
            var paramenter = new DynamicParameters();
            paramenter.Add("email", email, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<Empapi> result = dbContext.dBConnection.Query<Empapi>("getInfo.email", paramenter,commandType: System.Data.CommandType.StoredProcedure);
            
            if (result.Count() !=0 )
                return "Exist";
            else
                return "Not exist";
        }
        public List<string> DotCom()
        {
            IEnumerable<Empapi> result = dbContext.dBConnection.Query<Empapi>(".dotcom", commandType: CommandType.StoredProcedure);

            List<string> r = new List<string>();
            foreach(var item in result.ToList())
            {
                r.Add("Name: " + item.Empname + " || Email: " + item.Empemail + " || Salary: " + item.Salary + ". ");
            }
            return r;
        }
        public List<string> EmpDep()
        {
            IEnumerable<Empapi> result = dbContext.dBConnection.Query<Empapi>("EmpApi_package_api.getallEmpApi", commandType: CommandType.StoredProcedure);
            List<string> r = new List<string>();
            foreach(var item in result.ToList())
            {
                int count = result.ToList().Count(x => x.Depid == item.Depid);
                r.Add("department "+ item.Depid + ": "+ count);
            }
            return r;
        }
    }
}
