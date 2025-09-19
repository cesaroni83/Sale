using Sale.Shared.Modelo.DTO;
using System.Net.Http.Json;

namespace Sale.Web.Repositorio
{
    public class ConsumoPais
    {
        private readonly HttpClient _http;
        public ConsumoPais(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<PaisDTO>?> GetPaisAll() => await _http.GetFromJsonAsync<List<PaisDTO>>("api/Paises");
        public async Task<PaisDTO?> UpdatePais(PaisDTO pais)
        {
            // Envía la petición PUT a la API
            var response = await _http.PutAsJsonAsync($"api/Paises/{pais.Id_pais}", pais);

            if (response.IsSuccessStatusCode)
            {
                // Devuelve el objeto actualizado desde la respuesta
                return await response.Content.ReadFromJsonAsync<PaisDTO>();
            }
            else
            {
                // Puedes manejar errores según el código de respuesta
                // Por ejemplo: 400, 404, 401, etc.
                return null;
            }
        }
        // crear
        public async Task<PaisDTO?> CreatePais(PaisDTO nuevoPais)
        {
            var response = await _http.PostAsJsonAsync("api/Paises", nuevoPais);

            if (response.IsSuccessStatusCode)
            {
                // Deserializar la respuesta en PaisDTO
                return await response.Content.ReadFromJsonAsync<PaisDTO>();
            }

            // Manejo de error según el código de estado
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                throw new Exception("Datos inválidos enviados a la API.");

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                throw new Exception("No autorizado para crear.");

            throw new Exception($"Error en la API: {response.StatusCode}");
        }

        public async Task<bool> CancelPais(int idPais)
        {
            var response = await _http.DeleteAsync($"api/Pais/{idPais}");

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
    }
}
