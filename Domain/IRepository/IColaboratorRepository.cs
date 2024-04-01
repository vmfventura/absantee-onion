namespace Domain.IRepository;

using Domain.Model;

public interface IColaboratorRepository : IGenericRepository<Colaborator>
{
    Task<IEnumerable<Colaborator>> GetColaboratorsAsync();
<<<<<<< HEAD
    Task<Colaborator> GetColaboratorByEmailAsync(string email);
    Task<Colaborator> GetColaboratorByIdAsync(long id);
    Task<Colaborator> Add(Colaborator colaborator);
    Task<Colaborator> Update(Colaborator colaborator, List<string> errorMessages);
=======

    Task<Colaborator> GetColaboratorByEmailAsync(string email);

    Task<Colaborator> GetColaboratorByIdAsync(long id);

    Task<Colaborator> Add(Colaborator colaborator);

    Task<Colaborator> Update(Colaborator colaborator, List<string> errorMessages);

>>>>>>> 27b5ebcca87fe39f6866c9913765022427a001e8
    Task<bool> ColaboratorExists(string email);
}
