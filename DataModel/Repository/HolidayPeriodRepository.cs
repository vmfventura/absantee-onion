namespace DataModel.Repository;

using Microsoft.EntityFrameworkCore;

using DataModel.Model;
using DataModel.Mapper;

using Domain.Model;
using Domain.IRepository;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

public class HolidayPeriodRepository : GenericRepository<HolidayPeriod>, IHolidayPeriodRepository
{
    HolidayPeriodMapper _holidayPeriodMapper;

    public HolidayPeriodRepository(AbsanteeContext dbContext, HolidayPeriodMapper holidayPeriodMapper) : base(dbContext)
    {
        _holidayPeriodMapper = holidayPeriodMapper;
    }

    public async Task<IEnumerable<HolidayPeriod>> GetHolidayPeriodsAsync()
    {
        try
        {
            IEnumerable<HolidayPeriodDataModel> holidayPeriodsDataModel = await _context.Set<HolidayPeriodDataModel>()
                .ToListAsync();
            IEnumerable<HolidayPeriod> holidayPeriods = _holidayPeriodMapper.ToDomain(holidayPeriodsDataModel);
            return holidayPeriods;
        }
        catch 
        {
            return null;
        }
    }

    public async Task<HolidayPeriod> GetHolidayPeriodById(long id)
    {
        try
        {
            HolidayPeriodDataModel holidayPeriodDataModel = await _context.Set<HolidayPeriodDataModel>()
                .FirstAsync(h => h.Id == id);
            HolidayPeriod holidayPeriod = _holidayPeriodMapper.ToDomain(holidayPeriodDataModel);
            return holidayPeriod;
        }
        catch
        {
            return null;
        }
    }

    public async Task<HolidayPeriod> Add(HolidayPeriod holidayPeriod)
    {
        try
        {
            HolidayPeriodDataModel holidayPeriodDataModel = _holidayPeriodMapper.ToDataModel(holidayPeriod);

            EntityEntry<HolidayPeriodDataModel> holidayPeriodDataModelEntityEntry = _context.Set<HolidayPeriodDataModel>().Add(holidayPeriodDataModel);
            await _context.SaveChangesAsync();
            HolidayPeriodDataModel holidayPeriodDataModelSaved = holidayPeriodDataModelEntityEntry.Entity;
            HolidayPeriod holidayPeriodSaved = _holidayPeriodMapper.ToDomain(holidayPeriodDataModelSaved);
            return holidayPeriodSaved;
        }
        catch
        {
            
            throw;
        }
    }

    public async Task<bool> HolidayPeriodExists(long id)
    {
        return await _context.Set<HolidayPeriodDataModel>().AnyAsync(h => h.Id == id);
    }
}