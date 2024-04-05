namespace Application.DTO;

using Domain.Model;

public class HolidayDTO
{
    public long Id { get; set; }
    public string ColaboratorEmail { get; set; }

    public HolidayDTO()
    {        
    }

    public HolidayDTO(long id, string colaboratorEmail)
    {
        Id = id;
        ColaboratorEmail = colaboratorEmail;
    }

    public static HolidayDTO ToDTO(Holiday holiday)
    {
        Colaborator colab = (Colaborator)holiday.Colaborador;
        ColaboratorDTO colaboratorDTO = ColaboratorDTO.ToDTO(colab);

        HolidayDTO holidayDTO = new HolidayDTO(holiday.Id, colaboratorDTO.Email);

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

    public static Holiday ToDomain(HolidayDTO holidayDTO, Colaborator colab)
    {
        Holiday holiday = new Holiday(colab);
        return holiday;
    }
}