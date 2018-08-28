using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// filen for vårt administratorpanel
namespace eksamen2018wf
{

    public partial class adminpanel : Form
    {



        // for å fortelle adminpanelets hva den skal gjøre når den kjøres første gangen. Her skal adminpanelet starte med å kjøre første side i det adminpanelet blir startet
       
        public adminpanel(string brukernavn)
        {
           

            InitializeComponent();
            this.Refresh();
            // viser brukernavnet til brukeren
            label1.Text = "Du er logget inn som: " + brukernavn;
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            forsteside1.BringToFront();
            db = new database();
            // vi har her med oss brukernavnet gjennom string brukernavn og sender brukernavnet videre til andre filer på denne måten.
            this.tredjeside1.ID = db.returnid("select bruker_id from admin WHERE brukernavn = '"+ brukernavn +"';");
            this.andreside1.ID = db.returnid("select bruker_id from admin WHERE brukernavn = '" + brukernavn + "';");
            this.fjerdeside1.ID = db.returnid("select bruker_id from admin WHERE brukernavn = '" + brukernavn + "';");
            this.femteside1.ID = db.returnid("select bruker_id from admin WHERE brukernavn = '" + brukernavn + "';");
        }

        public database db;

        

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        // Når brukeren trykker på knapp nr 1 skal den vise førsteside
        private void button1_Click(object sender, EventArgs e)
        {

            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            forsteside1.BringToFront();
            
        }

    

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }
        // Når brukeren trykker på knapp nr 2 skal den vise tredjeside
        private void button2_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button2.Height;
            SidePanel.Top = button2.Top;
            tredjeside1.BringToFront();
          
        }
        // Når brukeren trykker på knapp nr 3 skal den vise andreside
        private void button3_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button3.Height;
            SidePanel.Top = button3.Top;
            andreside1.BringToFront();
            

        }
        // Når brukeren trykker på knapp nr 4 skal den vise fjerdeside
        private void button4_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button4.Height;
            SidePanel.Top = button4.Top;
            fjerdeside1.BringToFront();
        }
        // Når brukeren trykker på knapp nr 5 skal den vise femteside
        private void button5_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button5.Height;
            SidePanel.Top = button5.Top;
            femteside1.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tredjeside1_Load(object sender, EventArgs e)
        {

        }

        
        
    }
}
