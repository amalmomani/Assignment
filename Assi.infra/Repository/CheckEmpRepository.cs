﻿using Assi.core.domain;
using Assi.core.Repository;
using Assignment.Data;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
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

        public List<Checkemp> getall()
        {
            throw new NotImplementedException();
        }

        public bool insert(Checkemp checkemp)
        {
            throw new NotImplementedException();
        }

        public bool update(Checkemp checkemp)
        {
            throw new NotImplementedException();
        }
    }
}
