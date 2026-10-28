namespace UI
{
    partial class FrmCliente
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
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtApellidos = new TextBox();
            txtNombres = new TextBox();
            txtDni = new TextBox();
            txtTelefono = new TextBox();
            txtCorreo = new TextBox();
            txtDireccion = new TextBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEliminar = new Button();
            grid = new DataGridView();
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
            // btnBuscar
            // 
            btnBuscar.Location = new Point(842, 31);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 0;
            btnBuscar.Text = "buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(115, 32);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(689, 23);
            txtBuscar.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 424);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 2;
            label2.Text = "Apellidos:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(53, 484);
            label3.Name = "label3";
            label3.Size = new Size(30, 15);
            label3.TabIndex = 3;
            label3.Text = "DNI:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(365, 424);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 4;
            label4.Text = "Nombres:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(365, 484);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 5;
            label5.Text = "Teléfono:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(700, 424);
            label6.Name = "label6";
            label6.Size = new Size(46, 15);
            label6.TabIndex = 6;
            label6.Text = "Correo:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(700, 484);
            label7.Name = "label7";
            label7.Size = new Size(60, 15);
            label7.TabIndex = 7;
            label7.Text = "Dirección:";
            // 
            // txtApellidos
            // 
            txtApellidos.Location = new Point(53, 442);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(287, 23);
            txtApellidos.TabIndex = 8;
            // 
            // txtNombres
            // 
            txtNombres.Location = new Point(365, 442);
            txtNombres.Name = "txtNombres";
            txtNombres.Size = new Size(307, 23);
            txtNombres.TabIndex = 9;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(53, 502);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(287, 23);
            txtDni.TabIndex = 10;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(365, 502);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(307, 23);
            txtTelefono.TabIndex = 11;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(700, 442);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(242, 23);
            txtCorreo.TabIndex = 12;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(700, 502);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(242, 23);
            txtDireccion.TabIndex = 13;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(68, 560);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 23);
            btnNuevo.TabIndex = 14;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(165, 560);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 16;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(265, 560);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 17;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // grid
            // 
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grid.Location = new Point(50, 75);
            grid.Name = "grid";
            grid.Size = new Size(892, 331);
            grid.TabIndex = 18;
            // 
            // FrmCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 611);
            Controls.Add(grid);
            Controls.Add(btnEliminar);
            Controls.Add(btnGuardar);
            Controls.Add(btnNuevo);
            Controls.Add(txtDireccion);
            Controls.Add(txtCorreo);
            Controls.Add(txtTelefono);
            Controls.Add(txtDni);
            Controls.Add(txtNombres);
            Controls.Add(txtApellidos);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtBuscar);
            Controls.Add(btnBuscar);
            Controls.Add(label1);
            Name = "FrmCliente";
            Text = "FrmCliente";
            Load += FrmCliente_Load;
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnBuscar;
        private TextBox txtBuscar;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtApellidos;
        private TextBox txtNombres;
        private TextBox txtDni;
        private TextBox txtTelefono;
        private TextBox txtCorreo;
        private TextBox txtDireccion;
        private Button btnNuevo;
        private Button btnGuardar;
        private Button btnEliminar;
        private DataGridView grid;
    }
}