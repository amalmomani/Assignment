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
            try
            {
                var parameter = new DynamicParameters();
                parameter.Add("idofEmpApi", id, dbType: DbType.Int32, direction: ParameterDirection.Input);


                var result = dbContext.dBConnection.ExecuteAsync("EmpApi_package_api.deleteEmpApi", parameter, commandType: CommandType.StoredProcedure);
                if (result == null)
                    return "Something went wrong";
                else
                    return "Deleted!";
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }

        public List<Empapi> getall()
        {
            IEnumerable<Empapi> result = dbContext.dBConnection.Query<Empapi>("EmpApi_package_api.getallEmpApi", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public string insert(Empapi empapi)
        {
            try
            {
                var paramenter = new DynamicParameters();
                paramenter.Add("idofEmpApi", empapi.Empid, dbType: DbType.Int32, direction: ParameterDirection.Input);
                paramenter.Add("nameofEmpApi", empapi.Empname, dbType: DbType.String, direction: ParameterDirection.Input);
                paramenter.Add("emailOfEmpApi", empapi.Empemail, dbType: DbType.String, direction: ParameterDirection.Input);
                paramenter.Add("empSalary", empapi.Salary, dbType: DbType.Int32, direction: ParameterDirection.Input);
                paramenter.Add("dep", empapi.Depid, dbType: DbType.Int32, direction: ParameterDirection.Input);

                var result = dbContext.dBConnection.ExecuteAsync("EmpApi_package_api.createinsertEmpApi", paramenter, commandType: CommandType.StoredProcedure);
                return "Name: " + empapi.Empname + "|| Email: " + empapi.Empemail + "|| Salary: " + empapi.Salary + "|| Department: " + empapi.Depid + ", inserted!";
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }

        public string update(Empapi empapi)
        {
            try
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
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }
        public List<string> getNameSalarydep()
        {
            try
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
            catch (Exception ex)
            {
                List<string> e = new List<string>() { "Something went wrong" };
                return e;
            }
        }
        public string Salary()
        {
            try
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
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }
        public List<string> getNameTask()
        {
            try
            {
                IEnumerable<EmpTaskDTO> result = dbContext.dBConnection.Query<EmpTaskDTO>("getInfo.getNameTask", commandType: System.Data.CommandType.StoredProcedure);
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
        public string count()
        {
            try
            {
                IEnumerable<Empapi> result = dbContext.dBConnection.Query<Empapi>("EmpApi_package_api.getallEmpApi", commandType: CommandType.StoredProcedure);
                List<Empapi> r = result.ToList();
                return "Employee Count= " + r.Count();
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }
        public string sum()
        {
            try
            {
                IEnumerable<Empapi> result = dbContext.dBConnection.Query<Empapi>("EmpApi_package_api.getallEmpApi", commandType: CommandType.StoredProcedure);
                List<Empapi> r = result.ToList();
                int sum = 0;
                foreach (var item in r)
                {
                    sum += (int)item.Salary;
                }
                return "Employees salaries= " + sum;
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }
        public string avg()
        {
            try
            {
                IEnumerable<Empapi> result = dbContext.dBConnection.Query<Empapi>("EmpApi_package_api.getallEmpApi", commandType: CommandType.StoredProcedure);
                List<Empapi> r = result.ToList();
                double sum = 0.0;
                foreach (var item in r)
                {
                    sum += (int)item.Salary;
                }
                double avg =(double) sum / r.Count();
                return "Employees salaries average= " + avg;
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }
        public List<string> FilterName(string name)
        {
            try
            {
                var paramenter = new DynamicParameters();
                paramenter.Add("name", name, dbType: DbType.String, direction: ParameterDirection.Input);

                IEnumerable<Empapi> result = dbContext.dBConnection.Query<Empapi>("EmpApi_package_api.FilterName", paramenter, commandType: System.Data.CommandType.StoredProcedure);
                List<string> r = new List<string>();
                List<Empapi> resultt = result.ToList();
                foreach (var item in resultt)
                {
                    r.Add("Name: " + item.Empname + " || Salary: " + item.Salary + ". ");
                }
                return r;
            }
            catch (Exception ex)
            {
                List<string> e = new List<string>() { "Something went wrong" };
                return e;
            }
        }
        public string EmailExist(string email)
        {
            try
            {
                var paramenter = new DynamicParameters();
                paramenter.Add("email", email, dbType: DbType.String, direction: ParameterDirection.Input);

                IEnumerable<Empapi> result = dbContext.dBConnection.Query<Empapi>("getInfo.email", paramenter, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() != 0)
                    return "Exist";
                else
                    return "Not exist";
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }
        public List<string> DotCom()
        {
            try
            {
                IEnumerable<Empapi> result = dbContext.dBConnection.Query<Empapi>(".dotcom", commandType: CommandType.StoredProcedure);

                List<string> r = new List<string>();
                foreach (var item in result.ToList())
                {
                    r.Add("Name: " + item.Empname + " || Email: " + item.Empemail + " || Salary: " + item.Salary + ". ");
                }
                return r;
            }
            catch (Exception ex)
            {
                List<string> e = new List<string>() { "Something went wrong" };
                return e;
            }
        }
        public List<string> EmpDep()
        {
            try
            {
                IEnumerable<Empapi> result = dbContext.dBConnection.Query<Empapi>("EmpApi_package_api.getallEmpApi", commandType: CommandType.StoredProcedure);
                List<string> r = new List<string>();
                foreach (var item in result.ToList())
                {
                    int count = result.ToList().Count(x => x.Depid == item.Depid);
                    r.Add("department " + item.Depid + ": " + count);
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
