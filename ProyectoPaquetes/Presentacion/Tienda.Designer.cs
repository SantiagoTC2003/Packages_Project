namespace Presentacion
{
    partial class Tienda
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
            this.dgvTienda = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtArticulo = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.btnComprar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPaquete = new System.Windows.Forms.TextBox();
            this.txtDurabilidad = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTienda)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTienda
            // 
            this.dgvTienda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTienda.Location = new System.Drawing.Point(12, 12);
            this.dgvTienda.Name = "dgvTienda";
            this.dgvTienda.Size = new System.Drawing.Size(485, 211);
            this.dgvTienda.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID del Articulo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Su ID de Usuario";
            // 
            // txtArticulo
            // 
            this.txtArticulo.Location = new System.Drawing.Point(12, 248);
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.Size = new System.Drawing.Size(100, 20);
            this.txtArticulo.TabIndex = 3;
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(168, 248);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(100, 20);
            this.txtCliente.TabIndex = 4;
            // 
            // btnComprar
            // 
            this.btnComprar.Location = new System.Drawing.Point(422, 246);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(75, 23);
            this.btnComprar.TabIndex = 5;
            this.btnComprar.Text = "Comprar";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 283);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Un ID para el paquete";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(165, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Una descripcion de su durabilidad";
            // 
            // txtPaquete
            // 
            this.txtPaquete.Location = new System.Drawing.Point(12, 299);
            this.txtPaquete.Name = "txtPaquete";
            this.txtPaquete.Size = new System.Drawing.Size(100, 20);
            this.txtPaquete.TabIndex = 8;
            // 
            // txtDurabilidad
            // 
            this.txtDurabilidad.Location = new System.Drawing.Point(168, 299);
            this.txtDurabilidad.Name = "txtDurabilidad";
            this.txtDurabilidad.Size = new System.Drawing.Size(100, 20);
            this.txtDurabilidad.TabIndex = 9;
            // 
            // Tienda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 343);
            this.Controls.Add(this.txtDurabilidad);
            this.Controls.Add(this.txtPaquete);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.txtArticulo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTienda);
            this.Name = "Tienda";
            this.Text = "Tienda";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTienda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTienda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtArticulo;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPaquete;
        private System.Windows.Forms.TextBox txtDurabilidad;
    }
}