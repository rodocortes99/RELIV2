using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace RELIV.classes
{
    class ClassConexionBD
    {

        public MySqlConnection conexionSQL()
        { //Pasar a  config


            string server = ConfigurationManager.AppSettings["SERVER"];
            string db = ConfigurationManager.AppSettings["DB"];
            string user = ConfigurationManager.AppSettings["USER"];
            string pass = ConfigurationManager.AppSettings["PASS"];

            MySqlConnection cnn = null;
            string conSQL = "Server=" + server + ";" + "Database=" + db + ";" + "UID=" + user + ";" + "Password=" + pass + ";";
            cnn = new MySqlConnection(conSQL);
            cnn.Open();
            return cnn;
        }

        public DataTable Consultasql(string query)
        {
            MySqlConnection cnn = conexionSQL();
            DataTable dt = new DataTable();
           
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = new MySqlCommand(query, cnn);
            adapter.Fill(dt);
            cnn.Close();
            return dt;
        }

        public bool InsertaSql(string query)
        {
            MySqlConnection cnn = conexionSQL();
            try
            {
                MySqlCommand comando = new MySqlCommand(query, cnn);
                comando.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            cnn.Close();
            return true;
        }

        public int numeroFilas(string query)
        {
            MySqlConnection cnn = conexionSQL();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = new MySqlCommand(query, cnn);
            adapter.Fill(dt);
            cnn.Close();
            int numero = dt.Rows.Count;
            return numero;
        }
    }
}
