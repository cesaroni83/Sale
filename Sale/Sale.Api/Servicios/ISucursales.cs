using Sale.Shared.Modelo.DTO;

namespace Sale.Api.Servicios
{
    public interface ISucursales
    {
        Task<List<SucursalDTO>> GetListaAllSucursales();
        Task<SucursalDTO> GetSucursal(int id);
        Task<SucursalDTO> CreateSucursal(SucursalDTO modelo);
        Task<bool> UpdateSucursal(SucursalDTO modelo);
        Task<bool> DeleteSucursal(int id);
        Task<List<SucursalDTO>> GetListSucursalActivo(string Estado_Activo);

        Task<List<SucursalDropDTO>> GetSucursalCombo(string Estado_Activo);

        Task<string> GetSucursalName(int id);

        Task<bool> DeleteSucursalLogica(int id);
    }
}
