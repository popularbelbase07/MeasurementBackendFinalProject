using System;
using System.Collections.Generic;
using MeasurementWebApplication_Final_Project_.Presistancy;
using Microsoft.AspNetCore.Mvc;
using WeatherLibrary;

namespace MeasurementWebApplication_Final_Project_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        // GET: api/Measurement
        [HttpGet]
        public IEnumerable<Weather> Get()
        {
            MeasurementPresistancy mp = new MeasurementPresistancy();
            return mp.Get();
        }


        // POST: api/Measurement
        [HttpPost]
        public void Post([FromBody] Weather value)
        {
            MeasurementPresistancy mp = new MeasurementPresistancy();
            mp.Post(value);

        }
        // GET: api/Measurement/2019-12-11T13:07:21.98
        [HttpGet("{time}", Name = "Get")]
        public Weather Get(DateTime time)
        {
            MeasurementPresistancy Mp = new MeasurementPresistancy();
            return Mp.GetByTime(time);
        }

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        [HttpDelete]
        public void Delete()
        {
            MeasurementPresistancy mp = new MeasurementPresistancy();
            mp.Delete();
        }


    }
}
