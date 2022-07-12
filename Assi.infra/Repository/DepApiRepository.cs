using Assi.core.domain;
using Assi.core.Repository;
using Assignment.Data;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
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
            throw new NotImplementedException();
        }

        public string insert(Depapi depapi)
        {
            throw new NotImplementedException();
        }

        public string update(Depapi depapi)
        {
            throw new NotImplementedException();
        }
    }
}
