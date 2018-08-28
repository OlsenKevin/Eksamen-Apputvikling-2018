using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace eksamen2018
{
    public partial class administrerlag : System.Web.UI.Page
    {
        String lag_id;

        database database = new database();


        protected void Page_Load(object sender, EventArgs e)
        {
            //Sjekker om brukeren er logget inn
            if (Session["brukernavn"] == null)
            {   
                //Blir her sendt til logginn hvis ikke brukeren er logget inn
                Response.Redirect("logginn.aspx?sjekk=3");
            }
            else
            {
                lag_id = Request.QueryString["lag_id"];
            }

            if (!IsPostBack)
            {
                hentelag();
            }
        }


        //metode for å hente informasjon til autofyll av alle brukerens lag
        private void hentelag()
        {
            String koblingautofyll = "Host=cteam.mysql.domeneshop.no;Database=cteam;User=cteam;Password=AkVQirXSTZAg7bG";
            using (MySqlConnection cn = new MySqlConnection(koblingautofyll))
            {
                MySqlDataAdapter adp = new MySqlDataAdapter("SELECT lag_navn FROM lag WHERE lag_id = "+ lag_id +"", cn);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lagnavn.Text = dt.Rows[0]["lag_navn"].ToString();
                }
            }
        }

        //Denne metoden brukes til å kunne gjøre endringer på laget, så langt kun endre lag navn
        protected void endrelag_Click(object sender, EventArgs e)
        {
            //Hvis brukeren er logget inn, så kan man endre brukeren
            if (Session["brukernavn"] != null)
            {

                // med oldnavn og if betingelsen sjekker vi om lag navnet finnes fra før

                String oldnavn = database.returnid("SELECT lag_navn FROM lag WHERE lag_id = '" + lag_id + "';");

                if (database.antallRader("SELECT * FROM deltager WHERE nickname = '" + lagnavn.Text + "' ;") == 0 || lagnavn.Text == oldnavn)
                {
                    database.Kjorsporring("UPDATE lag SET lag_navn = '" + lagnavn.Text + "' WHERE lag_id = '" + lag_id + "';");

                    endrelagtext.InnerHtml = "<div class='alert alert-success'><strong></strong> Laget, " + lagnavn.Text + ", ble endret.</div>";

                    Response.AddHeader("REFRESH", "2;URL=minelag.aspx");

                }
                else
                {
                    endrelagtext.InnerHtml = "<div class='alert alert-danger'><strong> FEIL!</strong>  Lagnvanet; " + lagnavn.Text + ", er registrert fra før.</div>";
                }
            }
        }

        //Denne click hendelsen sletter laget du har valgt
        protected void slettlag_Click(object sender, EventArgs e)
        {
            DialogResult svar = MessageBox.Show("Vil du slette " + lagnavn.Text + "?", "Sikker?", MessageBoxButtons.YesNo);
            if (svar == DialogResult.Yes)
            {
                //i if betingelsen sjekker vi om laget er tomt for deltagere, stemmer det så sletter den laget
                if (database.antallRader("SELECT * FROM deltager WHERE lag_id = '" + lag_id + "' ;") == 0)
                {
                    database.Kjorsporring("DELETE FROM lag WHERE lag_id = '" + lag_id + "';");

                    endrelagtext.InnerHtml = "<div class='alert alert-success'><strong> Laget er slettet!</strong></div>";
                }
                else //eksisterer det deltagere i laget, må disse slettes først pga foreign key i databasen
                {
                    database.Kjorsporring("DELETE FROM deltager WHERE lag_id = '" + lag_id + "';");

                    if (database.antallRader("SELECT * FROM deltager WHERE lag_id = '" + lag_id + "' ;") == 0)
                    {
                        database.Kjorsporring("DELETE FROM lag WHERE lag_id = '" + lag_id + "';");

                        endrelagtext.InnerHtml = "<div class='alert alert-success'><strong> Laget er slettet!</strong></div>";
                        Response.AddHeader("REFRESH", "2;URL=minelag.aspx");
                    }

                }

            }
            
        }

    }

   
 }
