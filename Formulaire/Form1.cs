using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Formulaire
{
   
    public partial class Form1 : Form
    {
        string condition;
        string requete;
        MySqlCommand cmd;

        public Form1()
        {
            InitializeComponent();
        }
        MySqlConnection conn = new MySqlConnection("Server=localhost;Database=etudiant;Password=\"\";");
            

private void lbl_nom_Load(object sender, EventArgs e)
        {
            btn_Ajout.Enabled = true;
            btn_annuler.Enabled = false;
            btn_modif.Enabled = false;
            btn_save.Enabled = false;
            btn_supprimer.Enabled = false;
            
        }

        private void recherche_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_Ajout.Enabled = false;
            btn_supprimer.Enabled = true;
            btn_annuler.Enabled = false;
            btn_modif.Enabled = true;
            btn_save.Enabled=false;
            recherche.Enabled = true;
        }

        private void btn_Ajout_Click(object sender, EventArgs e)
        {
            btn_Ajout.Enabled = false;
            btn_supprimer.Enabled = false;
            btn_annuler.Enabled = true;
            btn_modif.Enabled = false;
            btn_save.Enabled = true;
            recherche.Enabled = false;
        }

        private void btn_modif_Click(object sender, EventArgs e)
        {
            btn_Ajout.Enabled = false;
            btn_supprimer.Enabled = true;
            btn_annuler.Enabled = true;
            btn_modif.Enabled = false;
            btn_save.Enabled = true;
            recherche.Enabled = false;
        }

        private void btn_supprimer_Click(object sender, EventArgs e)
        {
            condition = recherche.Text;
            requete = "SELECT id FROM Etudiant WHERE Etudiant.id =" + condition;
            btn_Ajout.Enabled = false;
            btn_supprimer.Enabled = false;
            btn_annuler.Enabled = false;
            btn_modif.Enabled = false;
            btn_save.Enabled = false;
            recherche.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            
            MessageBoxButtons boutton = MessageBoxButtons.YesNo;
            DialogResult resultat = MessageBox.Show("Continuer", "non", boutton);
            if (resultat == DialogResult.Yes)
            {
                requete = "DELETE FROM Etudiant ";
                cmd = new MySqlCommand(requete,conn);
                try
                {
                    conn.Open();
                    MessageBox.Show("coneection open");
                    int rowCount  = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            else 
            {
                btn_Ajout.Enabled = true;
                btn_supprimer.Enabled = false;
                btn_annuler.Enabled = false;
                btn_modif.Enabled = true;
                btn_save.Enabled = false;
                recherche.Enabled = true;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
            }
        }

        private void btn_annuler_Click(object sender, EventArgs e)
        {
            btn_Ajout.Enabled = true;
            btn_supprimer.Enabled = false;
            btn_annuler.Enabled = false;
            btn_modif.Enabled = true;
            btn_save.Enabled = false;
            recherche.Enabled = true;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            btn_Ajout.Enabled = true;
            btn_supprimer.Enabled = false;
            btn_annuler.Enabled = false;
            btn_modif.Enabled = true;
            btn_save.Enabled = false;
            recherche.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
        }

        
    }
}
