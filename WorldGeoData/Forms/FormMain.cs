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

namespace WorldGeoData
{
    public partial class FormMain : Form
    {
        private bool m_bLayoutCalled = false;
        private DateTime m_dt;

        WorldGeoDataDB db;

        #region Constructor
        public FormMain()
        {
            InitializeComponent();
            InitializeDataSources();
        }

        private void InitializeDataSources()
        {
            db = new WorldGeoDataDB();

            SplashScreen.SetStatus("Loading Cities");
            db.View_Cities.Load();
            db.Cities.Load();
            dataGridViewCities.DataSource = db.Cities.Local.ToBindingList();

            SplashScreen.SetStatus("Loading Streets");
            db.View_Streets.Load();
            db.View_Streets_With_Synonyms.Load();
            db.Streets.Load();
            dataGridViewStreets.DataSource = db.Streets.Local.ToBindingList();

            SplashScreen.SetStatus("Loading Regions");
            db.Country_Regions.Load();
            dataGridViewRegions.DataSource = db.Country_Regions.Local.ToBindingList();

            SplashScreen.SetStatus("Loading Lishkot");
            db.Lishkot_Mana.Load();
            dataGridViewLishkot.DataSource = db.Lishkot_Mana.Local.ToBindingList();

            SplashScreen.SetStatus("Loading Regional_Councils");
            db.Regional_Councils.Load();
            dataGridViewMuacot.DataSource = db.Regional_Councils.Local.ToBindingList();
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

            Country_Region country_Region = new Country_Region();
            int region_code;
            bool converted = Int32.TryParse(formRegion.textBoxRegionCode.Text, out region_code);
            if (converted == false)
                return;
            country_Region.Country_Region_Code = region_code;
            country_Region.Country_Region_Name = formRegion.textBoxRegionName.Text;

            db.Country_Regions.Add(country_Region);
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

                Country_Region country_Region = db.Country_Regions.Find(region_code);

                FormRegion formRegion = new FormRegion();
                formRegion.textBoxRegionCode.Text = country_Region.Country_Region_Code.ToString();
                formRegion.textBoxRegionName.Text = country_Region.Country_Region_Name;
                formRegion.textBoxRegionCode.Enabled = false;

                DialogResult result = formRegion.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                country_Region.Country_Region_Name = formRegion.textBoxRegionName.Text;

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

                Country_Region country_Region = db.Country_Regions.Find(region_code);
                db.Country_Regions.Remove(country_Region);
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

            Lishkat_Mana lishka = new Lishkat_Mana();
            int lishkat_mana_code;
            bool converted = Int32.TryParse(formLishka.textBoxLishkaCode.Text, out lishkat_mana_code);
            if (converted == false)
                return;
            lishka.Lishkat_Mana_Code = lishkat_mana_code;
            lishka.Lishkat_Mana_Name = formLishka.textBoxLishkaName.Text;

            db.Lishkot_Mana.Add(lishka);
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

                Lishkat_Mana lishka = db.Lishkot_Mana.Find(lishkat_mana_code);

                FormLishka formLishka = new FormLishka();
                formLishka.textBoxLishkaCode.Text = lishka.Lishkat_Mana_Code.ToString();
                formLishka.textBoxLishkaName.Text = lishka.Lishkat_Mana_Name;
                formLishka.textBoxLishkaCode.Enabled = false;

                DialogResult result = formLishka.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                lishka.Lishkat_Mana_Name = formLishka.textBoxLishkaName.Text;

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

                Lishkat_Mana lishka = db.Lishkot_Mana.Find(lishkat_mana_code);
                db.Lishkot_Mana.Remove(lishka);
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

            Regional_Council muaca = new Regional_Council();
            int muaca_ezorit_code;
            bool converted = Int32.TryParse(formMuaca.textBoxMuacaCode.Text, out muaca_ezorit_code);
            if (converted == false)
                return;
            muaca.Regional_Council_Code = muaca_ezorit_code;
            muaca.Regional_Council_Name = formMuaca.textBoxMuacaName.Text;

            db.Regional_Councils.Add(muaca);
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

                Regional_Council muaca = db.Regional_Councils.Find(muaca_ezorit_code);

                FormMuaca formMuaca = new FormMuaca();
                formMuaca.textBoxMuacaCode.Text = muaca.Regional_Council_Code.ToString();
                formMuaca.textBoxMuacaName.Text = muaca.Regional_Council_Name;
                formMuaca.textBoxMuacaCode.Enabled = false;

                DialogResult result = formMuaca.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                muaca.Regional_Council_Name = formMuaca.textBoxMuacaName.Text;

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

                Regional_Council muaca = db.Regional_Councils.Find(muaca_ezorit_code);
                db.Regional_Councils.Remove(muaca);
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
            city.City_Code = city_code;
            city.City_Name = formCity.textBoxCityName.Text;
            city.City_Name_En = formCity.textBoxCityNameForeign.Text;
            city.Country_Region_Code = (formCity.comboBoxRegion.SelectedItem as dynamic).Value;
            city.Lishkat_Mana_Code = (formCity.comboBoxLishka.SelectedItem as dynamic).Value;
            city.Regional_Council_Code = (formCity.comboBoxMuaca.SelectedItem as dynamic).Value;

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
                formCity.textBoxCityCode.Text = city.City_Code.ToString();
                formCity.textBoxCityName.Text = city.City_Name;
                formCity.textBoxCityNameForeign.Text = city.City_Name_En;
                formCity.comboBoxRegion.SelectedIndex = formCity.comboBoxRegion.FindStringExact(city.Country_Region.Country_Region_Name);
                formCity.comboBoxLishka.SelectedIndex = formCity.comboBoxLishka.FindStringExact(city.Lishkat_Mana.Lishkat_Mana_Name);
                formCity.comboBoxMuaca.SelectedIndex = formCity.comboBoxMuaca.FindStringExact(city.Regional_Council.Regional_Council_Name);

                formCity.textBoxCityCode.Enabled = false;

                DialogResult result = formCity.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;

                city.City_Name = formCity.textBoxCityName.Text;
                city.City_Name_En = formCity.textBoxCityNameForeign.Text;
                city.Country_Region_Code = (formCity.comboBoxRegion.SelectedItem as dynamic).Value;
                city.Lishkat_Mana_Code = (formCity.comboBoxLishka.SelectedItem as dynamic).Value;
                city.Regional_Council_Code = (formCity.comboBoxMuaca.SelectedItem as dynamic).Value;

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
            street.Street_Code = street_code;
            street.Street_Name = formStreet.textBoxStreetName.Text;
            street.Street_Name_Status = formStreet.textBoxNameStatus.Text;
            int official_code;
            converted = Int32.TryParse(formStreet.textBoxOfficialCode.Text, out official_code);
            if (converted == false)
                return;
            street.Street_Official_Code = official_code;
            street.City_Code = (formStreet.comboBoxCity.SelectedItem as dynamic).Value;

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
                formStreet.textBoxStreetCode.Text = street.Street_Code.ToString();
                formStreet.textBoxStreetName.Text = street.Street_Name;
                formStreet.textBoxNameStatus.Text = street.Street_Name_Status;
                formStreet.textBoxOfficialCode.Text = street.Street_Official_Code.ToString();
                formStreet.comboBoxCity.SelectedIndex = formStreet.comboBoxCity.FindStringExact(street.City.City_Name);

                formStreet.textBoxStreetCode.Enabled = false;

                DialogResult result = formStreet.ShowDialog(this);

                if (result == DialogResult.Cancel)
                    return;
                                
                street.Street_Name = formStreet.textBoxStreetName.Text;
                street.Street_Name_Status = formStreet.textBoxNameStatus.Text;
                int official_code;
                converted = Int32.TryParse(formStreet.textBoxOfficialCode.Text, out official_code);
                if (converted == false)
                    return;
                street.Street_Official_Code = official_code;
                street.City_Code = (formStreet.comboBoxCity.SelectedItem as dynamic).Value;
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
