namespace eksamen2018wf
{
    partial class logginn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary
        /// 




            //// fack deg kevin :)
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.brukernavn = new System.Windows.Forms.TextBox();
            this.passord = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.registrerbruker = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // brukernavn
            // 
            this.brukernavn.Location = new System.Drawing.Point(58, 47);
            this.brukernavn.Margin = new System.Windows.Forms.Padding(4);
            this.brukernavn.Name = "brukernavn";
            this.brukernavn.Size = new System.Drawing.Size(197, 28);
            this.brukernavn.TabIndex = 0;
            this.brukernavn.Tag = "";
            // 
            // passord
            // 
            this.passord.Location = new System.Drawing.Point(58, 117);
            this.passord.Margin = new System.Windows.Forms.Padding(4);
            this.passord.Name = "passord";
            this.passord.Size = new System.Drawing.Size(197, 28);
            this.passord.TabIndex = 1;
            this.passord.Text = "Passord";
            this.passord.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(54, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 5;
            // 
            // registrerbruker
            // 
            this.registrerbruker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.registrerbruker.FlatAppearance.BorderSize = 0;
            this.registrerbruker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registrerbruker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.registrerbruker.Image = global::eksamen2018wf.Properties.Resources.button_13_;
            this.registrerbruker.Location = new System.Drawing.Point(58, 344);
            this.registrerbruker.Margin = new System.Windows.Forms.Padding(0);
            this.registrerbruker.Name = "registrerbruker";
            this.registrerbruker.Size = new System.Drawing.Size(197, 42);
            this.registrerbruker.TabIndex = 6;
            this.registrerbruker.UseVisualStyleBackColor = false;
            this.registrerbruker.Click += new System.EventHandler(this.registrerbruker_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::eksamen2018wf.Properties.Resources.button_12_;
            this.button1.Location = new System.Drawing.Point(58, 282);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 42);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.TextChanged += new System.EventHandler(this.button1_TextChanged);
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // logginn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(332, 453);
            this.Controls.Add(this.registrerbruker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.passord);
            this.Controls.Add(this.brukernavn);
            this.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "logginn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Logg inn";
            this.Load += new System.EventHandler(this.logginn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox brukernavn;
        private System.Windows.Forms.TextBox passord;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button registrerbruker;
    }
}

