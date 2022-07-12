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
    public class CheckApiService : ICheckApiService
    {
        private readonly IDBContext dbContext;
        public CheckApiService(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool delete(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("idofcategory", id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.dBConnection.ExecuteAsync("category_package_api.deletecategory", parameter, commandType: CommandType.StoredProcedure);
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<Checkapi> getall()
        {
            throw new NotImplementedException();
        }

        public bool insert(Checkapi checkapi)
        {
            throw new NotImplementedException();
        }

        public bool update(Checkapi checkapi)
        {
            throw new NotImplementedException();
        }
    }
}
