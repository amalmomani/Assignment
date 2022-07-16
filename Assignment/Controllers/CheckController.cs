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
        public ActionResult delete(int id)
        {
            string result = null;
            result = this.checkapiService.delete(id);
            if (result != null)
                return Ok(result);
            else
                return BadRequest();
        }
        [HttpGet]//retrevie all data
        public ActionResult check()
        {
            List<Checkapi> result = checkapiService.getall();
            if (result != null)
                return Ok(result);
            else return BadRequest();
        }
       
        [HttpPost]//insert new record in database
        public ActionResult create([FromBody] Checkapi checkapi)
        {
            string result = checkapiService.insert(checkapi);
            if (result != null)
                return Ok(result);
            else return BadRequest();
        }
        [HttpPut] //update
        public ActionResult update([FromBody] Checkapi checkapi)
        {
            string result = checkapiService.update(checkapi);
            if (result != null)
                return Ok(result);
            else return BadRequest();
        }

    }
}
