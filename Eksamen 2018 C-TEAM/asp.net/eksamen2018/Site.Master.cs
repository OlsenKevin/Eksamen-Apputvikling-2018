using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eksamen2018
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["brukernavn"] == null)
            {
            
            
          
                gjemtmeny1.Visible = false;
         
                gjemtmeny5.Visible = false;
            }

            else
            {
                gjemtmeny3.Visible = false;

            }
        }
    }
}