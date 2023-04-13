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
    public class GasCarController : ControllerBase
    {
        // GET: api/GasCar
        [HttpGet]
        public List<Gas_Car> Get()
        {
            GasCarHandler myGasCarHandler = new GasCarHandler();
            return myGasCarHandler.GetAllGasCars();
        }


        // GET: api/GasCar/5
        [HttpGet("{id}", Name = "GetGasCar")]
        public IActionResult Get(string id)
        {
            SaveGasCar mySavedGasCar = new SaveGasCar();
            Gas_Car gasCar = mySavedGasCar.GetGasCarById(id);
            Console.WriteLine("Fetched gas car: " + JsonConvert.SerializeObject(gasCar));
            if(gasCar != null)
            {
                return Ok(gasCar);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Gas_Car value)
        {
            try
            {
                Console.WriteLine("Received gas car: " + JsonConvert.SerializeObject(value));

            if (value != null && 
                !string.IsNullOrEmpty(value.Make) && 
                !string.IsNullOrEmpty(value.Model) && 
                value.Year != 0 && // Assuming Year is an integer
                value.Range != 0 && // Assuming Range is an integer or a float
                value.Price != 0 && // Assuming Price is an integer or a float
                value.MPG != 0 && // Assuming KWH is an integer or a float
                !string.IsNullOrEmpty(value.AddOn))
            {
                GasCarHandler myGasCarHandler = new GasCarHandler();
                myGasCarHandler.AddGasCar(value);
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

        // PUT: api/GasCar/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Gas_Car value)
        {
            System.Console.WriteLine(value);
            GasCarHandler myGasCarHandler = new GasCarHandler();
            myGasCarHandler.EditGasCar(id, value);
        }

        // DELETE: api/GasCar/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            GasCarHandler myGasCarHandler = new GasCarHandler();
            myGasCarHandler.DeleteGasCar(id);
        }
    }
}
