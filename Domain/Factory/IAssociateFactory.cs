namespace Domain.Factory;

using Domain.Model;

public interface IAssociateFactory
{
    Associate NewAssociate(IColaborator colaborator, DateOnly startDate, DateOnly? endDate);
}