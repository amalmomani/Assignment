using Assignment.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assi.core.Service
{
    public interface ICheckapiService
    {
        public bool insert(Checkapi checkapi);
        public bool update(Checkapi checkapi);

        public bool delete(int id);

        public List<Checkapi> getall();
    }
}
