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
            Electric_Car electricCar = new Electric_Car();
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

        // POST: api/ElectricCar
        [HttpPost]
        public void Post([FromBody] Electric_Car value)
        {
            ElectricCarHandler myElectricCarHandler = new ElectricCarHandler();
            myElectricCarHandler.AddElectricCar(value);
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
