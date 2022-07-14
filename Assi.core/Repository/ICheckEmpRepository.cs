using Assi.core.DTO;
using Assignment.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assi.core.Repository
{
    public interface ICheckEmpRepository
    {
        public string insert(Checkemp checkemp);
        public string update(Checkemp checkemp);

        public string delete(int id);

        public List<Checkemp> getall();
        public List<string> FilterDate(Checkapi checkapi);
    }
}
