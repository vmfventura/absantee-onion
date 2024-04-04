namespace DataModel.Repository;

using Microsoft.EntityFrameworkCore;

using DataModel.Model;
using DataModel.Mapper;

using Domain.Model;
using Domain.IRepository;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

public class HolidayRepository : GenericRepository<Holiday>, IHolidayRepository
{
    HolidayMapper _holidayMapper;
    public HolidayRepository(AbsanteeContext context, HolidayMapper mapper) : base(context!)
    {
        _holidayMapper = mapper;
    }

    public async Task<IEnumerable<Holiday>> GetAllHolidays()
    {
        try
        {
            IEnumerable<HolidayDataModel> holidaysDataModel = await _context.Set<HolidayDataModel>()
                .Include(h => h.ColaboratorDataModel)
                .Include(h => h.HolidayPeriods)
                .Include(h => h.ColaboratorDataModel.Address)
                .ToListAsync();
            IEnumerable<Holiday> holidays = _holidayMapper.ToDomain(holidaysDataModel);
            return holidays;
        }
        catch
        {
            return null;
        }
    }

    public async Task<Holiday> GetHolidayById(long id)
    {
        try
        {
            HolidayDataModel holidayDataModel = await _context.Set<HolidayDataModel>()
                        .Include(h => h.ColaboratorDataModel)
                        .Include(h => h.HolidayPeriods)
                        .Include(h => h.ColaboratorDataModel.Address)
                        .FirstAsync(h => h.Id == id);

            Holiday holiday = _holidayMapper.ToDomain(holidayDataModel);
            return holiday;
        }
        catch
        {
            return null;
        }
    }

    public async Task<Holiday> Add(Holiday holiday)
    {
        try
        {
            HolidayDataModel holidayDataModel = _holidayMapper.ToDataModel(holiday);

            EntityEntry<HolidayDataModel> holidayDataModelEntityEntry = _context.Set<HolidayDataModel>().Add(holidayDataModel);

            await _context.SaveChangesAsync();

            HolidayDataModel holidayDataModelSaved = holidayDataModelEntityEntry.Entity;

            Holiday holidaySaved = _holidayMapper.ToDomain(holidayDataModelSaved);
            
            return holidaySaved;
        }
        catch
        {            
            throw;
        }
    }

    public async Task<Holiday> Update(Holiday holiday, List<string> errorMessages)
    {
        try
        {
            HolidayDataModel holidayDataModel = await _context.Set<HolidayDataModel>()
                            .FirstAsync(h => h.Id == holiday.Id);
            
            _holidayMapper.UpdateDataModel(holidayDataModel, holiday);
            _context.Entry(holidayDataModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return holiday;
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await HolidayExists(holiday.Id))
            {
                errorMessages.Add("Not found");
                return null;
            }
            else
            {
                throw;
            }
        }
    }
    public async Task<bool> HolidayExists(long id)
    {
        return await _context.Set<HolidayDataModel>().AnyAsync(h => h.Id == id);
    }
    public async Task<bool> HolidayExistsByColaborator(string email)
    {
        return await _context.Set<HolidayDataModel>().AnyAsync(h => h.ColaboratorDataModel.Email == email);
    }
}
