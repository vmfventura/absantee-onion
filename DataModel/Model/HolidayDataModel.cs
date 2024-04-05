using System.ComponentModel.DataAnnotations.Schema;
using Domain.Model;

namespace DataModel.Model;
public class HolidayDataModel
{
    public long Id { get; set; }
    public string ColaboratorEmail { get; set; }
    [ForeignKey(nameof(ColaboratorEmail))]
    public virtual ColaboratorDataModel Colaborator { get; set; }    

    public HolidayDataModel()
    {            
    }

    public HolidayDataModel(Holiday holiday)
    {
        Id = holiday.Id;
        ColaboratorEmail = holiday.Colaborador.GetEmail();
    }
}