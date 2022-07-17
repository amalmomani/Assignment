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
    public class TaskController : ControllerBase
    {
        private readonly ITaskApiService TaskapiService;
        public TaskController(ITaskApiService TaskapiService)
        {
            this.TaskapiService = TaskapiService;

        }
        [HttpDelete("delete/{id}")] //delete record from database
        public ActionResult delete(int id)
        {
            string result = null;
            result = this.TaskapiService.delete(id);
            if (result != null)
                return Ok(result);
            else return BadRequest();
        }
        [HttpGet]//retrevie all data
        public ActionResult Task()
        {
            List<Taskapi> result = null;
            result = this.TaskapiService.getall();
            if (result != null)
                return Ok(result);
            else return BadRequest();
        }
        [HttpGet("{id}")] // retrive data by id
        public ActionResult Task(int id)
        {
            Taskapi result = null;
            result = this.TaskapiService.getbyid(id);
            if (result != null)
                return Ok(result);
            else return BadRequest();
        }
        [HttpGet("getId")] // retrive data by id
        public ActionResult getId([FromBody] int id)
        {
            Taskapi result = null;
            result = this.TaskapiService.getbyid(id);
            if (result != null)
                return Ok(result);
            else return BadRequest();
        }
        [HttpPost]//insert new record in database
        public ActionResult create([FromBody] Taskapi Taskapi)
        {
            string result = null;
            result = this.TaskapiService.insert(Taskapi);
            if (result != null)
                return Ok(result);
            else return BadRequest();
        }
        [HttpPut] //update
        public ActionResult update([FromBody] Taskapi Taskapi)
        {
            string result = null;
            result = this.TaskapiService.update(Taskapi);
            if (result != null)
                return Ok(result);
            else return BadRequest();
        }

       
    }
}
