using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bigproject.Handler;
using Bigproject.Models;
using Bigproject.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        // GET: api/Admin
        [HttpGet]
        public List<Admin> Get()
        {
            AdminHandler myAdminHandler = new AdminHandler();
            return myAdminHandler.GetAllAdmins();
        }

        // GET: api/Admin/5
        [HttpGet("{id}", Name = "GetAdmin")]
        public IActionResult Get(string id)
        {
            SaveAdmin mySavedAdmin = new SaveAdmin();
            Admin admin = new Admin();
            Console.WriteLine("Fetched admin: " + JsonConvert.SerializeObject(admin));
            if(admin != null)
            {
                return Ok(admin);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Admin
        // [HttpPost]
        // public void Post([FromBody] Admin value)
        // {
        //     AdminHandler myAdminHandler = new AdminHandler();
        //     myAdminHandler.AddAdmin(value);
        // }

        // POST: api/Admin
        [HttpPost]
        public IActionResult Post([FromBody] Admin value)
        {
            try
            {
                Console.WriteLine("Received Admin: " + JsonConvert.SerializeObject(value));

                if (value != null && !string.IsNullOrEmpty(value.Email) && !string.IsNullOrEmpty(value.Password) && !string.IsNullOrEmpty(value.SecurityKey))
                {
                    AdminHandler myAdminHandler = new AdminHandler();
                    myAdminHandler.AddAdmin(value);
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

        
        // PUT: api/Admin/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Admin value)
        {
            System.Console.WriteLine(value);
            AdminHandler myAdminHandler = new AdminHandler();
            myAdminHandler.EditAdmin(id, value);
        }

        // DELETE: api/Admin/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            AdminHandler myAdminHandler = new AdminHandler();
            myAdminHandler.DeleteAdmin(id);
        }
    }
}
