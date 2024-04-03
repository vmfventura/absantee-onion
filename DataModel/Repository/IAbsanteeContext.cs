namespace DataModel.Repository;

using Microsoft.EntityFrameworkCore;

using DataModel.Model;

public interface IAbsanteeContext
{
	DbSet<ColaboratorDataModel> Colaboradores { get; set; }
	DbSet<AddressDataModel> Address { get; set; }
	DbSet<HolidayPeriodDataModel> HolidayPeriod { get; set; }
	DbSet<HolidayDataModel> Holiday { get; set; }
}