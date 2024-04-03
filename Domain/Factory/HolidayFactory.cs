namespace Domain.Factory;

using Domain.Model;

public class HolidayFactory : IHolidayFactory
{
    public Holiday NewHoliday(IColaborator colaborator)
    {
        return new Holiday(colaborator);
    }
}