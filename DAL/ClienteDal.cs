using Entidades;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Acceso a datos de Clientes. En esta arquitectura el acceso a la BD es por API REST
    /// Se utilizará HTTPCLIENT en lugar de SQLCONNECTION
    /// </summary>
    public class ClienteDal : IClienteDal
    {
        //Objetos privados
        private const string RUTA = "api/clientes";
        private readonly HttpClient _http;

        //Constructor (nombre de la Clase)
        public ClienteDal(HttpClient http) => _http = http;

        public async Task ActualizarAsync(Cliente cliente, CancellationToken ct = default)
        {
            using var resp = await _http.PutAsJsonAsync($"{RUTA}/{cliente.Id}", cliente, ct);
            await AsegurarExitoAsync(resp, ct);
        }

        public async Task<Cliente?> CrearAsync(Cliente cliente, CancellationToken ct = default)
        {
            using var resp = await _http.PostAsJsonAsync(RUTA, cliente, ct);
            await AsegurarExitoAsync(resp, ct);
            return await resp.Content.ReadFromJsonAsync<Cliente>(ct); //Al registrar, API Rest devuelve {...}
        }

        public async Task EliminarAsync(int id, CancellationToken ct = default)
        {
            using var resp = await _http.DeleteAsync($"{RUTA}/{id}", ct);
            await AsegurarExitoAsync(resp, ct);
        }

        /// <summary>
        /// Retorna una lista de clientes utilizando un filtro de manera opcional
        /// </summary>
        /// <param name="buscar"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<List<Cliente>> ListarAsync(string? buscar = null, CancellationToken ct = default)
        {
            //¿Se nos envió datos en la variable buscar?
            var url = string.IsNullOrWhiteSpace(buscar) ? RUTA : $"{RUTA}?buscar={Uri.EscapeDataString(buscar)}";

            using var resp = await _http.GetAsync(url, ct);
            await AsegurarExitoAsync(resp, ct);

            return await resp.Content.ReadFromJsonAsync<List<Cliente>>(ct) ?? new();
        }

        public async Task<Cliente?> ObtenerAsync(int id, CancellationToken ct = default)
        {
            using var resp = await _http.GetAsync($"{RUTA}/{id}", ct);
            if (resp.StatusCode == HttpStatusCode.NotFound) { return null; }
            await AsegurarExitoAsync(resp,ct);

            //Es una busqueda por ID, Solo devolvemos un objeto
            return await resp.Content.ReadFromJsonAsync<Cliente>(ct);
        }

        private static async Task AsegurarExitoAsync(HttpResponseMessage resp, CancellationToken ct)
        {
            //Server Code 2XX
            if (resp.IsSuccessStatusCode) return;

            //¿Y si algo no funcionó? ...
            var cuerpo = await resp.Content.ReadAsStringAsync(ct);
            var detalle = string.IsNullOrWhiteSpace(cuerpo) ? resp.ReasonPhrase : cuerpo;

            //Excepción
            throw new ApiException($"El servidor respondió: {(int)resp.StatusCode}: {detalle}");
        }
    }
}
