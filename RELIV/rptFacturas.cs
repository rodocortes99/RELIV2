using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Configuration;

namespace RELIV
{
    public partial class rptFacturas : Form
    {
        classes.ClassConexionBD conexion = new classes.ClassConexionBD();
    
        public rptFacturas()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
          
 
           string fecha_Inicio = dtFInicio.Text + " "+"00:00:00";
           string fecha_Final = dtFfinal.Text+" "+"23:59:59";

            //Se carga del app config
           string server = ConfigurationManager.AppSettings["SERVER"];
           string db = ConfigurationManager.AppSettings["DB"];
           string user = ConfigurationManager.AppSettings["USER"];
           string pass = ConfigurationManager.AppSettings["PASS"];
            //Conexion a la BD
          
            
           MySqlConnection cnn;
           string connectionString = null;
          
            connectionString = "Server=" + server + ";" + "Database=" + db + ";" + "UID=" + user + ";" + "Password=" + pass + ";";
            cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open();

            }
            catch (System.Exception exep)
            {
                MessageBox.Show(exep.Message);
            }
            string query = "SELECT dfecha,ifolio,vchNombre,vchRfcReceptor,iNOrden,fGravado16,fGravado0,fflete,fTotalIVA,fDescuento,ftotal FROM r_facturas WHERE dfecha BETWEEN '" + fecha_Inicio + "' AND  '" + fecha_Final + "' ORDER BY ifolio ASC;";
           
         
           MySqlDataAdapter dscmd = new MySqlDataAdapter(query, cnn);
           DataSet1 ds = new DataSet1();
           dscmd.Fill(ds, "r_facturas");
           cnn.Close();
                

            //Se agrega fecha de inicio y fin al data table.
           try
           {
               DataTable datosExtra = ds.Filtros;
               DataRow drow;
               drow = datosExtra.NewRow();
               drow["dfechaInicio"] = dtFInicio.Text;
               drow["dfechaFinal"] = dtFfinal.Text;
               datosExtra.Rows.Add(drow);
           }
           catch (System.Exception exep)
           {
               MessageBox.Show(exep.Message);
           }
           

            //Reporte
           Reporte rptFacturas = new Reporte();
           rptFacturas.SetDataSource(ds);
           //Asocia el reporte con el visualizador
           crystalReportViewer1.ReportSource = rptFacturas; 
           
        }

        private void rptFacturas_Load(object sender, EventArgs e)
        {
           
        }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
        }

    }
}
