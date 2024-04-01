namespace Domain.IRepository;

using Domain.Model;

public interface IColaboratorRepository : IGenericRepository<Colaborator>
{
    Task<IEnumerable<Colaborator>> GetColaboratorsAsync();
}
