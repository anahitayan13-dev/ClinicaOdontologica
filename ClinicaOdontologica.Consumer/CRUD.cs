using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClinicaOdontologica.Consumer
{
    public static class CRUD<T>
    {
        public static string Endpoint { get; set; }

        // Un solo HttpClient reutilizado (crear uno por cada llamada puede
        // agotar los sockets disponibles y causar errores intermitentes).
        private static readonly HttpClient cliente = new HttpClient();

        private static void ValidarEndpoint()
        {
            if (string.IsNullOrWhiteSpace(Endpoint))
            {
                throw new InvalidOperationException(
                    $"CRUD<{typeof(T).Name}>.Endpoint no fue asignado. " +
                    $"Ponlo en Program.cs antes de usar CRUD<{typeof(T).Name}>.");
            }
        }

        public static List<T> GetAll()
        {
            ValidarEndpoint();

            var response = cliente.GetAsync(Endpoint).Result;
            var contenido = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<T>>(contenido);
            }
            else
            {
                throw new Exception(
                    $"Error {(int)response.StatusCode} ({response.StatusCode}) al llamar GET {Endpoint}. " +
                    $"Respuesta: {contenido}");
            }
        }


        public static T GetById(int id)
        {
            ValidarEndpoint();

            var url = $"{Endpoint}/{id}";
            var response = cliente.GetAsync(url).Result;
            var contenido = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(contenido);
            }
            else
            {
                throw new Exception(
                    $"Error {(int)response.StatusCode} ({response.StatusCode}) al llamar GET {url}. " +
                    $"Respuesta: {contenido}");
            }
        }

        public static T Create(T item)
        {
            ValidarEndpoint();

            var body = new StringContent(
                JsonConvert.SerializeObject(item),
                Encoding.UTF8,
                "application/json");

            var response = cliente.PostAsync(Endpoint, body).Result;
            var contenido = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(contenido);
            }
            else
            {
                throw new Exception(
                    $"Error {(int)response.StatusCode} ({response.StatusCode}) al llamar POST {Endpoint}. " +
                    $"Respuesta: {contenido}");
            }
        }

        public static bool Update(int id, T item)
        {
            ValidarEndpoint();

            var url = $"{Endpoint}/{id}";
            var body = new StringContent(
                JsonConvert.SerializeObject(item),
                Encoding.UTF8,
                "application/json");

            var response = cliente.PutAsync(url, body).Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var contenido = response.Content.ReadAsStringAsync().Result;
                throw new Exception(
                    $"Error {(int)response.StatusCode} ({response.StatusCode}) al llamar PUT {url}. " +
                    $"Respuesta: {contenido}");
            }
        }

        public static bool Delete(int id)
        {
            ValidarEndpoint();

            var url = $"{Endpoint}/{id}";
            var response = cliente.DeleteAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var contenido = response.Content.ReadAsStringAsync().Result;
                throw new Exception(
                    $"Error {(int)response.StatusCode} ({response.StatusCode}) al llamar DELETE {url}. " +
                    $"Respuesta: {contenido}");
            }
        }
    }
}