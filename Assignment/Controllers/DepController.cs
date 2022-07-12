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
    public class DepController : ControllerBase
    {
        private readonly IDepApiService DepApiService;
        public DepController(IDepApiService DepApiService)
        {
            this.DepApiService = DepApiService;

        }
        [HttpDelete("delete/{id}")] //delete record from database
        public string delete(int id)
        {

            return DepApiService.delete(id);
        }
        [HttpGet]//retrevie all data
        public List<Depapi> Dep()
        {
            return DepApiService.getall();
        }

        [HttpPost]//insert new record in database
        public string create([FromBody] Depapi DepApi)
        {

            return DepApiService.insert(DepApi);
        }
        [HttpPut] //update
        public string update([FromBody] Depapi DepApi)
        {

            return DepApiService.update(DepApi);
        }
    }
}
