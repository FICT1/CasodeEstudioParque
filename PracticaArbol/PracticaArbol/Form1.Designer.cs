namespace PracticaArbol
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tvParque = new System.Windows.Forms.TreeView();
            this.lblLugar = new System.Windows.Forms.Label();
            this.tbParque = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnContar = new System.Windows.Forms.Button();
            this.btnNivel = new System.Windows.Forms.Button();
            this.btnBusqueda = new System.Windows.Forms.Button();
            this.PartesTrabajo = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.PartesTrabajo.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvParque
            // 
            this.tvParque.Location = new System.Drawing.Point(59, 123);
            this.tvParque.Name = "tvParque";
            this.tvParque.Size = new System.Drawing.Size(280, 264);
            this.tvParque.TabIndex = 0;
            // 
            // lblLugar
            // 
            this.lblLugar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLugar.Location = new System.Drawing.Point(70, 39);
            this.lblLugar.Name = "lblLugar";
            this.lblLugar.Size = new System.Drawing.Size(121, 39);
            this.lblLugar.TabIndex = 1;
            this.lblLugar.Text = "Lugar: ";
            // 
            // tbParque
            // 
            this.tbParque.Location = new System.Drawing.Point(59, 81);
            this.tbParque.Name = "tbParque";
            this.tbParque.Size = new System.Drawing.Size(172, 22);
            this.tbParque.TabIndex = 2;
            this.tbParque.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(257, 19);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(102, 43);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(257, 74);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(102, 43);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnContar
            // 
            this.btnContar.Location = new System.Drawing.Point(32, 407);
            this.btnContar.Name = "btnContar";
            this.btnContar.Size = new System.Drawing.Size(102, 43);
            this.btnContar.TabIndex = 5;
            this.btnContar.Text = "Contar";
            this.btnContar.UseVisualStyleBackColor = true;
            this.btnContar.Click += new System.EventHandler(this.btnContar_Click);
            // 
            // btnNivel
            // 
            this.btnNivel.Location = new System.Drawing.Point(151, 407);
            this.btnNivel.Name = "btnNivel";
            this.btnNivel.Size = new System.Drawing.Size(102, 43);
            this.btnNivel.TabIndex = 6;
            this.btnNivel.Text = "Nivel";
            this.btnNivel.UseVisualStyleBackColor = true;
            this.btnNivel.Click += new System.EventHandler(this.btnNivel_Click);
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.Location = new System.Drawing.Point(272, 407);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(102, 43);
            this.btnBusqueda.TabIndex = 7;
            this.btnBusqueda.Text = "Buscar";
            this.btnBusqueda.UseVisualStyleBackColor = true;
            this.btnBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // PartesTrabajo
            // 
            this.PartesTrabajo.Controls.Add(this.tabPage1);
            this.PartesTrabajo.Controls.Add(this.tabPage2);
            this.PartesTrabajo.Location = new System.Drawing.Point(-1, 12);
            this.PartesTrabajo.Name = "PartesTrabajo";
            this.PartesTrabajo.SelectedIndex = 0;
            this.PartesTrabajo.Size = new System.Drawing.Size(581, 564);
            this.PartesTrabajo.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnBusqueda);
            this.tabPage1.Controls.Add(this.btnNivel);
            this.tabPage1.Controls.Add(this.tvParque);
            this.tabPage1.Controls.Add(this.btnContar);
            this.tabPage1.Controls.Add(this.lblLugar);
            this.tabPage1.Controls.Add(this.btnEliminar);
            this.tabPage1.Controls.Add(this.tbParque);
            this.tabPage1.Controls.Add(this.btnAgregar);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(573, 535);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Parte A";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(573, 535);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Parte B";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(573, 577);
            this.Controls.Add(this.PartesTrabajo);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GrafoyArbol";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PartesTrabajo.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvParque;
        private System.Windows.Forms.Label lblLugar;
        private System.Windows.Forms.TextBox tbParque;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnContar;
        private System.Windows.Forms.Button btnNivel;
        private System.Windows.Forms.Button btnBusqueda;
        private System.Windows.Forms.TabControl PartesTrabajo;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

