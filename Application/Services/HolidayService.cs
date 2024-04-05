namespace Application.Services;

using Domain.Model;
using Application.DTO;

using Microsoft.EntityFrameworkCore;
using Domain.IRepository;

public class HolidayService
{
    private readonly IHolidayRepository _holidayRepository;

    private readonly IColaboratorRepository _colaboratorRepository;

    public HolidayService(IHolidayRepository holidayRepository, IColaboratorRepository colaboratorRepository)
    {
        _holidayRepository = holidayRepository;
        _colaboratorRepository = colaboratorRepository;
    }

    public async Task<IEnumerable<HolidayDTO>> GetAllHolidays()
    {
        var holidays = await _holidayRepository.GetAllHolidays();

        if (holidays is not null)
        {
            IEnumerable<HolidayDTO> holidaysDTO = HolidayDTO.ToDTO(holidays);
            return holidaysDTO;
        }
        return null;
    }

    public async Task<HolidayDTO> GetById(long id)
    {
        Holiday holiday = await _holidayRepository.GetHolidayById(id);
        if (holiday is not null)
        {
            HolidayDTO holidayDTO = HolidayDTO.ToDTO(holiday);
            return holidayDTO;
        }
        return null;
    }

    public async Task<HolidayDTO> Add(HolidayDTO holidayDTO, List<string> errorMessages)
    {
        bool holidayExists = await _holidayRepository.HolidayExists(holidayDTO.Id);
        if (holidayExists)
        {
            errorMessages.Add("Already exists");
            return null;
        }
        bool cExists = await _colaboratorRepository.ColaboratorExists(holidayDTO.ColaboratorEmail);
        if (!cExists)
        {
            errorMessages.Add("Colaborator doesnt exist");
            return null;
        }

        Colaborator colaborator = await _colaboratorRepository.GetColaboratorByEmailAsync(holidayDTO.ColaboratorEmail);
        try
        {
            Holiday holiday = HolidayDTO.ToDomain(holidayDTO, colaborator);
            Holiday holidaySaved = await _holidayRepository.Add(holiday);
            HolidayDTO holidayDTOSaved = HolidayDTO.ToDTO(holidaySaved);
            return holidayDTOSaved;
        }
        catch (ArgumentException ex)
        {
            errorMessages.Add(ex.Message);
            return null;
        }
    }
}