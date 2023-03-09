using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Licoreria_Negocio;

namespace Licoreria_Presentacion
{
    public partial class BuscarProducto : Form
    {
        private Venta padre;
                
        public BuscarProducto(Venta parametro)
        {
            InitializeComponent();
            padre = parametro;
        }

        private void BuscarProducto_Load(object sender, EventArgs e)
        {
            MostrarProductos();
            

        }

        private void AvisoProductoPorTerminarse()
        {
            for (int i = 0; i < dtgProducto.RowCount - 1; i++)
            {

                string nombre;
                nombre = dtgProducto.Rows[i].Cells["Nombre"].Value.ToString();
                if (Int32.Parse(dtgProducto.Rows[i].Cells["Stock"].Value.ToString()) <= 10)
                {
                    dtgProducto.Rows[i].DefaultCellStyle.BackColor = Color.Red;

                    lblAviso.Text = "Se han marcado en rojo los productos por terminarse.";

                    //MessageBox.Show("Se esta acabando el producto: " + nombre, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            BuscarProd();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            BuscarProd();
        }

        private void dtgrdProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            padre.txtProducto.Text = dtgProducto.CurrentRow.Cells["Nombre"].Value.ToString();
            padre.txtPrecio.Text = dtgProducto.CurrentRow.Cells["Precio Venta"].Value.ToString();
            padre.txtID.Text = dtgProducto.CurrentRow.Cells["ID"].Value.ToString();
            padre.txtPrecioCompra.Text = dtgProducto.CurrentRow.Cells["Precio Compra"].Value.ToString();

            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Metodos
        private void MostrarProductos()
        {
            CNProducto objeto = new CNProducto();
            dtgProducto.DataSource = objeto.MostrarP();
            AvisoProductoPorTerminarse();
        }
        private void BuscarProd()
        {
            CNProducto objeto = new CNProducto();
            dtgProducto.DataSource = objeto.BuscarP(txtProducto.Text);
        }
        #endregion
    }
}
