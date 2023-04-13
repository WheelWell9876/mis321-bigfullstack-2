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
    public class ElectricCarController : ControllerBase
    {
        // GET: api/ElectricCar
        [HttpGet]
        public List<Electric_Car> Get()
        {
            ElectricCarHandler myElectricCarHandler = new ElectricCarHandler();
            return myElectricCarHandler.GetAllElectricCars();
        }

        // GET: api/ElectricCar/5
        [HttpGet("{id}", Name = "GetElectricCar")]
        public IActionResult Get(string id)
        {
            SaveElectricCar mySavedElectricCar = new SaveElectricCar();
            Electric_Car electricCar = mySavedElectricCar.GetElectricCarById(id);
            Console.WriteLine("Fetched electric car: " + JsonConvert.SerializeObject(electricCar));
            if(electricCar != null)
            {
                return Ok(electricCar);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Electric_Car value)
        {
            try
            {
                Console.WriteLine("Received electric car: " + JsonConvert.SerializeObject(value));

            if (value != null && 
                !string.IsNullOrEmpty(value.Make) && 
                !string.IsNullOrEmpty(value.Model) && 
                value.Year != 0 && // Assuming Year is an integer
                value.Range != 0 && // Assuming Range is an integer or a float
                value.Price != 0 && // Assuming Price is an integer or a float
                value.KWH != 0 && // Assuming KWH is an integer or a float
                !string.IsNullOrEmpty(value.AddOn))
            {
                ElectricCarHandler myElectricCarHandler = new ElectricCarHandler();
                myElectricCarHandler.AddElectricCar(value);
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

        // PUT: api/ElectricCar/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Electric_Car value)
        {
            System.Console.WriteLine(value);
            ElectricCarHandler myElectricCarHandler = new ElectricCarHandler();
            myElectricCarHandler.EditElectricCar(id, value);
        }

        // DELETE: api/ElectricCar/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            ElectricCarHandler myElectricCarHandler = new ElectricCarHandler();
            myElectricCarHandler.DeleteElectricCar(id);
        }
    }
}
