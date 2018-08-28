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
    public partial class _turnering : Page
    {
        //Instansierer et dataset og en dataadapter til bruk videre i koden
        DataSet ds;
        MySqlDataAdapter da;

        protected void Page_Load(object sender, EventArgs e)
        {
            // kobler til DB
            String cs = "Host=cteam.mysql.domeneshop.no;Database=cteam;User=cteam;Password=AkVQirXSTZAg7bG";
            MySqlConnection dbconn = new MySqlConnection(cs);
            dbconn.Open();

            //Sjekker om turnering har fått med event id
            string e_id = Request.QueryString["e_id"];
            if (e_id == null)
            {

                //Hvis event id ikke er med, så blir brukeren sendt tilbake til event
                Response.Redirect("event.aspx");
            }
            else
            {
                tilevent.InnerHtml = "<a href='event.aspx' class='btn btn-sm btn-primary' title='tilevent'>Til event</a>";
                //Hvis event id er med, så henter den info rundt turneringen som hører til det eventet
                // henter ut fra databasen
                String sql = "select event.event_id, event.event_navn AS e_navn, turnering.event_id, turnering_id AS id, turnering_navn AS t_navn, status AS status, spill_navn AS spill" +
                    " from turnering INNER JOIN spill ON turnering.spill_id = spill.spill_id INNER JOIN event ON event.event_id = turnering.event_id  WHERE turnering.event_id =" + e_id + ";";

                MySqlCommand cmd = new MySqlCommand(sql, dbconn);
                da = new MySqlDataAdapter(cmd);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                ds = new DataSet("TEST");
                da.Fill(ds, "turnering");

                String divcontent = "";

                foreach (DataRow radturnering in ds.Tables["turnering"].Rows)
                {

                    divcontent += addturnering(radturnering);
                }
                //Skriver all HTML kode, som i addturnering, til turnering.aspx som viser det på nettsiden
                turneringoppsett.InnerHtml = divcontent;
            }
        }
        //addturnering skriver ut alle turneringene til valgt event ved hjelp av foreach
        public string addturnering (DataRow turneringinfo)
        {
                String t_id = Convert.ToString(turneringinfo["id"]);
                String e_navn = Convert.ToString(turneringinfo["e_navn"]);
                String t_navn = Convert.ToString(turneringinfo["t_navn"]);
                String status = Convert.ToString(turneringinfo["status"]);
                String spill = Convert.ToString(turneringinfo["spill"]);

                String divdesign = @"<div class='col-md-4 col-xs-12 col-sm-6 search-result'>
		        <div class='well well-lg'>
                  <h3>" + t_navn + @"</h3>
                  <p>
		          <ul class='meta-search'>
					        <li><i class='fas fa-globe'></i> <span>" + e_navn + @"</span></li>
					        <li><i class='fas fa-gamepad'></i> <span>" + spill + @"</span></li>
				        </ul>
		          </p>
                  <a href='registrerlag.aspx?t_id=" + t_id + @"' class='btn btn-primary' title='registrerlag'>Registrer lag</a>
                  <a href='bracket.aspx?t_id=" + t_id + @"' class='btn btn-primary' title='bracket'>Bracket</a>
		          </div>
                </div>";

                return divdesign;
        }
    }
}