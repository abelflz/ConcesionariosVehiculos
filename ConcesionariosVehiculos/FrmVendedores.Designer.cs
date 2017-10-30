namespace ConcesionariosVehiculos
{
    partial class FrmVendedores
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxFilter = new System.Windows.Forms.ComboBox();
            this.dgvVendedores = new System.Windows.Forms.DataGridView();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.txtValueFilter = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCedulaEditar = new System.Windows.Forms.TextBox();
            this.txtVentasRealizadasModificar = new System.Windows.Forms.TextBox();
            this.txtApellidoModificar = new System.Windows.Forms.TextBox();
            this.cbxNIF = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.txtNombreModificar = new System.Windows.Forms.TextBox();
            this.lblConcensionario = new System.Windows.Forms.Label();
            this.lblVentaRealizada = new System.Windows.Forms.Label();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.lblDomicilio = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblNIF = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBorrarVendedor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCrear = new System.Windows.Forms.Button();
            this.txtVentaRealizada = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxCedulaBorrar = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtNIF = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbxServOfic = new System.Windows.Forms.ComboBox();
            this.cbxServOficEditar = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedores)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxFilter);
            this.groupBox1.Controls.Add(this.dgvVendedores);
            this.groupBox1.Controls.Add(this.btnFiltrar);
            this.groupBox1.Controls.Add(this.txtValueFilter);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 322);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cbxFilter
            // 
            this.cbxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFilter.FormattingEnabled = true;
            this.cbxFilter.Items.AddRange(new object[] {
            "Nombres",
            "Apellidos",
            "Cedula"});
            this.cbxFilter.Location = new System.Drawing.Point(161, 23);
            this.cbxFilter.Name = "cbxFilter";
            this.cbxFilter.Size = new System.Drawing.Size(119, 21);
            this.cbxFilter.TabIndex = 6;
            // 
            // dgvVendedores
            // 
            this.dgvVendedores.AllowUserToAddRows = false;
            this.dgvVendedores.AllowUserToDeleteRows = false;
            this.dgvVendedores.AllowUserToOrderColumns = true;
            this.dgvVendedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendedores.Location = new System.Drawing.Point(6, 58);
            this.dgvVendedores.Name = "dgvVendedores";
            this.dgvVendedores.ReadOnly = true;
            this.dgvVendedores.Size = new System.Drawing.Size(370, 258);
            this.dgvVendedores.TabIndex = 5;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(286, 22);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(90, 23);
            this.btnFiltrar.TabIndex = 1;
            this.btnFiltrar.Text = "Buscar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // txtValueFilter
            // 
            this.txtValueFilter.Location = new System.Drawing.Point(7, 24);
            this.txtValueFilter.Name = "txtValueFilter";
            this.txtValueFilter.Size = new System.Drawing.Size(148, 20);
            this.txtValueFilter.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxServOficEditar);
            this.groupBox2.Controls.Add(this.txtCedulaEditar);
            this.groupBox2.Controls.Add(this.txtVentasRealizadasModificar);
            this.groupBox2.Controls.Add(this.txtApellidoModificar);
            this.groupBox2.Controls.Add(this.cbxNIF);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnModificar);
            this.groupBox2.Controls.Add(this.txtNombreModificar);
            this.groupBox2.Controls.Add(this.lblConcensionario);
            this.groupBox2.Controls.Add(this.lblVentaRealizada);
            this.groupBox2.Controls.Add(this.lblFechaNacimiento);
            this.groupBox2.Controls.Add(this.lblDomicilio);
            this.groupBox2.Controls.Add(this.lblNombre);
            this.groupBox2.Controls.Add(this.lblNIF);
            this.groupBox2.Location = new System.Drawing.Point(572, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(162, 342);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // txtCedulaEditar
            // 
            this.txtCedulaEditar.Location = new System.Drawing.Point(9, 191);
            this.txtCedulaEditar.Name = "txtCedulaEditar";
            this.txtCedulaEditar.ReadOnly = true;
            this.txtCedulaEditar.Size = new System.Drawing.Size(147, 20);
            this.txtCedulaEditar.TabIndex = 23;
            // 
            // txtVentasRealizadasModificar
            // 
            this.txtVentasRealizadasModificar.Location = new System.Drawing.Point(9, 275);
            this.txtVentasRealizadasModificar.Name = "txtVentasRealizadasModificar";
            this.txtVentasRealizadasModificar.ReadOnly = true;
            this.txtVentasRealizadasModificar.Size = new System.Drawing.Size(147, 20);
            this.txtVentasRealizadasModificar.TabIndex = 23;
            // 
            // txtApellidoModificar
            // 
            this.txtApellidoModificar.Location = new System.Drawing.Point(9, 150);
            this.txtApellidoModificar.Name = "txtApellidoModificar";
            this.txtApellidoModificar.ReadOnly = true;
            this.txtApellidoModificar.Size = new System.Drawing.Size(147, 20);
            this.txtApellidoModificar.TabIndex = 22;
            // 
            // cbxNIF
            // 
            this.cbxNIF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNIF.FormattingEnabled = true;
            this.cbxNIF.Location = new System.Drawing.Point(9, 71);
            this.cbxNIF.Name = "cbxNIF";
            this.cbxNIF.Size = new System.Drawing.Size(147, 21);
            this.cbxNIF.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(41, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 18);
            this.label3.TabIndex = 15;
            this.label3.Text = "Modificar";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(44, 312);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // txtNombreModificar
            // 
            this.txtNombreModificar.Location = new System.Drawing.Point(9, 111);
            this.txtNombreModificar.Name = "txtNombreModificar";
            this.txtNombreModificar.ReadOnly = true;
            this.txtNombreModificar.Size = new System.Drawing.Size(147, 20);
            this.txtNombreModificar.TabIndex = 7;
            // 
            // lblConcensionario
            // 
            this.lblConcensionario.AutoSize = true;
            this.lblConcensionario.Location = new System.Drawing.Point(6, 218);
            this.lblConcensionario.Name = "lblConcensionario";
            this.lblConcensionario.Size = new System.Drawing.Size(77, 13);
            this.lblConcensionario.TabIndex = 5;
            this.lblConcensionario.Text = "Servicio Oficial";
            // 
            // lblVentaRealizada
            // 
            this.lblVentaRealizada.AutoSize = true;
            this.lblVentaRealizada.Location = new System.Drawing.Point(6, 259);
            this.lblVentaRealizada.Name = "lblVentaRealizada";
            this.lblVentaRealizada.Size = new System.Drawing.Size(95, 13);
            this.lblVentaRealizada.TabIndex = 4;
            this.lblVentaRealizada.Text = "Ventas Realizadas";
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.AutoSize = true;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(6, 175);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(40, 13);
            this.lblFechaNacimiento.TabIndex = 3;
            this.lblFechaNacimiento.Text = "Cedula";
            // 
            // lblDomicilio
            // 
            this.lblDomicilio.AutoSize = true;
            this.lblDomicilio.Location = new System.Drawing.Point(6, 134);
            this.lblDomicilio.Name = "lblDomicilio";
            this.lblDomicilio.Size = new System.Drawing.Size(44, 13);
            this.lblDomicilio.TabIndex = 2;
            this.lblDomicilio.Text = "Apellido";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(6, 95);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(44, 13);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre";
            // 
            // lblNIF
            // 
            this.lblNIF.AutoSize = true;
            this.lblNIF.Location = new System.Drawing.Point(6, 56);
            this.lblNIF.Name = "lblNIF";
            this.lblNIF.Size = new System.Drawing.Size(24, 13);
            this.lblNIF.TabIndex = 0;
            this.lblNIF.Text = "NIF";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Borrar";
            // 
            // btnBorrarVendedor
            // 
            this.btnBorrarVendedor.Location = new System.Drawing.Point(263, 13);
            this.btnBorrarVendedor.Name = "btnBorrarVendedor";
            this.btnBorrarVendedor.Size = new System.Drawing.Size(75, 23);
            this.btnBorrarVendedor.TabIndex = 3;
            this.btnBorrarVendedor.Text = "Borrar";
            this.btnBorrarVendedor.UseVisualStyleBackColor = true;
            this.btnBorrarVendedor.Click += new System.EventHandler(this.btnBorrarVendedor_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "Crear";
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(44, 312);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(75, 23);
            this.btnCrear.TabIndex = 2;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // txtVentaRealizada
            // 
            this.txtVentaRealizada.Location = new System.Drawing.Point(6, 275);
            this.txtVentaRealizada.Name = "txtVentaRealizada";
            this.txtVentaRealizada.Size = new System.Drawing.Size(149, 20);
            this.txtVentaRealizada.TabIndex = 11;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(6, 150);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(149, 20);
            this.txtApellido.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbxCedulaBorrar);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btnBorrarVendedor);
            this.groupBox3.Location = new System.Drawing.Point(12, 340);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(387, 41);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            // 
            // cbxCedulaBorrar
            // 
            this.cbxCedulaBorrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCedulaBorrar.FormattingEnabled = true;
            this.cbxCedulaBorrar.Location = new System.Drawing.Point(145, 13);
            this.cbxCedulaBorrar.Name = "cbxCedulaBorrar";
            this.cbxCedulaBorrar.Size = new System.Drawing.Size(112, 21);
            this.cbxCedulaBorrar.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(103, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Cédula";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbxServOfic);
            this.groupBox4.Controls.Add(this.txtCedula);
            this.groupBox4.Controls.Add(this.txtNombre);
            this.groupBox4.Controls.Add(this.txtNIF);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.txtVentaRealizada);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.btnCrear);
            this.groupBox4.Controls.Add(this.txtApellido);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(405, 39);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(161, 342);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            // 
            // txtCedula
            // 
            this.txtCedula.Location = new System.Drawing.Point(6, 192);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new System.Drawing.Size(149, 20);
            this.txtCedula.TabIndex = 22;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(6, 111);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(149, 20);
            this.txtNombre.TabIndex = 16;
            // 
            // txtNIF
            // 
            this.txtNIF.Location = new System.Drawing.Point(6, 72);
            this.txtNIF.Name = "txtNIF";
            this.txtNIF.Size = new System.Drawing.Size(149, 20);
            this.txtNIF.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Servicio Oficial";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "NIF";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Ventas Realizadas";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Nombre";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Cedula";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Apellido";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(508, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(140, 27);
            this.label10.TabIndex = 22;
            this.label10.Text = "Vendedores";
            // 
            // cbxServOfic
            // 
            this.cbxServOfic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxServOfic.FormattingEnabled = true;
            this.cbxServOfic.Location = new System.Drawing.Point(8, 235);
            this.cbxServOfic.Name = "cbxServOfic";
            this.cbxServOfic.Size = new System.Drawing.Size(147, 21);
            this.cbxServOfic.TabIndex = 25;
            // 
            // cbxServOficEditar
            // 
            this.cbxServOficEditar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxServOficEditar.Enabled = false;
            this.cbxServOficEditar.FormattingEnabled = true;
            this.cbxServOficEditar.Location = new System.Drawing.Point(10, 234);
            this.cbxServOficEditar.Name = "cbxServOficEditar";
            this.cbxServOficEditar.Size = new System.Drawing.Size(147, 21);
            this.cbxServOficEditar.TabIndex = 26;
            // 
            // FrmVendedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 387);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmVendedores";
            this.Text = "Vendedores";
            this.Load += new System.EventHandler(this.FrmVendedores_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendedores)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.TextBox txtValueFilter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvVendedores;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnBorrarVendedor;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Label lblConcensionario;
        private System.Windows.Forms.Label lblVentaRealizada;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.Label lblDomicilio;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblNIF;
        private System.Windows.Forms.TextBox txtVentaRealizada;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombreModificar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtNIF;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtVentasRealizadasModificar;
        private System.Windows.Forms.TextBox txtApellidoModificar;
        private System.Windows.Forms.ComboBox cbxNIF;
        private System.Windows.Forms.ComboBox cbxCedulaBorrar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCedulaEditar;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.ComboBox cbxFilter;
        private System.Windows.Forms.ComboBox cbxServOficEditar;
        private System.Windows.Forms.ComboBox cbxServOfic;
    }
}