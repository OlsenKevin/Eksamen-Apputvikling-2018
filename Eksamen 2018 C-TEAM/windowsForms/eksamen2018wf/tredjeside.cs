using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace eksamen2018wf
{
    public partial class tredjeside : UserControl
    {

        // tilkobling til database og oppretting av datatables 
        static string conString = "Host=cteam.mysql.domeneshop.no;Database=cteam;User=cteam;Password=AkVQirXSTZAg7bG";
        MySqlConnection con = new MySqlConnection(conString);
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt = new DataTable();




        public database db;
        public tredjeside()
        {
            InitializeComponent();
            db = new database();
           //koden for å fylle informasjon til gridview i det siden lastes inn 
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "host_id";
            dataGridView1.Columns[1].Name = "host_Navn";
            


            // fyller hele grid view
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

          
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;


        }

        // for å ta med bruker_id
        string bruker_id = "";
        public string ID
        {
            set { bruker_id = value;
                retrive();
            }
        }
        

        // legge til i DB. Se andreside.cs linje 131 for fullstendig kommentert kode av metoden
        private void add(string host_navn)

        {

            
            string sql = "INSERT INTO host (host_navn, bruker_id) VALUES(@HOSTNAVN, '" + bruker_id +"');";
            cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@HOSTNAVN", host_navn);



            if (db.antallRader("Select * from host where host_navn = '" + host_navn + "' AND bruker_id ='" + bruker_id + "' ;") == 0)
            {
                try
                {
                    con.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Data er registrert til tabellen");
                        clearTxts();

                    }


                    con.Close();
                    retrive();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    con.Close();
                }

            }

            else {

                MessageBox.Show("Navnet finnes fra før av ");
            }


                

       
        }


        // for å legge til informasjon i gridview
        private void populate (String host_id, String host_navn, String bruker_id)
        {

            dataGridView1.Rows.Add(host_id, host_navn);
        }

        // hente fra DB.  Se andreside.cs linje 98 for fullstendig kommentert kode av metoden
        private void retrive()
        {
            dataGridView1.Rows.Clear();

            // sql
            string sql = "SELECT * FROM host WHERE bruker_id = '" + bruker_id + "';";
            cmd = new MySqlCommand(sql, con);

            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(cmd);

                adapter.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    populate(row[0].ToString(), row[1].ToString(), row[2].ToString());
                }

                con.Close();

                // rydd
                dt.Rows.Clear();
            }
            catch(Exception ex) {
                con.Close();
            }
        }

        //Oppdatere i  db.  Se andreside.cs linje 180 for fullstendig kommentert kode av metoden
        private void update(int host_id, string host_navn)
        {
            if (db.antallRader("Select * from host where host_navn = '" + host_navn + "' AND bruker_id ='" + bruker_id + "' ;") == 0)
            {
                db.Kjorsporring ("UPDATE host set host_navn= '" + host_navn + "' WHERE host_id= " + host_id + ";");
               
                 MessageBox.Show("Info er oppdatert i db");
                clearTxts();
                 retrive();
                }



            else {
                MessageBox.Show("Hostnavnet finnes allerede i db");

            }
        }

        // slette fra db.  Se andreside.cs linje 201 for fullstendig kommentert kode av metoden
        private void delete(int host_id)
        {
            //SQLSTMT
            string sql = "DELETE FROM host WHERE host_id =" + host_id + "";
            cmd = new MySqlCommand(sql, con);

            //'OPEN CON,EXECUTE DELETE,CLOSE CON
            try
            {
                con.Open();
              
                adapter = new MySqlDataAdapter(cmd);

                adapter.DeleteCommand = con.CreateCommand();

                adapter.DeleteCommand.CommandText = sql;

                //PROMPT FOR CONFIRMATION
                if (MessageBox.Show("Sikker på at du vil slette valgt host ?", "SLETT", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        clearTxts();  
                        MessageBox.Show("Hosten er slettet");
                    }
                }

                con.Close();

                retrive();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }

        }

        // tar bort info som er skrevet i tekstfelt 
        private void clearTxts()
        {
          
            textbox2.Text = "";
        
        }
     
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // kode for å ta verdiene som er valgt i gridview og legge i tekstboks 2
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {


            textbox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
         
        }


        // når man trykker på knapp nr 1 ber vi programmet om å legge til informasjon i databasen, da bruker vi add metoden som er laget fra før av 
        private void button1_Click(object sender, EventArgs e)
        {
            add(textbox2.Text);
     
        }

        // når man trykker på knapp nr 3 ber vi programmet om å oppdatere informasjon i databasen, da bruker vi update metoden som er laget fra før av
        private void button3_Click(object sender, EventArgs e)
        {
            string selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int host_id = Convert.ToInt32(selected);

            update(host_id, textbox2.Text);

        }


        // når man trykker på knapp nr 4 ber vi programmet slette informasjonene fra databasen, da bruker vi delete metoden som er laget fra før av.
        private void button4_Click(object sender, EventArgs e)
        {
            String selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int host_id = Convert.ToInt32(selected);

            delete(host_id);
        }

        // når man trykker på knapp nr 3 ber vi programmet om å fjerne valget verdier, da bruker vi metoden cleartxts som er laget fra før av 
        private void button5_Click(object sender, EventArgs e)
        {
            clearTxts();
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            BringToFront();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textbox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
