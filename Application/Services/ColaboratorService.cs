namespace Application.Services;

using Domain.Model;
using Application.DTO;

using Microsoft.EntityFrameworkCore;
using Domain.IRepository;

public class ColaboratorService {

    // private readonly AbsanteeContext _context;

    private readonly IColaboratorRepository _colaboratorRepository;
    
    public ColaboratorService(IColaboratorRepository colaboratorRepository) {
        _colaboratorRepository = colaboratorRepository;
    }

    public async Task<IEnumerable<ColaboratorDTO>> GetAllWithAddress()
    {    
        IEnumerable<Colaborator> colabs = await _colaboratorRepository.GetColaboratorsAsync();
        
        if (colabs is not null)
        {
            IEnumerable<ColaboratorDTO> colabsDTO = ColaboratorDTO.ToDTO(colabs);

            return colabsDTO;
        }

        return null;

    }

    public async Task<ColaboratorDTO> GetByIdWithAddress(long id)
    {    
        Colaborator colaborator = await _colaboratorRepository.GetColaboratorByIdAsync(id);


        if (colaborator is not null)
        {
            ColaboratorDTO colabDTO = ColaboratorDTO.ToDTO(colaborator);

            return colabDTO;
        }
        return null;
    }

    public async Task<ColaboratorDTO> GetByEmailWithAddress(string strEmail)
    {    
        Colaborator colaborator =  await _colaboratorRepository.GetColaboratorByEmailAsync(strEmail);


        if (colaborator is not null)
        {
            ColaboratorDTO colabDTO = ColaboratorDTO.ToDTO(colaborator);

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