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
    public partial class administrerspiller : System.Web.UI.Page
    {
        String d_id, t_id, b_navn;

        database database = new database();

        protected void Page_Load(object sender, EventArgs e)
        {

            //Sjekker om brukeren er logget inn
            if (Session["brukernavn"] == null)
            {   
                //Blir sendt til loggin med en gang hvis ikke logget inn
                Response.Redirect("logginn.aspx?sjekk=3");
            }
            else
            {
                d_id = Request.QueryString["d_id"];
                t_id = Request.QueryString["t_id"];
                b_navn = Session["brukernavn"].ToString();
               
            }

            if (!IsPostBack)
            {
                hentenasjon();
                hentautoinfo();
            }
        }

        //metode for å hente informasjon til fylle ut spillerne til laget på siden
        private void hentautoinfo()
        {
            String koblingautofyll = "Host=cteam.mysql.domeneshop.no;Database=cteam;User=cteam;Password=AkVQirXSTZAg7bG";
            using (MySqlConnection cn = new MySqlConnection(koblingautofyll))
            {
                MySqlDataAdapter adp = new MySqlDataAdapter("SELECT d.fornavn, d.etternavn, d.nickname, n.nasjon_id, n.land FROM deltager AS d INNER JOIN nasjon AS n ON d.nasjon_id = n.nasjon_id WHERE deltager_id = '" + d_id + "'", cn);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    fornavn.Text = dt.Rows[0]["fornavn"].ToString(); 
                    etternavn.Text = dt.Rows[0]["etternavn"].ToString();
                    nickname.Text = dt.Rows[0]["nickname"].ToString();
                }
            }
        }

        // medtode for å hente nasjon inn i liste boksen
        private void hentenasjon()
        {
            String koblingnasjon = "Host=cteam.mysql.domeneshop.no;Database=cteam;User=cteam;Password=AkVQirXSTZAg7bG";
            using (MySqlConnection cn = new MySqlConnection(koblingnasjon))
            {
                String oldnasjon_id = database.returnid("SELECT n.nasjon_id FROM deltager AS d INNER JOIN nasjon AS n ON n.nasjon_id = d.nasjon_id WHERE d.deltager_id = '" + d_id + "';");
                String oldnasjon_navn = database.returnid("SELECT n.land FROM deltager AS d INNER JOIN nasjon AS n ON n.nasjon_id = d.nasjon_id WHERE d.deltager_id = '" + d_id + "';");

                MySqlDataAdapter adp = new MySqlDataAdapter("SELECT land, nasjon_id from nasjon", cn);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    nasjonlist.DataSource = dt;
                    nasjonlist.DataTextField = "land";
                    nasjonlist.DataValueField = "nasjon_id";
                    nasjonlist.DataBind();

                    //Ønsket at listeboksen for nasjon startet på den allerede registrerte nasjonen ved endring av spiller. Har løst dette gjennom å legge den samme nasjonen inn som nytt item på toppen av listen.
                    nasjonlist.Items.Insert(0, new ListItem(oldnasjon_navn, oldnasjon_id));

                }


            }

        }

        protected void endredeltager_Click(object sender, EventArgs e)
        {

            //Hvis brukeren er logget inn, så kan man endre brukeren
            if (Session["brukernavn"] != null)
            {
                                
                // med oldnick og if betingelsen sjekker vi om spiller navnet finnes fra før

                String oldnick = database.returnid("SELECT nickname FROM deltager WHERE deltager_id = '" + d_id + "';");

                if (database.antallRader("SELECT * FROM deltager WHERE nickname = '" + nickname.Text + "' ;") == 0 || nickname.Text == oldnick)
                {
                        //henter ut lag_id for å kunne sende med verdien i Response.Redirect
                        String lag_id = database.returnid("SELECT lag_id FROM deltager WHERE deltager_id = '" + d_id + "';");

                        database.Kjorsporring("UPDATE deltager SET fornavn = '" + fornavn.Text + "', etternavn = '" + etternavn.Text + "', nickname = '" + nickname.Text + "', nasjon_id = " + nasjonlist.SelectedValue + " WHERE deltager_id = '" + d_id + "';");

                        redigerspillertext.InnerHtml = "<div class='alert alert-success'><strong></strong> Spiller, " + nickname.Text + ", ble endret.</div>";

                        //her blir brukeren sendt tilbake til spiller siden når en spiller er endret
                        Response.AddHeader("REFRESH", "2;URL=visdeltager.aspx?lag_id=" + lag_id + ";");

                }
                else
                {
                    redigerspillertext.InnerHtml = "<div class='alert alert-danger'><strong> FEIL!</strong>  Nickname, " + nickname.Text + ", er registrert fra før.</div>";
                }
            }
        }


    

        protected void slettedeltager_Click(object sender, EventArgs e)
        {
            DialogResult svar = MessageBox.Show("Vil du slette " + nickname.Text + "?", "Sikker?", MessageBoxButtons.YesNo);
            if (svar == DialogResult.Yes)
            {
                //henter ut lag_id for å kunne sende med verdien i Response.Redirect
                String lag_id = database.returnid("SELECT lag_id FROM deltager WHERE deltager_id = '" + d_id + "';");

                database.Kjorsporring("DELETE FROM deltager WHERE deltager_id = '" + d_id + "';");

                redigerspillertext.InnerHtml = "<div class='alert alert-success'><strong> Spilleren er slettet!</strong></div>";
                
                //her blir brukeren sendt tilbake til spiller siden når en spiller er slettet
                Response.AddHeader("REFRESH", "2;URL=visdeltager.aspx?lag_id="+lag_id+";");
            }
        }
    }


}
