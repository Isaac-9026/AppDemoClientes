using System;
using System.Windows.Forms;
using BOL;

namespace UI
{
    public partial class FrmMain : Form
    {
        private readonly ClienteBol _clienteBol;
        private readonly ProveedorBol _proveedorBol;

        public FrmMain(ClienteBol clienteBol, ProveedorBol proveedorBol)
        {
            InitializeComponent();
            _clienteBol = clienteBol;
            _proveedorBol = proveedorBol;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            using var frm = new FrmCliente(_clienteBol);
            Hide();
            frm.ShowDialog(this);
            Show();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            using var frm = new FrmProveedor(_proveedorBol);
            Hide();
            frm.ShowDialog(this);
            Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblFooter_Click(object sender, EventArgs e)
        {

        }
    }
}
