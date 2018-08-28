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
    public partial class registrerdeltager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Sjekker om brukeren er logget inn
            if (Session["brukernavn"] == null)
            {
                Response.Redirect("logginn.aspx?sjekk=3");
            }
            else
            {
               
            }

            if (!IsPostBack)
            {
                hentenasjon();
                hentelag();
            }
        }

        // medtode for å hente nasjon
        private void hentenasjon()
        {
            String kobling = "Host=cteam.mysql.domeneshop.no;Database=cteam;User=cteam;Password=AkVQirXSTZAg7bG";
            using (MySqlConnection cn = new MySqlConnection(kobling))
            {
                MySqlDataAdapter adp = new MySqlDataAdapter("SELECT land, nasjon_id from nasjon", cn);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DropDownList1.DataSource = dt;
                    DropDownList1.DataTextField = "land";
                    DropDownList1.DataValueField = "nasjon_id";
                    DropDownList1.DataBind();

                }


            }

        }

        // metoden henter ut lag som er registrert til brukeren. Brukeren får kun lov til å registrere deltagere til egne lag
        private void hentelag()
        {
            String b_navn = Session["brukernavn"].ToString();
            String kobling = "Host=cteam.mysql.domeneshop.no;Database=cteam;User=cteam;Password=AkVQirXSTZAg7bG";
            using (MySqlConnection cn = new MySqlConnection(kobling))
            {
                MySqlDataAdapter adp = new MySqlDataAdapter("SELECT t.turnering_navn AS t_navn, lag_id, l.lag_navn as l_navn FROM turnering t INNER JOIN lag l ON l.turnering_id = t.turnering_id INNER JOIN bruker ON bruker.bruker_id = l.bruker_id WHERE bruker.brukernavn = '" + b_navn + "';", cn);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //Her vil listeboksen vise lag navnet, men bruker lag id som verdi
                    DropDownList2.DataSource = dt;
                    DropDownList2.DataTextField = "l_navn";
                    DropDownList2.DataValueField = "lag_id";
                    DropDownList2.DataBind();
                }
            }
        }

        protected void registrerspiller_Click(object sender, EventArgs e)
        {
            String b_navn = Session["brukernavn"].ToString();
            String lag_id = Request.QueryString["lag_id"].ToString();
            database database = new database();

            //sjekker om brukeren har noen lag, hvis ikke kan det ikke registreres spillere
            if (database.antallRader("SELECT * FROM lag INNER JOIN bruker on bruker.bruker_id = lag.bruker_id WHERE bruker.brukernavn ='" + b_navn + "';") > 0)
            {
                // setter et maks antall lag på 5
                if (database.antallRader("SELECT * FROM deltager WHERE lag_id = '" + DropDownList2.SelectedValue + "';") < 5)
                {
                    //sjekker om spilleren finnes fra før, ved å kontrollere om spørringen returnererer 0 rader
                    if (database.antallRader("SELECT * FROM deltager WHERE lag_id = '" + DropDownList2.SelectedValue + "' AND nickname = '" + nickname.Text + "';") == 0)
                    {
                        database.Kjorsporring("INSERT INTO deltager (nickname, fornavn, etternavn, nasjon_id, status_id, lag_id) VALUES ('" + nickname.Text + "', '" + fornavn.Text + "', '" + etternavn.Text + "', '" + DropDownList1.SelectedValue + "', 1 , '" + DropDownList2.SelectedValue + "');");

                        registrerlagtext.InnerHtml = "<div class='alert alert-success'> Spiller, " + nickname.Text + ", ble registrert   ."+
                            "<a href='visdeltager.aspx?lag_id=" + lag_id + @"' class='btn btn-sm btn-primary' title='visspillere'>Tilbake til spillere</a></div>";
                    }
                    else
                    {
                        registrerlagtext.InnerHtml = "<div class='alert alert-danger'><strong> FEIL!</strong> nicknamet  finnes fra før.</div>";
                    }
                }                
                else
                {
                    registrerlagtext.InnerHtml = "<div class='alert alert-danger'><strong> FEIL!</strong> 5 deltagere er allrede registrert.</div>";
                }
            }
            else
            {
                registrerlagtext.InnerHtml = "<div class='alert alert-danger'><strong> FEIL!</strong> Du har ikke registrert noe lag.</div>";
            }
        }
    }
}