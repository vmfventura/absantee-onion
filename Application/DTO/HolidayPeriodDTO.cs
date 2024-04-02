namespace Application.DTO;

using Domain.Model;
public class HolidayPeriodDTO
{
    public long Id { get; set; }
    public DateOnly StartDate { get; set; }
	public DateOnly EndDate { get; set; }
	public int Status { get; set; }

    public HolidayPeriodDTO()
    {        
    }

    public HolidayPeriodDTO(long id, DateOnly startDate, DateOnly endDate)
    {
        Id = id;
        StartDate = startDate;
        EndDate = endDate;
    }

    public static HolidayPeriodDTO ToDTO(HolidayPeriod holidayPeriod)
    {
        HolidayPeriodDTO holidayPeriodDTO = new HolidayPeriodDTO(holidayPeriod.Id, holidayPeriod.StartDate, holidayPeriod.EndDate);
        return holidayPeriodDTO;
    }

    public static IEnumerable<HolidayPeriodDTO> ToDTO(IEnumerable<HolidayPeriod> holidayPeriods)
    {
        List<HolidayPeriodDTO> holidayPeriodsDTO = new List<HolidayPeriodDTO>();
        foreach (HolidayPeriod holidayPeriod in holidayPeriods)
        {
            HolidayPeriodDTO holidayPeriodDTO = ToDTO(holidayPeriod);
            holidayPeriodsDTO.Add(holidayPeriodDTO);
        }
        return holidayPeriodsDTO;
    }

    public static HolidayPeriod ToDomain(HolidayPeriodDTO holidayPeriodDTO)
    {
        HolidayPeriod holidayPeriod = new HolidayPeriod(holidayPeriodDTO.StartDate, holidayPeriodDTO.EndDate);
        return holidayPeriod;
    }
}