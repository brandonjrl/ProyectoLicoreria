
namespace Licoreria_Presentacion
{
    partial class Reporte
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
            //aqui agregare informacion sobre reportes
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reporte));
            this.btnDeudor = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnExistencias = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDeudor
            // 
            this.btnDeudor.BackColor = System.Drawing.Color.Moccasin;
            this.btnDeudor.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeudor.Image = global::Licoreria_Presentacion.Properties.Resources.documentediting_editdocuments_text_documentedi_2820;
            this.btnDeudor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeudor.Location = new System.Drawing.Point(44, 61);
            this.btnDeudor.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeudor.Name = "btnDeudor";
            this.btnDeudor.Size = new System.Drawing.Size(208, 50);
            this.btnDeudor.TabIndex = 59;
            this.btnDeudor.Text = "Deudor a la Fecha";
            this.btnDeudor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeudor.UseVisualStyleBackColor = false;
            // 
            // btnProductos
            // 
            this.btnProductos.BackColor = System.Drawing.Color.Moccasin;
            this.btnProductos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.Image = global::Licoreria_Presentacion.Properties.Resources.documentediting_editdocuments_text_documentedi_2820;
            this.btnProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.Location = new System.Drawing.Point(331, 61);
            this.btnProductos.Margin = new System.Windows.Forms.Padding(4);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(349, 50);
            this.btnProductos.TabIndex = 60;
            this.btnProductos.Text = "Productos mas Consumidos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProductos.UseVisualStyleBackColor = false;
            // 
            // btnVentas
            // 
            this.btnVentas.BackColor = System.Drawing.Color.Moccasin;
            this.btnVentas.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas.Image = global::Licoreria_Presentacion.Properties.Resources.documentediting_editdocuments_text_documentedi_2820;
            this.btnVentas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.Location = new System.Drawing.Point(44, 161);
            this.btnVentas.Margin = new System.Windows.Forms.Padding(4);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(208, 50);
            this.btnVentas.TabIndex = 61;
            this.btnVentas.Text = "Ventas por Dia";
            this.btnVentas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVentas.UseVisualStyleBackColor = false;
            // 
            // btnExistencias
            // 
            this.btnExistencias.BackColor = System.Drawing.Color.Moccasin;
            this.btnExistencias.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExistencias.Image = global::Licoreria_Presentacion.Properties.Resources.documentediting_editdocuments_text_documentedi_2820;
            this.btnExistencias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExistencias.Location = new System.Drawing.Point(331, 161);
            this.btnExistencias.Margin = new System.Windows.Forms.Padding(4);
            this.btnExistencias.Name = "btnExistencias";
            this.btnExistencias.Size = new System.Drawing.Size(349, 50);
            this.btnExistencias.TabIndex = 62;
            this.btnExistencias.Text = "Numero de existencias por Producto";
            this.btnExistencias.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExistencias.UseVisualStyleBackColor = false;
            // 
            // Reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Licoreria_Presentacion.Properties.Resources.Portada_Documento_Corporativo_Elegante_Gris_Blanco;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(699, 274);
            this.Controls.Add(this.btnExistencias);
            this.Controls.Add(this.btnVentas);
            this.Controls.Add(this.btnProductos);
            this.Controls.Add(this.btnDeudor);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Cooper Black", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Reporte";
            this.Text = "Reporte";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDeudor;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnExistencias;
    }
}