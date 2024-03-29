﻿using Microsoft.VisualBasic.PowerPacks.Printing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Licoreria_Presentacion
{
    public partial class Recibo : Form
    {
        public Recibo()
        {
            InitializeComponent();
        }


        private void Recibo_Load(object sender, EventArgs e)
        {
            //esto se debe cambiar con cristal reports
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PrintForm print = new PrintForm();
            print.Form = this;
            print.PrinterSettings.DefaultPageSettings.Landscape = true;
            print.PrintAction = System.Drawing.Printing.PrintAction.PrintToPreview;
            print.Print(this, PrintForm.PrintOption.FullWindow);

        }

        private void lstProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
