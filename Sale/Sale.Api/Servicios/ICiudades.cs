using Sale.Shared.Modelo.DTO;

namespace Sale.Api.Servicios
{
    public interface ICiudades
    {
        Task<List<CiudadDTO>> GetListaAllCiudades();
        Task<CiudadDTO> GetCiudad(int id);
        Task<CiudadDTO> CreateCiudad(CiudadDTO modelo);
        Task<bool> UpdateCiudad(CiudadDTO modelo);
        Task<bool> DeleteCiudad(int id);
        Task<List<CiudadDTO>> GetListCiudadActivo(string Estado_Activo);

        Task<List<CiudadDropDTO>> GetCiudadCombo(string Estado_Activo);

        Task<string> GetCiudadName(int id_Ciudad);

        Task<bool> DeleteCiudadLogica(int id_Ciudad);
    }
}
