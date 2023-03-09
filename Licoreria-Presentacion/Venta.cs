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
using Microsoft.OData.Edm;
using Licoreria_Entidades;

namespace Licoreria_Presentacion
{
    public partial class Venta : Form
    {
        CNProductoVenta objetoCN = new CNProductoVenta();
        int contador_id = 1;
        DateTime hoy = DateTime.Now;
        int idvendedor;
        CNVendedor cnVendedor = new CNVendedor();
        EVendedor v1;
        public Venta()
        {
            InitializeComponent();  
            lblFecha.Text = hoy.ToShortDateString();
        }
        private void btnRecibo_Click(object sender, EventArgs e)
        {
            EListaVendedor lista = new EListaVendedor();
            lista.setListac(cnVendedor.ObtenerVendedores());
            v1 = lista.delvolverVendedor(lbnombreUsuario.Text);
            Recibo r = new Recibo();
            r.txtTotal.Text = txtTotal.Text;
            r.lblCedula.Text = txtCedula.Text;
            r.lblDireccion.Text = txtDireccionCliente.Text;
            r.lblNombre.Text = txtNombreCliente.Text;
            r.lblPago.Text = FormaPago();
            r.lblNombreVendedor.Text = lbnombreUsuario.Text;
            r.lblObs.Text = txtObs.Text;
            r.lstProductos.Items.Add("Producto\tPrecio\tCantidad\tTotal");

            if (lbnombreUsuario.Text == "Usuario por defecto")
            {
                idvendedor = 0;
            }
            else if (lbnombreUsuario.Text == v1.Nombre)
            {
                idvendedor = v1.Id;
            }

            foreach (DataGridViewRow row in dtgDetalle.Rows)
            {
                r.lstProductos.Items.Add(Convert.ToString(row.Cells["Producto"].Value) + "\t\t" + Convert.ToString(row.Cells["ValorU"].Value) + "\t" + Convert.ToString(row.Cells["Cantidad"].Value) + "\t\t" + Convert.ToString(row.Cells["ValorT"].Value));

            }
            /*
            //Guarda en la base de Datos Venta con ProductoVenta y Pago 
            if (optEfectivo.Checked == true)
            {
                objetoPV.InsertarProducto_Venta(0, float.Parse(txtEfectivo.Text), txtObs.Text, txtObs.Text, float.Parse(txtTotal.Text), txtCedula.Text, idvendedor, int.Parse(txtTotal.Text), int.Parse(txtTotal.Text), float.Parse(txtPrecio.Text), int.Parse(txtID.Text));
            }
            else if (optTransferencia.Checked == true)
            {
                objetoPV.InsertarProducto_Venta(float.Parse(txtTransferencia.Text), 0, txtObs.Text, txtObs.Text, float.Parse(txtTotal.Text), txtCedula.Text, idvendedor, int.Parse(txtTotal.Text), int.Parse(txtTotal.Text), float.Parse(txtPrecio.Text), int.Parse(txtID.Text));
            }
            else if (optCombinado.Checked == true)
            {
                objetoPV.InsertarProducto_Venta(float.Parse(txtTransferencia.Text), float.Parse(txtEfectivo.Text), txtObs.Text, txtObs.Text, float.Parse(txtTotal.Text), txtCedula.Text, idvendedor, int.Parse(txtTotal.Text), int.Parse(txtTotal.Text), float.Parse(txtPrecio.Text), int.Parse(txtID.Text));
            }*/

            if (VerificarDatosNulos() == true)
            {
                r.ShowDialog();
            }
            else if (chbFiar.Checked == true && txtCedula.Text != "" && txtNombreCliente.Text != "")
            {
                r.ShowDialog();
            }
            else { MessageBox.Show("No se pudo generar el recibo.\nPor favor llene todos los campos.", "Error al crear el recibo"); }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            Cliente c = new Cliente(this);
            c.ShowDialog();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //bool existe = false;
            if (txtID.Text == "" || txtPrecio.Text == "" || txtProducto.Text == "" || nUDCant.Value == 0)
            {
                MessageBox.Show("No es posible agregar un producto con valores nulos.\nLlene todos los campos.", "Aviso");
            }
            else 
            {
                string[] row1 = new string[] { Convert.ToString(contador_id), txtProducto.Text, nUDCant.Value.ToString(), txtPrecio.Text, txtPrecioCompra.Text , (decimal.Parse(txtPrecio.Text) * nUDCant.Value).ToString(), (decimal.Parse(txtPrecioCompra.Text) * nUDCant.Value).ToString() };
                object[] rows = new object[] { row1 };
                foreach (string[] rowArray in rows)
                {
                    dtgDetalle.Rows.Add(rowArray);
                    contador_id++;
                }

                double total = 0;
                double totalcompra = 0;
                foreach (DataGridViewRow row in dtgDetalle.Rows)
                {
                    total += Convert.ToDouble(row.Cells["ValorT"].Value);
                    totalcompra += Convert.ToDouble(row.Cells["TotalC"].Value);
                }
                txtTotal.Text = total.ToString();
                txtTotalCompa.Text = totalcompra.ToString();
            }
            optCombinado.Checked = false;
            optEfectivo.Checked = false;
            optTransferencia.Checked = false;

            objetoCN.InsertarPV(Int32.Parse(nUDCant.Value.ToString()), float.Parse(txtPrecio.Text), Int32.Parse(txtID.Text));

        }

