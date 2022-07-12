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
    public class DepApiRepository : IDepApiRepository
    {
        private readonly IDBContext dbContext;
        public DepApiRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public string delete(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofDepApi", id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.dBConnection.ExecuteAsync("DepApi_package_api.deleteDepApi", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
                return "Something went wrong";
            else
                return "Deleted!";
        }

        public List<Depapi> getall()
        {
            IEnumerable<Depapi> result = dbContext.dBConnection.Query<Depapi>("DepApi_package_api.getallDepApi", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public string insert(Depapi depapi)
        {
            var paramenter = new DynamicParameters();
            paramenter.Add("idofDepApi", depapi.Depid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            paramenter.Add("nameofDepApi", depapi.Depname, dbType: DbType.String, direction: ParameterDirection.Input);
            paramenter.Add("phoneOfDepApi", depapi.Depphone, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.dBConnection.ExecuteAsync("DepApi_package_api.createinsertDepApi", paramenter, commandType: CommandType.StoredProcedure);
            return "Department name: " + depapi.Depname + "|| Department phone: " + depapi.Depphone + ", inserted!";
        }

        public string update(Depapi depapi)
        {
            var paramenter = new DynamicParameters();
            paramenter.Add("idofDepApi", depapi.Depid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            paramenter.Add("nameofDepApi", depapi.Depname, dbType: DbType.String, direction: ParameterDirection.Input);
            paramenter.Add("phoneOfDepApi", depapi.Depphone, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.dBConnection.ExecuteAsync("DepApi_package_api.UpdateDepApi", paramenter, commandType: CommandType.StoredProcedure);
            return "Department name: " + depapi.Depname + "|| Department phone: " + depapi.Depphone + ", updated!";

        }
    }
}
