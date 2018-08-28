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
    public partial class andreside : UserControl
    {
        // tilkobling til database og oppretting av datatables 
        static string conString = "Host=cteam.mysql.domeneshop.no;Database=cteam;User=cteam;Password=AkVQirXSTZAg7bG";
        MySqlDataAdapter adapter;
        MySqlConnection con = new MySqlConnection(conString);
        DataTable table = new DataTable();
        public database db;
        MySqlCommand cmd;
        DataTable dt = new DataTable();


        public andreside()
        {
            InitializeComponent();
            db = new database();
            this.Refresh();

        }


    // for å hente brukernavnet fra adminepanelet
        string bruker_id = "";
        public string ID
        {
            set
            {
                bruker_id = value;
                retrive();
             
            }
        }

        // når man laster inn andreside ber vi programmet hente ut alt fra host hvor bruker_id = brukeren som er logget inn og fylle dette i en listeboks.
        public void andreside_Load(object sender, EventArgs e)
        {
            adapter = new MySqlDataAdapter("SELECT * FROM host WHERE bruker_id = '" + bruker_id + "';", conString);
            adapter.Fill(table);
            
            listBox1.DisplayMember ="host_navn";
            listBox1.ValueMember = "host_id";
            listBox1.DataSource = table;
            this.Refresh();









        }

        // når man klikker på knapp nr fem ber vi programmet hente ut alle eventene fra hosten som er valgt og fylle dette inn i en datagridview
        public void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "event_id";
            dataGridView1.Columns[1].Name = "event_navn";
            dataGridView1.Columns[2].Name = "host_id";



            // fyller hele grid view
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

         
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            retrive();

        }

        // her ber vi programmet ta verdien som er valgt i ilsiteboksen og legge den i textbox1
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.SelectedValue.ToString();
            this.Refresh();
        }


        // metode for å hente data fra databasen
        private void retrive()
        {
            dataGridView1.Rows.Clear();

            // sql setning for å hente ut data
            string sql = "SELECT * FROM event WHERE host_id =  '" + textBox1.Text + "';";
            // 
            cmd = new MySqlCommand(sql, con);

            try
            {
                con.Open();
                adapter = new MySqlDataAdapter(cmd);

                adapter.Fill(dt);
                // for hver rad programmet finner i databasen fyller den inn dette i tre rader
                foreach (DataRow row in dt.Rows)
                {
                    populate(row[0].ToString(), row[1].ToString(), row[2].ToString());
                }

                con.Close();

                
                dt.Rows.Clear();
            }
            catch (Exception ex)
            {
                con.Close();
            }
        }

        // legge til i DB
        private void add()
        {
            // sql for å legge til i event tabellen i databasen
            
        string conString = "INSERT INTO event (event_navn, host_id) VALUES('" + this.textBox2.Text + "', '" + this.textBox1.Text + "');";
            cmd = new MySqlCommand(conString, con);
       
            // resterende av kode er for å sjekke om event navnet finnes fra før av i eventene. Man får registrert om det ikke finnes fra før av, mens om det finnes fra før av vil man få opp en
            // feilmelding som forklarer dette. Det ligger også en feilmelding hvis programmet ikke skulle klare å gjennomføre sql settningen. Dette er mest for får del for å feilsøke underveis.
            if (db.antallRader("Select * from event where event_navn = '" + this.textBox2.Text + "' AND host_id ='" + this.textBox1.Text + "' ;") == 0)
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
                             MessageBox.Show("FEIL");
                         con.Close();
                     }

                  }
                
                 else
                 {
                
                     MessageBox.Show("Navnet finnes fra før av ");
                 }
        }
 
          // for å legge til informasjon i gridview
        private void populate(String event_id, String event_navn, String host_id)
          {
           dataGridView1.Rows.Add(event_id, event_navn, host_id);
           }

        
        

        // metode for å oppdatere i databasen. Her ber vi programmet først sjekke om det nye event navnet finnes fra før av. Hvis det ikke finnes fra før av vil man få lov til å oppdatere, hvis det
        // finnes fra før av vil man ikke få lov og man vil få opp en forklarende feilmelding
        private void update(int event_id, string event_navn)
        {
        if (db.antallRader("Select * from event where event_navn = '" + event_navn + "' AND host_id ='" + listBox1.SelectedValue.ToString() + "' ;") == 0)
        {
        db.Kjorsporring("UPDATE event set event_navn= '" + event_navn + "' WHERE event_id= " + event_id + ";");

        MessageBox.Show("Info er oppdatert i db");
        clearTxts();
        retrive();
        }


        else
        {
        MessageBox.Show("Eventnavnet finnes allerede i db");

        }
        }

      // metode for å slette data fra databasen
        private void delete(int event_id)
        {
        // sql for å slette hvor even_id = event_id i programmet
        string sql = "DELETE FROM event WHERE event_id =" + event_id + "";
        cmd = new MySqlCommand(sql, con);

      
        try
        {
        con.Open();

        adapter = new MySqlDataAdapter(cmd);

        adapter.DeleteCommand = con.CreateCommand();

        adapter.DeleteCommand.CommandText = sql;

        // Kode for å få opp en advarsel som spør deg om du vil slette før slettingen faktsik utføres.
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


        // metode for å fjerne info som står i tekstboks en og to 
        private void clearTxts()
        {
        textBox1.Text = "";
        textBox2.Text = "";

        }

        // kode for å ta verdiene som er valgt i gridview og legge i tekstboks 2
        private void dataGridView1_MouseClick1(object sender, MouseEventArgs e)
        {

            if (dataGridView1.RowCount == 0)  {


            }
            else
            {

                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // når man trykker på knapp nr 1 ber vi programmet om å legge til informasjon i databasen, da bruker vi add metoden som er laget fra før av 
        private void button1_Click_1(object sender, EventArgs e)
        {

           

            add();

          
        }
        // når man trykker på knapp nr 2 ber vi programmet om å oppdatere informasjon i databasen, da bruker vi update metoden som er laget fra før av
        private void button2_Click_1(object sender, EventArgs e)
        {
            string selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int event_id = Convert.ToInt32(selected);

            update(event_id, textBox2.Text);
        }

        // når man trykker på knapp nr 3 ber vi programmet slette informasjonene fra databasen, da bruker vi delete metoden som er laget fra før av.
        private void button3_Click_1(object sender, EventArgs e)
        {
            String selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int event_id = Convert.ToInt32(selected);

            delete(event_id);
        }

        // når man trykker på knapp nr 3 ber vi programmet om å fjerne valget verdier, da bruker vi metoden cleartxts som er laget fra før av 
        private void button4_Click_1(object sender, EventArgs e)
        {
            clearTxts();
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
    }


