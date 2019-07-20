using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldGeoData
{
    public partial class FormStreet : Form
    {
        public FormStreet(WorldGeoDataDB db)
        {
            InitializeComponent();
            InitializeBoxes(db);
        }

        private void InitializeBoxes(WorldGeoDataDB db)
        {
            //Regions            
            var cities = db.Cities.OrderBy(item => item.City_Name);

            comboBoxCity.DisplayMember = "Text";
            comboBoxCity.ValueMember = "Value";
            foreach (City c in cities)
                comboBoxCity.Items.Add(new { Text = c.City_Name, Value = c.City_Code });
            comboBoxCity.SelectedIndex = comboBoxCity.FindStringExact("לא רשום");
            //comboBoxCity.SelectedIndex = 0;

            textBoxNameStatus.Text = "official";
        }

        private void textBoxStreetCode_TextChanged(object sender, EventArgs e)
        {
            textBoxOfficialCode.Text = textBoxStreetCode.Text;
        }
    }
}
