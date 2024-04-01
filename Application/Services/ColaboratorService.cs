namespace Application.Services;

using Domain.Model;
using Application.DTO;

using Microsoft.EntityFrameworkCore;
using DataModel.Repository;

public class ColaboratorService {

    private readonly AbsanteeContext _context;

    private readonly ColaboratorRepository _colaboratorRepository;
    
    public ColaboratorService(ColaboratorRepository colaboratorRepository, AbsanteeContext context) {
        _colaboratorRepository = colaboratorRepository;

        _context = context;
    }

    public async Task<IEnumerable<ColaboratorDTO>> GetAllWithAddress()
    {    
        IEnumerable<Colaborator> colabs = await _colaboratorRepository.GetColaboratorsAsync();

        IEnumerable<ColaboratorDTO> colabsDTO = ColaboratorDTO.ToDTO(colabs);

        return colabsDTO;
    }

    public async Task<ColaboratorDTO> GetByIdWithAddress(long id)
    {    
        Colaborator colaborator = await _colaboratorRepository.GetColaboratorByIdAsync(id);

        ColaboratorDTO colabDTO = ColaboratorDTO.ToDTO(colaborator);

        return colabDTO;
    }

    public async Task<ColaboratorDTO> GetByEmailWithAddress(string strEmail)
    {    
        Colaborator colaborator =  await _colaboratorRepository.GetColaboratorByEmailAsync(strEmail);

        ColaboratorDTO colabDTO = ColaboratorDTO.ToDTO(colaborator);

        return colabDTO;
    }

    public async Task<ColaboratorDTO> Add(ColaboratorDTO colaboratorDTO, List<string> errorMessages)
    {
        bool bExists = await _colaboratorRepository.ColaboratorExists(colaboratorDTO.Email);
        if(bExists) {
            errorMessages.Add("Already exists");
            return null;
        }

        Colaborator colaborator = ColaboratorDTO.ToDomain(colaboratorDTO);

        colaborator = await _colaboratorRepository.Add(colaborator);

        ColaboratorDTO colabDTO = ColaboratorDTO.ToDTO(colaborator);

        return colabDTO;
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