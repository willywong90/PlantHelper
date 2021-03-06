﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlantHelper.Classes;

namespace PlantHelper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private readonly DatabaseContext dbContext = new DatabaseContext();

        [HttpGet]
        public IEnumerable<Plant> Get()
        {
            return dbContext.Plants;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Plant data)
        {
            try
            {
                dbContext.Plants.Add(data);
                dbContext.SaveChanges();

                return Created($"/api/plants", "OK");
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("{id}/water")]
        public IActionResult setWaterDate(int id, [FromBody] DateTime date)
        {
            try
            {
                Plant plant = dbContext.Plants.FirstOrDefault(i => i.Id == id);

                if (plant != null)
                {
                    plant.LastWaterDate = date;
                    dbContext.SaveChanges();
                }

                return Ok();
            } 
            catch
            {
                return BadRequest();
            }
        }
    }
}