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
    public partial class FormCity : Form
    {
        public FormCity(WorldGeoDataDB db)
        {
            InitializeComponent();
            InitializeComboBoxes(db);
        }

        private void InitializeComboBoxes(WorldGeoDataDB db)
        {
            //Regions db.Cities.OrderBy(item => item.City_Name);
            var regions = db.Country_Regions.OrderBy(item => item.Country_Region_Name);
            comboBoxRegion.DisplayMember = "Text";
            comboBoxRegion.ValueMember = "Value";
            foreach (Country_Region r in regions)
                comboBoxRegion.Items.Add(new { Text = r.Country_Region_Name, Value = r.Country_Region_Code });
            comboBoxRegion.SelectedIndex = comboBoxRegion.FindStringExact("לא ידוע");
            //comboBoxRegion.SelectedIndex = 0;

            //Lishkot
            var lishkot = db.Lishkot_Mana.OrderBy(item => item.Lishkat_Mana_Name);
            comboBoxLishka.DisplayMember = "Text";
            comboBoxLishka.ValueMember = "Value";
            foreach (Lishkat_Mana l in lishkot)
                comboBoxLishka.Items.Add(new { Text = l.Lishkat_Mana_Name, Value = l.Lishkat_Mana_Code });
            comboBoxLishka.SelectedIndex = comboBoxLishka.FindStringExact("");
            //comboBoxLishka.SelectedIndex = 0;

            //Muacot
            var muacot = db.Regional_Councils.OrderBy(item => item.Regional_Council_Name);
            comboBoxMuaca.DisplayMember = "Text";
            comboBoxMuaca.ValueMember = "Value";
            foreach (Regional_Council m in muacot)
                comboBoxMuaca.Items.Add(new { Text = m.Regional_Council_Name, Value = m.Regional_Council_Code });
            comboBoxMuaca.SelectedIndex = comboBoxMuaca.FindStringExact("");
            //comboBoxMuaca.SelectedIndex = 0;
        }
    }
}
