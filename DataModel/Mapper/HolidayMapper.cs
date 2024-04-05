namespace DataModel.Mapper;

using DataModel.Model;

using Domain.Model;
using Domain.Factory;

public class HolidayMapper
{
    private IHolidayFactory _holidayFactory;

    private ColaboratorMapper _colaboratorMapper;
    

    public HolidayMapper(IHolidayFactory holidayFactory, ColaboratorMapper colaboratorMapper)
    {
        _holidayFactory = holidayFactory;
        _colaboratorMapper = colaboratorMapper;
    }

    public Holiday ToDomain(HolidayDataModel holidayDM)
    {
        IColaborator colaborator = _colaboratorMapper.ToDomain(holidayDM.Colaborator);
        Holiday holiday = _holidayFactory.NewHoliday(colaborator);
        holiday.Id = holidayDM.Id;
        return holiday;
    }

    public IEnumerable<Holiday> ToDomain(IEnumerable<HolidayDataModel> holidaysDM)
    {
        List<Holiday> holidays = new List<Holiday>();
        foreach (HolidayDataModel holidayDM in holidaysDM)
        {
            Holiday holiday = ToDomain(holidayDM);
            holidays.Add(holiday);
        }
        return holidays;
    }

    public HolidayDataModel ToDataModel(Holiday holiday)
    {
        HolidayDataModel holidayDM = new HolidayDataModel(holiday);
        return holidayDM;
    }

    // public bool UpdateDataModel (HolidayDataModel holidayDM, Holiday holiday)
    // {
    //     // holidayDM.ColaboratorId = holiday.Colaborador.Id;
    //     return true;
    // }
}