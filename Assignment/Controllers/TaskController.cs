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
        public string delete(int id)
        {

            return TaskapiService.delete(id);
        }
        [HttpGet]//retrevie all data
        public List<Taskapi> Dep()
        {
            return TaskapiService.getall();
        }
        [HttpGet("{id}")] // retrive data by id
        public Taskapi Dep(int id)
        {
            return TaskapiService.getbyid(id);
        }
        [HttpGet("getId")] // retrive data by id
        public Taskapi getId([FromBody] int id)
        {
            return TaskapiService.getbyid(id);
        }
        [HttpPost]//insert new record in database
        public string create([FromBody] Taskapi Taskapi)
        {

            return TaskapiService.insert(Taskapi);
        }
        [HttpPut] //update
        public string update([FromBody] Taskapi Taskapi)
        {

            return TaskapiService.update(Taskapi);
        }

       
    }
}
