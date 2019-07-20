using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IsraelGeoDataCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            //LoadCitiesFromXmlByXmlTextReader(@"CitiesDataXMLFile.xml");
            LoadCitiesFromXmlByXmlDocument(@"CitiesDataXMLFile.xml");
            //LoadStreetsFromXmlByXmlDocument(@"StreetsDataXMLFile.xml");
            LoadStreetsSynonymsFromXmlByXmlDocument(@"StreetsDataSynonymsXMLFile.xml");
            Console.WriteLine("Press any key to exit");
            Console.Read();
        }

        private static void LoadCitiesFromXmlByXmlDocument(string fileName)
        {
            XmlDocument xmlDocument = new XmlDocument();

            List<Region> regions = new List<Region>();
            List<Lishka> lishkot = new List<Lishka>();
            List<Muaca> muacot = new List<Muaca>();
            List<City> cities = new List<City>();

            Console.WriteLine("Loading XML " + fileName);
            xmlDocument.Load(fileName);
            Console.WriteLine(fileName + " XML Loaded");

            Console.WriteLine("Parsing XML");
            foreach (XmlNode node in xmlDocument.DocumentElement)
            {
                //foreach (XmlNode child in node.ChildNodes)
                //{
                //    
                //}

                Region region = new Region
                {
                    region_code = int.Parse(node.ChildNodes[4].InnerText),
                    region_name = node.ChildNodes[5].InnerText.Trim()
                };
                if (!regions.Exists(x => x.region_code == region.region_code))
                {
                    regions.Add(region);
                }

                Lishka lishka = new Lishka
                {
                    lishkat_mana_code = int.Parse(node.ChildNodes[6].InnerText),
                    lishka = node.ChildNodes[7].InnerText.Trim()
                };
                if (!lishkot.Exists(x => x.lishkat_mana_code == lishka.lishkat_mana_code))
                {
                    lishkot.Add(lishka);
                }

                Muaca muaca = new Muaca
                {
                    muaca_ezorit_code = int.Parse(node.ChildNodes[8].InnerText),
                    muaca_name = node.ChildNodes[9].InnerText.Trim()
                };
                if (!muacot.Exists(x => x.muaca_ezorit_code == muaca.muaca_ezorit_code))
                {
                    muacot.Add(muaca);
                }

                City city = new City
                {
                    //Table = node.ChildNodes[0].InnerText,
                    city_code = int.Parse(node.ChildNodes[1].InnerText),
                    city_name = node.ChildNodes[2].InnerText.Trim(),
                    city_name_foreign = node.ChildNodes[3].InnerText.Trim(),
                    region_code = int.Parse(node.ChildNodes[4].InnerText),
                    //Region_name = node.ChildNodes[5].InnerText,
                    lishkat_mana_code = int.Parse(node.ChildNodes[6].InnerText),
                    //Lishka_Name = node.ChildNodes[7].InnerText,
                    muaca_ezorit_code = int.Parse(node.ChildNodes[8].InnerText),
                    //Muaca_Izorit_Name = node.ChildNodes[9].InnerText
                };
                if (!cities.Exists(x => x.city_code == city.city_code))
                {
                    cities.Add(city);
                }

                /*
                if (db.Regions.Find(region.region_code) == null)
                    db.Regions.Add(region);
                //db.SaveChanges();

                if (db.Lishkot.Find(lishka.lishkat_mana_code) == null)
                    db.Lishkot.Add(lishka);
                //db.SaveChanges();

                if (muaca.muaca_ezorit_code != 0 || db.Muacot.Find(muaca.muaca_ezorit_code) == null)
                    db.Muacot.Add(muaca);
                //db.SaveChanges();

                if (db.Cities.Find(city.city_code) == null)
                    db.Cities.Add(city);
                //db.SaveChanges();
                */
            }
            Console.WriteLine("XML Parsed");

            Console.WriteLine("Conecting to db");
            using (IsraelGeoDataDB db = new IsraelGeoDataDB())
            {
                Console.WriteLine("Ading data to DB");

                Console.WriteLine("Ading regions");
                db.Regions.AddRange(regions);
                db.SaveChanges();
                Console.WriteLine("Regions Added");

                Console.WriteLine("Ading lishkot");
                db.Lishkot.AddRange(lishkot);
                db.SaveChanges();
                Console.WriteLine("Lishkot Added");

                Console.WriteLine("Ading muacot");
                db.Muacot.AddRange(muacot);
                db.SaveChanges();
                Console.WriteLine("Muacot Added");

                Console.WriteLine("Ading cities");
                db.Cities.AddRange(cities);
                db.SaveChanges();
                Console.WriteLine("Cities Added");
            }
        }

        private static void LoadStreetsFromXmlByXmlDocument(string fileName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            string table;
            int city_code;
            string city_name;
            int street_code;
            string street_name;

            foreach (XmlNode node in xmlDocument.DocumentElement)
            {
                //foreach (XmlNode child in node.ChildNodes)
                //{
                //    
                //}

                table = node.ChildNodes[0].InnerText;
                city_code = int.Parse(node.ChildNodes[1].InnerText);
                city_name = node.ChildNodes[2].InnerText;
                street_code = int.Parse(node.ChildNodes[3].InnerText);
                street_name = node.ChildNodes[4].InnerText;
            }
        }

        private static void LoadStreetsSynonymsFromXmlByXmlDocument(string fileName)
        {
            XmlDocument xmlDocument = new XmlDocument();

            Console.WriteLine("Loading XML " + fileName);
            xmlDocument.Load(fileName);
            Console.WriteLine(fileName + " XML Loaded");

            List<Street> streets = new List<Street>();

            Console.WriteLine("Parsing XML");
            foreach (XmlNode node in xmlDocument.DocumentElement)
            {
                //foreach (XmlNode child in node.ChildNodes)
                //{
                //    
                //}
                Street street = new Street
                {
                    //region_code = int.Parse(node.ChildNodes[0].InnerText),
                    //region_name = node.ChildNodes[1].InnerText,
                    city_code = int.Parse(node.ChildNodes[2].InnerText),
                    //city_name = node.ChildNodes[3].InnerText,
                    street_code = int.Parse(node.ChildNodes[4].InnerText),
                    street_name = node.ChildNodes[5].InnerText,
                    street_name_status = node.ChildNodes[6].InnerText,
                    official_code = int.Parse(node.ChildNodes[7].InnerText)
                };
                if (!streets.Exists(x => x.street_code == street.street_code))
                {
                    streets.Add(street);
                }

            }
            Console.WriteLine("XML Parsed");

            Console.WriteLine("Conecting to db");
            using (IsraelGeoDataDB db = new IsraelGeoDataDB())
            {
                Console.WriteLine("Ading streets");
                db.Streets.AddRange(streets);
                db.SaveChanges();
                Console.WriteLine("Streets Added");
            }
        }

        private static void LoadCitiesFromXmlByXmlTextReader(string fileName)
        {
            XmlTextReader readerCities = new XmlTextReader(fileName);
            string table;
            int city_code;
            string city_name;
            string city_name_foreign;
            int region_code;
            string region_name;
            int סמל_לשכת_מנא;
            string לשכה;
            int סמל_מועצה_איזורית;
            string שם_מועצה;

            while (true)
            {
                readerCities.ReadToFollowing("ROW");

                readerCities.ReadToFollowing("טבלה");
                if (readerCities.NodeType == XmlNodeType.None)
                {
                    break;
                }
                table = readerCities.ReadElementContentAsString();

                readerCities.ReadToFollowing("סמל_ישוב");
                city_code = readerCities.ReadElementContentAsInt();

                readerCities.ReadToFollowing("שם_ישוב");
                city_name = readerCities.ReadElementContentAsString();

                readerCities.ReadToFollowing("שם_ישוב_לועזי");
                city_name_foreign = readerCities.ReadElementContentAsString();

                readerCities.ReadToFollowing("סמל_נפה");
                region_code = readerCities.ReadElementContentAsInt();

                readerCities.ReadToFollowing("שם_נפה");
                region_name = readerCities.ReadElementContentAsString();

                readerCities.ReadToFollowing("סמל_לשכת_מנא");
                סמל_לשכת_מנא = readerCities.ReadElementContentAsInt();

                readerCities.ReadToFollowing("לשכה");
                לשכה = readerCities.ReadElementContentAsString();

                readerCities.ReadToFollowing("סמל_מועצה_איזורית");
                סמל_מועצה_איזורית = readerCities.ReadElementContentAsInt();

                readerCities.ReadToFollowing("שם_מועצה");
                שם_מועצה = readerCities.ReadElementContentAsString();
            }
        }
    }
}
