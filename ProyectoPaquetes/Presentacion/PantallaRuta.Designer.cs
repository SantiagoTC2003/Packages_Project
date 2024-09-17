namespace Presentacion
{
    partial class PantallaRuta
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
            this.btnVolver = new System.Windows.Forms.Button();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.txtLocalizacion = new System.Windows.Forms.TextBox();
            this.txtLocalizacionOriginal = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtPaquete = new System.Windows.Forms.TextBox();
            this.txtIDRuta = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnModificarR = new System.Windows.Forms.Button();
            this.btnEliminarR = new System.Windows.Forms.Button();
            this.btnSeleccionarR = new System.Windows.Forms.Button();
            this.btnAgregarR = new System.Windows.Forms.Button();
            this.dgvRuta = new System.Windows.Forms.DataGridView();
            this.dgvLocalizacion = new System.Windows.Forms.DataGridView();
            this.btnModificarL = new System.Windows.Forms.Button();
            this.btnEliminarL = new System.Windows.Forms.Button();
            this.btnAgregarL = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRuta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalizacion)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(12, 359);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 39;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(260, 241);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(100, 20);
            this.txtFecha.TabIndex = 38;
            // 
            // txtLocalizacion
            // 
            this.txtLocalizacion.Location = new System.Drawing.Point(12, 299);
            this.txtLocalizacion.Name = "txtLocalizacion";
            this.txtLocalizacion.Size = new System.Drawing.Size(100, 20);
            this.txtLocalizacion.TabIndex = 36;
            // 
            // txtLocalizacionOriginal
            // 
            this.txtLocalizacionOriginal.Location = new System.Drawing.Point(565, 241);
            this.txtLocalizacionOriginal.Name = "txtLocalizacionOriginal";
            this.txtLocalizacionOriginal.Size = new System.Drawing.Size(100, 20);
            this.txtLocalizacionOriginal.TabIndex = 35;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(689, 241);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(100, 20);
            this.txtDescripcion.TabIndex = 34;
            // 
            // txtPaquete
            // 
            this.txtPaquete.Location = new System.Drawing.Point(136, 241);
            this.txtPaquete.Name = "txtPaquete";
            this.txtPaquete.Size = new System.Drawing.Size(100, 20);
            this.txtPaquete.TabIndex = 33;
            // 
            // txtIDRuta
            // 
            this.txtIDRuta.Location = new System.Drawing.Point(12, 241);
            this.txtIDRuta.Name = "txtIDRuta";
            this.txtIDRuta.Size = new System.Drawing.Size(100, 20);
            this.txtIDRuta.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(562, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "IDLocalizacion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(686, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "IDDescripcion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 283);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "IDLocalizacion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Fecha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "IDPaquete";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "IDRuta";
            // 
            // btnModificarR
            // 
            this.btnModificarR.Location = new System.Drawing.Point(260, 336);
            this.btnModificarR.Name = "btnModificarR";
            this.btnModificarR.Size = new System.Drawing.Size(75, 23);
            this.btnModificarR.TabIndex = 24;
            this.btnModificarR.Text = "Modificar";
            this.btnModificarR.UseVisualStyleBackColor = true;
            this.btnModificarR.Click += new System.EventHandler(this.btnModificarR_Click);
            // 
            // btnEliminarR
            // 
            this.btnEliminarR.Location = new System.Drawing.Point(260, 365);
            this.btnEliminarR.Name = "btnEliminarR";
            this.btnEliminarR.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarR.TabIndex = 23;
            this.btnEliminarR.Text = "Eliminar";
            this.btnEliminarR.UseVisualStyleBackColor = true;
            this.btnEliminarR.Click += new System.EventHandler(this.btnEliminarR_Click);
            // 
            // btnSeleccionarR
            // 
            this.btnSeleccionarR.Location = new System.Drawing.Point(260, 307);
            this.btnSeleccionarR.Name = "btnSeleccionarR";
            this.btnSeleccionarR.Size = new System.Drawing.Size(75, 23);
            this.btnSeleccionarR.TabIndex = 22;
            this.btnSeleccionarR.Text = "Seleccionar";
            this.btnSeleccionarR.UseVisualStyleBackColor = true;
            this.btnSeleccionarR.Click += new System.EventHandler(this.btnSeleccionarR_Click);
            // 
            // btnAgregarR
            // 
            this.btnAgregarR.Location = new System.Drawing.Point(260, 278);
            this.btnAgregarR.Name = "btnAgregarR";
            this.btnAgregarR.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarR.TabIndex = 21;
            this.btnAgregarR.Text = "Agregar";
            this.btnAgregarR.UseVisualStyleBackColor = true;
            this.btnAgregarR.Click += new System.EventHandler(this.btnAgregarR_Click);
            // 
            // dgvRuta
            // 
            this.dgvRuta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRuta.Location = new System.Drawing.Point(12, 28);
            this.dgvRuta.Name = "dgvRuta";
            this.dgvRuta.Size = new System.Drawing.Size(363, 194);
            this.dgvRuta.TabIndex = 20;
            // 
            // dgvLocalizacion
            // 
            this.dgvLocalizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalizacion.Location = new System.Drawing.Point(400, 28);
            this.dgvLocalizacion.Name = "dgvLocalizacion";
            this.dgvLocalizacion.Size = new System.Drawing.Size(388, 194);
            this.dgvLocalizacion.TabIndex = 40;
            // 
            // btnModificarL
            // 
            this.btnModificarL.Location = new System.Drawing.Point(713, 296);
            this.btnModificarL.Name = "btnModificarL";
            this.btnModificarL.Size = new System.Drawing.Size(75, 23);
            this.btnModificarL.TabIndex = 44;
            this.btnModificarL.Text = "Modificar";
            this.btnModificarL.UseVisualStyleBackColor = true;
            this.btnModificarL.Click += new System.EventHandler(this.btnModificarL_Click);
            // 
            // btnEliminarL
            // 
            this.btnEliminarL.Location = new System.Drawing.Point(714, 325);
            this.btnEliminarL.Name = "btnEliminarL";
            this.btnEliminarL.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarL.TabIndex = 43;
            this.btnEliminarL.Text = "Eliminar";
            this.btnEliminarL.UseVisualStyleBackColor = true;
            this.btnEliminarL.Click += new System.EventHandler(this.btnEliminarL_Click);
            // 
            // btnAgregarL
            // 
            this.btnAgregarL.Location = new System.Drawing.Point(713, 267);
            this.btnAgregarL.Name = "btnAgregarL";
            this.btnAgregarL.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarL.TabIndex = 41;
            this.btnAgregarL.Text = "Agregar";
            this.btnAgregarL.UseVisualStyleBackColor = true;
            this.btnAgregarL.Click += new System.EventHandler(this.btnAgregarL_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(470, 307);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 45;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // PantallaRuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 391);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnModificarL);
            this.Controls.Add(this.btnEliminarL);
            this.Controls.Add(this.btnAgregarL);
            this.Controls.Add(this.dgvLocalizacion);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.txtLocalizacion);
            this.Controls.Add(this.txtLocalizacionOriginal);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtPaquete);
            this.Controls.Add(this.txtIDRuta);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnModificarR);
            this.Controls.Add(this.btnEliminarR);
            this.Controls.Add(this.btnSeleccionarR);
            this.Controls.Add(this.btnAgregarR);
            this.Controls.Add(this.dgvRuta);
            this.Name = "PantallaRuta";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRuta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalizacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.TextBox txtLocalizacion;
        private System.Windows.Forms.TextBox txtLocalizacionOriginal;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtPaquete;
        private System.Windows.Forms.TextBox txtIDRuta;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnModificarR;
        private System.Windows.Forms.Button btnEliminarR;
        private System.Windows.Forms.Button btnSeleccionarR;
        private System.Windows.Forms.Button btnAgregarR;
        private System.Windows.Forms.DataGridView dgvRuta;
        private System.Windows.Forms.DataGridView dgvLocalizacion;
        private System.Windows.Forms.Button btnModificarL;
        private System.Windows.Forms.Button btnEliminarL;
        private System.Windows.Forms.Button btnAgregarL;
        private System.Windows.Forms.Button btnLimpiar;
    }
}