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
        public ActionResult delete(int id)
        {
            string result = null;
            result = this.CheckEmpService.delete(id);
            if (result != null)
                return Ok(result);
            else
                return BadRequest();
        }
        [HttpGet]//retrevie all data
        public ActionResult check()
        {
            List<Checkemp> result = null;
            result = this.CheckEmpService.getall();
            if (result != null)
                return Ok(result);
            else
                return BadRequest();
        }

        [HttpPost]//insert new record in database
        public ActionResult create([FromBody] Checkemp CheckEmp)
        {
            string result = null;
            result = this.CheckEmpService.insert(CheckEmp);
            if (result != null)
                return Ok(result);
            else
                return BadRequest();
        }
        [HttpPut] //update
        public ActionResult update([FromBody] Checkemp CheckEmp)
        {
            string result = null;
            result = this.CheckEmpService.update(CheckEmp);
            if (result != null)
                return Ok(result);
            else
                return BadRequest();
        }
        [HttpGet("filter")] //delete record from database
        public ActionResult Filter([FromBody]Checkapi checkapi)
        {
            List<string> result = null;
            result = this.CheckEmpService.FilterDate(checkapi);
            if (result != null)
                return Ok(result);
            else
                return BadRequest();
        }
    }
}
