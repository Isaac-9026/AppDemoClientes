using System;
using System.Collections.Generic;
using System.Text;

//Invocar capa Entidades
using Entidades;

namespace DAL
{
    public interface IClienteDal
    {
        //Listar <Cliente> Entidad (CAPA)
        Task<List<Cliente>> ListarAsync(string? buscar = null, CancellationToken ct = default);

        //obtener >Clase?>
        //Podemos retornar una clase o un NULL
        Task<Cliente?> ObtenerAsync(int id, CancellationToken ct = default);

        //Crear
        Task<Cliente?> CrearAsync(Cliente cliente, CancellationToken ct = default);

        //actualizar
        //No retorna valor, pero si define un método ASINCRONO
        Task ActualizarAsync(Cliente cliente, CancellationToken ct = default);

        //eliminar
        Task EliminarAsync(int id, CancellationToken ct = default);
    }
}
