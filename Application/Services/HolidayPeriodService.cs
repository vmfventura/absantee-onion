namespace Application.Services;

using Domain.Model;
using Application.DTO;

using Microsoft.EntityFrameworkCore;
using Domain.IRepository;
public class HolidayPeriodService
{
    private readonly IHolidayPeriodRepository _holidayPeriodRepository;

    public HolidayPeriodService(IHolidayPeriodRepository holidayPeriodRepository)
    {
        _holidayPeriodRepository = holidayPeriodRepository;
    }

    public async Task<IEnumerable<HolidayPeriodDTO>> GetAll()
    {
        IEnumerable<HolidayPeriod> holidayPeriods = await _holidayPeriodRepository.GetHolidayPeriodsAsync();

        if (holidayPeriods is not null)
        {
            IEnumerable<HolidayPeriodDTO> holidayPeriodsDTO = HolidayPeriodDTO.ToDTO(holidayPeriods);
            return holidayPeriodsDTO; 
        }

        return null;
    }

    public async Task<HolidayPeriodDTO> GetById(long id)
    {
        HolidayPeriod holidayPeriod = await _holidayPeriodRepository.GetHolidayPeriodById(id);

        if (holidayPeriod is not null)
        {
            HolidayPeriodDTO holidayPeriodDTO = HolidayPeriodDTO.ToDTO(holidayPeriod);
            return holidayPeriodDTO;
        }
        return null;
    }

    public async Task<HolidayPeriodDTO> Add (HolidayPeriodDTO holidayPeriodDTO, List<string> errorMessages)
    {
        bool hpExists = await _holidayPeriodRepository.HolidayPeriodExists(holidayPeriodDTO.Id);
        if (hpExists)
        {
            errorMessages.Add("Already exists");
            return null;
        }
        try
        {
            HolidayPeriod holidayPeriod = HolidayPeriodDTO.ToDomain(holidayPeriodDTO);
            HolidayPeriod holidayPeriodSaved = await _holidayPeriodRepository.Add(holidayPeriod);
            HolidayPeriodDTO holidayPeriodDTOSaved = HolidayPeriodDTO.ToDTO(holidayPeriodSaved);
            return holidayPeriodDTOSaved;
        }
        catch (ArgumentException ex)
        {
            errorMessages.Add(ex.Message);
            return null;
        }
    }
}