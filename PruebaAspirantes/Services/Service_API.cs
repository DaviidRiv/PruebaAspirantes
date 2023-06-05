using PruebaAspirantes.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace PruebaAspirantes.Services
{
    public class Service_API : IService_API
    {
        private static string? _baseUrl;
        public Service_API() 
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }

        //No puedo acceder
        public async Task<bool> Editar(ModelAspirantes objeto)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var content = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("https://practical-moore.68-168-208-58.plesk.page/Aspirantes", content);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }


        public async Task<bool> Eliminar(int Id)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
           
            var response = await cliente.DeleteAsync($"https://practical-moore.68-168-208-58.plesk.page/Aspirantes/{Id}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }

        public async Task<bool> Guardar(ModelAspirantes objeto)
        {
            bool respuesta = false;

            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var jsonContent = new StringContent(JsonConvert.SerializeObject(objeto), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("https://practical-moore.68-168-208-58.plesk.page/Aspirantes", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }

            return respuesta;
        }


        public async Task<List<ModelAspirantes>> Lista()
        {
            List<ModelAspirantes> lista = new List<ModelAspirantes>();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.GetAsync("https://practical-moore.68-168-208-58.plesk.page/Aspirantes");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<ModelAspirantes>>(json_respuesta);
            }

            return lista;
        }

        public async Task<ModelAspirantes> Obtener(int Id)
        {
            ModelAspirantes objeto = new ModelAspirantes();

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://practical-moore.68-168-208-58.plesk.page/Aspirantes/{Id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var modelAspirantes = System.Text.Json.JsonSerializer.Deserialize<ModelAspirantes>(content);
                objeto = modelAspirantes;
            }

            return objeto;
        }


    }
}
