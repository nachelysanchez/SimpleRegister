
namespace SimpleRegister.UI
{
    partial class rBusqueda
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
            this.busquedadtg = new System.Windows.Forms.DataGridView();
            this.txtCriterio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.filtroCombo = new System.Windows.Forms.ComboBox();
            this.BuscarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.busquedadtg)).BeginInit();
            this.SuspendLayout();
            // 
            // busquedadtg
            // 
            this.busquedadtg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.busquedadtg.Location = new System.Drawing.Point(42, 82);
            this.busquedadtg.Name = "busquedadtg";
            this.busquedadtg.Size = new System.Drawing.Size(693, 228);
            this.busquedadtg.TabIndex = 0;
            this.busquedadtg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.busquedadtg_KeyPress);
            // 
            // txtCriterio
            // 
            this.txtCriterio.Location = new System.Drawing.Point(245, 44);
            this.txtCriterio.Name = "txtCriterio";
            this.txtCriterio.Size = new System.Drawing.Size(393, 20);
            this.txtCriterio.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(242, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Criterio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filtro";
            // 
            // filtroCombo
            // 
            this.filtroCombo.FormattingEnabled = true;
            this.filtroCombo.Location = new System.Drawing.Point(42, 44);
            this.filtroCombo.Name = "filtroCombo";
            this.filtroCombo.Size = new System.Drawing.Size(177, 21);
            this.filtroCombo.TabIndex = 5;
            // 
            // BuscarButton
            // 
            this.BuscarButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BuscarButton.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuscarButton.Location = new System.Drawing.Point(644, 37);
            this.BuscarButton.Name = "BuscarButton";
            this.BuscarButton.Size = new System.Drawing.Size(91, 31);
            this.BuscarButton.TabIndex = 12;
            this.BuscarButton.Text = "Buscar";
            this.BuscarButton.UseVisualStyleBackColor = false;
            this.BuscarButton.Click += new System.EventHandler(this.BuscarButton_Click);
            // 
            // rBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 362);
            this.Controls.Add(this.BuscarButton);
            this.Controls.Add(this.filtroCombo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCriterio);
            this.Controls.Add(this.busquedadtg);
            this.Name = "rBusqueda";
            this.Text = "Busquedas";
            ((System.ComponentModel.ISupportInitialize)(this.busquedadtg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView busquedadtg;
        private System.Windows.Forms.TextBox txtCriterio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox filtroCombo;
        private System.Windows.Forms.Button BuscarButton;
    }
}