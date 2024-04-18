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
    public class EnvironmentController : ControllerBase
    {
        // GET: api/Environment
        [HttpGet]
        public List<Environment> Get()
        {
            //List<Environment> environment = EnvironmentUtility.GetEnvironment();
            //return environment;
            string envVariable = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            return Ok(envVariable);
        }

        
    }
}