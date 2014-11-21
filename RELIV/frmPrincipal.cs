using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
/* 
 *  Company: Plataformas Digitales S.A. de C.V.
 *  Version: 2.0
 *  
 *  Personal Comments:
 *  Herramienta, permite generar reporte de facturas RELIV NOW 
 *  Estos datos son tomados de  la BD local MySql
 *   Author:  Guadalupe Santiago Morgado / Rodolfo Cortes
 */


namespace RELIV
{
    public partial class frmPrincipal : Form
    {
        
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void reporteDeFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rptFacturas rptFacturas = new rptFacturas();
            rptFacturas.MdiParent = this;
            rptFacturas.Show();
            
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl.GetType() == typeof(MdiClient))
                {
                    // ctl.BackColor = Color.SteelBlue;
                    ctl.BackColor = Color.White;
                }
            }       
        
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
