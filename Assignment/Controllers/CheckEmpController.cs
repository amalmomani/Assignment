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
    public class CheckEmpController : ControllerBase
    {
        private readonly ICheckEmpService CheckEmpService;
        public CheckEmpController(ICheckEmpService CheckEmpService)
        {
            this.CheckEmpService = CheckEmpService;

        }
        [HttpDelete("delete/{id}")] //delete record from database
        public string delete(int id)
        {

            return CheckEmpService.delete(id);
        }
        [HttpGet]//retrevie all data
        public List<Checkemp> check()
        {
            return CheckEmpService.getall();
        }

        [HttpPost]//insert new record in database
        public string create([FromBody] Checkemp CheckEmp)
        {

            return CheckEmpService.insert(CheckEmp);
        }
        [HttpPut] //update
        public string update([FromBody] Checkemp CheckEmp)
        {

            return CheckEmpService.update(CheckEmp);
        }
        [HttpGet("filter")] //delete record from database
        public List<string> Filter([FromBody]Checkapi checkapi)
        {
            return CheckEmpService.FilterDate(checkapi);
        }
    }
}
