using System.Net.Http.Json;

namespace Sale.Web.Repositorio.Implementacion
{
    public class ConsumoGeneral<Tmodelo> : IConsumoGeneral<Tmodelo> where Tmodelo : class
    {
        protected readonly HttpClient _http;
        public ConsumoGeneral(HttpClient http)
        {
            _http = http;

        }

        public async Task<Tmodelo?> Create(string api, Tmodelo modelo)
        {
            var response = await _http.PostAsJsonAsync(api, modelo);

            if (response.IsSuccessStatusCode)
            {
                // Deserializar la respuesta en PaisDTO
                return await response.Content.ReadFromJsonAsync<Tmodelo>();
            }

            // Manejo de error según el código de estado
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                throw new Exception("Datos inválidos enviados a la API.");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new Exception("No autorizado para crear.");

            throw new Exception($"Error en la API: {response.StatusCode}");
        }

        public async Task<bool> Delete(string api, int id)
        {
            var response = await _http.DeleteAsync($"{api}/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true; // Eliminación exitosa
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return false; // No existe
            }
            else
            {
                // Aquí puedes agregar manejo de otros códigos (403, 401, etc.)
                return false;
            }
        }

        public async Task<List<Tmodelo>?> GetAllRecords(string api) => await _http.GetFromJsonAsync<List<Tmodelo>>(api);

        public async Task<List<Tmodelo>?> GetAllRecordsActive(string api, string Estado) => await _http.GetFromJsonAsync<List<Tmodelo>>($"{api}/default/{Estado}");

        public async Task<string?> GetName(string api, int id) => await _http.GetStringAsync($"{api}/name/{id}");

        public async Task<Tmodelo?> GetRecordsById(string api, int id) => await _http.GetFromJsonAsync<Tmodelo>($"{api}/{id}");


        public async Task<List<Tmodelo>?> GetRecordsDropActive(string api, string Estado) => await _http.GetFromJsonAsync<List<Tmodelo>>($"{api}/Combo/{Estado}");

        public async Task<Tmodelo?> Update(string api, int id, Tmodelo modelo)
        {
            var response = await _http.PutAsJsonAsync($"{api}/{id}", modelo);
            if (response.IsSuccessStatusCode)
            {
                // Devuelve el objeto actualizado desde la respuesta
                return await response.Content.ReadFromJsonAsync<Tmodelo>();
            }
            else
            {
                // Puedes manejar errores según el código de respuesta
                // Por ejemplo: 400, 404, 401, etc.
                return null;
            }
        }

    }
}
