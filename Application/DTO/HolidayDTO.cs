namespace Application.DTO;

using Domain.Model;

public class HolidayDTO
{
    public long Id { get; set; }
    public ColaboratorDTO Colaborator { get; set; }
    public List<HolidayPeriodDTO> HolidayPeriods { get; set; }

    public HolidayDTO()
    {        
    }

    public HolidayDTO(long Id, ColaboratorDTO colaborator, List<HolidayPeriodDTO> holidayPeriods)
    {
        Colaborator = colaborator;
        HolidayPeriods = holidayPeriods;
    }

    public static HolidayDTO ToDTO(Holiday holiday)
    {
        HolidayDTO holidayDTO = new HolidayDTO(holiday.Id,
                    new ColaboratorDTO(
                            holiday.Colaborador.Id, 
                            holiday.Colaborador.GetName(), 
                            holiday.Colaborador.GetEmail(),
                            holiday.Colaborador.GetStreet(),
                            holiday.Colaborador.GetPostalCode()
                    ), 
                    HolidayPeriodDTO.ToDTO(holiday.HolidayPeriods).ToList());
        return holidayDTO;
    }

    public static IEnumerable<HolidayDTO> ToDTO(IEnumerable<Holiday> holidays)
    {
        List<HolidayDTO> holidayDTOs = new List<HolidayDTO>();

        foreach (Holiday holiday in holidays)
        {
            HolidayDTO holidayDTO = ToDTO(holiday);
            holidayDTOs.Add(holidayDTO);
        }
        return holidayDTOs;
    }

    public static Holiday ToDomain(HolidayDTO holidayDTO)
    {
        List<HolidayPeriod> holidayPeriods = holidayDTO.HolidayPeriods.Select(hp => HolidayPeriodDTO.ToDomain(hp)).ToList();
        Holiday holiday = new Holiday(
                        ColaboratorDTO.ToDomain(holidayDTO.Colaborator),
                        holidayPeriods
    );
        return holiday;
    }
}