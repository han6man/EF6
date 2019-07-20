using MDH.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsraelGeoDataWF
{
    public partial class FormMain : Form
    {
        private bool m_bLayoutCalled = false;
        private DateTime m_dt;

        IsraelGeoDataCS db;

        #region Constructor
        public FormMain()
        {
            //using (IsraelGeoDataCS db = new IsraelGeoDataCS())
            //{
            //    var cities = db.Cities;
            //    foreach (City c in cities)
            //        Console.WriteLine("{0}.{1} - {2}", c.city_code, c.city_name, c.city_name_foreign);
            //}

            InitializeComponent();
            InitializeDataSources();
        }

        private void InitializeDataSources()
        {
            db = new IsraelGeoDataCS();

            SplashScreen.SetStatus("Loading Cities");
            db.View_Cities.Load();
            db.Cities.Load();
            dataGridViewCities.DataSource = db.Cities.Local.ToBindingList();

            SplashScreen.SetStatus("Loading Streets");
            db.View_Streets.Load();
            db.Streets.Load();
            dataGridViewStreets.DataSource = db.Streets.Local.ToBindingList();

            SplashScreen.SetStatus("Loading Regions");
            db.Regions.Load();
            dataGridViewRegions.DataSource = db.Regions.Local.ToBindingList();

            SplashScreen.SetStatus("Loading Lishkot");
            db.Lishkot.Load();
            dataGridViewLishkot.DataSource = db.Lishkot.Local.ToBindingList();

            SplashScreen.SetStatus("Loading Muacot");
            db.Muacot.Load();
            dataGridViewMuacot.DataSource = db.Muacot.Local.ToBindingList();
        }
        #endregion

        private void FormMain_Shown(object sender, EventArgs e)
        {
            if (m_bLayoutCalled == false)
            {
                m_bLayoutCalled = true;
                m_dt = DateTime.Now;
                this.Activate();
                SplashScreen.CloseForm();
            }            
        }

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region Regions
        private void toolStripButtonRegionAdd_Click(object sender, EventArgs e)
        {
            FormRegion formRegion = new FormRegion();
            DialogResult result = formRegion.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Region region = new Region();
            int region_code;
            bool converted = Int32.TryParse(formRegion.textBoxRegionCode.Text, out region_code);
            if (converted == false)
                return;
            region.region_code = region_code;
            region.region_name = formRegion.textBoxRegionName.Text;

            db.Regions.Add(region);
            db.SaveChanges();

            MessageBox.Show("New object added");
        }

        private void toolStripButtonRegionEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewRegions.SelectedRows.Count > 0)
            {
                int index = dataGridViewRegions.SelectedRows[0].Index;
                int region_code;
                bool converted = Int32.TryParse(dataGridViewRegions[0, index].Value.ToString(), out region_code);
                if (converted == false)
                    return;

                Region region = db.Regions.Find(region_code);

                FormRegion formRegion = new FormRegion();
                formRegion.textBoxRegionCode.Text = region.region_code.ToString();
                formRegion.textBoxRegionName.Text = region.region_name;
                formRegion.textBoxRegionCode.Enabled = false;

                DialogResult result = formRegion.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                region.region_name = formRegion.textBoxRegionName.Text;

                db.SaveChanges();

                dataGridViewRegions.Refresh(); // обновляем грид

                MessageBox.Show("Object updated");

            }
        }

        private void toolStripButtonRegionRemove_Click(object sender, EventArgs e)
        {
            if (dataGridViewRegions.SelectedRows.Count > 0)
            {
                int index = dataGridViewRegions.SelectedRows[0].Index;
                int region_code = 0;
                bool converted = Int32.TryParse(dataGridViewRegions[0, index].Value.ToString(), out region_code);
                if (converted == false)
                    return;

                Region region = db.Regions.Find(region_code);
                db.Regions.Remove(region);
                db.SaveChanges();

                MessageBox.Show("Object removed");
            }
        }
        #endregion

        #region Lishkot
        private void toolStripButtonLishkaAdd_Click(object sender, EventArgs e)
        {
            FormLishka formLishka = new FormLishka();
            DialogResult result = formLishka.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Lishka lishka = new Lishka();
            int lishkat_mana_code;
            bool converted = Int32.TryParse(formLishka.textBoxLishkaCode.Text, out lishkat_mana_code);
            if (converted == false)
                return;
            lishka.lishkat_mana_code = lishkat_mana_code;
            lishka.lishka = formLishka.textBoxLishkaName.Text;

            db.Lishkot.Add(lishka);
            db.SaveChanges();

            MessageBox.Show("New object added");
        }

        private void toolStripButtonLishkaEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewLishkot.SelectedRows.Count > 0)
            {
                int index = dataGridViewLishkot.SelectedRows[0].Index;
                int lishkat_mana_code;
                bool converted = Int32.TryParse(dataGridViewLishkot[0, index].Value.ToString(), out lishkat_mana_code);
                if (converted == false)
                    return;

                Lishka lishka = db.Lishkot.Find(lishkat_mana_code);

                FormLishka formLishka = new FormLishka();
                formLishka.textBoxLishkaCode.Text = lishka.lishkat_mana_code.ToString();
                formLishka.textBoxLishkaName.Text = lishka.lishka;
                formLishka.textBoxLishkaCode.Enabled = false;

                DialogResult result = formLishka.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                lishka.lishka = formLishka.textBoxLishkaName.Text;

                db.SaveChanges();

                dataGridViewLishkot.Refresh(); // обновляем грид

                MessageBox.Show("Object updated");
            }
        }

        private void toolStripButtonLishkaRemove_Click(object sender, EventArgs e)
        {
            if (dataGridViewLishkot.SelectedRows.Count > 0)
            {
                int index = dataGridViewLishkot.SelectedRows[0].Index;
                int lishkat_mana_code = 0;
                bool converted = Int32.TryParse(dataGridViewLishkot[0, index].Value.ToString(), out lishkat_mana_code);
                if (converted == false)
                    return;

                Lishka lishka = db.Lishkot.Find(lishkat_mana_code);
                db.Lishkot.Remove(lishka);
                db.SaveChanges();

                MessageBox.Show("Object removed");
            }
        }
        #endregion

        #region Muacot
        private void toolStripButtonMuacaAdd_Click(object sender, EventArgs e)
        {
            FormMuaca formMuaca = new FormMuaca();
            DialogResult result = formMuaca.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Muaca muaca = new Muaca();
            int muaca_ezorit_code;
            bool converted = Int32.TryParse(formMuaca.textBoxMuacaCode.Text, out muaca_ezorit_code);
            if (converted == false)
                return;
            muaca.muaca_ezorit_code = muaca_ezorit_code;
            muaca.muaca_name = formMuaca.textBoxMuacaName.Text;

            db.Muacot.Add(muaca);
            db.SaveChanges();

            MessageBox.Show("New object added");
        }

        private void toolStripButtonMuacaEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewMuacot.SelectedRows.Count > 0)
            {
                int index = dataGridViewMuacot.SelectedRows[0].Index;
                int muaca_ezorit_code;
                bool converted = Int32.TryParse(dataGridViewMuacot[0, index].Value.ToString(), out muaca_ezorit_code);
                if (converted == false)
                    return;

                Muaca muaca = db.Muacot.Find(muaca_ezorit_code);

                FormMuaca formMuaca = new FormMuaca();
                formMuaca.textBoxMuacaCode.Text = muaca.muaca_ezorit_code.ToString();
                formMuaca.textBoxMuacaName.Text = muaca.muaca_name;
                formMuaca.textBoxMuacaCode.Enabled = false;

                DialogResult result = formMuaca.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                muaca.muaca_name = formMuaca.textBoxMuacaName.Text;

                db.SaveChanges();

                dataGridViewMuacot.Refresh(); // обновляем грид

                MessageBox.Show("Object updated");

            }
        }

        private void toolStripButtonMuacaRemove_Click(object sender, EventArgs e)
        {
            if (dataGridViewMuacot.SelectedRows.Count > 0)
            {
                int index = dataGridViewMuacot.SelectedRows[0].Index;
                int muaca_ezorit_code = 0;
                bool converted = Int32.TryParse(dataGridViewMuacot[0, index].Value.ToString(), out muaca_ezorit_code);
                if (converted == false)
                    return;

                Muaca muaca = db.Muacot.Find(muaca_ezorit_code);
                db.Muacot.Remove(muaca);
                db.SaveChanges();

                MessageBox.Show("Object removed");
            }
        }
        #endregion

        #region Cities
        private void toolStripButtonCityAdd_Click(object sender, EventArgs e)
        {
            FormCity formCity = new FormCity(db);
            DialogResult result = formCity.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            City city = new City();
            int city_code;
            bool converted = Int32.TryParse(formCity.textBoxCityCode.Text, out city_code);
            if (converted == false)
                return;
            city.city_code = city_code;
            city.city_name = formCity.textBoxCityName.Text;
            city.city_name_foreign = formCity.textBoxCityNameForeign.Text;
            city.region_code = (formCity.comboBoxRegion.SelectedItem as dynamic).Value;
            city.lishkat_mana_code = (formCity.comboBoxLishka.SelectedItem as dynamic).Value;
            city.muaca_ezorit_code = (formCity.comboBoxMuaca.SelectedItem as dynamic).Value;

            db.Cities.Add(city);
            db.SaveChanges();

            MessageBox.Show("New object added");
        }

        private void toolStripButtonCityEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewCities.SelectedRows.Count > 0)
            {
                int index = dataGridViewCities.SelectedRows[0].Index;
                int city_code;
                bool converted = Int32.TryParse(dataGridViewCities[0, index].Value.ToString(), out city_code);
                if (converted == false)
                    return;

                City city = db.Cities.Find(city_code);

                FormCity formCity = new FormCity(db);
                formCity.textBoxCityCode.Text = city.city_code.ToString();
                formCity.textBoxCityName.Text = city.city_name;
                formCity.textBoxCityNameForeign.Text = city.city_name_foreign;
                formCity.comboBoxRegion.SelectedIndex = formCity.comboBoxRegion.FindStringExact(city.Region.region_name);
                formCity.comboBoxLishka.SelectedIndex = formCity.comboBoxLishka.FindStringExact(city.Lishka.lishka);
                formCity.comboBoxMuaca.SelectedIndex = formCity.comboBoxMuaca.FindStringExact(city.Muaca.muaca_name);

                formCity.textBoxCityCode.Enabled = false;

                DialogResult result = formCity.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                city.city_name = formCity.textBoxCityName.Text;
                city.city_name_foreign = formCity.textBoxCityNameForeign.Text;
                city.region_code = (formCity.comboBoxRegion.SelectedItem as dynamic).Value;
                city.lishkat_mana_code = (formCity.comboBoxLishka.SelectedItem as dynamic).Value;
                city.muaca_ezorit_code = (formCity.comboBoxMuaca.SelectedItem as dynamic).Value;

                db.SaveChanges();

                dataGridViewCities.Refresh(); // обновляем грид

                MessageBox.Show("Object updated");

            }
        }

        private void toolStripButtonCityRemove_Click(object sender, EventArgs e)
        {
            if (dataGridViewCities.SelectedRows.Count > 0)
            {
                int index = dataGridViewCities.SelectedRows[0].Index;
                int city_code = 0;
                bool converted = Int32.TryParse(dataGridViewCities[0, index].Value.ToString(), out city_code);
                if (converted == false)
                    return;

                City city = db.Cities.Find(city_code);
                db.Cities.Remove(city);
                db.SaveChanges();

                MessageBox.Show("Object removed");
            }
        }
        #endregion

        #region Streets
        private void toolStripButtonStreetAdd_Click(object sender, EventArgs e)
        {
            FormStreet formStreet = new FormStreet(db);
            DialogResult result = formStreet.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            Street street = new Street();
            int street_code;
            bool converted = Int32.TryParse(formStreet.textBoxStreetCode.Text, out street_code);
            if (converted == false)
                return;
            street.street_code = street_code;
            street.street_name = formStreet.textBoxStreetName.Text;
            street.street_name_status = formStreet.textBoxNameStatus.Text;
            int official_code;
            converted = Int32.TryParse(formStreet.textBoxOfficialCode.Text, out official_code);
            if (converted == false)
                return;
            street.official_code = official_code;
            street.city_code = (formStreet.comboBoxCity.SelectedItem as dynamic).Value;

            db.Streets.Add(street);
            db.SaveChanges();

            MessageBox.Show("New object added");
        }

        private void toolStripButtonStreetEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewStreets.SelectedRows.Count > 0)
            {
                int index = dataGridViewStreets.SelectedRows[0].Index;
                int street_code;
                bool converted = Int32.TryParse(dataGridViewStreets[0, index].Value.ToString(), out street_code);
                if (converted == false)
                    return;

                Street street = db.Streets.Find(street_code);

                FormStreet formStreet = new FormStreet(db);
                formStreet.textBoxStreetCode.Text = street.street_code.ToString();
                formStreet.textBoxStreetName.Text = street.street_name;
                formStreet.textBoxNameStatus.Text = street.street_name_status;
                formStreet.textBoxOfficialCode.Text = street.official_code.ToString();
                formStreet.comboBoxCity.SelectedIndex = formStreet.comboBoxCity.FindStringExact(street.City.city_name);

                formStreet.textBoxStreetCode.Enabled = false;

                DialogResult result = formStreet.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;
                                
                street.street_name = formStreet.textBoxStreetName.Text;
                street.street_name_status = formStreet.textBoxNameStatus.Text;
                int official_code;
                converted = Int32.TryParse(formStreet.textBoxOfficialCode.Text, out official_code);
                if (converted == false)
                    return;
                street.official_code = official_code;
                street.city_code = (formStreet.comboBoxCity.SelectedItem as dynamic).Value;
                //
                db.SaveChanges();

                dataGridViewStreets.Refresh(); // обновляем грид

                MessageBox.Show("Object updated");
            }
        }

        private void toolStripButtonStreetRemove_Click(object sender, EventArgs e)
        {
            if (dataGridViewStreets.SelectedRows.Count > 0)
            {
                int index = dataGridViewStreets.SelectedRows[0].Index;
                int street_code = 0;
                bool converted = Int32.TryParse(dataGridViewStreets[0, index].Value.ToString(), out street_code);
                if (converted == false)
                    return;

                Street street = db.Streets.Find(street_code);
                db.Streets.Remove(street);
                db.SaveChanges();

                MessageBox.Show("Object removed");
            }
        }
        #endregion
                
    }
}
