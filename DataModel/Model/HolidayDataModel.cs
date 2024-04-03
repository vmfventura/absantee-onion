using Domain.Model;

namespace DataModel.Model;
public class HolidayDataModel
{
    public long Id { get; set; }
    public ColaboratorDataModel ColaboratorDataModel { get; set; }
    public List<HolidayPeriodDataModel> HolidayPeriods { get; set; }

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