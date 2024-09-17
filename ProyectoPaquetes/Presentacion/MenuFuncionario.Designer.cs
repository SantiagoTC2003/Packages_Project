namespace Presentacion
{
    partial class MenuFuncionario
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnPaquetes = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClientes = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRutas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Lista de paquetes\r\n";
            // 
            // btnPaquetes
            // 
            this.btnPaquetes.Location = new System.Drawing.Point(15, 171);
            this.btnPaquetes.Name = "btnPaquetes";
            this.btnPaquetes.Size = new System.Drawing.Size(75, 23);
            this.btnPaquetes.TabIndex = 10;
            this.btnPaquetes.Text = "Paquetes";
            this.btnPaquetes.UseVisualStyleBackColor = true;
            this.btnPaquetes.Click += new System.EventHandler(this.btnPaquetes_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(308, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Lista de Clientes/Funcionarios (donde se manejan sus permisos)";
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(15, 100);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(75, 23);
            this.btnClientes.TabIndex = 8;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Lista de seguimiento de los paquetes por ruta";
            // 
            // btnRutas
            // 
            this.btnRutas.Location = new System.Drawing.Point(15, 34);
            this.btnRutas.Name = "btnRutas";
            this.btnRutas.Size = new System.Drawing.Size(75, 23);
            this.btnRutas.TabIndex = 6;
            this.btnRutas.Text = "Rutas";
            this.btnRutas.UseVisualStyleBackColor = true;
            this.btnRutas.Click += new System.EventHandler(this.btnRutas_Click);
            // 
            // MenuFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 209);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPaquetes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRutas);
            this.Name = "MenuFuncionario";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPaquetes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRutas;
    }
}