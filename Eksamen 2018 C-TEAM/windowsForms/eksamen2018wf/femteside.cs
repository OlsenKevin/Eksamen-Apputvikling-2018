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
    public partial class femteside : UserControl
    {

        public femteside()
        {
            
            InitializeComponent();
        }
      

        // kobling til database og oppretting av datatables
        MySqlConnection con = new MySqlConnection("Host=cteam.mysql.domeneshop.no;Database=cteam;User=cteam;Password=AkVQirXSTZAg7bG");
        static string conString = "Host=cteam.mysql.domeneshop.no;Database=cteam;User=cteam;Password=AkVQirXSTZAg7bG";
        MySqlDataAdapter adapter;
    
        DataTable table = new DataTable();
        DataTable eventtabel = new DataTable();

        public database db;
        MySqlCommand cmd;
        DataTable dt = new DataTable();



        // for å hente bruker_id som er sendt fra adminpanelet
        string bruker_id = "";
        public string ID
        {
            set
            {
                bruker_id = value;


            }
        }

        // når femteside laster inn ber vi programmet om å hente ut turneringer som er laget av brukeren som er logget inn og legge disse turneringene i listeboks1
        private void femteside_Load(object sender, EventArgs e)
        {


            adapter = new MySqlDataAdapter("SELECT t.turnering_id, t.turnering_navn FROM turnering AS t INNER JOIN event AS e ON e.event_id = t.event_id INNER JOIN host AS h ON e.host_id = h.host_id INNER JOIN admin AS a ON h.bruker_id = a.bruker_id WHERE a.bruker_id = '" + bruker_id + "';", conString);
            adapter.Fill(table);

            listBox1.DisplayMember = "turnering_navn";
            listBox1.ValueMember = "turnering_id";
            listBox1.DataSource = table;

            // Koden på linje 64 - 337 tillater drag and drop mellom tekstbokser.
           
            /////////////////////////////////////////////////////////////////////
            textBox1.DragEnter += new DragEventHandler(textBox9_DragEnter);
            textBox1.MouseDown += new MouseEventHandler(textBox9_MouseDown);
            textBox1.DragDrop += new DragEventHandler(textBox9_DragDrop);

            textBox2.DragEnter += new DragEventHandler(textBox9_DragEnter);
            textBox2.MouseDown += new MouseEventHandler(textBox9_MouseDown);
            textBox2.DragDrop += new DragEventHandler(textBox9_DragDrop);

            textBox3.DragEnter += new DragEventHandler(textBox9_DragEnter);
            textBox3.MouseDown += new MouseEventHandler(textBox9_MouseDown);
            textBox3.DragDrop += new DragEventHandler(textBox9_DragDrop);

            textBox4.DragEnter += new DragEventHandler(textBox9_DragEnter);
            textBox4.MouseDown += new MouseEventHandler(textBox9_MouseDown);
            textBox4.DragDrop += new DragEventHandler(textBox9_DragDrop);

            textBox5.DragEnter += new DragEventHandler(textBox9_DragEnter);
            textBox5.MouseDown += new MouseEventHandler(textBox9_MouseDown);
            textBox5.DragDrop += new DragEventHandler(textBox9_DragDrop);

            textBox6.DragEnter += new DragEventHandler(textBox9_DragEnter);
            textBox6.MouseDown += new MouseEventHandler(textBox9_MouseDown);
            textBox6.DragDrop += new DragEventHandler(textBox9_DragDrop);

            textBox7.DragEnter += new DragEventHandler(textBox9_DragEnter);
            textBox7.MouseDown += new MouseEventHandler(textBox9_MouseDown);
            textBox7.DragDrop += new DragEventHandler(textBox9_DragDrop);

            textBox8.DragEnter += new DragEventHandler(textBox9_DragEnter);
            textBox8.MouseDown += new MouseEventHandler(textBox9_MouseDown);
            textBox8.DragDrop += new DragEventHandler(textBox9_DragDrop);

            ///////////////////////////////////////////////////////////////

            textBox1.DragEnter += new DragEventHandler(textBox10_DragEnter);
            textBox1.MouseDown += new MouseEventHandler(textBox10_MouseDown);
            textBox1.DragDrop += new DragEventHandler(textBox10_DragDrop);

            textBox2.DragEnter += new DragEventHandler(textBox10_DragEnter);
            textBox2.MouseDown += new MouseEventHandler(textBox10_MouseDown);
            textBox2.DragDrop += new DragEventHandler(textBox10_DragDrop);

            textBox3.DragEnter += new DragEventHandler(textBox10_DragEnter);
            textBox3.MouseDown += new MouseEventHandler(textBox10_MouseDown);
            textBox3.DragDrop += new DragEventHandler(textBox10_DragDrop);

            textBox4.DragEnter += new DragEventHandler(textBox10_DragEnter);
            textBox4.MouseDown += new MouseEventHandler(textBox10_MouseDown);
            textBox4.DragDrop += new DragEventHandler(textBox10_DragDrop);

            textBox5.DragEnter += new DragEventHandler(textBox10_DragEnter);
            textBox5.MouseDown += new MouseEventHandler(textBox10_MouseDown);
            textBox5.DragDrop += new DragEventHandler(textBox10_DragDrop);

            textBox6.DragEnter += new DragEventHandler(textBox10_DragEnter);
            textBox6.MouseDown += new MouseEventHandler(textBox10_MouseDown);
            textBox6.DragDrop += new DragEventHandler(textBox10_DragDrop);

            textBox7.DragEnter += new DragEventHandler(textBox10_DragEnter);
            textBox7.MouseDown += new MouseEventHandler(textBox10_MouseDown);
            textBox7.DragDrop += new DragEventHandler(textBox10_DragDrop);

            textBox8.DragEnter += new DragEventHandler(textBox10_DragEnter);
            textBox8.MouseDown += new MouseEventHandler(textBox10_MouseDown);
            textBox8.DragDrop += new DragEventHandler(textBox10_DragDrop);

            /////////////////////////////////////////////////////////////////

            textBox1.DragEnter += new DragEventHandler(textBox11_DragEnter);
            textBox1.MouseDown += new MouseEventHandler(textBox11_MouseDown);
            textBox1.DragDrop += new DragEventHandler(textBox11_DragDrop);

            textBox2.DragEnter += new DragEventHandler(textBox11_DragEnter);
            textBox2.MouseDown += new MouseEventHandler(textBox11_MouseDown);
            textBox2.DragDrop += new DragEventHandler(textBox11_DragDrop);

            textBox3.DragEnter += new DragEventHandler(textBox11_DragEnter);
            textBox3.MouseDown += new MouseEventHandler(textBox11_MouseDown);
            textBox3.DragDrop += new DragEventHandler(textBox11_DragDrop);

            textBox4.DragEnter += new DragEventHandler(textBox11_DragEnter);
            textBox4.MouseDown += new MouseEventHandler(textBox11_MouseDown);
            textBox4.DragDrop += new DragEventHandler(textBox11_DragDrop);

            textBox5.DragEnter += new DragEventHandler(textBox11_DragEnter);
            textBox5.MouseDown += new MouseEventHandler(textBox11_MouseDown);
            textBox5.DragDrop += new DragEventHandler(textBox11_DragDrop);

            textBox6.DragEnter += new DragEventHandler(textBox11_DragEnter);
            textBox6.MouseDown += new MouseEventHandler(textBox11_MouseDown);
            textBox6.DragDrop += new DragEventHandler(textBox11_DragDrop);

            textBox7.DragEnter += new DragEventHandler(textBox11_DragEnter);
            textBox7.MouseDown += new MouseEventHandler(textBox11_MouseDown);
            textBox7.DragDrop += new DragEventHandler(textBox11_DragDrop);

            textBox8.DragEnter += new DragEventHandler(textBox11_DragEnter);
            textBox8.MouseDown += new MouseEventHandler(textBox11_MouseDown);
            textBox8.DragDrop += new DragEventHandler(textBox11_DragDrop);

            ///////////////////////////////////////////////////////////////////////

            textBox1.DragEnter += new DragEventHandler(textBox12_DragEnter);
            textBox1.MouseDown += new MouseEventHandler(textBox12_MouseDown);
            textBox1.DragDrop += new DragEventHandler(textBox12_DragDrop);

            textBox2.DragEnter += new DragEventHandler(textBox12_DragEnter);
            textBox2.MouseDown += new MouseEventHandler(textBox12_MouseDown);
            textBox2.DragDrop += new DragEventHandler(textBox12_DragDrop);

            textBox3.DragEnter += new DragEventHandler(textBox12_DragEnter);
            textBox3.MouseDown += new MouseEventHandler(textBox12_MouseDown);
            textBox3.DragDrop += new DragEventHandler(textBox12_DragDrop);

            textBox4.DragEnter += new DragEventHandler(textBox12_DragEnter);
            textBox4.MouseDown += new MouseEventHandler(textBox12_MouseDown);
            textBox4.DragDrop += new DragEventHandler(textBox12_DragDrop);

            textBox5.DragEnter += new DragEventHandler(textBox12_DragEnter);
            textBox5.MouseDown += new MouseEventHandler(textBox12_MouseDown);
            textBox5.DragDrop += new DragEventHandler(textBox12_DragDrop);

            textBox6.DragEnter += new DragEventHandler(textBox12_DragEnter);
            textBox6.MouseDown += new MouseEventHandler(textBox12_MouseDown);
            textBox6.DragDrop += new DragEventHandler(textBox12_DragDrop);

            textBox7.DragEnter += new DragEventHandler(textBox12_DragEnter);
            textBox7.MouseDown += new MouseEventHandler(textBox12_MouseDown);
            textBox7.DragDrop += new DragEventHandler(textBox12_DragDrop);

            textBox8.DragEnter += new DragEventHandler(textBox12_DragEnter);
            textBox8.MouseDown += new MouseEventHandler(textBox12_MouseDown);
            textBox8.DragDrop += new DragEventHandler(textBox12_DragDrop);

            ///////////////////////////////////////////////////////////////////////

            textBox1.DragEnter += new DragEventHandler(textBox13_DragEnter);
            textBox1.MouseDown += new MouseEventHandler(textBox13_MouseDown);
            textBox1.DragDrop += new DragEventHandler(textBox13_DragDrop);

            textBox2.DragEnter += new DragEventHandler(textBox13_DragEnter);
            textBox2.MouseDown += new MouseEventHandler(textBox13_MouseDown);
            textBox2.DragDrop += new DragEventHandler(textBox13_DragDrop);

            textBox3.DragEnter += new DragEventHandler(textBox13_DragEnter);
            textBox3.MouseDown += new MouseEventHandler(textBox13_MouseDown);
            textBox3.DragDrop += new DragEventHandler(textBox13_DragDrop);

            textBox4.DragEnter += new DragEventHandler(textBox13_DragEnter);
            textBox4.MouseDown += new MouseEventHandler(textBox13_MouseDown);
            textBox4.DragDrop += new DragEventHandler(textBox13_DragDrop);

            textBox5.DragEnter += new DragEventHandler(textBox13_DragEnter);
            textBox5.MouseDown += new MouseEventHandler(textBox13_MouseDown);
            textBox5.DragDrop += new DragEventHandler(textBox13_DragDrop);

            textBox6.DragEnter += new DragEventHandler(textBox13_DragEnter);
            textBox6.MouseDown += new MouseEventHandler(textBox13_MouseDown);
            textBox6.DragDrop += new DragEventHandler(textBox13_DragDrop);

            textBox7.DragEnter += new DragEventHandler(textBox13_DragEnter);
            textBox7.MouseDown += new MouseEventHandler(textBox13_MouseDown);
            textBox7.DragDrop += new DragEventHandler(textBox13_DragDrop);

            textBox8.DragEnter += new DragEventHandler(textBox13_DragEnter);
            textBox8.MouseDown += new MouseEventHandler(textBox13_MouseDown);
            textBox8.DragDrop += new DragEventHandler(textBox13_DragDrop);

            ///////////////////////////////////////////////////////////////////////

            textBox1.DragEnter += new DragEventHandler(textBox14_DragEnter);
            textBox1.MouseDown += new MouseEventHandler(textBox14_MouseDown);
            textBox1.DragDrop += new DragEventHandler(textBox14_DragDrop);

            textBox2.DragEnter += new DragEventHandler(textBox14_DragEnter);
            textBox2.MouseDown += new MouseEventHandler(textBox14_MouseDown);
            textBox2.DragDrop += new DragEventHandler(textBox14_DragDrop);

            textBox3.DragEnter += new DragEventHandler(textBox14_DragEnter);
            textBox3.MouseDown += new MouseEventHandler(textBox14_MouseDown);
            textBox3.DragDrop += new DragEventHandler(textBox14_DragDrop);

            textBox4.DragEnter += new DragEventHandler(textBox14_DragEnter);
            textBox4.MouseDown += new MouseEventHandler(textBox14_MouseDown);
            textBox4.DragDrop += new DragEventHandler(textBox14_DragDrop);

            textBox5.DragEnter += new DragEventHandler(textBox14_DragEnter);
            textBox5.MouseDown += new MouseEventHandler(textBox14_MouseDown);
            textBox5.DragDrop += new DragEventHandler(textBox14_DragDrop);

            textBox6.DragEnter += new DragEventHandler(textBox14_DragEnter);
            textBox6.MouseDown += new MouseEventHandler(textBox14_MouseDown);
            textBox6.DragDrop += new DragEventHandler(textBox14_DragDrop);

            textBox7.DragEnter += new DragEventHandler(textBox14_DragEnter);
            textBox7.MouseDown += new MouseEventHandler(textBox14_MouseDown);
            textBox7.DragDrop += new DragEventHandler(textBox14_DragDrop);

            textBox8.DragEnter += new DragEventHandler(textBox14_DragEnter);
            textBox8.MouseDown += new MouseEventHandler(textBox14_MouseDown);
            textBox8.DragDrop += new DragEventHandler(textBox14_DragDrop);

            ///////////////////////////////////////////////////////////////////////

            textBox1.DragEnter += new DragEventHandler(textBox15_DragEnter);
            textBox1.MouseDown += new MouseEventHandler(textBox15_MouseDown);
            textBox1.DragDrop += new DragEventHandler(textBox15_DragDrop);

            textBox2.DragEnter += new DragEventHandler(textBox15_DragEnter);
            textBox2.MouseDown += new MouseEventHandler(textBox15_MouseDown);
            textBox2.DragDrop += new DragEventHandler(textBox15_DragDrop);

            textBox3.DragEnter += new DragEventHandler(textBox15_DragEnter);
            textBox3.MouseDown += new MouseEventHandler(textBox15_MouseDown);
            textBox3.DragDrop += new DragEventHandler(textBox15_DragDrop);

            textBox4.DragEnter += new DragEventHandler(textBox15_DragEnter);
            textBox4.MouseDown += new MouseEventHandler(textBox15_MouseDown);
            textBox4.DragDrop += new DragEventHandler(textBox15_DragDrop);

            textBox5.DragEnter += new DragEventHandler(textBox15_DragEnter);
            textBox5.MouseDown += new MouseEventHandler(textBox15_MouseDown);
            textBox5.DragDrop += new DragEventHandler(textBox15_DragDrop);

            textBox6.DragEnter += new DragEventHandler(textBox15_DragEnter);
            textBox6.MouseDown += new MouseEventHandler(textBox15_MouseDown);
            textBox6.DragDrop += new DragEventHandler(textBox15_DragDrop);

            textBox7.DragEnter += new DragEventHandler(textBox15_DragEnter);
            textBox7.MouseDown += new MouseEventHandler(textBox15_MouseDown);
            textBox7.DragDrop += new DragEventHandler(textBox15_DragDrop);

            textBox8.DragEnter += new DragEventHandler(textBox15_DragEnter);
            textBox8.MouseDown += new MouseEventHandler(textBox15_MouseDown);
            textBox8.DragDrop += new DragEventHandler(textBox15_DragDrop);

            ///////////////////////////////////////////////////////////////////////

            textBox1.DragEnter += new DragEventHandler(textBox16_DragEnter);
            textBox1.MouseDown += new MouseEventHandler(textBox16_MouseDown);
            textBox1.DragDrop += new DragEventHandler(textBox16_DragDrop);

            textBox2.DragEnter += new DragEventHandler(textBox16_DragEnter);
            textBox2.MouseDown += new MouseEventHandler(textBox16_MouseDown);
            textBox2.DragDrop += new DragEventHandler(textBox16_DragDrop);

            textBox3.DragEnter += new DragEventHandler(textBox16_DragEnter);
            textBox3.MouseDown += new MouseEventHandler(textBox16_MouseDown);
            textBox3.DragDrop += new DragEventHandler(textBox16_DragDrop);

            textBox4.DragEnter += new DragEventHandler(textBox16_DragEnter);
            textBox4.MouseDown += new MouseEventHandler(textBox16_MouseDown);
            textBox4.DragDrop += new DragEventHandler(textBox16_DragDrop);

            textBox5.DragEnter += new DragEventHandler(textBox16_DragEnter);
            textBox5.MouseDown += new MouseEventHandler(textBox16_MouseDown);
            textBox5.DragDrop += new DragEventHandler(textBox16_DragDrop);

            textBox6.DragEnter += new DragEventHandler(textBox16_DragEnter);
            textBox6.MouseDown += new MouseEventHandler(textBox16_MouseDown);
            textBox6.DragDrop += new DragEventHandler(textBox16_DragDrop);

            textBox7.DragEnter += new DragEventHandler(textBox16_DragEnter);
            textBox7.MouseDown += new MouseEventHandler(textBox16_MouseDown);
            textBox7.DragDrop += new DragEventHandler(textBox16_DragDrop);

            textBox8.DragEnter += new DragEventHandler(textBox16_DragEnter);
            textBox8.MouseDown += new MouseEventHandler(textBox16_MouseDown);
            textBox8.DragDrop += new DragEventHandler(textBox16_DragDrop);

            ///////////////////////////////////////////////////////////////////////


            con.Open();
        }

        // fra linje 342 - 906  skaper vi drag and drop hendelser/ eventer. Dette må til fordi disse tektboksene skal skrive til databasen når de får en verdi.
     
        private void textBox9_DragDrop(object sender, DragEventArgs e)
        {
           
            TextBox tb = (TextBox)sender;
            tb.Text = (string)e.Data.GetData(DataFormats.Text);


            if (tb.Text != null)
            {
                
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE kamp SET lag1 = " + tb.Text + " WHERE turnering_id = '" +textBox24.Text + "'  AND bracketstep = 1";
                cmd.ExecuteNonQuery();
              
               
         
            }
            else
            {

            }
        }

        private void textBox9_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void textBox9_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.SelectAll();
            tb.DoDragDrop(tb.Text, DragDropEffects.Copy);
        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBox10_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.SelectAll();
            tb.DoDragDrop(tb.Text, DragDropEffects.Copy);
        }

        private void textBox10_DragDrop(object sender, DragEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = (string)e.Data.GetData(DataFormats.Text);

            if (tb.Text != null)
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE kamp SET lag2 = " + tb.Text + " WHERE turnering_id = '" + textBox24.Text + "' AND bracketstep = 1";
                cmd.ExecuteNonQuery();
            }
            else
            {

            }
        }

        private void textBox10_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.All;

            }
            else
            {
                e.Effect = DragDropEffects.None;

            }
        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBox11_DragDrop(object sender, DragEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = (string)e.Data.GetData(DataFormats.Text);

            if (tb.Text != null)
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE kamp SET lag1 = " + tb.Text + " WHERE turnering_id = '" + textBox24.Text + "'  AND bracketstep = 2";
                cmd.ExecuteNonQuery();
            }
            else
            {

            }
        }

        private void textBox11_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void textBox11_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.SelectAll();
            tb.DoDragDrop(tb.Text, DragDropEffects.Copy);
        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBox12_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.SelectAll();
            tb.DoDragDrop(tb.Text, DragDropEffects.Copy);
        }

        private void textBox12_DragDrop(object sender, DragEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = (string)e.Data.GetData(DataFormats.Text);

            if (tb.Text != null)
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE kamp SET lag2 = " + tb.Text + " WHERE turnering_id =  '" + textBox24.Text + "'  AND bracketstep = 2";
                cmd.ExecuteNonQuery();
            }
            else
            {

            }
        }

        private void textBox12_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBox13_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.SelectAll();
            tb.DoDragDrop(tb.Text, DragDropEffects.Copy);
        }

        private void textBox13_DragDrop(object sender, DragEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = (string)e.Data.GetData(DataFormats.Text);

            if (tb.Text != null)
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE kamp SET lag1 = " + tb.Text + " WHERE turnering_id =  '" + textBox24.Text + "'  AND bracketstep = 3";
                cmd.ExecuteNonQuery();
            }
            else
            {

            }
        }

        private void textBox13_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBox14_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.SelectAll();
            tb.DoDragDrop(tb.Text, DragDropEffects.Copy);
        }

        private void textBox14_DragDrop(object sender, DragEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = (string)e.Data.GetData(DataFormats.Text);

            if (tb.Text != null)
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE kamp SET lag2 = " + tb.Text + " WHERE turnering_id = '" + textBox24.Text + "'  AND bracketstep = 3";
                cmd.ExecuteNonQuery();
            }
            else
            {

            }
        }

        private void textBox14_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBox15_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.SelectAll();
            tb.DoDragDrop(tb.Text, DragDropEffects.Copy);
        }

        private void textBox15_DragDrop(object sender, DragEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = (string)e.Data.GetData(DataFormats.Text);

            if (tb.Text != null)
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE kamp SET lag1 = " + tb.Text + " WHERE turnering_id =  '" + textBox24.Text + "'  AND bracketstep = 4";
                cmd.ExecuteNonQuery();
            }
            else
            {

            }
        }

        private void textBox15_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBox16_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.SelectAll();
            tb.DoDragDrop(tb.Text, DragDropEffects.Copy);
        }

        private void textBox16_DragDrop(object sender, DragEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = (string)e.Data.GetData(DataFormats.Text);

            if (tb.Text != null)
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE kamp SET lag2 = " + tb.Text + " WHERE turnering_id =  '" + textBox24.Text + "' AND bracketstep = 4";
                cmd.ExecuteNonQuery();
            }
            else
            {

            }
        }

        private void textBox16_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBox17_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.SelectAll();
            tb.DoDragDrop(tb.Text, DragDropEffects.Copy);
        }

        private void textBox17_DragDrop(object sender, DragEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = (string)e.Data.GetData(DataFormats.Text);

            if (tb.Text != null)
            {
               
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE kamp SET lag2 = " + tb.Text + " WHERE turnering_id = '" + textBox24.Text + "' AND bracketstep = 6";
                cmd.ExecuteNonQuery();
             

            }
            else
            {

            }
        }

        private void textBox17_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBox18_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.SelectAll();
            tb.DoDragDrop(tb.Text, DragDropEffects.Copy);
        }

        private void textBox18_DragDrop(object sender, DragEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = (string)e.Data.GetData(DataFormats.Text);

            if (tb.Text != null)
            {
               
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
               cmd.CommandText = "UPDATE kamp SET lag1 = " + tb.Text + " WHERE turnering_id =  '" + textBox24.Text + "'  AND bracketstep = 6";
                cmd.ExecuteNonQuery();
                
            }
            else
            {

            }

        }

        private void textBox18_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.All;

            }
            else
            {
                e.Effect = DragDropEffects.None;

            }
        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBox19_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.SelectAll();
            tb.DoDragDrop(tb.Text, DragDropEffects.Copy);
        }

        private void textBox19_DragDrop(object sender, DragEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = (string)e.Data.GetData(DataFormats.Text);

            if (tb.Text != null)
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
             cmd.CommandText = "UPDATE kamp SET lag2 = " + tb.Text + " WHERE turnering_id = '" + textBox24.Text + "'  AND bracketstep = 5";
                cmd.ExecuteNonQuery();
            }
            else
            {

            }
        }

        private void textBox19_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBox20_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.SelectAll();
            tb.DoDragDrop(tb.Text, DragDropEffects.Copy);
        }

        private void textBox20_DragDrop(object sender, DragEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = (string)e.Data.GetData(DataFormats.Text);

            if (tb.Text != null)
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE kamp SET lag1 = " + tb.Text + " WHERE turnering_id =  '" + textBox24.Text + "'  AND bracketstep = 5";
                cmd.ExecuteNonQuery();
            }
            else
            {

            }
        }

        private void textBox20_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }


        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBox21_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.SelectAll();
            tb.DoDragDrop(tb.Text, DragDropEffects.Copy);
        }

        private void textBox21_DragDrop(object sender, DragEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = (string)e.Data.GetData(DataFormats.Text);

            if (tb.Text != null)
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE kamp SET lag1 = " + tb.Text + " WHERE turnering_id =  '" + textBox24.Text + "'  AND bracketstep = 7";
                cmd.ExecuteNonQuery();
            }
            else
            {

            }
        }

        private void textBox21_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBox22_MouseDown(object sender, MouseEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.SelectAll();
            tb.DoDragDrop(tb.Text, DragDropEffects.Copy);
        }

        private void textBox22_DragDrop(object sender, DragEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = (string)e.Data.GetData(DataFormats.Text);

            if (tb.Text != null)
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE kamp SET lag2 = " + tb.Text + " WHERE turnering_id = '" + textBox24.Text + "'  AND bracketstep = 7";
                cmd.ExecuteNonQuery();

            }
            else
            {

            }
        }

        private void textBox22_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // her ber vi programmet ta verdien som er valgt i listeboksen og legge den i textbox24
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox24.Text = listBox1.SelectedValue.ToString();
          
        }

        // 
        private void button1_Click(object sender, EventArgs e)
        {

           
            //SQL som henter ut for å fylle lag i startpunkt
            MySqlDataAdapter adp = new MySqlDataAdapter("SELECT lag_id, lag_navn FROM lag WHERE turnering_id = '" + textBox24.Text + "';", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            //SQL som henter lag for å fylle videre i bracketen utover i turneringen
            MySqlDataAdapter adp1 = new MySqlDataAdapter("SELECT lag1, lag2 FROM kamp WHERE turnering_id = '" + textBox24.Text + "' ORDER BY bracketstep;", con);
            DataTable dt1 = new DataTable();
            adp1.Fill(dt1);

            //fyller textboxene med riktig lag
            if (dt.Rows.Count > 0 && dt1.Rows.Count > 0)
            {
                textBox1.Text = dt.Rows[0]["lag_id"].ToString();
               // Det blir ikke sjekket, en etter en, om det er rader i dt1, ettersom en trigger i databasen legger i tomme matcher på forhånd.
                textBox9.Text = dt1.Rows[0]["lag1"].ToString();
                textBox10.Text = dt1.Rows[0]["lag2"].ToString();
                textBox11.Text = dt1.Rows[1]["lag1"].ToString();
                textBox12.Text = dt1.Rows[1]["lag2"].ToString();
                textBox13.Text = dt1.Rows[2]["lag1"].ToString();
                textBox14.Text = dt1.Rows[2]["lag2"].ToString();
                textBox15.Text = dt1.Rows[3]["lag1"].ToString();
                textBox16.Text = dt1.Rows[3]["lag2"].ToString();
                textBox17.Text = dt1.Rows[5]["lag2"].ToString();
                textBox18.Text = dt1.Rows[5]["lag1"].ToString();
                textBox19.Text = dt1.Rows[4]["lag2"].ToString();
                textBox20.Text = dt1.Rows[4]["lag1"].ToString();
                textBox21.Text = dt1.Rows[6]["lag1"].ToString();
                textBox22.Text = dt1.Rows[6]["lag2"].ToString();

                //legger lagene i rekkefølge i startpunktet
                if (dt.Rows.Count > 1)
                {

                    textBox2.Text = dt.Rows[1]["lag_id"].ToString();


                    if (dt.Rows.Count > 2)
                    {

                        textBox3.Text = dt.Rows[2]["lag_id"].ToString();

                        if (dt.Rows.Count > 3)
                        {

                            textBox4.Text = dt.Rows[3]["lag_id"].ToString();

                            if (dt.Rows.Count > 4)
                            {

                                textBox5.Text = dt.Rows[4]["lag_id"].ToString();

                                if (dt.Rows.Count > 5)
                                {

                                    textBox6.Text = dt.Rows[5]["lag_id"].ToString();

                                    if (dt.Rows.Count > 6)
                                    {

                                        textBox7.Text = dt.Rows[6]["lag_id"].ToString();

                                        if (dt.Rows.Count > 7)
                                        {

                                            textBox8.Text = dt.Rows[7]["lag_id"].ToString();


                                        }

                                    }
                                  
                                }
                                
                            }
                           
                        }
                        
                    }
                  
                }
                
            }
           
        }
        
    }
    }

