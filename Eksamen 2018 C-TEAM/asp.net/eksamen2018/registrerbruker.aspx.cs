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
    public partial class _registrerbruker : Page
    {
 
        protected void Page_Load(object sender, EventArgs e)
        {

          
        }

        public void Registrerbruker_Click(object sender, EventArgs e)
        {
            database database = new database();
            if (database.antallRader("SELECT * from bruker WHERE brukernavn = '" + brukernavn.Text +"';") !=0)
            {
                // Det går ikke ann å registrere en bruker med brukernavn som eksisterer fra før, dermed printes denne feilmeldingen ut
                registrerbrukertext.InnerHtml = "<div class='alert alert-danger'><strong> Bruker</strong> " + brukernavn.Text + " finnes fra før.</div>";
            }

            else {

                // Security.HashSHA1(passord.Text) for å hashe passord inn til databasen
                database.Kjorsporring("INSERT INTO bruker (brukernavn, passord) VALUES ('" + brukernavn.Text + "', '" + Security.HashSHA1(passord.Text) + "');");
                registrerbrukertext.InnerHtml = "<div class='alert alert-success'><strong> Brukeren er registrert!</strong> " + brukernavn.Text + " ble registrert.</div>";

                //Brukeren blir sendt til logg inn etter registrering med brukernavnet slik at brukernavnet blir fylt inn
                Response.Redirect("logginn.aspx?sjekk=4&brukernavn=" + brukernavn.Text + "");
            }
        }

        public class Security
        {
            // metode som hasjer string value 
            public static string HashSHA1(string value)
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

        protected void brukernavn_TextChanged(object sender, EventArgs e)
        {

        }
    }

    }
