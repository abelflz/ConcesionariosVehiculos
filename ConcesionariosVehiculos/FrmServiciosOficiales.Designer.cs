namespace ConcesionariosVehiculos
{
    partial class FrmServiciosOficiales
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNIF = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCrear = new System.Windows.Forms.Button();
            this.txtDomicilio = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvServOfic = new System.Windows.Forms.DataGridView();
            this.txtValueFilter = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxNIFModificar = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDomilicioModificar = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.txtNombreModificar = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbxNIFBorrar = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServOfic)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtNIF);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnCrear);
            this.groupBox2.Controls.Add(this.txtDomicilio);
            this.groupBox2.Controls.Add(this.txtNombre);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(459, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(168, 234);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(55, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 34;
            this.label5.Text = "Crear";
            // 
            // txtNIF
            // 
            this.txtNIF.Location = new System.Drawing.Point(26, 79);
            this.txtNIF.MaxLength = 10;
            this.txtNIF.Name = "txtNIF";
            this.txtNIF.Size = new System.Drawing.Size(120, 20);
            this.txtNIF.TabIndex = 31;
            this.txtNIF.TextChanged += new System.EventHandler(this.txtNIF_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "NIF";
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(44, 194);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(75, 23);
            this.btnCrear.TabIndex = 27;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Location = new System.Drawing.Point(26, 158);
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(120, 20);
            this.txtDomicilio.TabIndex = 16;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(26, 119);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(120, 20);
            this.txtNombre.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Domicilio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvServOfic);
            this.groupBox1.Controls.Add(this.txtValueFilter);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Location = new System.Drawing.Point(11, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 294);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // dgvServOfic
            // 
            this.dgvServOfic.AllowUserToAddRows = false;
            this.dgvServOfic.AllowUserToDeleteRows = false;
            this.dgvServOfic.AllowUserToOrderColumns = true;
            this.dgvServOfic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServOfic.Location = new System.Drawing.Point(6, 45);
            this.dgvServOfic.Name = "dgvServOfic";
            this.dgvServOfic.ReadOnly = true;
            this.dgvServOfic.Size = new System.Drawing.Size(430, 243);
            this.dgvServOfic.TabIndex = 2;
            // 
            // txtValueFilter
            // 
            this.txtValueFilter.Location = new System.Drawing.Point(6, 19);
            this.txtValueFilter.Name = "txtValueFilter";
            this.txtValueFilter.Size = new System.Drawing.Size(286, 20);
            this.txtValueFilter.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(298, 16);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(124, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbxNIFModificar);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtDomilicioModificar);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.btnModificar);
            this.groupBox3.Controls.Add(this.txtNombreModificar);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(633, 50);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(168, 234);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            // 
            // cbxNIFModificar
            // 
            this.cbxNIFModificar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNIFModificar.FormattingEnabled = true;
            this.cbxNIFModificar.Location = new System.Drawing.Point(25, 79);
            this.cbxNIFModificar.Name = "cbxNIFModificar";
            this.cbxNIFModificar.Size = new System.Drawing.Size(121, 21);
            this.cbxNIFModificar.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(44, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 20);
            this.label6.TabIndex = 34;
            this.label6.Text = "Editar";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Nombre ";
            // 
            // txtDomilicioModificar
            // 
            this.txtDomilicioModificar.Location = new System.Drawing.Point(26, 158);
            this.txtDomilicioModificar.Name = "txtDomilicioModificar";
            this.txtDomilicioModificar.ReadOnly = true;
            this.txtDomilicioModificar.Size = new System.Drawing.Size(120, 20);
            this.txtDomilicioModificar.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "NIF";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(48, 194);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 28;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            // 
            // txtNombreModificar
            // 
            this.txtNombreModificar.Location = new System.Drawing.Point(26, 119);
            this.txtNombreModificar.Name = "txtNombreModificar";
            this.txtNombreModificar.ReadOnly = true;
            this.txtNombreModificar.Size = new System.Drawing.Size(120, 20);
            this.txtNombreModificar.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Domicilio";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbxNIFBorrar);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.btnBorrar);
            this.groupBox4.Location = new System.Drawing.Point(459, 290);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(342, 54);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            // 
            // cbxNIFBorrar
            // 
            this.cbxNIFBorrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNIFBorrar.FormattingEnabled = true;
            this.cbxNIFBorrar.Location = new System.Drawing.Point(134, 21);
            this.cbxNIFBorrar.Name = "cbxNIFBorrar";
            this.cbxNIFBorrar.Size = new System.Drawing.Size(121, 21);
            this.cbxNIFBorrar.TabIndex = 38;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 20);
            this.label11.TabIndex = 34;
            this.label11.Text = "Borrar";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(104, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "NIF";
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(261, 19);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 23);
            this.btnBorrar.TabIndex = 29;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(252, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(353, 42);
            this.label12.TabIndex = 37;
            this.label12.Text = "Servicios Generales";
            // 
            // FrmServiciosOficiales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 353);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmServiciosOficiales";
            this.Text = "Servicios Oficiales";
            this.Load += new System.EventHandler(this.FrmServiciosOficiales_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServOfic)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.TextBox txtDomicilio;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvServOfic;
        private System.Windows.Forms.TextBox txtValueFilter;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtNIF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbxNIFModificar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDomilicioModificar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.TextBox txtNombreModificar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbxNIFBorrar;
    }
}