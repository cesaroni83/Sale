using Sale.Shared.Modelo.DTO;
using Sale.Shared.Modelo.Entidades;

namespace Sale.Api.Servicios
{
    public interface IPaises
    {
        Task<List<PaisDTO>> GetListaAllPaises();
        Task<PaisDTO> GetPais(int id);
        Task<PaisDTO> CreatePais(PaisDTO modelo);
        Task<bool> UpdatePais(PaisDTO modelo);
        Task<bool> DeletePais(int id);
        Task<List<PaisDTO>> GetListPaisActivo(string Estado_Activo);

        Task<List<PaisDropDTO>> GetPaisCombo(string Estado_Activo);

        Task<string> GetPaisName(int id_pais);

        Task<bool> DeletePaisLogica(int id_pais);
    }
}
