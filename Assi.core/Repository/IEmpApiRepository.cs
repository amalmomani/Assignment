using Assignment.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assi.core.Repository
{
    public interface IEmpApiRepository
    {
        public string insert(Empapi empapi);
        public string update(Empapi empapi);

        public string delete(int id);

        public List<Empapi> getall();
        public List<string> getNameSalarydep();
        public List<string> getNameTask();
        public string count();
        public string sum();
        public string avg();

    }
}
