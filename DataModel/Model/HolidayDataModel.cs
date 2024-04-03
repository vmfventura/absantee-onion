using Domain.Model;

namespace DataModel.Model;
public class HolidayDataModel
{
    public long Id { get; set; }
    public ColaboratorDataModel ColaboratorDataModel;
    public List<HolidayPeriodDataModel> HolidayPeriods;

    public HolidayDataModel()
    {            
    }

    public HolidayDataModel(Holiday holiday)
    {
        Id = holiday.Id;
        ColaboratorDataModel = new ColaboratorDataModel(holiday.Colaborador);
        HolidayPeriods = new List<HolidayPeriodDataModel>();
        foreach (HolidayPeriod holidayPeriod in holiday.HolidayPeriods)
        {
            HolidayPeriods.Add(new HolidayPeriodDataModel(holidayPeriod));
        }
    }
}