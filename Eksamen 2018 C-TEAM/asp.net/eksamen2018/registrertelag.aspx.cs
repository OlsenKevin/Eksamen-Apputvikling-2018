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
    public partial class registrertelag : System.Web.UI.Page
    {
        //instansierer database og et dataset
        database database = new database();
        DataSet ds;

        protected void Page_Load(object sender, EventArgs e)
        {       
            //henter ut t_id gjennom URL
                string t_id = Request.QueryString["t_id"];            

                // kobler til DB
                String cs = "Host=cteam.mysql.domeneshop.no;Database=cteam;User=cteam;Password=AkVQirXSTZAg7bG";
                MySqlConnection dbconn = new MySqlConnection(cs);
                dbconn.Open();

                //henter ut event_id for å kunne sende med verdien i knappen som sender brukeren tilbake i turnering
                //String e_id = database.returnid("SELECT event_id FROM turnering WHERE turnering_id = '" + t_id + "';");
                //tilturnering.InnerHtml = "<a href='turnering.aspx?e_id=" + e_id + @"' class='btn btn-sm btn-primary' title='tilturnering'>Til turnering</a>";

                if (database.antallRader("SELECT * FROM lag") != 0)
                {
                    // henter ut info fra databasen for å fylle datasettet                 
                    String lag_turnering = ("SELECT t.turnering_navn AS t_navn, l.lag_navn as l_navn, deltager.nickname AS d_name FROM turnering t INNER JOIN lag l ON l.turnering_id = t.turnering_id LEFT JOIN deltager ON deltager.lag_id = l.lag_id INNER JOIN bruker ON bruker.bruker_id = l.bruker_id ORDER BY l.lag_id;");
                   
                    MySqlDataAdapter da;
                    MySqlCommand cmd = new MySqlCommand(lag_turnering, dbconn);
                    da = new MySqlDataAdapter(cmd);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                    ds = new DataSet("TESTE");
                    da.Fill(ds, "lag");

                    pameldtelag.InnerHtml = vislag(ds);
                }
                else
                {
                    pameldtelag.InnerHtml = "<div class='alert alert-danger'><strong> Advarsel!</strong> Det er ingen registrerte lag.</div>";
                }                         
        }
        
        //metoden skriver ut alle lag som finnes registrert organisert etter lag_id slik at de ligger sammen, dette er gjort i SQL spørringen - lag_turnering
        public string vislag(DataSet ds)
        {
            int antallLag = 0;
            String tempLagNavn = "";
            String divcontent = "";

            foreach (DataRow radevent in ds.Tables["lag"].Rows)
            {                
                String t_navn = Convert.ToString(radevent["t_navn"]);
                String s_navn = Convert.ToString(radevent["d_name"]);
                divcontent += "";
                if (tempLagNavn == "" || tempLagNavn != Convert.ToString(radevent["l_navn"]))
                {
                    if (antallLag > 0 )
                    {
                        divcontent += @"</ul></div></div>";
                    }
                    if (antallLag % 3 == 0)
                    {
                        if(antallLag == 0)
                        {
                            divcontent += "<div class='row'>";
                        }
                        else
                        {
                            divcontent += "</div><div class='row'>";
                        }
                    }                                         
                    
                    tempLagNavn = Convert.ToString(radevent["l_navn"]);
                    divcontent += @"<div class='col-sm-4'>
                                    <div class='well well-lg'>" +

                                    "<h3>" + tempLagNavn + "</h3>" +
                                    "<ul class='meta-search'>" +
                                    "<h5> Turnering: </h5>" +
                                    "<li><i class='fa fa-trophy'></i> <span>" + t_navn + "</span></li> <br/>";
                    
                    //Sjekker om det er registrerte spillere på laget                 
                    if (s_navn == "")
                    {
                        divcontent += @"<li>Ingen registrerte spillere</li>";
                    }
                    else
                    {                       
                        divcontent += @" <h5> Spillere: </h5><li><i class='glyphicon glyphicon-user'></i> <span>" + s_navn + "</span></li>";
                    }                  
                    antallLag++;
                }
                else
                {
                   divcontent += @"<li><i class='glyphicon glyphicon-user'></i> <span>" + s_navn + "</span></li>";                 
                }                       
            }
            divcontent += @"</ul></div></div></div>";
            return divcontent;
        }
    }
}