using Domain.Model;

namespace DataModel.Model
{
    public class HolidayPeriodDataModel
    {
        public long Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int Status { get; set; }
        public HolidayPeriodDataModel()
        {            
        }

        public HolidayPeriodDataModel(HolidayPeriod holidayPeriod)
        {
            Id = holidayPeriod.Id;
            StartDate = holidayPeriod.StartDate;
            EndDate = holidayPeriod.EndDate;
        }
    }
}