        private void Venta_Load(object sender, EventArgs e)
        {
            //Borrar una vez calculado el total
            txtTotal.Text = "000,00";
        }

        private void btnDeudar_Click(object sender, EventArgs e)
        {
            
            Deuda r = new Deuda();
            r.txtNombreCliente.Text = txtNombreCliente.Text;
            r.txtCedula.Text = txtCedula.Text;
            r.txtTotal.Text = txtTotal.Text;
            optEfectivo.Checked = false;
            optTransferencia.Checked = false;
            optCombinado.Checked = false;

            //CNDeuda objeto = new CNDeuda();
            //MessageBox.Show(Convert.ToString(objeto.EstadoDeuda(txtCedula.Text)));
            //if (EstadoDeuda() == "Activo" || EstadoDeuda() == "activo" || objeto.EstadoDeuda(txtCedula.Text).ToString() == "Activo")
            //{
            //    MessageBox.Show("El cliente actual ya tiene una deuda");
            //}
            //else
            r.Show();
            //this.Hide();
        }
        //private string EstadoDeuda()
        //{
        //    string estado;
        //    CNDeuda objeto = new CNDeuda();
        //    estado = Convert.ToString( objeto.EstadoDeuda(txtCedula.Text));
        //    //MessageBox.Show(estado);
        //    return estado;
        //}

        private void txtNombreCliente_TextChanged(object sender, EventArgs e)
        {
            Deuda a = new Deuda();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Regresar();

        }

        private void optEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            FormaDePago();
            Pago2();
            Vuelto();
            chbFiar.Checked = false;
        }

        private void optTransferencia_CheckedChanged(object sender, EventArgs e)
        {
            FormaDePago();
            Pago1();
            Vuelto();
            chbFiar.Checked = false;
        }

