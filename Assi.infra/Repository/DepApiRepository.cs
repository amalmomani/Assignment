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
            parameter.Add("idofcategory", id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.dBConnection.ExecuteAsync("category_package_api.deletecategory", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
            {
                return "";
            }
            else
            {
                return "";
            }
        }

        public List<Depapi> getall()
        {
            IEnumerable<Depapi> result = dbContext.dBConnection.Query<Depapi>("DepApi_package_api.getallDepApi", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public string insert(Depapi depapi)
        {
            return "";
        }

        public string update(Depapi depapi)
        {
            throw new NotImplementedException();
        }
    }
}
