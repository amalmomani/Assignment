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
    public class CheckController : ControllerBase
    {
        private readonly ICheckapiService  checkapiService;
        public CheckController(ICheckapiService  checkapiService)
        {
            this.checkapiService = checkapiService;

        }
        [HttpDelete("delete/{id}")] //delete record from database
        public string delete(int id)
        {

            return checkapiService.delete(id);
        }
        [HttpGet]//retrevie all data
        public List<Checkapi> check()
        {
            return checkapiService.getall();
        }
       
        [HttpPost]//insert new record in database
        public string create([FromBody] Checkapi checkapi)
        {

            return checkapiService.insert(checkapi);
        }
        [HttpPut] //update
        public string updatecourse([FromBody] Checkapi checkapi)
        {

            return checkapiService.update(checkapi);
        }

    }
}
