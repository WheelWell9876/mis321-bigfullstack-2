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
            Gas_Car gasCar = new Gas_Car();
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

        // POST: api/GasCar
        [HttpPost]
        public void Post([FromBody] Gas_Car value)
        {
            GasCarHandler myGasCarHandler = new GasCarHandler();
            myGasCarHandler.AddGasCar(value);
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
