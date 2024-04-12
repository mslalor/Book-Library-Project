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
    public class UserController : ControllerBase
    {
        // GET: api/User
        [HttpGet]
        public List<User> Get()
        {
            List<User> user = UserUtility.GetUser();
            return user;
        }

        /*[HttpGet("{id}", Name = "Get")]
        public User Get(int id)
        {
            User newUser= UserUtility.GetUserById(id);
            return newUser;
        }*/

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] User user)
        {
            UserUtility.AddUser(user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] int num)
        {
        
            if (num == 1) {
                UserUtility.UpdateUser(id);
            } else {
                UserUtility.UpdateUserMinus(id);
            }
        }

        // PUT: api/User/5
        /*[HttpPut("{id}")]
        public void Put(int id)
        {
            UserUtility.HoldUser(id);
        }*/

        // DELETE: api/User/5
        /*[HttpDelete("{id}")]
        public void Delete(int id)
        {
            UserUtility.DeleteUser(id);
        }*/
    }
}