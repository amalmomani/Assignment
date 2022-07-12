using Assi.core.Service;
using Assignment.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly IEmpApiService EmpApiService;
        public EmpController(IEmpApiService EmpApiService)
        {
            this.EmpApiService = EmpApiService;

        }
        [HttpDelete("delete/{id}")] //delete record from database
        public string delete(int id)
        {

            return EmpApiService.delete(id);
        }
        [HttpGet]//retrevie all data
        public List<Empapi> Dep()
        {
            return EmpApiService.getall();
        }

        [HttpPost]//insert new record in database
        public string create([FromBody] Empapi EmpApi)
        {

            return EmpApiService.insert(EmpApi);
        }
        [HttpPut] //update
        public string update([FromBody] Empapi EmpApi)
        {

            return EmpApiService.update(EmpApi);
        }
    }
}
