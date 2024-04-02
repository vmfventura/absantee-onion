using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HolidayPeriodController : ControllerBase
    {
        private readonly HolidayPeriodService _holidayPeriodService;

        List<string> _errorMessages = new List<string>();

        public HolidayPeriodController(HolidayPeriodService holidayPeriodService)
        {
            _holidayPeriodService = holidayPeriodService;
        }

        // GET: api/HolidayPeriod
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HolidayPeriodDTO>>> GetHolidayPeriods()
        {
            IEnumerable<HolidayPeriodDTO> holidayPeriodDTO = await _holidayPeriodService.GetAll();
            return Ok(holidayPeriodDTO);
        }        

        // GET: api/HolidayPeriod/2
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<HolidayPeriodDTO>>> GetHolidayPeriodsById(long id)
        {
            var holidayPeriodDTO = await _holidayPeriodService.GetById(id);
            if (holidayPeriodDTO is not null)
            {
                return Ok(holidayPeriodDTO);
            }
            return NotFound();
        }   

        // POST: api/HolidayPeriod
        [HttpPost]
        public async Task<ActionResult<IEnumerable<HolidayPeriodDTO>>> PostHolidayPeriods(HolidayPeriodDTO holidayPeriodDTO)
        {
            HolidayPeriodDTO holidayPeriodResultDTO = await _holidayPeriodService.Add(holidayPeriodDTO, _errorMessages);

            if (holidayPeriodResultDTO is not null)
            {
                return CreatedAtAction(nameof(GetHolidayPeriodsById), new { id = holidayPeriodDTO.Id }, holidayPeriodDTO);
            }
            return BadRequest(_errorMessages);
        }           

    }
}