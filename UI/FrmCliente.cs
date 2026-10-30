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
        private bool _cargandoGrid; //Evita la selección mientras se renderiza los datos

        //Definir constantes
        Color colorActivo = Color.LightYellow;
        Color colorBase = Color.White;

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

            _cargandoGrid = true;
            grid.DataSource = lista;
            grid.ClearSelection();
            _cargandoGrid = false;

            configurarGrid();
            LimpiarFormulario();
        }

        private async Task EjecutarAsync(Func<Task> action)
        {
            Control? foco = null; //ReglaNegocioException -> Error -> COTROL

            try
            {
                UseWaitCursor = true;
                Enabled = false;
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
                foco?.Focus();
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
                //LimpiarFormulario();

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
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            grid.ClearSelection();
            txtApellidos.Focus();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            await GuardarAsync();
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            //SoloDigitos(sender, e);
        }

        /// <summary>
        /// Bloquea cualquier caracter ingresado a excepción de números
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SoloDigitos(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void configurarGrid()
        {
            if (grid.Columns.Count < 7) return;

            //Ancho columnas
            grid.Columns[0].Visible = false;
            grid.Columns[1].Width = 170;
            grid.Columns[2].Width = 170;
            grid.Columns[5].Width = 200;
            grid.Columns[6].Width = 200;

            //Filas cebreadas
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            //Se ejecuta después del constructor...
        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtApellidos_Enter(object sender, EventArgs e)
        {
            txtApellidos.BackColor = colorActivo;
        }

        private void txtApellidos_Leave(object sender, EventArgs e)
        {
            txtApellidos.BackColor = colorBase;
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            //Este evento se ejecuta cuando cambias la fila activa
            MostrarSeleccionado();
        }

        private void MostrarSeleccionado()
        {
            if (_cargandoGrid || grid.SelectedRows.Count == 0) return;
            if (grid.SelectedRows[0].DataBoundItem is not Cliente c) return; //API

            _idActual = c.Id;
            txtApellidos.Text = c.Apellidos;
            txtNombres.Text = c.Nombres;
            txtDireccion.Text = c.Direccion;
            txtDni.Text = c.Dni;
            txtTelefono.Text = c.Telefono;
            txtCorreo.Text = c.Correo;
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            await EliminarAsync();
        }

        private async Task EliminarAsync()
        {
            if (_idActual == 0)
            {
                MessageBox.Show("Seleccione un cliente para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string datosCliente = $"{txtApellidos.Text} {txtNombres.Text}".Trim();
            string mensaje = string.IsNullOrWhiteSpace(datosCliente)
                ? "¿Desea eliminar el cliente seleccionado?"
                : $"¿Desea eliminar a {datosCliente}?";

            DialogResult rpta = MessageBox.Show(mensaje, "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rpta == DialogResult.No) return;

            var id = _idActual;

            //1. Eliminar > 2. Actualizar Grid > 3. Limpiar
            await EjecutarAsync(async () =>
            {
                await _bol.EliminarAsync(id);
                await CargarListAsync();
                MessageBox.Show("Cliente eliminado correctamente.", "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await CargarAsync();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            //Keypress (presiona, libera) vs Keydown (botón presionado)
            //Identificar el ENTER
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnBuscar.PerformClick();
            }
        }
    }
}
