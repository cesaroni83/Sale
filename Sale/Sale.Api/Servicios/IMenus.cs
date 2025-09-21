using Sale.Shared.Modelo.DTO;

namespace Sale.Api.Servicios
{
    public interface IMenus
    {
        Task<List<MenuDTO>> GetListaAllMenu();
        Task<MenuDTO> GetMenu(int id);
        Task<MenuDTO> CreateMenu(MenuDTO modelo);
        Task<bool> UpdateMenu(MenuDTO modelo);
        Task<bool> DeleteMenu(int id);
        Task<List<MenuDTO>> GetListMenuActivo(string Estado_Activo);

        Task<List<MenuDropDTO>> GetMenuCombo(string Estado_Activo);

        Task<string> GetMenuName(int id_Menu);

        Task<bool> DeleteMenuLogica(int id_Menu);
    }
}
