namespace Application.Services;

using Domain.Model;
using Application.DTO;

using Microsoft.EntityFrameworkCore;
using Domain.IRepository;

public class ColaboratorService {

<<<<<<< HEAD
    // private readonly AbsanteeContext _context;

=======
>>>>>>> 27b5ebcca87fe39f6866c9913765022427a001e8
    private readonly IColaboratorRepository _colaboratorRepository;
    
    public ColaboratorService(IColaboratorRepository colaboratorRepository) {
        _colaboratorRepository = colaboratorRepository;
<<<<<<< HEAD

        // _context = context;
=======
>>>>>>> 27b5ebcca87fe39f6866c9913765022427a001e8
    }

    public async Task<IEnumerable<ColaboratorDTO>> GetAllWithAddress()
    {    
        IEnumerable<Colaborator> colabs = await _colaboratorRepository.GetColaboratorsAsync();
        
        if (colabs is not null)
        {
            IEnumerable<ColaboratorDTO> colabsDTO = ColaboratorDTO.ToDTO(colabs);

<<<<<<< HEAD
            return colabsDTO;
        }

        return null;
=======
        //IEnumerable<Colaborator> colabs2 = _colaboratorRepository.GetAll();

        IEnumerable<ColaboratorDTO> colabsDTO = ColaboratorDTO.ToDTO(colabs);
>>>>>>> 27b5ebcca87fe39f6866c9913765022427a001e8

    }

    public async Task<ColaboratorDTO> GetByIdWithAddress(long id)
    {    
        Colaborator colaborator = await _colaboratorRepository.GetColaboratorByIdAsync(id);

<<<<<<< HEAD
        if (colaborator is not null)
        {
            ColaboratorDTO colabDTO = ColaboratorDTO.ToDTO(colaborator);

            return colabDTO;
        }
        return null;

=======
        if(colaborator!=null)
        {
            ColaboratorDTO colabDTO = ColaboratorDTO.ToDTO(colaborator);
            return colabDTO;
        }
        return null;
>>>>>>> 27b5ebcca87fe39f6866c9913765022427a001e8
    }

    public async Task<ColaboratorDTO> GetByEmailWithAddress(string strEmail)
    {    
        Colaborator colaborator =  await _colaboratorRepository.GetColaboratorByEmailAsync(strEmail);

<<<<<<< HEAD
        if (colaborator is not null)
        {
            ColaboratorDTO colabDTO = ColaboratorDTO.ToDTO(colaborator);

=======
        if(colaborator!=null)
        {
            ColaboratorDTO colabDTO = ColaboratorDTO.ToDTO(colaborator);
>>>>>>> 27b5ebcca87fe39f6866c9913765022427a001e8
            return colabDTO;
        }
        return null;
    }

    public async Task<ColaboratorDTO> Add(ColaboratorDTO colaboratorDTO, List<string> errorMessages)
    {
        bool bExists = await _colaboratorRepository.ColaboratorExists(colaboratorDTO.Email);
        if(bExists) {
            errorMessages.Add("Already exists");
            return null;
        }
        try{

        Colaborator colaborator = ColaboratorDTO.ToDomain(colaboratorDTO);

        Colaborator colaboratorSaved = await _colaboratorRepository.Add(colaborator);

        ColaboratorDTO colabDTO = ColaboratorDTO.ToDTO(colaboratorSaved);

        return colabDTO;
        }
        catch (ArgumentException ex)
        {
            errorMessages.Add(ex.Message);
            return null;
        }
    }

    public async Task<bool> Update(string email, ColaboratorDTO colaboratorDTO, List<string> errorMessages)
    {
        Colaborator colaborator = await _colaboratorRepository.GetColaboratorByEmailAsync(email);

        if(colaborator!=null)
        {
            ColaboratorDTO.UpdateToDomain(colaborator, colaboratorDTO);

            await _colaboratorRepository.Update(colaborator, errorMessages);

            return true;
        }
        else
        {
            errorMessages.Add("Not found");

            return false;
        }
    }
}