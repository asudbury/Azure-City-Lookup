using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Azure_City_Lookup
{
    public static class DataService
    {
        public static IEnumerable<City> GetCities(
            string cityData,
            string query)
        {
            JsonTextReader reader = new JsonTextReader(new StringReader(cityData));

            List<City> cities = new List<City>();

            City city = new City();

            while (reader.Read())
            {
                /// country

                if (reader.TokenType == JsonToken.PropertyName &&
                    reader.Value.ToString() == "c")
                {
                    reader.Read();

                    city.Country = reader.Value.ToString();
                }

                /// name of city

                if (reader.TokenType == JsonToken.PropertyName &&
                    reader.Value.ToString() == "n")
                {
                    reader.Read();

                    string value = reader.Value.ToString();

                    if (value.ToLower().StartsWith(query))
                    {
                        city.Name = value;
                        cities.Add(city);
                        city = new City();
                    }
                }
            }

            return cities;
        }

        public static string GetJson(IEnumerable<City> cities)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.WriteStartArray();

                foreach (City item in cities.OrderBy(x => x.Name))
                {
                    writer.WriteStartObject();
                    writer.WritePropertyName("c");
                    writer.WriteValue(item.Country);
                    writer.WritePropertyName("n");
                    writer.WriteValue(item.Name);
                    writer.WriteEndObject();
                }

                writer.WriteEndArray();
            }

            return sb.ToString();
        }
    }
}
