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
    public partial class fjerdeside : UserControl
    {
        // tilkobling til database og oppretting av datatables 
        static string conString = "Host=cteam.mysql.domeneshop.no;Database=cteam;User=cteam;Password=AkVQirXSTZAg7bG";
        MySqlDataAdapter adapter;
        MySqlConnection con = new MySqlConnection(conString);
        DataTable table = new DataTable();
        DataTable eventtabel = new DataTable();
        
        public database db;
        MySqlCommand cmd;
        DataTable dt = new DataTable();

        public fjerdeside()
        {
            InitializeComponent();
            db = new database();
            this.Refresh();
        }



        // hva som skjer når fjerdeside lastes inn
        private void fjerdeside_Load(object sender, EventArgs e)
        {
            // når man laster inn andreside ber vi programmet hente ut alt fra host hvor bruker_id = brukeren som er logget inn og fylle dette i en listeboks. 
            adapter = new MySqlDataAdapter("SELECT * FROM host WHERE bruker_id = '" + bruker_id + "';", conString);
            adapter.Fill(table);

            listBox1.DisplayMember = "host_navn";
            listBox1.ValueMember = "host_id";
            listBox1.DataSource = table;
            listBox1.Refresh();
           

        }

        // for å hente bruker_id som er sendt fra adminpanelet
        string bruker_id = "";
        public string ID
        {
            set
            {
                bruker_id = value;
                

            }
        }

        // her ber vi programmet ta verdien som er valgt i ilsiteboksen og legge den i textbox1
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.SelectedValue.ToString();
            listBox2.Refresh();

        }


        // når man trykker på knapp 1 ber man programmet ta om å fylle listeboks nr to med i alle eventene fra hosten som er valgt fra listebkos nr 1
        private void button1_Click(object sender, EventArgs e)
        {


    
            adapter = new MySqlDataAdapter("SELECT * FROM event WHERE host_id = '" + textBox1.Text + "';", conString);
            adapter.Fill(eventtabel);

           
            listBox2.DisplayMember = "event_navn";
            listBox2.ValueMember = "event_id";
            listBox2.DataSource = eventtabel;

        }



        // når man trykker inn knapp nr 2 ber man programmet om å fylle datagridview med hvilken hvilke turneringer som event man har valgt inneholder. Dette gjør vi med å bruke metoden retrve
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "turnering_id";
            dataGridView1.Columns[1].Name = "turnering_navn";
            dataGridView1.Columns[2].Name = "event_id";



            // fyller hele grid view
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //SELECTION MODE
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            retrive();
        }

        // hente fra DB.  Se andreside.cs linje 98 for fullstendig kommentert kode av metoden
        private void retrive()
        {
            dataGridView1.Rows.Clear();

            // sql setning for å hente 
            string sql = "SELECT * FROM turnering WHERE event_id =  '" + textBox2.Text + "';";
            // 
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
            catch (Exception ex)
            {
                con.Close();
            }
        }

        // for å legge til informasjon i gridview
        private void populate(String turnering_id, String turnering_navn, String event_id)
        {
            dataGridView1.Rows.Add(turnering_id, turnering_navn, event_id);
        }


        // her ber vi programmet ta verdien som er valgt i ilsiteboksen og legge den i textbox2
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = listBox2.SelectedValue.ToString();
            listBox2.Refresh();
        }


        // når man trykker på knapp nr 3 ber vi programmet om å legge til informasjon i databasen, da bruker vi add metoden som er laget fra før av 
        private void button3_Click(object sender, EventArgs e)
        {
            add();
        }

        // legge til i DB. Se andreside.cs linje 131 for fullstendig kommentert kode av metoden
        private void add()
        {







            string conString = "INSERT INTO turnering (turnering_navn, event_id, status, spill_id, type_id ) VALUES('" + this.textBox3.Text + "', '" + this.textBox2.Text + "', 1,1,1);";
            cmd = new MySqlCommand(conString, con);

            


            if (db.antallRader("Select * from turnering where turnering_navn = '" + this.textBox3.Text + "' AND event_id ='" + this.textBox2.Text + "' ;") == 0)
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

        // tar bort info som er skrevet i tekstfelt 
        private void clearTxts()
        {
            textBox1.Text = "";
            textBox2.Text = "";

        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // når man trykker på knapp nr 4 ber vi programmet om å oppdatere informasjon i databasen, da bruker vi update metoden som er laget fra før av
        private void button4_Click(object sender, EventArgs e)
        {
            string selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int turnering_id = Convert.ToInt32(selected);

            update(turnering_id, textBox3.Text);
        }


        //Oppdatere i  db.  Se andreside.cs linje 180 for fullstendig kommentert kode av metoden
        private void update(int turnering_id, string turnering_navn)
        {
            if (db.antallRader("Select * from turnering where turnering_navn = '" + turnering_navn + "';") == 0)
            {
                db.Kjorsporring("UPDATE turnering set turnering_navn= '" + turnering_navn + "' WHERE turnering_id= " + turnering_id + ";");

                MessageBox.Show("Info er oppdatert i db");
                clearTxts();
                retrive();
            }







            else
            {
                MessageBox.Show("Turneringsnavnet finnes allerede i db");

            }
        }

        // når man trykker på knapp nr 5 ber vi programmet slette informasjonene fra databasen, da bruker vi delete metoden som er laget fra før av.
        private void button5_Click(object sender, EventArgs e)
        {
            String selected = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int turnering_id = Convert.ToInt32(selected);

            delete(turnering_id);
        }

        // slette fra db.  Se andreside.cs linje 201 for fullstendig kommentert kode av metoden
        private void delete(int turnering_id)
        {
            
            string sql = "DELETE FROM kamp WHERE turnering_id = "+turnering_id+";" +
                "DELETE d.* FROM deltager AS d INNER JOIN lag AS l ON d.lag_id = l.lag_id WHERE l.turnering_id = "+turnering_id+";" +
                "DELETE FROM lag WHERE turnering_id = "+ turnering_id+";" +
                "DELETE FROM turnering WHERE turnering_id =" + turnering_id + "";
            cmd = new MySqlCommand(sql, con);

       
            try
            {
                con.Open();

                adapter = new MySqlDataAdapter(cmd);

                adapter.DeleteCommand = con.CreateCommand();

                adapter.DeleteCommand.CommandText = sql;

           
                if (MessageBox.Show("Sikker på at du vil slette valgt host ?", "SLETT", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        clearTxts();
                        MessageBox.Show("turneringen er slettet");
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // fyller tekstbos 3 med valgt rad fra datagridview
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {


            if (dataGridView1.RowCount == 0)
            {


            }
            else
            {

                textBox3.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            }
  
        }
    }


}
