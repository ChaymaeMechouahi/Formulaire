using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulaire
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new lbl_nom());
            string server = "localhost";
            string data = "tp3java";
            string username = "root";
            string password = "";
            string connect = "SERVER=" + server + ";" + "DATABASE=" + data + ";" + "UID" + username + ";" + "PASSWORD=" + password + ";";
            MySqlConnection cnx = new MySqlConnection(connect);
            try
            {
                cnx.Open();
                Console.WriteLine("Connected");

                string query = "SELECT * from Commande";
                MySqlCommand cmd = new MySqlCommand(query, cnx);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
