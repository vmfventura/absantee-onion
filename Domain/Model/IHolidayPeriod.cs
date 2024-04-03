namespace Domain.Model;

public interface IHolidayPeriod
{
    long Id { get;}
    DateOnly StartDate { get;}
    DateOnly EndDate { get;}
    bool IsStartDateIsValid(DateOnly startDate, DateOnly endDate);
    int GetNumberOfDays();
}