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
    public partial class bracket : Page
    {
        // kobler til db
        MySqlConnection con = new MySqlConnection("Host=cteam.mysql.domeneshop.no;Database=cteam;User=cteam;Password=AkVQirXSTZAg7bG");

        //instansierer klassen database
        database database = new database();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Kjører metodene for å fylle bracketen
            fillEarlyBracket();
            fillOnGoingBracket();
        }

        public void fillEarlyBracket()
        {
            // henter ut t_id gjennom URL, den er sendt fra forrige side
            String t_id = Request.QueryString["t_id"];

            if (t_id == null)
            {
                //Sender brukeren tilbake til turnering om ikke t_id er med. for da viser ikke bracketten riktig verdier
                bracketText.InnerHtml = "<div class='alert alert-danger'><strong> FEIL!</strong> Du har ikke valgt turnering, og blir nå tatt tilbake til event.</div>";

                Response.AddHeader("REFRESH", "3;URL=event.aspx?;");
            }
            else
            {
                String e_id = database.returnid("SELECT event_id FROM turnering WHERE turnering_id = " + t_id + ";");
                bracketText.InnerHtml =  "<a href = 'turnering.aspx?e_id=" + e_id + @"' class='btn btn-sm btn-primary' title='tilturnering'>Til turnering</a>";

                MySqlDataAdapter adp = new MySqlDataAdapter("SELECT lag_id, lag_navn FROM lag WHERE turnering_id = '" + t_id + "' ORDER BY lag_id", con);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                //Før hver label fylles, vil gjøres en sjekk om det finnes noe videre rader i datatablen. Dette gjør også at den viser tomt hvis de er tomme. Uten disse sjekkene krasjer programmet hvis dt er tomt.
                if (dt.Rows.Count > 0)
                {
                    Label1.Text = dt.Rows[0]["lag_navn"].ToString();

                    if (dt.Rows.Count > 1)
                    {
                        Label2.Text = dt.Rows[1]["lag_navn"].ToString();

                        if (dt.Rows.Count > 2)
                        {
                            Label3.Text = dt.Rows[2]["lag_navn"].ToString();

                            if (dt.Rows.Count > 3)
                            {
                                Label4.Text = dt.Rows[3]["lag_navn"].ToString();

                                if (dt.Rows.Count > 4)
                                {
                                    Label5.Text = dt.Rows[4]["lag_navn"].ToString();

                                    if (dt.Rows.Count > 5)
                                    {
                                        Label6.Text = dt.Rows[5]["lag_navn"].ToString();

                                        if (dt.Rows.Count > 6)
                                        {
                                            Label7.Text = dt.Rows[6]["lag_navn"].ToString();

                                            if (dt.Rows.Count > 7)
                                            {
                                                Label8.Text = dt.Rows[7]["lag_navn"].ToString();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    bracketText.InnerHtml = "<div class='alert alert-warning'>Det er ingen påmeldte lag, du blir nå tatt tilbake til turnering.</div>";
                }
            }
        }

        public void fillOnGoingBracket()
        {
           String t_id = Request.QueryString["t_id"];

            if (t_id == null)
            {
                //Sender brukeren tilbake til turnering om ikke t_id er med. for da viser ikke bracketten riktig verdier
                bracketText.InnerHtml = "<div class='alert alert-danger'><strong> FEIL!</strong> Du har ikke valgt turnering, og blir nå tatt tilbake til event.</div>";

                Response.AddHeader("REFRESH", "3;URL=event.aspx?;");
            }
            else
            {

                String e_id = database.returnid("SELECT event_id FROM turnering WHERE turnering_id = " + t_id + ";");
                bracketText.InnerHtml = "<a href = 'turnering.aspx?e_id=" + e_id + @"' class='btn btn-sm btn-primary' title='tilturnering'>Til turnering</a>";
                
                MySqlDataAdapter adp1 = new MySqlDataAdapter("SELECT lag1, lag2 FROM kamp WHERE turnering_id = '" + t_id + "' ORDER BY bracketstep", con);
                DataTable dt1 = new DataTable();
                adp1.Fill(dt1);

                //Før hver label fylles, vil gjøres en sjekk om det finnes noe videre rader i datatablen. Dette gjør også at den viser tomt hvis de er tomme. Uten disse sjekkene krasjer programmet hvis dt1 er tomt.
                if (dt1.Rows.Count > 0)
                {
                    Label9.Text = dt1.Rows[0]["lag1"].ToString();
                    Label10.Text = dt1.Rows[0]["lag2"].ToString();

                    if (dt1.Rows.Count > 1)
                    {
                        Label11.Text = dt1.Rows[1]["lag1"].ToString();
                        Label12.Text = dt1.Rows[1]["lag2"].ToString();

                        if (dt1.Rows.Count > 2)
                        {
                            Label13.Text = dt1.Rows[2]["lag1"].ToString();
                            Label14.Text = dt1.Rows[2]["lag2"].ToString();

                            if (dt1.Rows.Count > 3)
                            {
                                Label15.Text = dt1.Rows[3]["lag1"].ToString();
                                Label16.Text = dt1.Rows[3]["lag2"].ToString();

                                if (dt1.Rows.Count > 4)
                                {
                                    Label21.Text = dt1.Rows[4]["lag2"].ToString();
                                    Label22.Text = dt1.Rows[4]["lag1"].ToString();

                                    if (dt1.Rows.Count > 5)
                                    {
                                        Label17.Text = dt1.Rows[5]["lag2"].ToString();
                                        Label18.Text = dt1.Rows[5]["lag1"].ToString();

                                        if (dt1.Rows.Count > 6)
                                        {

                                            Label23.Text = dt1.Rows[6]["lag1"].ToString();
                                            Label24.Text = dt1.Rows[6]["lag2"].ToString();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}