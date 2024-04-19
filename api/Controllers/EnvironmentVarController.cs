using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.models; 

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvironmentVarController : ControllerBase
    {
        // GET: api/EnvironmentVar
        [HttpGet]
        public IActionResult GetEnvironmentVariable()
        {
            //List<Environment> environment = EnvironmentUtility.GetEnvironment();
            //return environment;
            var envVariable = System.Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            return envVariable;
        }

        
    }
}