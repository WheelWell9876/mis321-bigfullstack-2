using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bigproject.DataAccess;
using Bigproject.Handler;
using Bigproject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            UserHandler myUserHandler = new UserHandler();
            return myUserHandler.GetAllUsers();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult Get(string id)
        {
            SaveUser mySavedUser = new SaveUser();
            User user = mySavedUser.GetUserById(id);
            Console.WriteLine("Fetched user: " + JsonConvert.SerializeObject(user));
            if(user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        // // POST: api/User
        // [HttpPost]
        // public void Post([FromBody] User value)
        // {
        //     UserHandler myUserHandler = new UserHandler();
        //     myUserHandler.AddUser(value);
        // }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] User value)
        {
            try
            {
                Console.WriteLine("Received user: " + JsonConvert.SerializeObject(value));

                if (value != null && !string.IsNullOrEmpty(value.Email) && !string.IsNullOrEmpty(value.Password))
                {
                    UserHandler myUserHandler = new UserHandler();
                    myUserHandler.AddUser(value);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Post method: " + ex.Message);
                Console.WriteLine("Stack trace: " + ex.StackTrace);
                return StatusCode(500);
            }
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] User value)
        {
            System.Console.WriteLine(value);
            UserHandler myUserHandler = new UserHandler();
            myUserHandler.EditUser(id, value);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            UserHandler myUserHandler = new UserHandler();
            myUserHandler.DeleteUser(id);
        }
    }
}
