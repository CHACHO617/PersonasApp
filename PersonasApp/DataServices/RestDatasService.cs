using PersonasApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PersonasApp.DataServices
{
    public class RestDatasService : IRestDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public RestDatasService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5278" : "https://localhost:7032";
            _url = $"{_baseAddress}/api";

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task AddPersonaAsync(Persona persona)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("********* No internet Acess");
                return;
            }

            try
            {
                string jsonPersona = JsonSerializer.Serialize<Persona>(persona, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonPersona, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync($"{_url}/Personas", content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("********** Persona Creada Correctamente");

                }
                else
                {
                    Debug.WriteLine("********** Problema Crear Contacto");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops Exception: {ex.Message}");
            }

            return;
        }

        public async Task DeletePersonaAsync(int id)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("********* No internet Acess");
                return;
            }

            try
            {

                HttpResponseMessage response = await _httpClient.DeleteAsync($"{_url}/Personas/{id}");

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("********** Persona Eliminada Correctamente");

                }
                else
                {
                    Debug.WriteLine("********** Problema Eliminar Contacto");
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops Exception: {ex.Message}");
            }

        }

        public async Task<List<Persona>> GetAllPersonasAsync()
        {
            List<Persona> listaPersonas = new List<Persona>();

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("********* No internet Acess");
                return listaPersonas;
            }

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/Personas");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    listaPersonas = JsonSerializer.Deserialize<List<Persona>>(content, _jsonSerializerOptions);
                }
                else
                {
                    Debug.WriteLine("************ ProblemaTrayendoLista");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops Exception: {ex.Message}");
            }

            return listaPersonas;
        }

        public async Task UpdatePersonasAsync(Persona persona)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("********* No internet Acess");
                return;
            }

            try
            {

                string jsonPersona = JsonSerializer.Serialize<Persona>(persona, _jsonSerializerOptions);
                StringContent content = new StringContent(jsonPersona, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PutAsync($"{_url}/Personas/{persona.Id}", content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("********** Persona Editada Correctamente");

                }
                else
                {
                    Debug.WriteLine("********** Problema Editar Contacto");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops Exception: {ex.Message}");
            }

            return;
        }

    }
}

