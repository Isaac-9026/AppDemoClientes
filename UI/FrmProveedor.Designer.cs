namespace UI
{
    partial class FrmProveedor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            grid = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtRuc = new TextBox();
            txtRazonSocial = new TextBox();
            txtTelefono = new TextBox();
            txtDireccion = new TextBox();
            txtCorreo = new TextBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 35);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 0;
            label1.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(115, 32);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "RUC, Razón Social, Dirección, etc.";
            txtBuscar.Size = new Size(689, 23);
            txtBuscar.TabIndex = 1;
            txtBuscar.KeyDown += txtBuscar_KeyDown;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(842, 31);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // grid
            // 
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToOrderColumns = true;
            grid.AllowUserToResizeColumns = false;
            grid.AllowUserToResizeRows = false;
            grid.BackgroundColor = SystemColors.InactiveBorder;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.Location = new Point(50, 75);
            grid.MultiSelect = false;
            grid.Name = "grid";
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.Size = new Size(892, 331);
            grid.TabIndex = 3;
            grid.SelectionChanged += grid_SelectionChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 424);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 4;
            label2.Text = "RUC:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(365, 424);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 6;
            label3.Text = "Razón Social:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(700, 424);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 8;
            label4.Text = "Teléfono:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(53, 484);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 10;
            label5.Text = "Dirección:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(580, 484);
            label6.Name = "label6";
            label6.Size = new Size(46, 15);
            label6.TabIndex = 12;
            label6.Text = "Correo:";
            // 
            // txtRuc
            // 
            txtRuc.Location = new Point(53, 442);
            txtRuc.MaxLength = 11;
            txtRuc.Name = "txtRuc";
            txtRuc.Size = new Size(287, 23);
            txtRuc.TabIndex = 5;
            txtRuc.KeyPress += SoloDigitos;
            // 
            // txtRazonSocial
            // 
            txtRazonSocial.Location = new Point(365, 442);
            txtRazonSocial.MaxLength = 120;
            txtRazonSocial.Name = "txtRazonSocial";
            txtRazonSocial.Size = new Size(307, 23);
            txtRazonSocial.TabIndex = 7;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(700, 442);
            txtTelefono.MaxLength = 15;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(242, 23);
            txtTelefono.TabIndex = 9;
            txtTelefono.KeyPress += SoloDigitos;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(53, 502);
            txtDireccion.MaxLength = 150;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(500, 23);
            txtDireccion.TabIndex = 11;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(580, 502);
            txtCorreo.MaxLength = 150;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(362, 23);
            txtCorreo.TabIndex = 13;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(68, 560);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 23);
            btnNuevo.TabIndex = 14;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(165, 560);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 15;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(265, 560);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 16;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // FrmProveedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 611);
            Controls.Add(btnEliminar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(txtCorreo);
            Controls.Add(txtDireccion);
            Controls.Add(txtTelefono);
            Controls.Add(txtRazonSocial);
            Controls.Add(txtRuc);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(grid);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(label1);
            Name = "FrmProveedor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mantenimiento de Proveedores";
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView grid;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtRuc;
        private TextBox txtRazonSocial;
        private TextBox txtTelefono;
        private TextBox txtDireccion;
        private TextBox txtCorreo;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEliminar;
    }
}
