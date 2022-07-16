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
    public class EmpTaskController : ControllerBase
    {
        private readonly IEmpTaskService EmpTaskService;
        public EmpTaskController(IEmpTaskService EmpTaskService)
        {
            this.EmpTaskService = EmpTaskService;

        }
        [HttpDelete("delete/{id}")] //delete record from database
        public ActionResult delete(int id)
        {
            string result = null;
            result = this.EmpTaskService.delete(id);
            if (result != null)
                return Ok(result);
            else return BadRequest();
        }
        [HttpGet]//retrevie all data
        public ActionResult Dep()
        {
            List<Emptask> result = null;
            result = this.EmpTaskService.getall();
            if (result != null)
                return Ok(result);
            else return BadRequest();
        }

        [HttpPost]//insert new record in database
        public ActionResult create([FromBody] Emptask EmpTask)
        {
            string result = null;
            result = this.EmpTaskService.insert(EmpTask);
            if (result != null)
                return Ok(result);
            else return BadRequest();
        }
        [HttpPut] //update
        public ActionResult update([FromBody] Emptask EmpTask)
        {
            string result = null;
            result = this.EmpTaskService.update(EmpTask);
            if (result != null)
                return Ok(result);
            else return BadRequest();
        }
    }
}
