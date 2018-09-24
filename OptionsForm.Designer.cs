namespace VangDeVolger
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.PercentagePillarLabel = new System.Windows.Forms.Label();
            this.PercentageStoneLabel = new System.Windows.Forms.Label();
            this.PillarLabel = new System.Windows.Forms.Label();
            this.StoneLabel = new System.Windows.Forms.Label();
            this.SpeedList = new System.Windows.Forms.ComboBox();
            this.MapSizeList = new System.Windows.Forms.ComboBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.EnemySpeedLabel = new System.Windows.Forms.Label();
            this.MapSizeLabel = new System.Windows.Forms.Label();
            this.checkPickups = new System.Windows.Forms.CheckBox();
            this.HammerList = new System.Windows.Forms.ComboBox();
            this.HammerLabel = new System.Windows.Forms.Label();
            this.ShieldLabel = new System.Windows.Forms.Label();
            this.ShieldList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 30);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(51, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "20";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 87);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(51, 22);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "5";
            // 
            // PercentagePillarLabel
            // 
            this.PercentagePillarLabel.AutoSize = true;
            this.PercentagePillarLabel.Location = new System.Drawing.Point(69, 90);
            this.PercentagePillarLabel.Name = "PercentagePillarLabel";
            this.PercentagePillarLabel.Size = new System.Drawing.Size(20, 17);
            this.PercentagePillarLabel.TabIndex = 2;
            this.PercentagePillarLabel.Text = "%";
            // 
            // PercentageStoneLabel
            // 
            this.PercentageStoneLabel.AutoSize = true;
            this.PercentageStoneLabel.Location = new System.Drawing.Point(72, 32);
            this.PercentageStoneLabel.Name = "PercentageStoneLabel";
            this.PercentageStoneLabel.Size = new System.Drawing.Size(20, 17);
            this.PercentageStoneLabel.TabIndex = 3;
            this.PercentageStoneLabel.Text = "%";
            // 
            // PillarLabel
            // 
            this.PillarLabel.AutoSize = true;
            this.PillarLabel.Location = new System.Drawing.Point(12, 66);
            this.PillarLabel.Name = "PillarLabel";
            this.PillarLabel.Size = new System.Drawing.Size(138, 17);
            this.PillarLabel.TabIndex = 4;
            this.PillarLabel.Text = "Percentage of pillars";
            // 
            // StoneLabel
            // 
            this.StoneLabel.AutoSize = true;
            this.StoneLabel.Location = new System.Drawing.Point(12, 9);
            this.StoneLabel.Name = "StoneLabel";
            this.StoneLabel.Size = new System.Drawing.Size(143, 17);
            this.StoneLabel.TabIndex = 5;
            this.StoneLabel.Text = "Percentage of stones";
            // 
            // SpeedList
            // 
            this.SpeedList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SpeedList.FormattingEnabled = true;
            this.SpeedList.Items.AddRange(new object[] {
            "0,5X",
            "1,0X",
            "2,0X"});
            this.SpeedList.SelectedIndex = 1;
            this.SpeedList.Location = new System.Drawing.Point(12, 149);
            this.SpeedList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SpeedList.Name = "SpeedList";
            this.SpeedList.Size = new System.Drawing.Size(77, 24);
            this.SpeedList.TabIndex = 6;
            // 
            // MapSizeList
            // 
            this.MapSizeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MapSizeList.FormattingEnabled = true;
            this.MapSizeList.Items.AddRange(new object[] {
            "10x10",
            "15x15",
            "20x20",
            "25x25"});
            this.MapSizeList.SelectedIndex = 2;
            this.MapSizeList.Location = new System.Drawing.Point(12, 204);
            this.MapSizeList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MapSizeList.Name = "MapSizeList";
            this.MapSizeList.Size = new System.Drawing.Size(77, 24);
            this.MapSizeList.TabIndex = 7;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(95, 406);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(83, 32);
            this.CancelButton.TabIndex = 8;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(12, 406);
            this.OKButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(77, 32);
            this.OKButton.TabIndex = 9;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // EnemySpeedLabel
            // 
            this.EnemySpeedLabel.AutoSize = true;
            this.EnemySpeedLabel.Location = new System.Drawing.Point(9, 128);
            this.EnemySpeedLabel.Name = "EnemySpeedLabel";
            this.EnemySpeedLabel.Size = new System.Drawing.Size(94, 17);
            this.EnemySpeedLabel.TabIndex = 10;
            this.EnemySpeedLabel.Text = "Enemy speed";
            // 
            // MapSizeLabel
            // 
            this.MapSizeLabel.AutoSize = true;
            this.MapSizeLabel.Location = new System.Drawing.Point(9, 183);
            this.MapSizeLabel.Name = "MapSizeLabel";
            this.MapSizeLabel.Size = new System.Drawing.Size(64, 17);
            this.MapSizeLabel.TabIndex = 11;
            this.MapSizeLabel.Text = "Map size";
            // 
            // checkPickups
            // 
            this.checkPickups.AutoSize = true;
            this.checkPickups.Checked = true;
            this.checkPickups.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkPickups.Location = new System.Drawing.Point(12, 245);
            this.checkPickups.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkPickups.Name = "checkPickups";
            this.checkPickups.Size = new System.Drawing.Size(85, 21);
            this.checkPickups.TabIndex = 12;
            this.checkPickups.Text = "Pick Ups";
            this.checkPickups.UseVisualStyleBackColor = true;
            this.checkPickups.CheckedChanged += new System.EventHandler(this.checkPickups_CheckedChanged);
            // 
            // HammerList
            // 
            this.HammerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HammerList.FormattingEnabled = true;
            this.HammerList.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.HammerList.SelectedIndex = 1;
            this.HammerList.Location = new System.Drawing.Point(12, 297);
            this.HammerList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HammerList.Name = "HammerList";
            this.HammerList.Size = new System.Drawing.Size(77, 24);
            this.HammerList.TabIndex = 13;
            // 
            // HammerLabel
            // 
            this.HammerLabel.AutoSize = true;
            this.HammerLabel.Location = new System.Drawing.Point(9, 276);
            this.HammerLabel.Name = "HammerLabel";
            this.HammerLabel.Size = new System.Drawing.Size(136, 17);
            this.HammerLabel.TabIndex = 14;
            this.HammerLabel.Text = "Number of hammers";
            // 
            // ShieldLabel
            // 
            this.ShieldLabel.AutoSize = true;
            this.ShieldLabel.Location = new System.Drawing.Point(9, 340);
            this.ShieldLabel.Name = "ShieldLabel";
            this.ShieldLabel.Size = new System.Drawing.Size(122, 17);
            this.ShieldLabel.TabIndex = 15;
            this.ShieldLabel.Text = "Number of shields";
            // 
            // ShieldList
            // 
            this.ShieldList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ShieldList.FormattingEnabled = true;
            this.ShieldList.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.ShieldList.SelectedIndex = 0;
            this.ShieldList.Location = new System.Drawing.Point(12, 359);
            this.ShieldList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ShieldList.Name = "ShieldList";
            this.ShieldList.Size = new System.Drawing.Size(77, 24);
            this.ShieldList.TabIndex = 16;
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 490);
            this.ControlBox = false;
            this.Controls.Add(this.ShieldList);
            this.Controls.Add(this.ShieldLabel);
            this.Controls.Add(this.HammerLabel);
            this.Controls.Add(this.HammerList);
            this.Controls.Add(this.checkPickups);
            this.Controls.Add(this.MapSizeLabel);
            this.Controls.Add(this.EnemySpeedLabel);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.MapSizeList);
            this.Controls.Add(this.SpeedList);
            this.Controls.Add(this.StoneLabel);
            this.Controls.Add(this.PillarLabel);
            this.Controls.Add(this.PercentageStoneLabel);
            this.Controls.Add(this.PercentagePillarLabel);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "OptionsForm";
            this.Text = "OptionsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StoneLabel;
        private System.Windows.Forms.ComboBox SpeedList;
        private System.Windows.Forms.Label PillarLabel;
        private System.Windows.Forms.Label PercentageStoneLabel;
        private System.Windows.Forms.Label PercentagePillarLabel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox MapSizeList;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label EnemySpeedLabel;
        private System.Windows.Forms.Label MapSizeLabel;
        private System.Windows.Forms.CheckBox checkPickups;
        private System.Windows.Forms.ComboBox HammerList;
        private System.Windows.Forms.Label HammerLabel;
        private System.Windows.Forms.Label ShieldLabel;
        private System.Windows.Forms.ComboBox ShieldList;
    }
}