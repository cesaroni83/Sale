namespace Sale.Web.Repositorio
{
    public interface IConsumoGeneral<Tmodelo> where Tmodelo : class
    {
        Task<List<Tmodelo>?> GetAllRecords(string api);
        Task<List<Tmodelo>?> GetAllRecordsActive(string api,string Estado);
        Task<List<Tmodelo>?> GetRecordsDropActive(string api, string Estado);
        Task<Tmodelo?> GetRecordsById(string api,int id);
        Task<string?> GetName(string api, int id);
        Task<Tmodelo?> Create(string api,Tmodelo modelo);
        Task<Tmodelo?> Update(string api,int id, Tmodelo modelo);
        Task<bool> Delete(string api, int id);
    }
}
