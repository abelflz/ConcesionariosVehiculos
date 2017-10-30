namespace ConcesionariosVehiculos
{
    partial class FrmAutoxEquipamiento
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalPrecio = new System.Windows.Forms.TextBox();
            this.lbChasis = new System.Windows.Forms.Label();
            this.cbxChasis = new System.Windows.Forms.ComboBox();
            this.txtEquipamientos = new System.Windows.Forms.TextBox();
            this.lbEquipamientos = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbEquipamientos);
            this.groupBox1.Controls.Add(this.txtEquipamientos);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTotalPrecio);
            this.groupBox1.Controls.Add(this.lbChasis);
            this.groupBox1.Controls.Add(this.cbxChasis);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 226);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Total Añadido por Equipamientos";
            // 
            // txtTotalPrecio
            // 
            this.txtTotalPrecio.Location = new System.Drawing.Point(175, 200);
            this.txtTotalPrecio.Name = "txtTotalPrecio";
            this.txtTotalPrecio.ReadOnly = true;
            this.txtTotalPrecio.Size = new System.Drawing.Size(198, 20);
            this.txtTotalPrecio.TabIndex = 6;
            this.txtTotalPrecio.TextChanged += new System.EventHandler(this.txtTotalPrecio_TextChanged);
            // 
            // lbChasis
            // 
            this.lbChasis.AutoSize = true;
            this.lbChasis.Location = new System.Drawing.Point(20, 22);
            this.lbChasis.Name = "lbChasis";
            this.lbChasis.Size = new System.Drawing.Size(90, 13);
            this.lbChasis.TabIndex = 1;
            this.lbChasis.Text = "Vehículo (Chasis)";
            // 
            // cbxChasis
            // 
            this.cbxChasis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxChasis.FormattingEnabled = true;
            this.cbxChasis.Location = new System.Drawing.Point(116, 19);
            this.cbxChasis.Name = "cbxChasis";
            this.cbxChasis.Size = new System.Drawing.Size(257, 21);
            this.cbxChasis.TabIndex = 0;
            this.cbxChasis.SelectedIndexChanged += new System.EventHandler(this.cbxChasis_SelectedIndexChanged);
            // 
            // txtEquipamientos
            // 
            this.txtEquipamientos.Location = new System.Drawing.Point(9, 80);
            this.txtEquipamientos.Multiline = true;
            this.txtEquipamientos.Name = "txtEquipamientos";
            this.txtEquipamientos.ReadOnly = true;
            this.txtEquipamientos.Size = new System.Drawing.Size(364, 114);
            this.txtEquipamientos.TabIndex = 8;
            // 
            // lbEquipamientos
            // 
            this.lbEquipamientos.AutoSize = true;
            this.lbEquipamientos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEquipamientos.Location = new System.Drawing.Point(138, 51);
            this.lbEquipamientos.Name = "lbEquipamientos";
            this.lbEquipamientos.Size = new System.Drawing.Size(136, 24);
            this.lbEquipamientos.TabIndex = 9;
            this.lbEquipamientos.Text = "Equipamientos";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(154, 264);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar Equipamientos y Salir";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FrmAutoxEquipamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 306);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmAutoxEquipamiento";
            this.Text = "Equipamientos Especiales por Vehículos";
            this.Load += new System.EventHandler(this.FrmAutoxEquipamiento_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbChasis;
        private System.Windows.Forms.ComboBox cbxChasis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalPrecio;
        private System.Windows.Forms.TextBox txtEquipamientos;
        private System.Windows.Forms.Label lbEquipamientos;
        private System.Windows.Forms.Button btnGuardar;
    }
}