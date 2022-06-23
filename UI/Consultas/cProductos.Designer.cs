
namespace SimpleRegister.UI.Consultas
{
    partial class cProductos
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
            this.USUARIOS = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.productosdtg = new System.Windows.Forms.DataGridView();
            this.BuscarButton = new System.Windows.Forms.Button();
            this.txtCriterio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboFiltro = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productosdtg)).BeginInit();
            this.SuspendLayout();
            // 
            // USUARIOS
            // 
            this.USUARIOS.AutoSize = true;
            this.USUARIOS.Font = new System.Drawing.Font("Stabillo Medium", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.USUARIOS.ForeColor = System.Drawing.Color.Navy;
            this.USUARIOS.Location = new System.Drawing.Point(271, 10);
            this.USUARIOS.Name = "USUARIOS";
            this.USUARIOS.Size = new System.Drawing.Size(143, 34);
            this.USUARIOS.TabIndex = 8;
            this.USUARIOS.Text = "Productos";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.productosdtg);
            this.groupBox1.Controls.Add(this.BuscarButton);
            this.groupBox1.Controls.Add(this.txtCriterio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboFiltro);
            this.groupBox1.Location = new System.Drawing.Point(12, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(664, 324);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // productosdtg
            // 
            this.productosdtg.BackgroundColor = System.Drawing.Color.Lavender;
            this.productosdtg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productosdtg.Location = new System.Drawing.Point(10, 68);
            this.productosdtg.Name = "productosdtg";
            this.productosdtg.Size = new System.Drawing.Size(627, 221);
            this.productosdtg.TabIndex = 14;
            // 
            // BuscarButton
            // 
            this.BuscarButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BuscarButton.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuscarButton.Location = new System.Drawing.Point(546, 20);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(91, 31);
            this.BuscarButton.TabIndex = 13;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = false;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // txtCriterio
            // 
            this.txtCriterio.Location = new System.Drawing.Point(146, 29);
            this.txtCriterio.Name = "txtCriterio";
            this.txtCriterio.Size = new System.Drawing.Size(358, 20);
            this.txtCriterio.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(157, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Criterio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filtro";
            // 
            // comboFiltro
            // 
            this.comboFiltro.FormattingEnabled = true;
            this.comboFiltro.Location = new System.Drawing.Point(10, 27);
            this.comboFiltro.Name = "comboFiltro";
            this.comboFiltro.Size = new System.Drawing.Size(121, 21);
            this.comboFiltro.TabIndex = 0;
            // 
            // cProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 369);
            this.Controls.Add(this.USUARIOS);
            this.Controls.Add(this.groupBox1);
            this.Name = "cProductos";
            this.Text = "Consulta de Productos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productosdtg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label USUARIOS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView productosdtg;
        private System.Windows.Forms.Button BuscarButton;
        private System.Windows.Forms.TextBox txtCriterio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboFiltro;
    }
}