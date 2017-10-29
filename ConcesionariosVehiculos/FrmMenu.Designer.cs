namespace ConcesionariosVehiculos
{
    partial class FrmMenu
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
            this.btnAutomovil = new System.Windows.Forms.Button();
            this.btnVendedores = new System.Windows.Forms.Button();
            this.btnVentAuto = new System.Windows.Forms.Button();
            this.btnServOfic = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAutomovil
            // 
            this.btnAutomovil.Location = new System.Drawing.Point(12, 12);
            this.btnAutomovil.Name = "btnAutomovil";
            this.btnAutomovil.Size = new System.Drawing.Size(87, 39);
            this.btnAutomovil.TabIndex = 0;
            this.btnAutomovil.Text = "Automovil";
            this.btnAutomovil.UseVisualStyleBackColor = true;
            this.btnAutomovil.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnVendedores
            // 
            this.btnVendedores.Location = new System.Drawing.Point(105, 57);
            this.btnVendedores.Name = "btnVendedores";
            this.btnVendedores.Size = new System.Drawing.Size(87, 39);
            this.btnVendedores.TabIndex = 1;
            this.btnVendedores.Text = "Vendedores";
            this.btnVendedores.UseVisualStyleBackColor = true;
            this.btnVendedores.Click += new System.EventHandler(this.btnVendedores_Click);
            // 
            // btnVentAuto
            // 
            this.btnVentAuto.Location = new System.Drawing.Point(12, 57);
            this.btnVentAuto.Name = "btnVentAuto";
            this.btnVentAuto.Size = new System.Drawing.Size(87, 39);
            this.btnVentAuto.TabIndex = 2;
            this.btnVentAuto.Text = "Venta de Vehiculos";
            this.btnVentAuto.UseVisualStyleBackColor = true;
            this.btnVentAuto.Click += new System.EventHandler(this.btnVentAuto_Click);
            // 
            // btnServOfic
            // 
            this.btnServOfic.Location = new System.Drawing.Point(105, 12);
            this.btnServOfic.Name = "btnServOfic";
            this.btnServOfic.Size = new System.Drawing.Size(87, 39);
            this.btnServOfic.TabIndex = 3;
            this.btnServOfic.Text = "Servicios Oficiales";
            this.btnServOfic.UseVisualStyleBackColor = true;
            this.btnServOfic.Click += new System.EventHandler(this.btnServOfic_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 118);
            this.Controls.Add(this.btnServOfic);
            this.Controls.Add(this.btnVentAuto);
            this.Controls.Add(this.btnVendedores);
            this.Controls.Add(this.btnAutomovil);
            this.Name = "FrmMenu";
            this.Text = "FrmMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAutomovil;
        private System.Windows.Forms.Button btnVendedores;
        private System.Windows.Forms.Button btnVentAuto;
        private System.Windows.Forms.Button btnServOfic;
    }
}