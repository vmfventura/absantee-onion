using Domain.Model;

namespace Domain.IRepository;
public interface IHolidayPeriodRepository : IGenericRepository<HolidayPeriod>
{
    Task<IEnumerable<HolidayPeriod>> GetHolidayPeriodsAsync();
    Task<HolidayPeriod> GetHolidayPeriodById(long id);
    Task<HolidayPeriod> Add(HolidayPeriod holidayPeriod);
    Task<bool> HolidayPeriodExists(long id);
}