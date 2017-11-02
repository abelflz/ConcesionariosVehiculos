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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAutosVendidos = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvAutosNoVendidos = new System.Windows.Forms.DataGridView();
            this.btnServOfic = new System.Windows.Forms.Button();
            this.btnVentAuto = new System.Windows.Forms.Button();
            this.btnVendedores = new System.Windows.Forms.Button();
            this.btnAutomovil = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutosVendidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutosNoVendidos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(224, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Concesionario";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgvAutosVendidos
            // 
            this.dgvAutosVendidos.AllowUserToAddRows = false;
            this.dgvAutosVendidos.AllowUserToDeleteRows = false;
            this.dgvAutosVendidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAutosVendidos.Location = new System.Drawing.Point(12, 137);
            this.dgvAutosVendidos.Name = "dgvAutosVendidos";
            this.dgvAutosVendidos.ReadOnly = true;
            this.dgvAutosVendidos.Size = new System.Drawing.Size(300, 257);
            this.dgvAutosVendidos.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(59, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Automóviles Vendidos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(346, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(255, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Automóviles no Vendidos";
            // 
            // dgvAutosNoVendidos
            // 
            this.dgvAutosNoVendidos.AllowUserToAddRows = false;
            this.dgvAutosNoVendidos.AllowUserToDeleteRows = false;
            this.dgvAutosNoVendidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAutosNoVendidos.Location = new System.Drawing.Point(318, 137);
            this.dgvAutosNoVendidos.Name = "dgvAutosNoVendidos";
            this.dgvAutosNoVendidos.ReadOnly = true;
            this.dgvAutosNoVendidos.Size = new System.Drawing.Size(300, 257);
            this.dgvAutosNoVendidos.TabIndex = 7;
            // 
            // btnServOfic
            // 
            this.btnServOfic.Image = global::ConcesionariosVehiculos.Properties.Resources.tienda_online;
            this.btnServOfic.Location = new System.Drawing.Point(207, 47);
            this.btnServOfic.Name = "btnServOfic";
            this.btnServOfic.Size = new System.Drawing.Size(115, 49);
            this.btnServOfic.TabIndex = 3;
            this.btnServOfic.Text = "Servicios Oficiales";
            this.btnServOfic.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnServOfic.UseVisualStyleBackColor = true;
            this.btnServOfic.Click += new System.EventHandler(this.btnServOfic_Click);
            // 
            // btnVentAuto
            // 
            this.btnVentAuto.Image = global::ConcesionariosVehiculos.Properties.Resources.carrito_de_la_compra;
            this.btnVentAuto.Location = new System.Drawing.Point(351, 47);
            this.btnVentAuto.Name = "btnVentAuto";
            this.btnVentAuto.Size = new System.Drawing.Size(109, 49);
            this.btnVentAuto.TabIndex = 2;
            this.btnVentAuto.Text = "Venta de Vehículos";
            this.btnVentAuto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnVentAuto.UseVisualStyleBackColor = true;
            this.btnVentAuto.Click += new System.EventHandler(this.btnVentAuto_Click);
            // 
            // btnVendedores
            // 
            this.btnVendedores.Image = global::ConcesionariosVehiculos.Properties.Resources.vendedor;
            this.btnVendedores.Location = new System.Drawing.Point(495, 47);
            this.btnVendedores.Name = "btnVendedores";
            this.btnVendedores.Size = new System.Drawing.Size(106, 49);
            this.btnVendedores.TabIndex = 1;
            this.btnVendedores.Text = "Vendedores";
            this.btnVendedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnVendedores.UseVisualStyleBackColor = true;
            this.btnVendedores.Click += new System.EventHandler(this.btnVendedores_Click);
            // 
            // btnAutomovil
            // 
            this.btnAutomovil.Image = global::ConcesionariosVehiculos.Properties.Resources.coche;
            this.btnAutomovil.Location = new System.Drawing.Point(64, 47);
            this.btnAutomovil.Name = "btnAutomovil";
            this.btnAutomovil.Size = new System.Drawing.Size(111, 49);
            this.btnAutomovil.TabIndex = 0;
            this.btnAutomovil.Text = "Automóviles";
            this.btnAutomovil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAutomovil.UseVisualStyleBackColor = true;
            this.btnAutomovil.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(632, 406);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvAutosNoVendidos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvAutosVendidos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnServOfic);
            this.Controls.Add(this.btnVentAuto);
            this.Controls.Add(this.btnVendedores);
            this.Controls.Add(this.btnAutomovil);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMenu";
            this.Text = "Menú Principal";
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutosVendidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAutosNoVendidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAutomovil;
        private System.Windows.Forms.Button btnVendedores;
        private System.Windows.Forms.Button btnVentAuto;
        private System.Windows.Forms.Button btnServOfic;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvAutosVendidos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvAutosNoVendidos;
    }
}