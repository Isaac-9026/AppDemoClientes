using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using BOL;
using DAL;
using Entidades;

namespace UI
{
    public partial class FrmCliente : Form
    {
        private readonly ClienteBol _bol;
        private int _idActual;

        //Constructor
        public FrmCliente(ClienteBol bol)
        {
            InitializeComponent(); //Construir UI

            _bol = bol;

            //Enlace EVENTO...
            Load += async (_, _) => await CargarAsync();
        }

        //Enviar la información obtenida del API REST al GRID
        private async Task CargarListAsync()
        {
            var lista = await _bol.ListarAsync(txtBuscar.Text);

            grid.DataSource = lista;
            grid.ClearSelection();
        }

        private async Task EjecutarAsync(Func<Task> action)
        {
            Control? foco = null; //ReglaNegocioException -> Error -> COTROL

            try
            {
                UseWaitCursor = true;
                Enabled = true;
                await action();
            }
            catch (ReglaNegocioException ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //ReglaNegocio solo nos indica el nombre del campo: apellidos, nombres, dni, etc. (txtApellidos, txtNombres, txtDni)
                foco = ex.Campo switch
                {
                    nameof(Cliente.Apellidos) => txtApellidos,
                    nameof(Cliente.Nombres) => txtNombres,
                    nameof(Cliente.Dni) => txtDni,
                    nameof(Cliente.Telefono) => txtTelefono,
                    nameof(Cliente.Correo) => txtCorreo,
                    _ => null
                };
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, "Error en el servidor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Error en el servidor", "Tiempo agotado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message, "No hay comunicacion server", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                Enabled = true;
                UseWaitCursor = false;
            }
        }

        private Task CargarAsync() => EjecutarAsync(CargarListAsync);

        private async Task GuardarAsync()
        {
            var cliente = new Cliente
            {
                Id = _idActual,
                Apellidos = txtApellidos.Text,
                Nombres = txtNombres.Text,
                Dni = txtDni.Text,
                Telefono = txtTelefono.Text,
                Direccion = txtDireccion.Text,
                Correo = txtCorreo.Text
            };

            await EjecutarAsync(async () =>
            {
                await _bol.GuardarAsync(cliente);
                await CargarListAsync(); //Actualizar Grid

                MessageBox.Show("Cliente guardado", "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        private void LimpiarFormulario()
        {
            _idActual = 0;
            txtApellidos.Clear();
            txtNombres.Clear();
            txtDni.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtCorreo.Clear();
        }
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            await GuardarAsync();
        }
        private void FrmCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
