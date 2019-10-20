using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AccountingEquipments.WindowsForms.Data
{
    public class DataManager
    {
        private HttpClient client = new HttpClient();

        public DataManager(string baseAddress)
        {
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T[]> List<T>(string controllerName)
        {
            HttpResponseMessage response = await client.GetAsync($"api/{controllerName}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T[]>();
            }
            return new T[0];
        }
        public async Task<T> Get<T>(string controllerName, int id)
        {
            HttpResponseMessage response = await client.GetAsync($"api/{controllerName}/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            return default(T);
        }
        public async Task<Uri> Create<T>(string controllerName, T model)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                $"api/{controllerName}", model);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        public async Task Update<T>(string controllerName, int id, T model)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/{controllerName}/{id}", model);
            response.EnsureSuccessStatusCode();
        }

        public async Task<HttpStatusCode> Delete(string controllerName, int id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"api/{controllerName}/{id}");
            return response.StatusCode;
        }
    }
}
