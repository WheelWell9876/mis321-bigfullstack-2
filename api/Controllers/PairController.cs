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
    public class PairController : ControllerBase
    {
        // GET: api/Pair
        [HttpGet]
        public List<CarPair> Get()
        {
            CarPairHandler myPairHandler = new CarPairHandler();
            return myPairHandler.GetAllCarPairs();
        }

        // GET: api/Pair/5
        [HttpGet("{id}", Name = "GetPair")]
        public IActionResult Get(string id)
        {
            SaveCarPair mySavedPair = new SaveCarPair();
            CarPair carPair = mySavedPair.GetPairById(id);
            Console.WriteLine("Fetched pair: " + JsonConvert.SerializeObject(carPair));
            if(carPair != null)
            {
                return Ok(carPair);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Pair
        [HttpPost]
        public void Post([FromBody] CarPair value)
        {
            CarPairHandler myPairHandler = new CarPairHandler();
            myPairHandler.AddCarPair(value);
        }

        // PUT: api/Pair/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] CarPair value)
        {
            System.Console.WriteLine(value);
            CarPairHandler myPairHandler = new CarPairHandler();
            myPairHandler.EditCarPair(id, value);
        }

        // DELETE: api/Pair/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            CarPairHandler myPairHandler = new CarPairHandler();
            myPairHandler.DeleteCarPair(id);
        }
    }
}
