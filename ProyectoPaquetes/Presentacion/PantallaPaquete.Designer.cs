namespace Presentacion
{
    partial class PantallaPaquete
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
            this.txtIDArticulo = new System.Windows.Forms.TextBox();
            this.txtDescrpcion = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.txtIDCliente = new System.Windows.Forms.TextBox();
            this.txtIDPaquete = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnPorID = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvPaquete = new System.Windows.Forms.DataGridView();
            this.rbtSi = new System.Windows.Forms.RadioButton();
            this.rbtNo = new System.Windows.Forms.RadioButton();
            this.btnPorFecha = new System.Windows.Forms.Button();
            this.btnPorDescripcion = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaquete)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(12, 343);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 39;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // txtIDArticulo
            // 
            this.txtIDArticulo.Location = new System.Drawing.Point(260, 225);
            this.txtIDArticulo.Name = "txtIDArticulo";
            this.txtIDArticulo.Size = new System.Drawing.Size(100, 20);
            this.txtIDArticulo.TabIndex = 38;
            // 
            // txtDescrpcion
            // 
            this.txtDescrpcion.Location = new System.Drawing.Point(136, 283);
            this.txtDescrpcion.Name = "txtDescrpcion";
            this.txtDescrpcion.Size = new System.Drawing.Size(100, 20);
            this.txtDescrpcion.TabIndex = 35;
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(260, 283);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(100, 20);
            this.txtFecha.TabIndex = 34;
            // 
            // txtIDCliente
            // 
            this.txtIDCliente.Location = new System.Drawing.Point(136, 225);
            this.txtIDCliente.Name = "txtIDCliente";
            this.txtIDCliente.Size = new System.Drawing.Size(100, 20);
            this.txtIDCliente.TabIndex = 33;
            // 
            // txtIDPaquete
            // 
            this.txtIDPaquete.Location = new System.Drawing.Point(12, 225);
            this.txtIDPaquete.Name = "txtIDPaquete";
            this.txtIDPaquete.Size = new System.Drawing.Size(100, 20);
            this.txtIDPaquete.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(133, 267);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Descripcion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(257, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Fecha";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Entregado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "IDArticulo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "IDCliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "IDPaquete";
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(488, 212);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 24;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(588, 212);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 23;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnPorID
            // 
            this.btnPorID.Location = new System.Drawing.Point(385, 262);
            this.btnPorID.Name = "btnPorID";
            this.btnPorID.Size = new System.Drawing.Size(75, 23);
            this.btnPorID.TabIndex = 22;
            this.btnPorID.Text = "Por ID";
            this.btnPorID.UseVisualStyleBackColor = true;
            this.btnPorID.Click += new System.EventHandler(this.btnPorID_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(385, 212);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 21;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvPaquete
            // 
            this.dgvPaquete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaquete.Location = new System.Drawing.Point(12, 12);
            this.dgvPaquete.Name = "dgvPaquete";
            this.dgvPaquete.Size = new System.Drawing.Size(651, 194);
            this.dgvPaquete.TabIndex = 20;
            // 
            // rbtSi
            // 
            this.rbtSi.AutoSize = true;
            this.rbtSi.Location = new System.Drawing.Point(12, 286);
            this.rbtSi.Name = "rbtSi";
            this.rbtSi.Size = new System.Drawing.Size(32, 17);
            this.rbtSi.TabIndex = 40;
            this.rbtSi.TabStop = true;
            this.rbtSi.Text = "si";
            this.rbtSi.UseVisualStyleBackColor = true;
            // 
            // rbtNo
            // 
            this.rbtNo.AutoSize = true;
            this.rbtNo.Location = new System.Drawing.Point(50, 286);
            this.rbtNo.Name = "rbtNo";
            this.rbtNo.Size = new System.Drawing.Size(39, 17);
            this.rbtNo.TabIndex = 41;
            this.rbtNo.TabStop = true;
            this.rbtNo.Text = "No";
            this.rbtNo.UseVisualStyleBackColor = true;
            // 
            // btnPorFecha
            // 
            this.btnPorFecha.Location = new System.Drawing.Point(475, 262);
            this.btnPorFecha.Name = "btnPorFecha";
            this.btnPorFecha.Size = new System.Drawing.Size(75, 23);
            this.btnPorFecha.TabIndex = 42;
            this.btnPorFecha.Text = "Por Fecha";
            this.btnPorFecha.UseVisualStyleBackColor = true;
            this.btnPorFecha.Click += new System.EventHandler(this.btnPorFecha_Click);
            // 
            // btnPorDescripcion
            // 
            this.btnPorDescripcion.Location = new System.Drawing.Point(569, 262);
            this.btnPorDescripcion.Name = "btnPorDescripcion";
            this.btnPorDescripcion.Size = new System.Drawing.Size(94, 23);
            this.btnPorDescripcion.TabIndex = 43;
            this.btnPorDescripcion.Text = "Por descripcion";
            this.btnPorDescripcion.UseVisualStyleBackColor = true;
            this.btnPorDescripcion.Click += new System.EventHandler(this.btnPorDescripcion_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(382, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "Seleccionar por";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(588, 315);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 45;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // PantallaPaquete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 372);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnPorDescripcion);
            this.Controls.Add(this.btnPorFecha);
            this.Controls.Add(this.rbtNo);
            this.Controls.Add(this.rbtSi);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.txtIDArticulo);
            this.Controls.Add(this.txtDescrpcion);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.txtIDCliente);
            this.Controls.Add(this.txtIDPaquete);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnPorID);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.dgvPaquete);
            this.Name = "PantallaPaquete";
            this.Text = "Pantalla de paquetes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaquete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.TextBox txtIDArticulo;
        private System.Windows.Forms.TextBox txtDescrpcion;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.TextBox txtIDCliente;
        private System.Windows.Forms.TextBox txtIDPaquete;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnPorID;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvPaquete;
        private System.Windows.Forms.RadioButton rbtSi;
        private System.Windows.Forms.RadioButton rbtNo;
        private System.Windows.Forms.Button btnPorFecha;
        private System.Windows.Forms.Button btnPorDescripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLimpiar;
    }
}