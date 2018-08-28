namespace eksamen2018wf
{
    partial class registrerbruker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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
            this.txtbrukernavn = new System.Windows.Forms.TextBox();
            this.txtpassord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnlogginn = new System.Windows.Forms.Button();
            this.btnregistrerbruker = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtbrukernavn
            // 
            this.txtbrukernavn.Font = new System.Drawing.Font("Verdana", 10.2F);
            this.txtbrukernavn.Location = new System.Drawing.Point(58, 47);
            this.txtbrukernavn.Name = "txtbrukernavn";
            this.txtbrukernavn.Size = new System.Drawing.Size(197, 28);
            this.txtbrukernavn.TabIndex = 0;
            this.txtbrukernavn.Text = "Brukernavn";
            // 
            // txtpassord
            // 
            this.txtpassord.Font = new System.Drawing.Font("Verdana", 10.2F);
            this.txtpassord.Location = new System.Drawing.Point(58, 117);
            this.txtpassord.Name = "txtpassord";
            this.txtpassord.Size = new System.Drawing.Size(197, 28);
            this.txtpassord.TabIndex = 1;
            this.txtpassord.Text = "Passord";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 5;
            // 
            // btnlogginn
            // 
            this.btnlogginn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlogginn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnlogginn.Image = global::eksamen2018wf.Properties.Resources.button_16_;
            this.btnlogginn.Location = new System.Drawing.Point(40, 305);
            this.btnlogginn.Margin = new System.Windows.Forms.Padding(0);
            this.btnlogginn.Name = "btnlogginn";
            this.btnlogginn.Size = new System.Drawing.Size(235, 42);
            this.btnlogginn.TabIndex = 6;
            this.btnlogginn.UseVisualStyleBackColor = true;
            this.btnlogginn.Click += new System.EventHandler(this.btnlogginn_Click);
            // 
            // btnregistrerbruker
            // 
            this.btnregistrerbruker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnregistrerbruker.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnregistrerbruker.Image = global::eksamen2018wf.Properties.Resources.button_13_1;
            this.btnregistrerbruker.Location = new System.Drawing.Point(63, 250);
            this.btnregistrerbruker.Margin = new System.Windows.Forms.Padding(0);
            this.btnregistrerbruker.Name = "btnregistrerbruker";
            this.btnregistrerbruker.Size = new System.Drawing.Size(197, 42);
            this.btnregistrerbruker.TabIndex = 4;
            this.btnregistrerbruker.UseVisualStyleBackColor = false;
            this.btnregistrerbruker.Click += new System.EventHandler(this.btnregistrerbruker_Click);
            // 
            // registrerbruker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(332, 453);
            this.Controls.Add(this.btnlogginn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnregistrerbruker);
            this.Controls.Add(this.txtpassord);
            this.Controls.Add(this.txtbrukernavn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "registrerbruker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrer bruker";
            this.Load += new System.EventHandler(this.registrerbruker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbrukernavn;
        private System.Windows.Forms.TextBox txtpassord;
        private System.Windows.Forms.Button btnregistrerbruker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnlogginn;
    }
}