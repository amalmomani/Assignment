﻿using Assignment.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assi.core.Repository
{
    public interface ICheckEmpRepository
    {
        public bool insert(Checkemp checkemp);
        public bool update(Checkemp checkemp);

        public bool delete(int id);

        public List<Checkemp> getall();
    }
}
