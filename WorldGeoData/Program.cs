using MDH.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WorldGeoData
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SplashScreen.ShowSplashScreen();
            Application.DoEvents();

            //using (WaitForm waitForm = new WaitForm(UploadData))
            //{
            //    waitForm.ShowDialog();
            //}            

            //LoadCitiesFromXmlByXmlDocument(@"CitiesDataXMLFile.xml");
            //LoadStreetsSynonymsFromXmlByXmlDocument(@"StreetsDataSynonymsXMLFile.xml");

            Application.Run(new FormMain());
        }

        private static void UploadData()
        {
            LoadCitiesFromXmlByXmlDocument(@"CitiesDataXMLFile.xml");
            LoadStreetsSynonymsFromXmlByXmlDocument(@"StreetsDataSynonymsXMLFile.xml");
        }

        private static void LoadCitiesFromXmlByXmlDocument(string fileName)
        {
            XmlDocument xmlDocument = new XmlDocument();

            List<Country_Region> regions = new List<Country_Region>();
            List<Lishkat_Mana> lishkot = new List<Lishkat_Mana>();
            List<Regional_Council> muacot = new List<Regional_Council>();
            List<City> cities = new List<City>();

            SplashScreen.SetStatus("Loading XML " + fileName);
            xmlDocument.Load(fileName);
            SplashScreen.SetStatus(fileName + " XML Loaded");

            SplashScreen.SetStatus("Parsing XML");
            foreach (XmlNode node in xmlDocument.DocumentElement)
            {
                //foreach (XmlNode child in node.ChildNodes)
                //{
                //    
                //}

                Country_Region region = new Country_Region
                {
                    Country_Region_Code = int.Parse(node.ChildNodes[4].InnerText),
                    Country_Region_Name = node.ChildNodes[5].InnerText.Trim()
                };
                if (!regions.Exists(x => x.Country_Region_Code == region.Country_Region_Code))
                {
                    regions.Add(region);
                }

                Lishkat_Mana lishka = new Lishkat_Mana
                {
                    Lishkat_Mana_Code = int.Parse(node.ChildNodes[6].InnerText),
                    Lishkat_Mana_Name = node.ChildNodes[7].InnerText.Trim()
                };
                if (!lishkot.Exists(x => x.Lishkat_Mana_Code == lishka.Lishkat_Mana_Code))
                {
                    lishkot.Add(lishka);
                }

                Regional_Council muaca = new Regional_Council
                {
                    Regional_Council_Code = int.Parse(node.ChildNodes[8].InnerText),
                    Regional_Council_Name = node.ChildNodes[9].InnerText.Trim()
                };
                if (!muacot.Exists(x => x.Regional_Council_Code == muaca.Regional_Council_Code))
                {
                    muacot.Add(muaca);
                }

                City city = new City
                {
                    //Table = node.ChildNodes[0].InnerText,
                    City_Code = int.Parse(node.ChildNodes[1].InnerText),
                    City_Name = node.ChildNodes[2].InnerText.Trim(),
                    City_Name_En = node.ChildNodes[3].InnerText.Trim(),
                    Country_Region_Code = int.Parse(node.ChildNodes[4].InnerText),
                    //Region_name = node.ChildNodes[5].InnerText,
                    Lishkat_Mana_Code = int.Parse(node.ChildNodes[6].InnerText),
                    //Lishka_Name = node.ChildNodes[7].InnerText,
                    Regional_Council_Code = int.Parse(node.ChildNodes[8].InnerText),
                    //Muaca_Izorit_Name = node.ChildNodes[9].InnerText
                };
                if (!cities.Exists(x => x.City_Code == city.City_Code))
                {
                    cities.Add(city);
                }

                /*
                if (db.Country_Regions.Find(region.Country_Region_Code) == null)
                    db.Country_Regions.Add(region);
                //db.SaveChanges();

                if (db.Lishkot_Mana.Find(lishka.Lishkat_Mana_Code) == null)
                    db.Lishkot_Mana.Add(lishka);
                //db.SaveChanges();

                if (muaca.Regional_Council_Code != 0 || db.Regional_Councils.Find(muaca.Regional_Council_Code) == null)
                    db.Regional_Councils.Add(muaca);
                //db.SaveChanges();

                if (db.Cities.Find(city.City_Code) == null)
                    db.Cities.Add(city);
                //db.SaveChanges();
                */
            }
            SplashScreen.SetStatus("XML Parsed");

            SplashScreen.SetStatus("Conecting to db");
            using (WorldGeoDataDB db = new WorldGeoDataDB())
            {
                SplashScreen.SetStatus("Ading data to DB");

                SplashScreen.SetStatus("Ading regions");
                db.Country_Regions.AddRange(regions);
                db.SaveChanges();
                SplashScreen.SetStatus("Country_Regions Added");

                SplashScreen.SetStatus("Ading lishkot");
                db.Lishkot_Mana.AddRange(lishkot);
                db.SaveChanges();
                SplashScreen.SetStatus("Lishkot_Mana Added");

                SplashScreen.SetStatus("Ading muacot");
                db.Regional_Councils.AddRange(muacot);
                db.SaveChanges();
                SplashScreen.SetStatus("Muacot Added");

                SplashScreen.SetStatus("Ading cities");
                db.Cities.AddRange(cities);
                db.SaveChanges();
                SplashScreen.SetStatus("Cities Added");
            }
        }
        private static void LoadStreetsSynonymsFromXmlByXmlDocument(string fileName)
        {
            XmlDocument xmlDocument = new XmlDocument();

            SplashScreen.SetStatus("Loading XML " + fileName);
            xmlDocument.Load(fileName);
            SplashScreen.SetStatus(fileName + " XML Loaded");

            List<Street> streets = new List<Street>();

            SplashScreen.SetStatus("Parsing XML");
            foreach (XmlNode node in xmlDocument.DocumentElement)
            {
                //foreach (XmlNode child in node.ChildNodes)
                //{
                //    
                //}
                Street street = new Street
                {
                    //Country_Region_Code = int.Parse(node.ChildNodes[0].InnerText),
                    //Country_Region_Name = node.ChildNodes[1].InnerText,
                    City_Code = int.Parse(node.ChildNodes[2].InnerText),
                    //City_Name = node.ChildNodes[3].InnerText,
                    Street_Code = int.Parse(node.ChildNodes[4].InnerText),
                    Street_Name = node.ChildNodes[5].InnerText,
                    Street_Name_Status = node.ChildNodes[6].InnerText,
                    Street_Official_Code = int.Parse(node.ChildNodes[7].InnerText)
                };
                if (!streets.Exists(x => x.Street_Code == street.Street_Code))
                {
                    streets.Add(street);
                }

            }
            SplashScreen.SetStatus("XML Parsed");

            SplashScreen.SetStatus("Conecting to db");
            using (WorldGeoDataDB db = new WorldGeoDataDB())
            {
                SplashScreen.SetStatus("Ading streets");
                db.Streets.AddRange(streets);
                db.SaveChanges();
                SplashScreen.SetStatus("Streets Added");
            }
        }


    }
}
