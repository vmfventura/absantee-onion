namespace DataModel.Repository;

using DataModel.Model;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;

public class AbsanteeContext : DbContext
{
	protected readonly IConfiguration Configuration;

	//public AbsanteeContext() {}
	public AbsanteeContext(DbContextOptions<AbsanteeContext> options)
		: base(options)
	{
		Database.EnsureCreated();
	}

	public virtual DbSet<ColaboratorDataModel> Colaborators { get; set; } = null!;
	public virtual DbSet<AddressDataModel> Address { get; set; } = null!;
	public virtual DbSet<HolidayPeriodDataModel> HolidayPeriod { get; set; } = null!;
	public virtual DbSet<HolidayDataModel> Holiday { get; set; } = null!;


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		// modelBuilder.Entity<HolidayDataModel>()
		// 	.HasOne(x => x.Colaborator)
		// 	.WithMany()
		// 	.HasForeignKey(x => x.ColaboratorEmail).HasPrincipalKey(x => x.Email);
		// necessário se Domain.Model.Colaborator fosse usado para persistência, e se pretendesse que os atributos/propriedades fossem privadas

		// var property = typeof(Colaborator).GetProperty("Name", BindingFlags.NonPublic | BindingFlags.Instance);
		// if (property != null)
		// 	modelBuilder.Entity<Colaborator>()
		// 		.Property("_strName")
		// 		.HasColumnName("Name");

		// modelBuilder.Entity<Colaborator>()
        // 	.HasKey(c => c.Id);
			
		// modelBuilder.Entity<Colaborator>()
        // 	.HasKey(c => c.Email);

	}
}