namespace ConcesionariosVehiculos
{
    partial class FrmVentaAuto
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
            this.cbxChasis = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxVendedores = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.cbxModoPago = new System.Windows.Forms.ComboBox();
            this.txtMontoTotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaVenta = new System.Windows.Forms.DateTimePicker();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtpFechaVenta);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbxChasis);
            this.groupBox2.Controls.Add(this.btnGuardar);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtMontoTotal);
            this.groupBox2.Controls.Add(this.cbxModoPago);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cbxVendedores);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(282, 214);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // cbxChasis
            // 
            this.cbxChasis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxChasis.FormattingEnabled = true;
            this.cbxChasis.Items.AddRange(new object[] {
            "Contado",
            "Financiado"});
            this.cbxChasis.Location = new System.Drawing.Point(18, 64);
            this.cbxChasis.Name = "cbxChasis";
            this.cbxChasis.Size = new System.Drawing.Size(121, 21);
            this.cbxChasis.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Chasis";
            // 
            // cbxVendedores
            // 
            this.cbxVendedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxVendedores.FormattingEnabled = true;
            this.cbxVendedores.Location = new System.Drawing.Point(145, 64);
            this.cbxVendedores.Name = "cbxVendedores";
            this.cbxVendedores.Size = new System.Drawing.Size(121, 21);
            this.cbxVendedores.TabIndex = 30;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(85, 173);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(110, 23);
            this.btnGuardar.TabIndex = 29;
            this.btnGuardar.Text = "Realizar Venta";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(82, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(113, 18);
            this.label14.TabIndex = 16;
            this.label14.Text = "Venta de Autos";
            // 
            // cbxModoPago
            // 
            this.cbxModoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxModoPago.FormattingEnabled = true;
            this.cbxModoPago.Items.AddRange(new object[] {
            "Contado",
            "Financiado"});
            this.cbxModoPago.Location = new System.Drawing.Point(145, 107);
            this.cbxModoPago.Name = "cbxModoPago";
            this.cbxModoPago.Size = new System.Drawing.Size(121, 21);
            this.cbxModoPago.TabIndex = 25;
            // 
            // txtMontoTotal
            // 
            this.txtMontoTotal.Location = new System.Drawing.Point(18, 147);
            this.txtMontoTotal.Name = "txtMontoTotal";
            this.txtMontoTotal.Size = new System.Drawing.Size(121, 20);
            this.txtMontoTotal.TabIndex = 16;
            this.txtMontoTotal.TextChanged += new System.EventHandler(this.txtMontoTotal_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(142, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Vendedor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(142, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Modo de Pago";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Monto Total";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Fecha de Venta";
            // 
            // dtpFechaVenta
            // 
            this.dtpFechaVenta.Location = new System.Drawing.Point(18, 108);
            this.dtpFechaVenta.Name = "dtpFechaVenta";
            this.dtpFechaVenta.Size = new System.Drawing.Size(121, 20);
            this.dtpFechaVenta.TabIndex = 43;
            // 
            // FrmVentaAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 231);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmVentaAuto";
            this.Text = "FrmVentaAuto";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbxModoPago;
        private System.Windows.Forms.TextBox txtMontoTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxVendedores;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxChasis;
        private System.Windows.Forms.DateTimePicker dtpFechaVenta;
        private System.Windows.Forms.Label label1;
    }
}