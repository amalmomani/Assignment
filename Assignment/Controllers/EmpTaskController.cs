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
        public string delete(int id)
        {

            return EmpTaskService.delete(id);
        }
        [HttpGet]//retrevie all data
        public List<Emptask> Dep()
        {
            return EmpTaskService.getall();
        }

        [HttpPost]//insert new record in database
        public string create([FromBody] Emptask EmpTask)
        {

            return EmpTaskService.insert(EmpTask);
        }
        [HttpPut] //update
        public string update([FromBody] Emptask EmpTask)
        {

            return EmpTaskService.update(EmpTask);
        }
    }
}
