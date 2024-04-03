namespace Domain.Factory;

using Domain.Model;
public interface IHolidayFactory
{
    Holiday NewHoliday(IColaborator colaborator);
}