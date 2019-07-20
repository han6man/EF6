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
    public partial class FormCity : Form
    {
        public FormCity(IsraelGeoDataCS db)
        {
            InitializeComponent();
            InitializeComboBoxes(db);
        }

        private void InitializeComboBoxes(IsraelGeoDataCS db)
        {
            //Regions db.Cities.OrderBy(item => item.city_name);
            var regions = db.Regions.OrderBy(item => item.region_name);
            comboBoxRegion.DisplayMember = "Text";
            comboBoxRegion.ValueMember = "Value";
            foreach (Region r in regions)
                comboBoxRegion.Items.Add(new { Text = r.region_name, Value = r.region_code });
            comboBoxRegion.SelectedIndex = comboBoxRegion.FindStringExact("לא ידוע");
            //comboBoxRegion.SelectedIndex = 0;

            //Lishkot
            var lishkot = db.Lishkot.OrderBy(item => item.lishka);
            comboBoxLishka.DisplayMember = "Text";
            comboBoxLishka.ValueMember = "Value";
            foreach (Lishka l in lishkot)
                comboBoxLishka.Items.Add(new { Text = l.lishka, Value = l.lishkat_mana_code });
            comboBoxLishka.SelectedIndex = comboBoxLishka.FindStringExact("");
            //comboBoxLishka.SelectedIndex = 0;

            //Muacot
            var muacot = db.Muacot.OrderBy(item => item.muaca_name);
            comboBoxMuaca.DisplayMember = "Text";
            comboBoxMuaca.ValueMember = "Value";
            foreach (Muaca m in muacot)
                comboBoxMuaca.Items.Add(new { Text = m.muaca_name, Value = m.muaca_ezorit_code });
            comboBoxMuaca.SelectedIndex = comboBoxMuaca.FindStringExact("");
            //comboBoxMuaca.SelectedIndex = 0;
        }
    }
}
