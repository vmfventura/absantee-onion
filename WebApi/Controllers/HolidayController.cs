using Microsoft.AspNetCore.Mvc;

using Application.Services;
using Application.DTO;
using Domain.Factory;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HolidayController : ControllerBase
    {
        private readonly HolidayService _holidayService;
        List<string> _errorMessages = new List<string>();

        public HolidayController(HolidayService holidayService)
        {
            _holidayService = holidayService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HolidayDTO>>> GetHolidays()
        {
            IEnumerable<HolidayDTO> holidaysDTO = await _holidayService.GetAllHolidays();
            return Ok(holidaysDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HolidayDTO>> GetHolidayById(long id)
        {
            var holidayDTO = await _holidayService.GetById(id);
            if (holidayDTO is not null)
            {
                return Ok(holidayDTO);
            }
            return NotFound();
        }
    

        [HttpPost]
        public async Task<ActionResult<HolidayDTO>> PostHoliday(HolidayDTO holidayDTO)
        {
            HolidayDTO holidayResultDTO = await _holidayService.Add(holidayDTO, _errorMessages);
            if (holidayResultDTO is not null)
            {
                return CreatedAtAction(nameof(GetHolidayById), new { id = holidayResultDTO.Id }, holidayResultDTO);
            }
            return BadRequest(_errorMessages);
        }
    }
}