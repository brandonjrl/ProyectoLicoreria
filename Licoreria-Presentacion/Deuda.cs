﻿using System;
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
    public partial class Deuda : Form
    {
        DateTime hoy = DateTime.Now;
        CNDeuda objetoCN = new CNDeuda();
        private string idD = null;

        private bool Editar = false;
        public Deuda()
        {
            InitializeComponent();
            txtFecha.Text = hoy.ToShortDateString();
            txtFecha.Enabled = false;
            txtNombreCliente.Enabled = false;
            txtTotal.Enabled = false;
        }
        
        private void Deuda_Load(object sender, EventArgs e)
        {

            if (txtNombreCliente.Text == "")
            {
                MostrarDeuda();
            }
            else 
            {
                MostrarDeudaCliente();
            }
            
                        
        }
        private void MostrarDeuda()
        {
            CNDeuda objeto = new CNDeuda();
            dtgDeuda.DataSource = objeto.MostrarD();
        }

        private void MostrarDeudaCliente()
        {
            CNDeuda objeto = new CNDeuda();
            dtgDeuda.DataSource = objeto.MostrarDC(txtCedula.Text);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OKCancel;
            DialogResult res = System.Windows.Forms.MessageBox.Show("¿Seguro que desea eliminar la deuda?", "Eliminar", btn, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                idD = dtgDeuda.CurrentRow.Cells["ID"].Value.ToString();

                objetoCN.EliminarD(int.Parse(idD));
                //MessageBox.Show("Eliminado correctamente");
                MostrarDeuda();
            }
            else if (res == DialogResult.Cancel)
            {
                MessageBox.Show("No se ha eliminado la deuda", "Aviso");
                MostrarDeuda();
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (dtgDeuda.SelectedRows.Count > 0)
            {
                Editar = true;
                cboEstado.Text = dtgDeuda.CurrentRow.Cells["Estado"].Value.ToString();
                txtPrenda.Text = dtgDeuda.CurrentRow.Cells["Prenda"].Value.ToString();
                idD = dtgDeuda.CurrentRow.Cells["ID"].Value.ToString();
            }
            else
                MessageBox.Show("Seleccione una fila por favor","Aviso");
        }
        private void limpiarForm()
        {
            txtPrenda.Clear();
            //txtCedula.Clear(); ??
            cboEstado.Text = " ";

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                if (txtNombreCliente.Text == "" || txtCedula.Text == "" || txtPrenda.Text == "   ," || cboEstado.Text == "   ,")
                {
                    MessageBox.Show("No es posible insertar un producto\ncon atributos vacios.", "Aviso");
                }
                else
                {
                    try
                    {
                        System.IO.MemoryStream MS = new System.IO.MemoryStream();
                        pbPrenda.Image.Save(MS, System.Drawing.Imaging.ImageFormat.Jpeg);
                        objetoCN.InsertarD(txtPrenda.Text, Convert.ToDateTime(txtFecha.Text), float.Parse(txtTotal.Text), cboEstado.Text, MS.GetBuffer(), int.Parse(txtCedula.Text));
                        //MessageBox.Show("Se insertó correctamente","Aviso");
                        MostrarDeuda();
                        limpiarForm();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo insertar los datos por: " + ex);
                    }
                }
            }
            
            //EDITAR
            if (Editar == true)
            {
                try
                {
                    objetoCN.EditarD(txtPrenda.Text, cboEstado.Text, Int32.Parse(idD));
                    //MessageBox.Show("Se edito correctamente","Aviso");
                    MostrarDeuda();
                    limpiarForm();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar los datos por: " + ex);
                }
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ofdExaminar.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (ofdExaminar.ShowDialog() == DialogResult.OK)
            {

                pbPrenda.Image = new Bitmap(ofdExaminar.FileName);
            }
        }

        private void ofdExaminar_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void dtgDeuda_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgDeuda.SelectedRows.Count > 0)
            {
                txtNombreCliente.Text = dtgDeuda.CurrentRow.Cells["Nombre Cliente"].Value.ToString();
                cboEstado.Text = dtgDeuda.CurrentRow.Cells["Estado"].Value.ToString();
                txtPrenda.Text = dtgDeuda.CurrentRow.Cells["Prenda"].Value.ToString();
                txtFecha.Text = dtgDeuda.CurrentRow.Cells["Fecha"].Value.ToString();
                idD = dtgDeuda.CurrentRow.Cells["ID"].Value.ToString();

                decimal aux = Convert.ToDecimal(dtgDeuda.CurrentRow.Cells["Deuda"].Value.ToString());
                txtTotal.Text = (decimal.Round(aux, 2)).ToString();
            }

            

        }

        private void btnDeudaTotal_Click(object sender, EventArgs e)
        {
            decimal deudaT = 0;
            if (dtgDeuda.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dtgDeuda.RowCount - 1; i++)
                {
                    if (dtgDeuda.Rows[i].Cells["Nombre Cliente"].Value.ToString().Equals(txtNombreCliente.Text.ToString()))
                    {
                        deudaT += Convert.ToDecimal(dtgDeuda.Rows[i].Cells["Deuda"].Value.ToString());
                    }
                }
                deudaT = decimal.Round(deudaT, 2);
                MessageBox.Show("Su cliente debe: $"+deudaT.ToString(), "Deuda:");
            }
            else
            {
                MessageBox.Show("Elija una fila que contenga su cliente", "Por favor:");
            }
        }
    }
}
