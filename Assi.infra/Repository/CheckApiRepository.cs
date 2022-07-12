using Assi.core.domain;
using Assi.core.Repository;
using Assi.core.Service;
using Assignment.Data;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Assi.infra.Repository
{
    public class CheckApiRepository : ICheckApiRepository
    {
        private readonly IDBContext dbContext;
        public CheckApiRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public string delete(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofCheckApi", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.dBConnection.ExecuteAsync("CheckApi_package_api.deleteCheckApi", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
            {
                return "Something went wrong!";
            }
            else
            {
                return "Deleted";
            }
        }

        public List<Checkapi> getall()
        {
            IEnumerable<Checkapi> result = dbContext.dBConnection.Query<Checkapi>("CheckApi_package_api.getallCheckApi", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public string insert(Checkapi checkapi)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idOfCheckApi", checkapi.Checkid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("checkinn", checkapi.Checkin, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("checkoutt", checkapi.Checkout, dbType: DbType.DateTime, direction: ParameterDirection.Input);


            var result = dbContext.dBConnection.ExecuteAsync("checkApi_package_api.createinsertcheckApi", parameter, commandType: CommandType.StoredProcedure);
            return "Checkin: " + checkapi.Checkin + "checkout: " + checkapi.Checkout + "inserted!";
        }

        public string update(Checkapi checkapi)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idOfCheckApi", checkapi.Checkid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("checkinn", checkapi.Checkin, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("checkoutt", checkapi.Checkout, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            var result = dbContext.dBConnection.ExecuteAsync("CheckApi_package_api.updatecheckApi", parameter, commandType: CommandType.StoredProcedure);
            return "Checkin: " + checkapi.Checkin + "checkout: " + checkapi.Checkout + "Updated!";
        }
    }
}
