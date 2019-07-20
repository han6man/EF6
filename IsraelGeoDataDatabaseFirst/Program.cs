using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsraelGeoDataDatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (IsraelGeoDataDB db = new IsraelGeoDataDB())
            {
                var cities = db.Cities;
                foreach (City c in cities)
                    Console.WriteLine("{0}.{1} - {2}", c.city_code, c.city_name, c.city_name_foreign);
            }
        }
    }
}
