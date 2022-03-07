using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Opgave4.Models;
using Opgave4.Managers;
using Opgave4.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Opgave4.Controllers
{
    [EnableCors(Startup.AllowOnlyGetCorsPolicy)]
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private static readonly string ItemCache = "items";
        private readonly IMemoryCache _memoryCache;
        private readonly CarsManager _manager = new CarsManager();

        public CarsController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }


        [EnableCors(Startup.AllowAllCorsPolicy)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // GET: api/<CarsController>
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get([FromQuery] string modelFilter, [FromQuery] int? priceFilter, [FromQuery] string lisenceFilter)
        {
            IEnumerable<Car> cars = _manager.GetAll(modelFilter, priceFilter, lisenceFilter);

            if (cars.Count() <= 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(cars);
            }
        }

        // GET api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Car car = _manager.GetById(id);
            //return _manager.GetById(id);
            if (car == null) return NotFound("car not found - id: " + id);
            return Ok(car);
        }

        // POST api/<CarsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public Car Post([FromBody] Car newCar)
        {
            Car createdItem = _manager.Add(newCar);
            return _manager.Add(newCar);
        }


        // PUT api/<CarsController>/5
        //[HttpPut("{id}")]
        //public Car Put(int id, [FromBody] Car value)
        //{
        //    return _manager.Update(id, value);
        //}


        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public Car Delete(int id)
        {
            return _manager.Delete(id);
        }
    }
}
