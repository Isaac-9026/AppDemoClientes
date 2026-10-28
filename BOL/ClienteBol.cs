using System;
using System.Collections.Generic;
using System.Text;
using Entidades;
using DAL;
using System.Text.RegularExpressions;

namespace BOL
{
    /// <summary>
    /// La UI solo puede conversar con esta clase
    /// </summary>
    public class ClienteBol
    {
        //Utilizaremos la interfaz para conocer los métodos a aplicar
        private readonly IClienteDal _dal;
        public ClienteBol(IClienteDal dal) => _dal = dal;

        /// <summary>
        /// Este método sirve la acción LISTAR para la UI, tomando como referencia la clase de BOL y su INTERFAZ
        /// </summary>
        /// <param name="buscar"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        //Métodos
        public Task<List<Cliente>> ListarAsync(string? buscar = null, CancellationToken ct = default) => _dal.ListarAsync(buscar?.Trim(), ct);

        /// <summary>
        /// Buscador de clientes por ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public Task<Cliente?> ObtenerAsync(int id, CancellationToken ct = default) => _dal.ObtenerAsync(id, ct);
        
        public async Task GuardarAsync(Cliente cliente, CancellationToken ct = default)
        {
            //Validación
            Normalizar(cliente);        //Quitar los espacios en blanco (sanitizar)
            Validar(cliente);

            //La UI nos envia un ID = 0 (NUEVO)
            //UI nos envía un ID = 7 (ACTUALIZAR)
            if (cliente.Id == 0) await _dal.CrearAsync(cliente, ct);
            else await _dal.ActualizarAsync(cliente, ct);
        }

        public Task EliminarAsync(int id, CancellationToken ct = default)
        {
            //En el UI manejaremos un ID = 0 (No hay registro activo)
            if (id == 0) { throw new ReglaNegocioException("Seleccione un cliente para eliminar"); }
            return _dal.EliminarAsync(id, ct);
        }

        private static void Normalizar(Cliente cliente)
        {
            cliente.Apellidos = cliente.Apellidos.Trim();
            cliente.Nombres = cliente.Nombres.Trim();
            cliente.Dni = cliente.Dni.Trim();
            cliente.Telefono = cliente.Telefono.Trim();
            cliente.Direccion = cliente.Direccion.Trim();
            cliente.Correo = cliente.Correo.Trim();
        }

        private static void Validar(Cliente cliente)
        {
            if (cliente.Apellidos.Length == 0) { throw new ReglaNegocioException("Ingresa los apellidos", nameof(Cliente.Apellidos)); }
            if (cliente.Nombres.Length == 0) { throw new ReglaNegocioException("Ingrese su nombre", nameof(Cliente.Nombres)); }
            if (cliente.Dni.Length != 8 || !Regex.IsMatch(cliente.Dni, @"^\d{8}$")) { throw new ReglaNegocioException("Escriba correctamente DNI", nameof(Cliente.Dni)); }
            if (!Regex.IsMatch(cliente.Telefono, @"^\d{9}$")) { throw new ReglaNegocioException("El teléfono debe tener 9 digitos", nameof(cliente.Telefono)); }
        }
    }
}
