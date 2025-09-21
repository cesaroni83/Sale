using Sale.Shared.Modelo.DTO;

namespace Sale.Api.Servicios
{
    public interface IPersonas
    {
        Task<List<PersonaDTO>> GetListaAllPersonas();
        Task<PersonaDTO> GetPersona(int id);
        Task<PersonaDTO> CreatePersona(PersonaDTO modelo);
        Task<bool> UpdatePersona(PersonaDTO modelo);
        Task<bool> DeletePersona(int id);
        Task<List<PersonaDTO>> GetListPersonaActivo(string Estado_Activo);

        Task<List<PersonaDropDTO>> GetPersonaCombo(string Estado_Activo);

        Task<string> GetPersonaName(int id);

        Task<bool> DeletePersonaLogica(int id);
    }
}
