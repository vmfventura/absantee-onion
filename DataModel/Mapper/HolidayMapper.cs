namespace DataModel.Mapper;

using DataModel.Model;

using Domain.Model;
using Domain.Factory;

public class HolidayMapper
{
    public IHolidayFactory _holidayFactory;
    

    public HolidayMapper(IHolidayFactory holidayFactory)
    {
        _holidayFactory = holidayFactory;
    }

    public Holiday ToDomain(HolidayDataModel holidayDM)
    {
        IColaborator colab = new Colaborator(
                                holidayDM.ColaboratorDataModel.Name, 
                                holidayDM.ColaboratorDataModel.Email, 
                                holidayDM.ColaboratorDataModel.Address.Street, 
                                holidayDM.ColaboratorDataModel.Address.PostalCode);
        Holiday holiday = _holidayFactory.NewHoliday(colab);
        foreach (var holidayPeriods in holidayDM.HolidayPeriods)
        {
            IHolidayPeriodFactory _holidayPeriodFactory = new HolidayPeriodFactory();
            _holidayPeriodFactory.NewHolidayPeriod(holidayPeriods.StartDate, holidayPeriods.EndDate);
            holiday.AddHolidayPeriod(_holidayPeriodFactory, holidayPeriods.StartDate, holidayPeriods.EndDate);
        }
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

    public bool UpdateDataModel (HolidayDataModel holidayDM, Holiday holiday)
    {
        holidayDM.ColaboratorDataModel = (ColaboratorDataModel)holiday.GetColaborator();
        return true;
    }
}