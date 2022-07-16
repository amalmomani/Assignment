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
        public ActionResult delete(int id)
        {
            string result = null;
            result = this.EmpApiService.delete(id);
            if (result != null)
                return Ok(result);
            else return BadRequest();
        }
        [HttpGet]//retrevie all data
        public ActionResult Dep()
        {
            List<Empapi> result = null;
            result = this.EmpApiService.getall();
            if (result != null)
                return Ok(result);
            else return BadRequest();
        }

        [HttpPost]//insert new record in database
        public ActionResult create([FromBody] Empapi EmpApi)
        {
            string result = null;
            result = this.EmpApiService.insert(EmpApi);
            if (result != null)
                return Ok(result);
            else return BadRequest();
        }
        [HttpPut] //update
        public ActionResult update([FromBody] Empapi EmpApi)
        {
            string result = null;
            result = this.EmpApiService.update(EmpApi);
            if (result != null)
                return Ok(result);
            else return BadRequest();
        }

        [HttpGet("getinfo")] 
        public ActionResult getinfo()
        {
            List<string> result = null;
            result = this.EmpApiService.getNameSalarydep();
            if (result != null)
                return Ok(result);
            else return BadRequest();
        }
        [HttpGet("filterName/{name}")] 
        public ActionResult Name(string name)
        {
            List<string> result = null;
            result = this.EmpApiService.FilterName(name);
            if (result != null)
                return Ok(result);
            else return BadRequest();
        }
        [HttpGet("emptask")] 
        public ActionResult emptask()
        {
            List<string> result = null;
            result = this.EmpApiService.getNameTask();
            if (result != null)
                return Ok(result);
            else return BadRequest();
        }
        [HttpGet("count")] 
        public ActionResult count()
        {
            string result = null;
            result = this.EmpApiService.count();
            if (result != null)
                return Ok(result);
            else return BadRequest();
        }
        [HttpGet("sum")] 
        public ActionResult sum()
        {
            string result = null;
            result = this.EmpApiService.sum();
            if (result != null)
                return Ok(result);
            else return BadRequest();
        }
        [HttpGet("avg")] 
        public ActionResult avg()
        {
            string result = null;
            result = this.EmpApiService.avg();
            if (result != null)
                return Ok(result);
            else return BadRequest();
        }
        [HttpGet("salary")] 
        public ActionResult salary()
        {
            string result = null;
            result = this.EmpApiService.Salary();
            if (result != null)
                return Ok(result);
            else return BadRequest();
        }
        [HttpGet("email/{email}")] 
        public ActionResult email(string email)
        {
            string result = null;
            result = this.EmpApiService.EmailExist(email);
            if (result != null)
                return Ok(result);
            else return BadRequest();
        }
        [HttpGet("dotcom")] 
        public ActionResult dotcom()
        {
            List<string> result = null;
            result = this.EmpApiService.DotCom();
            if (result != null)
                return Ok(result);
            else return BadRequest();
        }
        [HttpGet("empdep")]
        public ActionResult EmpDep()
        {
            List<string> result = null;
            result = this.EmpApiService.EmpDep();
            if (result != null)
                return Ok(result);
            else return BadRequest();
        }

    }
}
