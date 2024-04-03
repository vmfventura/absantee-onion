namespace Domain.Model;

using System.ComponentModel.DataAnnotations;
using Domain.Factory;

public class Holiday : IHoliday
{
	public long Id { get; set; }
	
	[Key]
	private IColaborator _colaborator;
	public IColaborator Colaborador
	{
		get { return _colaborator; }
	}

	private List<HolidayPeriod> _holidayPeriods = new List<HolidayPeriod>();
	public List<HolidayPeriod> HolidayPeriods
	{
		get { return _holidayPeriods; }
	}

	public Holiday(IColaborator colab)
	{
		if (colab != null)
		{
			_colaborator = colab;
		}
		else
			throw new ArgumentException("Invalid argument: colaborator must be non null");
	}

	public Holiday (IColaborator colab, List<HolidayPeriod> holidayPeriods)
	{
		if (colab is not null && holidayPeriods is not null)
		{
			_colaborator = colab;
			_holidayPeriods = holidayPeriods;
		}
		else
			throw new ArgumentException("Invalid argument: colaborator must be non null");
	}

	public HolidayPeriod AddHolidayPeriod(IHolidayPeriodFactory hpFactory, DateOnly startDate, DateOnly endDate)
	{
		HolidayPeriod holidayPeriod = hpFactory.NewHolidayPeriod(startDate, endDate);
		_holidayPeriods.Add(holidayPeriod);
		return holidayPeriod;
	}

	public string GetName()
	{
		return _colaborator.GetName();
	}

	public List<HolidayPeriod> GetHolidayPeriodsDuring(DateOnly startDate, DateOnly endDate)
	{
		return _holidayPeriods.Where(hp => hp.EndDate > startDate && hp.StartDate < endDate)
								// .Select(hp => new HolidayPeriod(hp.StartDate < startDate ? startDate : hp.StartDate,
								// 			hp.EndDate > endDate ? endDate : hp.EndDate))
								.ToList();
	}

	public bool HasColaboratorAndHolidayPeriodsDuring(IColaborator colaborator, DateOnly startDate, DateOnly endDate)
	{
			return _colaborator == colaborator && GetHolidayPeriodsDuring(startDate, endDate).Any();
	}

	

	public int GetHolidaysDaysWithMoreThanXDaysOff(int intDaysOff)
	{
		int numberOfDays = 0;

		foreach (HolidayPeriod hp in _holidayPeriods)
		{
			numberOfDays += hp.GetNumberOfDays();
		}
		if (numberOfDays > intDaysOff)
		{
			return numberOfDays;
		}
		else
		{
			return 0;
		}
	}

	public int GetNumberOfHolidayPeriodsDays()
	{
		return _holidayPeriods.Sum(hp => hp.GetNumberOfDays());
	}

	public bool HasColaborador(IColaborator colab)
	{
		return _colaborator == colab;
	}

	public IColaborator GetColaborator()
	{
		return _colaborator;
	}

	// public List<HolidayPeriod> GetHolidayPeriods()
	// {
	// 	return _holidayPeriods;
	// }
}