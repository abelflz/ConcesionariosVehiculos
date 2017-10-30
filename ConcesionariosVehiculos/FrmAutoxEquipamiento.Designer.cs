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
            this.cbxChasis = new System.Windows.Forms.ComboBox();
            this.lbChasis = new System.Windows.Forms.Label();
            this.chkVidriosTintados = new System.Windows.Forms.CheckBox();
            this.chkSpoiler = new System.Windows.Forms.CheckBox();
            this.chkIntPersonalizado = new System.Windows.Forms.CheckBox();
            this.chkAirbags = new System.Windows.Forms.CheckBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTotal);
            this.groupBox1.Controls.Add(this.chkAirbags);
            this.groupBox1.Controls.Add(this.chkIntPersonalizado);
            this.groupBox1.Controls.Add(this.chkSpoiler);
            this.groupBox1.Controls.Add(this.chkVidriosTintados);
            this.groupBox1.Controls.Add(this.lbChasis);
            this.groupBox1.Controls.Add(this.cbxChasis);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 226);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
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
            // lbChasis
            // 
            this.lbChasis.AutoSize = true;
            this.lbChasis.Location = new System.Drawing.Point(20, 22);
            this.lbChasis.Name = "lbChasis";
            this.lbChasis.Size = new System.Drawing.Size(90, 13);
            this.lbChasis.TabIndex = 1;
            this.lbChasis.Text = "Vehículo (Chasis)";
            // 
            // chkVidriosTintados
            // 
            this.chkVidriosTintados.AutoSize = true;
            this.chkVidriosTintados.Location = new System.Drawing.Point(30, 67);
            this.chkVidriosTintados.Name = "chkVidriosTintados";
            this.chkVidriosTintados.Size = new System.Drawing.Size(101, 17);
            this.chkVidriosTintados.TabIndex = 2;
            this.chkVidriosTintados.Text = "Vidrios Tintados";
            this.chkVidriosTintados.UseVisualStyleBackColor = true;
            this.chkVidriosTintados.CheckedChanged += new System.EventHandler(this.chkVidriosTintados_CheckedChanged);
            // 
            // chkSpoiler
            // 
            this.chkSpoiler.AutoSize = true;
            this.chkSpoiler.Location = new System.Drawing.Point(227, 67);
            this.chkSpoiler.Name = "chkSpoiler";
            this.chkSpoiler.Size = new System.Drawing.Size(97, 17);
            this.chkSpoiler.TabIndex = 3;
            this.chkSpoiler.Text = "Spoiler (Alerón)";
            this.chkSpoiler.UseVisualStyleBackColor = true;
            // 
            // chkIntPersonalizado
            // 
            this.chkIntPersonalizado.AutoSize = true;
            this.chkIntPersonalizado.Location = new System.Drawing.Point(30, 106);
            this.chkIntPersonalizado.Name = "chkIntPersonalizado";
            this.chkIntPersonalizado.Size = new System.Drawing.Size(127, 17);
            this.chkIntPersonalizado.TabIndex = 4;
            this.chkIntPersonalizado.Text = "Interior Personalizado";
            this.chkIntPersonalizado.UseVisualStyleBackColor = true;
            // 
            // chkAirbags
            // 
            this.chkAirbags.AutoSize = true;
            this.chkAirbags.Location = new System.Drawing.Point(227, 106);
            this.chkAirbags.Name = "chkAirbags";
            this.chkAirbags.Size = new System.Drawing.Size(61, 17);
            this.chkAirbags.TabIndex = 5;
            this.chkAirbags.Text = "Airbags";
            this.chkAirbags.UseVisualStyleBackColor = true;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(175, 138);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(198, 20);
            this.txtTotal.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Total Añadido por Equipamientos";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(116, 190);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(110, 23);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar y Salir";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // FrmAutoxEquipamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 247);
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
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.CheckBox chkAirbags;
        private System.Windows.Forms.CheckBox chkIntPersonalizado;
        private System.Windows.Forms.CheckBox chkSpoiler;
        private System.Windows.Forms.CheckBox chkVidriosTintados;
        private System.Windows.Forms.Button btnGuardar;
    }
}