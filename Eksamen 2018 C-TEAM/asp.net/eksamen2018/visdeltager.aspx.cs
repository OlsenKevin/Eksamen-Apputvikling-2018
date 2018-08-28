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
    public partial class visdeltager : System.Web.UI.Page
    {


        DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            string lag_id = Request.QueryString["lag_id"];

            //Sjekker om brukeren er logget inn
            if (Session["brukernavn"] == null)
            {
                Response.Redirect("logginn.aspx?sjekk=3");
            }
            else if (lag_id == null)
            {   
                //har ikke siden med lag_id vil ikke programme kunne vise riktige spillere til laget og brukeren blir sendt til mine lag
                feilspillere.InnerHtml = "<div class='alert alert-danger'><strong> FEIL!!</strong> Velg lag for å se spillere.</div>";
                Response.AddHeader("REFRESH", "2;URL=minelag.aspx");
            }
            else
            {
                //To knapper, en til å registrere spillere og en til å gå tilbake til mine lag
                registrerspiller.InnerHtml = "<a href = 'registrerdeltager.aspx?lag_id=" + lag_id + @"' class='btn btn-sm btn-primary' title='registrerdeltager'>Registrer spiller</a>";
                tilminelag.InnerHtml = "<a href='minelag.aspx' class='btn btn-sm btn-primary' title='tilminelag'>Til mine lag</a>";


                String b_navn = Session["brukernavn"].ToString();

                // kobler til DB
                String cs = "Host=cteam.mysql.domeneshop.no;Database=cteam;User=cteam;Password=AkVQirXSTZAg7bG";
                MySqlConnection dbconn = new MySqlConnection(cs);
                dbconn.Open();
                               
                // henter ut fra databasen
                String lag_turnering = ("SELECT deltager.deltager_id, deltager.nickname AS nickname, lag.lag_navn AS l_navn, deltager.fornavn as fornavn, deltager.etternavn as etternavn, nasjon.land as nasjon FROM deltager INNER JOIN lag ON lag.lag_id = deltager.lag_id INNER JOIN nasjon ON deltager.nasjon_id = nasjon.nasjon_id WHERE lag.lag_id = '" + lag_id + "';");

                MySqlDataAdapter da;
                MySqlCommand cmd = new MySqlCommand(lag_turnering, dbconn);
                da = new MySqlDataAdapter(cmd);
                MySqlCommandBuilder cb = new MySqlCommandBuilder(da);
                ds = new DataSet("TESTE");
                da.Fill(ds, "deltager");

                //Skriver all HTML kode, som i visdeltagere, til visdeltagere.aspx som viser det på nettsiden
                deltagere.InnerHtml = visdeltagere(ds);
            }
        }


        public string visdeltagere(DataSet ds)
        {
            int antallDeltagere = 0;
            String tempdeltager = "";
            String divcontent = "";

            // hvis ikke datasettet er tomt, så vil den vise alle deltagere til gitt lag på siden.
            if (ds.Tables[0].Rows.Count != 0)
            {

                foreach (DataRow radevent in ds.Tables["deltager"].Rows)
                {
                    String fornavn = Convert.ToString(radevent["fornavn"]);
                    String etternavn = Convert.ToString(radevent["etternavn"]);
                    String nasjon = Convert.ToString(radevent["nasjon"]);
                    String d_id = Convert.ToString(radevent["deltager_id"]);
                    

                    divcontent += "";
                    if (tempdeltager == "" || tempdeltager != Convert.ToString(radevent["nickname"]))
                    {
                        if (antallDeltagere > 0)
                        {
                            divcontent += @"</ul></div></div>";
                        }

                        tempdeltager = Convert.ToString(radevent["nickname"]);
                        divcontent += @"<div class='col-sm-4'>
                                        
                                        <div class='well well-lg'>
                                        <h3>" + tempdeltager + "</h3>" +
                                        "<ul class='meta-search'>" +

                                        "<li><i class='fas fa-user'></i> <span>" + fornavn + " " + etternavn + "</span></li> " +
                                         "<li><i class='fas fa-flag'></i> <span>" + nasjon + "</span></li> </ul>  " +
                                        "<a href = 'administrerspiller.aspx?d_id=" + d_id + "' class='btn btn-primary' title='administrerspiller'>Administrer spiller</a> </div> </div>";
                        
                    }
                }
            }
            else
            {
                feilspillere.InnerHtml = "<div class='alert alert-warning'>Det er ingen registrerte spillere på laget.</div>";
            }                 
            return divcontent;

        }

    }
}