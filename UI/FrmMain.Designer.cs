namespace UI
{
    partial class FrmMain
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
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            btnClientes = new Button();
            btnProveedores = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.MidnightBlue;
            lblTitulo.Location = new Point(111, 22);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(366, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "DEMO DE GESTIÓN EMPRESARIAL";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 10F);
            lblSubtitulo.ForeColor = Color.DimGray;
            lblSubtitulo.Location = new Point(154, 63);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(266, 19);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Seleccione el módulo que desea gestionar:";
            lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnClientes
            // 
            btnClientes.BackColor = Color.FromArgb(230, 240, 255);
            btnClientes.Cursor = Cursors.Hand;
            btnClientes.FlatStyle = FlatStyle.System;
            btnClientes.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClientes.Location = new Point(53, 126);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(220, 85);
            btnClientes.TabIndex = 2;
            btnClientes.Text = "Gestión de Clientes\r\n";
            btnClientes.UseVisualStyleBackColor = false;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnProveedores
            // 
            btnProveedores.BackColor = Color.FromArgb(230, 255, 240);
            btnProveedores.Cursor = Cursors.Hand;
            btnProveedores.FlatStyle = FlatStyle.System;
            btnProveedores.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnProveedores.Location = new Point(324, 126);
            btnProveedores.Name = "btnProveedores";
            btnProveedores.Size = new Size(220, 85);
            btnProveedores.TabIndex = 3;
            btnProveedores.Text = "Gestión de Proveedores\r\n";
            btnProveedores.UseVisualStyleBackColor = false;
            btnProveedores.Click += btnProveedores_Click;
            // 
            // btnSalir
            // 
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.FlatStyle = FlatStyle.System;
            btnSalir.Font = new Font("Segoe UI", 9.5F);
            btnSalir.Location = new Point(225, 268);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(130, 35);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(600, 345);
            Controls.Add(btnSalir);
            Controls.Add(btnProveedores);
            Controls.Add(btnClientes);
            Controls.Add(lblSubtitulo);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AppDemoClientes - Menú Principal";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblSubtitulo;
        private Button btnClientes;
        private Button btnProveedores;
        private Button btnSalir;
    }
}
