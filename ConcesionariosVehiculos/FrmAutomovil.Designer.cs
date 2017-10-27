namespace ConcesionariosVehiculos
{
    partial class FrmAutomovil
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
            this.txtValueFilter = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvAutomovil = new System.Windows.Forms.DataGridView();
            this.cbxFilter = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutomovil)).BeginInit();
            this.SuspendLayout();
            // 
            // txtValueFilter
            // 
            this.txtValueFilter.Location = new System.Drawing.Point(12, 12);
            this.txtValueFilter.Name = "txtValueFilter";
            this.txtValueFilter.Size = new System.Drawing.Size(162, 20);
            this.txtValueFilter.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(342, 10);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(154, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvAutomovil
            // 
            this.dgvAutomovil.AllowUserToAddRows = false;
            this.dgvAutomovil.AllowUserToDeleteRows = false;
            this.dgvAutomovil.AllowUserToOrderColumns = true;
            this.dgvAutomovil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAutomovil.Location = new System.Drawing.Point(12, 60);
            this.dgvAutomovil.Name = "dgvAutomovil";
            this.dgvAutomovil.ReadOnly = true;
            this.dgvAutomovil.Size = new System.Drawing.Size(484, 370);
            this.dgvAutomovil.TabIndex = 2;
            // 
            // cbxFilter
            // 
            this.cbxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFilter.FormattingEnabled = true;
            this.cbxFilter.Items.AddRange(new object[] {
            "Marca",
            "Modelo",
            "Descuento",
            "Precio",
            "Motor",
            "Color",
            "Combustible",
            "Tipo",
            "Puertas",
            "Pasajeros",
            "Tracción"});
            this.cbxFilter.Location = new System.Drawing.Point(190, 12);
            this.cbxFilter.Name = "cbxFilter";
            this.cbxFilter.Size = new System.Drawing.Size(131, 21);
            this.cbxFilter.TabIndex = 3;
            // 
            // FrmAutomovil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 467);
            this.Controls.Add(this.cbxFilter);
            this.Controls.Add(this.dgvAutomovil);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtValueFilter);
            this.Name = "FrmAutomovil";
            this.Text = "Automovil";
            this.Load += new System.EventHandler(this.FrmAutomovil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutomovil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtValueFilter;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvAutomovil;
        private System.Windows.Forms.ComboBox cbxFilter;
    }
}