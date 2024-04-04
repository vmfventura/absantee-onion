using Domain.Model;

namespace Domain.IRepository;
public interface IHolidayRepository : IGenericRepository<Holiday>
{
    Task<IEnumerable<Holiday>> GetAllHolidays();
    Task<Holiday> GetHolidayById(long id);
    Task<Holiday> Add(Holiday holiday);
    Task<Holiday> Update(Holiday holiday, List<string> errorMessages);
    Task<bool> HolidayExists(long id);
    Task<bool> HolidayExistsByColaborator(string email);
}