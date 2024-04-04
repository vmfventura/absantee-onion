namespace Domain.Factory;

using Domain.Model;
public class AssociateFactory
{
    public Associate NewAssociate(IColaborator colaborator, DateOnly startDate, DateOnly endDate)
    {
        return new Associate(colaborator, startDate, endDate);
    }
}