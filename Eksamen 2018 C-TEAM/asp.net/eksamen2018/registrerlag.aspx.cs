using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace eksamen2018
{
    public partial class registrerlag : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            //Sjekker om brukeren er logget inn
            if (Session["brukernavn"] == null)
            {
                Response.Redirect("logginn.aspx?sjekk=2");
            }
        } 

        public void Registrerlag_Click(object sender, EventArgs e)
        {
            database database = new database();
            String t_id = Request.QueryString["t_id"];
            String b_navn = Session["brukernavn"].ToString();

            //Hvis brukeren er logget inn, så registreres laget
            if (Session["brukernavn"] != null)
            {
                // første sql settningen sjekker om lagnavnet finnes i turneringen fra før av.
                //Andre sql settningen skjekker om brukeren har registrerte et lag i turneringen fra før av. Har brukere allerede registrete et lag skal den ikke få registrerte et lag til i samme turnering.
                if (database.antallRader("SELECT * FROM lag WHERE turnering_id = '"+ t_id +"' AND lag_navn = '" + lagnavn.Text + "';") == 0 && database.antallRader("SELECT * FROM lag INNER JOIN bruker ON bruker.bruker_id = lag.bruker_id INNER JOIN turnering ON turnering.turnering_id = lag.turnering_id WHERE turnering.turnering_id = '" + t_id + "' AND bruker.brukernavn = '" + b_navn + "';") == 0)
                {
                    if (database.antallRader("SELECT * FROM lag WHERE turnering_id = '" + t_id + "';") < 8)
                    {                        
                        String b_id = database.returnid("SELECT bruker_id FROM bruker WHERE brukernavn = '" + b_navn + "';");
                        database.Kjorsporring("INSERT INTO lag (lag_navn, turnering_id, bruker_id) VALUES ('" + lagnavn.Text + "', " + t_id + ", " + b_id + ");");

                        registrerlagtext.InnerHtml = "<div class='alert alert-success'><strong> Laget er registrert!</strong> Laget, " + lagnavn.Text + ", ble registrert.</div>";
                        Response.AddHeader("REFRESH", "3;URL=minelag.aspx");
                    }
                    else
                    {
                        registrerlagtext.InnerHtml = "<div class='alert alert-danger'><strong> FEIL!</strong> Det er registrert maks antall lag i turneringen.</div>";
                    }
                }
                else
                {
                    registrerlagtext.InnerHtml = "<div class='alert alert-danger'><strong> FEIL!</strong> Lagnavnet finnes fra før eller du har allerede registrert et lag til denne turneringen.</div>";
                }
            }
            //Hvis ikke brukeren er logget inn, så blir brukeren sendt til logginn siden med en  feilmelding først.
            else
            {
                registrerlagtext.InnerHtml = "<div class='alert alert-danger'><strong> Logg inn!!</strong> Du må være innlogget for å registrere lag.</div>";

                Response.AddHeader("REFRESH", "2;URL=logginn.aspx");
            }      
        }
    }
}
