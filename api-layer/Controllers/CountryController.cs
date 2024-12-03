﻿using BuisnessLayer;
using DTOsLayer;
using Microsoft.AspNetCore.Mvc;

namespace api_layer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class CountryController : Controller
    {
        [HttpGet("All", Name = "GetCountries")]
        public ActionResult<IEnumerable<string>> AllTypes()
        {
            var list =  clsCountries.GetAllCountries();

            if (list.Count() <= 0)
                return NotFound("No Countries Found");
            else
                return Ok(list);
        }
    }
}