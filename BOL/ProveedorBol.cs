using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using DAL;
using Entidades;

namespace BOL
{
    public class ProveedorBol
    {
        private readonly IProveedorDal _dal;

        public ProveedorBol(IProveedorDal dal) => _dal = dal;

        public Task<List<Proveedor>> ListarAsync(string? buscar = null, CancellationToken ct = default)
            => _dal.ListarAsync(buscar?.Trim(), ct);

        public Task<Proveedor?> ObtenerAsync(int id, CancellationToken ct = default)
            => _dal.ObtenerAsync(id, ct);

        public async Task GuardarAsync(Proveedor proveedor, CancellationToken ct = default)
        {
            Normalizar(proveedor);
            Validar(proveedor);

            if (proveedor.Id == 0)
                await _dal.CrearAsync(proveedor, ct);
            else
                await _dal.ActualizarAsync(proveedor, ct);
        }

        public Task EliminarAsync(int id, CancellationToken ct = default)
        {
            if (id == 0)
                throw new ReglaNegocioException("Seleccione un proveedor para eliminar");

            return _dal.EliminarAsync(id, ct);
        }

        private static void Normalizar(Proveedor proveedor)
        {
            proveedor.Ruc = proveedor.Ruc.Trim();
            proveedor.RazonSocial = proveedor.RazonSocial.Trim();
            proveedor.Direccion = proveedor.Direccion.Trim();
            proveedor.Telefono = proveedor.Telefono.Trim();
            proveedor.Correo = proveedor.Correo.Trim();
        }

        private static void Validar(Proveedor proveedor)
        {
            if (string.IsNullOrWhiteSpace(proveedor.Ruc) || !Regex.IsMatch(proveedor.Ruc, @"^\d{11}$"))
                throw new ReglaNegocioException("El RUC debe contener exactamente 11 dígitos numéricos", nameof(Proveedor.Ruc));

            if (string.IsNullOrWhiteSpace(proveedor.RazonSocial))
                throw new ReglaNegocioException("Ingrese la razón social de la empresa", nameof(Proveedor.RazonSocial));

            if (string.IsNullOrWhiteSpace(proveedor.Direccion))
                throw new ReglaNegocioException("Ingrese la dirección fiscal", nameof(Proveedor.Direccion));

            if (string.IsNullOrWhiteSpace(proveedor.Telefono) || !Regex.IsMatch(proveedor.Telefono, @"^\d{7,15}$"))
                throw new ReglaNegocioException("El teléfono debe contener entre 7 y 15 dígitos numéricos", nameof(Proveedor.Telefono));

            if (!string.IsNullOrWhiteSpace(proveedor.Correo))
            {
                try
                {
                    _ = new MailAddress(proveedor.Correo);
                }
                catch
                {
                    throw new ReglaNegocioException("Ingrese un correo electrónico válido", nameof(Proveedor.Correo));
                }
            }
        }
    }
}
