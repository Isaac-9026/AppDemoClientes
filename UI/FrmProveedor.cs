using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using BOL;
using DAL;
using Entidades;

namespace UI
{
    public partial class  FrmProveedor : Form
    {
        private readonly ProveedorBol _bol;
        private int _idActual;
        private bool _cargandoGrid;

        public FrmProveedor(ProveedorBol bol)
        {
            InitializeComponent();
            _bol = bol;

            Load+= async (_, _) => await CargarAsync();
        }

        private async Task CargarListAsync()
        {
            var lista = await _bol.ListarAsync(txtBuscar.Text);

            _cargandoGrid = true;
            grid.DataSource = lista;
            grid.ClearSelection();
            _cargandoGrid = false;

            ConfigurarGrid();
            LimpiarFormulario();
        }

        private async Task EjecutarAsync(Func<Task> action)
        {
            Control? foco = null;

            try
            {
                UseWaitCursor = true;
                Enabled = false;
                await action();
            }
            catch (ReglaNegocioException ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                foco = ex.Campo switch
                {
                    nameof(Proveedor.Ruc) => txtRuc,
                    nameof(Proveedor.RazonSocial) => txtRazonSocial,
                    nameof(Proveedor.Direccion) => txtDireccion,
                    nameof(Proveedor.Telefono) => txtTelefono,
                    nameof(Proveedor.Correo) => txtCorreo,
                    _ => null
                };
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, "Error en el servidor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("El tiempo de espera de la solicitud se agoto.", "Tiempo agotado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message, "Error de comunicación con el servidor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            var proveedor = new Proveedor
            {
                Id = _idActual,
                Ruc = txtRuc.Text,
                RazonSocial = txtRazonSocial.Text,
                Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text
            };

            await EjecutarAsync(async () =>
            {
                await _bol.GuardarAsync(proveedor);
                await CargarListAsync();

                MessageBox.Show("Proveedor guardado correctamente.", "Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        private void LimpiarFormulario()
        {
            _idActual = 0;
            txtRuc.Clear();
            txtRazonSocial.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            grid.ClearSelection();
            txtRuc.Focus();
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            await GuardarAsync();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            await EliminarAsync();
        }

        private async Task EliminarAsync()
        {
            if (_idActual == 0)
            {
                MessageBox.Show("Seleccione un proveedor para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string datos = txtRazonSocial.Text.Trim();
            string mensaje = string.IsNullOrWhiteSpace(datos)
                ? "¿Desea eliminar el proveedor seleccionado?"
                : $"¿Desea eliminar al proveedor '{datos}'?";

            DialogResult rpta = MessageBox.Show(mensaje, "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rpta == DialogResult.No) return;

            var id = _idActual;

            await EjecutarAsync(async () =>
            {
                await _bol.EliminarAsync(id);
                await CargarListAsync();
                MessageBox.Show("Proveedor eliminado correctamente.", "Proveedores", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await CargarAsync();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnBuscar.PerformClick();
            }
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            MostrarSeleccionado();
        }

        private void MostrarSeleccionado()
        {
            if (_cargandoGrid || grid.SelectedRows.Count == 0) return;
            if (grid.SelectedRows[0].DataBoundItem is not Proveedor p) return;

            _idActual = p.Id;
            txtRuc.Text = p.Ruc;
            txtRazonSocial.Text = p.RazonSocial;
            txtDireccion.Text = p.Direccion;
            txtTelefono.Text = p.Telefono;
            txtCorreo.Text = p.Correo;
        }

        private void ConfigurarGrid()
        {
            if (grid.Columns.Count < 6) return;

            // Ocultar ID y formatear columnas
            grid.Columns[0].Visible = false;
            grid.Columns[1].HeaderText = "RUC";
            grid.Columns[1].Width = 110;
            grid.Columns[2].HeaderText = "Razón Social";
            grid.Columns[2].Width = 240;
            grid.Columns[3].HeaderText = "Dirección";
            grid.Columns[3].Width = 220;
            grid.Columns[4].HeaderText = "Teléfono";
            grid.Columns[4].Width = 110;
            grid.Columns[5].HeaderText = "Correo";
            grid.Columns[5].Width = 180;

            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
        }

        private void SoloDigitos(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
