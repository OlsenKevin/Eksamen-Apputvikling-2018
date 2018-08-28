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
    public partial class minelag : System.Web.UI.Page
    {
        //instansierer database klassen og et dataset
        database database = new database();
        DataSet ds;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Sjekker om brukeren er logget inn
            if (Session["brukernavn"] == null)
            {
                Response.Redirect("logginn.aspx?sjekk=3");
            }
            else
            {
                // kobler til DB
                String cs = "Host=cteam.mysql.domeneshop.no;Database=cteam;User=cteam;Password=AkVQirXSTZAg7bG";
                MySqlConnection dbconn = new MySqlConnection(cs);
                dbconn.Open();

                // henter ut fra databasen
                String b_navn = Session["brukernavn"].ToString();

                String lag_turnering = ("SELECT t.turnering_navn AS t_navn, l.lag_navn as l_navn, l.lag_id AS lag_id, l.bruker_id AS b_id FROM turnering t INNER JOIN lag l ON l.turnering_id = t.turnering_id INNER JOIN bruker ON bruker.bruker_id = l.bruker_id WHERE bruker.brukernavn = '" + b_navn + "';");

                //instansierer en dataadapter som fylles med radene fra spørringen - lag_turnering
                MySqlDataAdapter da;
                MySqlCommand cmd = new MySqlCommand(lag_turnering, dbconn);
                da = new MySqlDataAdapter(cmd);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                ds = new DataSet("TESTE");
                da.Fill(ds, "lag");

                eventoppsett.InnerHtml = vislag(ds);             
            }
        }
                
        public string vislag(DataSet ds)
        {
            int antallLag = 0;
            String tempLagNavn = "";
            String divcontent = "";

            //skriver ut alle lagene med hjelp av foreach på siden hvis datasettet ikke er tomt
            if (ds.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow radevent in ds.Tables["lag"].Rows)
                {
                    String t_navn = Convert.ToString(radevent["t_navn"]);
                    String lag_id = Convert.ToString(radevent["lag_id"]);

                        if (tempLagNavn == "" || tempLagNavn != Convert.ToString(radevent["l_navn"]))
                        {
                            if (antallLag > 0)
                            {
                                divcontent += @"</ul></div></div>";
                            }

                            tempLagNavn = Convert.ToString(radevent["l_navn"]);
                            divcontent += @"<div class='col-sm-4'>
                                            <div class='well well-lg'>
                                            <h3>" + tempLagNavn + "</h3>" +
                                            "<ul class='meta-search'>" +

                                            "<li><i class='fa fa-trophy'></i> <span>" + t_navn + "</span></li> <br/> </ul>" +
                                            "<a href='visdeltager.aspx?lag_id=" + lag_id + @"' class='btn btn-primary' title='visspillere'>Spillere</a> " +
                                            "<a href='administrerlag.aspx?lag_id=" + lag_id + @"' class='btn btn-primary' title='administrerlag'>Administrer lag</a>  </div> </div>";
                        }                   
                }
            }
            else
            {
                //  Feilmelding hvis du ikke har noen registrerte lag
                minelagtext.InnerHtml = "<div class='alert alert-danger'><strong> FEIL!!</strong> Du har ingen registrerte lag.</div>";
            }
            return divcontent;
        }        
    }
}