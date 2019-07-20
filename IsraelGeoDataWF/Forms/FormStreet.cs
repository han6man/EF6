using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsraelGeoDataWF
{
    public partial class FormStreet : Form
    {
        public FormStreet(IsraelGeoDataCS db)
        {
            InitializeComponent();
            InitializeBoxes(db);
        }

        private void InitializeBoxes(IsraelGeoDataCS db)
        {
            //Regions            
            var cities = db.Cities.OrderBy(item => item.city_name);

            comboBoxCity.DisplayMember = "Text";
            comboBoxCity.ValueMember = "Value";
            foreach (City c in cities)
                comboBoxCity.Items.Add(new { Text = c.city_name, Value = c.city_code });
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