        private void optCombinado_CheckedChanged(object sender, EventArgs e)
        {
            FormaDePago();
            Pago3();
            Vuelto();
            chbFiar.Checked = false;
        }
        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            BuscarProducto p = new BuscarProducto(this);
            p.ShowDialog();

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dtgDetalle.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow dr in this.dtgDetalle.SelectedRows)
                {
                    if (dr.IsNewRow == false)
                    {
                        // Si no es una fila enviada, de forma predeterminada, después de agregar una fila de datos correctamente, DataGridView creará una nueva fila como la nueva posición de inserción de datos
                        this.dtgDetalle.Rows.Remove(dr);

                        int cantidad = Int32.Parse(nUDCant.Value.ToString());
                        int devolver = -cantidad;
                        objetoCN.InsertarPV(devolver, float.Parse(txtPrecio.Text), Int32.Parse(txtID.Text));

                        double total = 0;
                        foreach (DataGridViewRow row in dtgDetalle.Rows)
                        {
                            total += Convert.ToDouble(row.Cells["ValorT"].Value);
                        }
                        txtTotal.Text = total.ToString();
                    }
                }
            }
            else
                MessageBox.Show("Seleccione una fila por favor", "Aviso");
        }


        #region Metodos
        private void Pago1()
        {
            float transf;

            if (txtTransferencia.Text == "   ,")
            {
                transf = 0;
            }
            else
            {
                transf = float.Parse(txtTransferencia.Text);
            }
            txtPago.Text = transf.ToString();
        }
        private void Pago2()
        {
            float efectivo;

            if (txtEfectivo.Text == "   ,")
            {
                efectivo = 0;
            }
            else
            {
                efectivo = float.Parse(txtEfectivo.Text);
            }
            txtPago.Text = efectivo.ToString();
        }
        private void Pago3()
        {
            float transferencia;
            float efectivo;
            float valor = 0;
            float pago;

            if (txtEfectivo.Text == "   ," && txtTransferencia.Text == "   ,")
            {
                efectivo = valor;
                transferencia = valor;
                pago = transferencia + efectivo;
            }
            else if (txtTransferencia.Text == "   ,")
            {
                efectivo = float.Parse(txtEfectivo.Text);
                pago = efectivo;
            }
            else if (txtEfectivo.Text == "   ,")
            {
                transferencia = float.Parse(txtTransferencia.Text);
                pago = transferencia;
            }
            else
            {
                transferencia = float.Parse(txtTransferencia.Text);
                efectivo = float.Parse(txtEfectivo.Text);
                pago = transferencia + efectivo;
            }
            txtPago.Text = pago.ToString();
        }
        private void FormaDePago()
        {
            if (optCombinado.Checked == true)
            {
                txtTransferencia.Enabled = true;
                txtEfectivo.Enabled = true;
            }

            else if (optEfectivo.Checked == true)
            {
                txtTransferencia.Enabled = false;
                txtEfectivo.Enabled = true;
                txtPago.Text = txtEfectivo.Text;
            }
            else if (optTransferencia.Checked == true)
            {
                txtTransferencia.Enabled = true;
                txtEfectivo.Enabled = false;
                txtPago.Text = txtTransferencia.Text;
            }

        }
        private string FormaPago()
        {
            string forma;
            if (optCombinado.Checked == true)
            {
                forma = "Efectivo y Transferencia";
            }
            else if (optEfectivo.Checked == true)
            {
                forma = "Efectivo";
            }
            else if (optTransferencia.Checked == true)
            {
                forma = "Transferencia";
            }
            else if (chbFiar.Checked == true)
            {
                forma = "El cliente fio";
            }
            else
            {
                forma = "";
            }
            return forma;
        }

        private void Vuelto()
        {
            float pago;
            float total;
            float vuelto;

            total = float.Parse(txtTotal.Text);
            pago = float.Parse(txtPago.Text);
            vuelto = pago - total;
            if (vuelto >= 0)
            {
                if (optTransferencia.Checked == true)
                {
                    vuelto = 0;
                    txtVuelto.Text = "";
                }
                else if (optCombinado.Checked == true)
                {
                    vuelto = 0;
                    txtVuelto.Text = "";
                }
                else
                    txtVuelto.Text = vuelto.ToString();
            }
            else
            {
                txtVuelto.Text = "";
                optEfectivo.Checked = false;
                optTransferencia.Checked = false;
                optCombinado.Checked = false;
                MessageBox.Show("Falta dinero.");
            }
        }

        private bool VerificarDatosNulos()
        {
            bool verificado;
            if (txtCedula.Text == "" || txtNombreCliente.Text == "" || FormaPago() == "")
            {
                verificado = false;
            }
            else { verificado = true; }


            return verificado;
        }

        public void Regresar()
        {
            MessageBoxButtons btn = MessageBoxButtons.OKCancel;
            DialogResult res = System.Windows.Forms.MessageBox.Show("¿Seguro que desea regresar a la ventana principal?", "Salir", btn, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                Principal p = new Principal();
                p.lblUsuarioVendedor.Text = lbnombreUsuario.Text;
                p.Show();
                this.Hide();
            }
            else if (res == DialogResult.Cancel) { }
        }

        #endregion

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("Por favor seleccione un cliente desde el buscador.","Aviso");
        }

        private void txtCedula_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Por favor seleccione un cliente desde el buscador.", "Aviso");
        }

        private void txtNombreCliente_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Por favor seleccione un cliente desde el buscador.", "Aviso");
        }

        private void txtProducto_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Por favor seleccione un producto desde el buscador.", "Aviso");
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("Por favor seleccione un producto desde el buscador.", "Aviso");
        }

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("Por favor seleccione un producto desde el buscador.", "Aviso");
        }

        private void chbFiar_CheckedChanged(object sender, EventArgs e)
        {
            if (chbFiar.Checked == true)
            {
                optEfectivo.Checked = false;
                optTransferencia.Checked = false;
                optCombinado.Checked = false;
                chbFiar.Checked = true;
            }
            else { }
        }

        private void txtTotalVenta_Leave(object sender, EventArgs e)
        {

            decimal totalventa = decimal.Parse(txtTotal.Text);
            decimal totalcompra = decimal.Parse(txtTotalCompa.Text);

            VerificarTotal();
        }

        private void VerificarTotal()
        {
            if (decimal.Parse(txtTotal.Text) < decimal.Parse(txtTotalCompa.Text))
            {
                MessageBox.Show("No es posible vender un producto a un precio menor que la compra.\nEl valor debe ser mayor a: " + txtTotalCompa.Text, "ALERTA");
            }
            else 
            {
                txtObs.Text = "La venta se realizó con un precio de " + txtTotal.Text;
            }
        }

        private void lblHora_Click(object sender, EventArgs e)
        {

        }

        private void horaFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }
    }


}
