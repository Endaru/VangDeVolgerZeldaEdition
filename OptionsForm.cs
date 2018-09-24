using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VangDeVolger
{
    public partial class OptionsForm : Form
    {
        //get and set the variables for game
        public int stonePercentage { get; set; }
        public int pillarPercentage { get; set; }
        public float enemySpeed { get; set; }
        public int mapSize { get; set; }
        public bool enablePickups { get; set; }
        public int numberHammers { get; set; }
        public int numberShields { get; set; }

        public OptionsForm()
        {
            InitializeComponent();
        }

        //if OK.
        private void OKButton_Click(object sender, EventArgs e)
        {
            //save value of given textbox in this int.
            int returnedNumber;
            //look if input is numeric.
            bool isNumeric = int.TryParse(textBox1.Text, out returnedNumber);
            //if input is numeric and input is between 0 and 100.
            if (isNumeric && returnedNumber <= 100 && returnedNumber >= 0)
            {
                this.stonePercentage = returnedNumber;
            }
            //else use standard value.
            else
            {
                this.stonePercentage = 20;
            }

            isNumeric = int.TryParse(textBox2.Text, out returnedNumber);
            if (isNumeric && returnedNumber <= 100 && returnedNumber >= 0)
            {
                this.pillarPercentage = returnedNumber;
            } else
            {
                this.pillarPercentage = 5;
            }

            //string to save the selectedSpeed from the combobox.
            string selectedSpeed = SpeedList.GetItemText(SpeedList.SelectedItem);
            //get the value we actually need from the selectedSpeed.
            string subSelectedSpeed = selectedSpeed.Substring(0,3);
            //save the selectedSpeed in a float for further use.
            float parsedSelectedSpeed = float.Parse(subSelectedSpeed);
            this.enemySpeed = parsedSelectedSpeed;

            //get the selected item from mapsize.
            string selectedMapSize = MapSizeList.GetItemText(MapSizeList.SelectedItem);
            string subSelectedMapSize = selectedMapSize.Substring(0,2);
            int parsedSelectedMapSize = Int32.Parse(subSelectedMapSize);
            this.mapSize = parsedSelectedMapSize;

            //if checkpickups is true then enable else disable
            if (checkPickups.Checked) {
                int selectedHammer = Int32.Parse(HammerList.GetItemText(HammerList.SelectedItem));
                this.numberHammers = selectedHammer;

                int selectedShields = Int32.Parse(ShieldList.GetItemText(ShieldList.SelectedItem));
                this.numberShields = selectedShields;
            }
            else if (!checkPickups.Checked)
            {
                this.numberHammers = 0;
                this.numberShields = 0;
            }

            //give result of buttonpress.
            this.DialogResult = DialogResult.OK;
            //close the optionsform.
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            //give result.
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void checkPickups_CheckedChanged(object sender, EventArgs e)
        {
            this.HammerList.Enabled = !this.HammerList.Enabled;
            this.ShieldList.Enabled = !this.ShieldList.Enabled;
        }
    }
}
