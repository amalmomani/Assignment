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
    public class CheckEmpRepository : ICheckEmpRepository
    {
        private readonly IDBContext dbContext;
        public CheckEmpRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public string delete(int id)
        {
            try
            {
                var parameter = new DynamicParameters();
                parameter.Add("idOfCheckEmp", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

                var result = dbContext.dBConnection.ExecuteAsync("CheckEmp_package_api.deleteCheckEmp", parameter, commandType: CommandType.StoredProcedure);
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

        public List<Checkemp> getall()
        {
            IEnumerable<Checkemp> result = dbContext.dBConnection.Query<Checkemp>("CheckEmp_package_api.getallCheckEmp", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public string insert(Checkemp checkemp)
        {
            try
            {
                var paramenter = new DynamicParameters();
                paramenter.Add("idofCheckEmp", checkemp.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                paramenter.Add("emp", checkemp.Empid, dbType: DbType.Int32, direction: ParameterDirection.Input);
                paramenter.Add("checkk", checkemp.Checkid, dbType: DbType.Int32, direction: ParameterDirection.Input);

                var result = dbContext.dBConnection.ExecuteAsync("CheckEmp_package_api.createinsertCheckEmp", paramenter, commandType: CommandType.StoredProcedure);
                return "EmpId: " + checkemp.Empid + "|| CheckId: " + checkemp.Checkid + ", inserted!";
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }

        public string update(Checkemp checkemp)
        {
            try
            {
                var paramenter = new DynamicParameters();
                paramenter.Add("idofCheckEmp", checkemp.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
                paramenter.Add("emp", checkemp.Empid, dbType: DbType.Int32, direction: ParameterDirection.Input);
                paramenter.Add("checkk", checkemp.Checkid, dbType: DbType.Int32, direction: ParameterDirection.Input);

                var result = dbContext.dBConnection.ExecuteAsync("CheckEmp_package_api.UpdateCheckEmp", paramenter, commandType: CommandType.StoredProcedure);
                return "EmpId: " + checkemp.Empid + "|| CheckId: " + checkemp.Checkid + ", updated!";
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
        }
        public List<string> FilterDate(Checkapi checkapi)
        {
            try
            {
                var paramenter = new DynamicParameters();
                paramenter.Add("checkinn", checkapi.Checkin, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                paramenter.Add("checkoutt", checkapi.Checkout, dbType: DbType.DateTime, direction: ParameterDirection.Input);

                IEnumerable<CheckDateDTO> result = dbContext.dBConnection.Query<CheckDateDTO>("CheckEmp_package_api.filterCheckDate", paramenter, commandType: System.Data.CommandType.StoredProcedure);
                List<string> r = new List<string>();
                List<CheckDateDTO> resultt = result.ToList();
                foreach (var item in resultt)
                {
                    r.Add("Name: " + item.Employee + " || Email: " + item.Email + "|| Checkin: " + item.Checkin + "|| Checkout: " + item.Checkout + ".");
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
