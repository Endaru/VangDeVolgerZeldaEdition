namespace VangDeVolger
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Menu = new System.Windows.Forms.Panel();
            this.Options = new System.Windows.Forms.Button();
            this.Restart = new System.Windows.Forms.Button();
            this.Pauze = new System.Windows.Forms.Button();
            this.gamePicture = new System.Windows.Forms.PictureBox();
            this.Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gamePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.Controls.Add(this.Options);
            this.Menu.Controls.Add(this.Restart);
            this.Menu.Controls.Add(this.Pauze);
            this.Menu.Dock = System.Windows.Forms.DockStyle.Top;
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(501, 44);
            this.Menu.TabIndex = 0;
            // 
            // Options
            // 
            this.Options.Location = new System.Drawing.Point(164, 12);
            this.Options.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Options.Name = "Options";
            this.Options.Size = new System.Drawing.Size(75, 27);
            this.Options.TabIndex = 3;
            this.Options.Text = "Options";
            this.Options.UseVisualStyleBackColor = true;
            this.Options.Click += new System.EventHandler(this.Options_Click);
            // 
            // Restart
            // 
            this.Restart.Location = new System.Drawing.Point(84, 12);
            this.Restart.Name = "Restart";
            this.Restart.Size = new System.Drawing.Size(75, 27);
            this.Restart.TabIndex = 1;
            this.Restart.Text = "Restart";
            this.Restart.UseVisualStyleBackColor = true;
            this.Restart.Click += new System.EventHandler(this.Restart_Click);
            // 
            // Pauze
            // 
            this.Pauze.Location = new System.Drawing.Point(12, 12);
            this.Pauze.Name = "Pauze";
            this.Pauze.Size = new System.Drawing.Size(66, 27);
            this.Pauze.TabIndex = 0;
            this.Pauze.Text = "Pauze";
            this.Pauze.UseVisualStyleBackColor = true;
            this.Pauze.Click += new System.EventHandler(this.Pauze_Click);
            // 
            // gamePicture
            // 
            this.gamePicture.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gamePicture.BackgroundImage = global::VangDeVolger.Properties.Resources.grass;
            this.gamePicture.Location = new System.Drawing.Point(0, 45);
            this.gamePicture.Name = "gamePicture";
            this.gamePicture.Size = new System.Drawing.Size(501, 501);
            this.gamePicture.TabIndex = 1;
            this.gamePicture.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 546);
            this.Controls.Add(this.gamePicture);
            this.Controls.Add(this.Menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Vang De Volger";
            this.Menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gamePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private new System.Windows.Forms.Panel Menu;
        private System.Windows.Forms.Button Restart;
        private System.Windows.Forms.Button Pauze;
        private System.Windows.Forms.PictureBox gamePicture;
        private System.Windows.Forms.Button Options;
    }
}

