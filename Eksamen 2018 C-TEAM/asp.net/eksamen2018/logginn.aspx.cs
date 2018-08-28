using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;

namespace eksamen2018
{
    public partial class logginn : Page
    {
        // kobler til databasen
        MySqlConnection con = new MySqlConnection("Host=cteam.mysql.domeneshop.no;Database=cteam;User=cteam;Password=AkVQirXSTZAg7bG");
        protected void Page_Load(object sender, EventArgs e)
        {
            //sjekk i denne sammenhengen er en id som eventuelt er med fra registrer lag, er det en id der så vil den spytte ut feilmelding om at du ikke er logget inn
            string sjekk = Request.QueryString["sjekk"];
            if (sjekk != null)
            {
                logintext.InnerHtml = "<div class='alert alert-danger'><strong> Logg inn! !</strong> Du må være innlogget for å registrere lag.</div>";
            }
            else { }
        }

        protected void t1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void t2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            database database = new database();
            DataTable dt = database.Fylldataset("select * from bruker where brukernavn='" + t1.Text + "' and passord='" + HashSHA1(t2.Text) + "'");

            foreach (DataRow dr in dt.Rows)
            // her har vi satt opp slik at man blir redirectet til event om man logger inn med riktig brukernavn og passord
            {
                Session["brukernavn"] = dr["brukernavn"].ToString();

                string t_id = Request.QueryString["t_id"];
                if (t_id != null)
                {
                    Response.Redirect("registrerlag.aspx?t_id=" + t_id + "");
                }
                else
                {
                    Response.Redirect("event.aspx");
                }

            }


            con.Close();
            // en enkel label som sender ut en feilmelding om man skriver inn feil brukernavn eller passord
            Label1.Text = "feil brukernavn eller passord";
        }


        // metode som hasjer string value 
        public string HashSHA1(string value)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(value);
            var hash = sha1.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}

