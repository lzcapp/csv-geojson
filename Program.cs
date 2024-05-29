namespace csv_geojson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("gps_data.csv");

            // Create the output JSON file
            StreamWriter writer = new StreamWriter("gps_data.geojson");

            writer.WriteLine("{");
            writer.WriteLine("    \"type\": \"FeatureCollection\",");
            writer.WriteLine("    \"features\": [");

            for (int i = 1; i < lines.Length; i++) // Skip header row
            {
                string[] columns = lines[i].Split(',');

                double latitude = Convert.ToDouble(columns[0]);
                double longitude = Convert.ToDouble(columns[1]);
                long timestamp = Convert.ToInt64(columns[2]);

                writer.WriteLine("        {");
                writer.WriteLine("            \"type\": \"Feature\",");
                writer.WriteLine("            \"geometry\": {");
                writer.WriteLine("                \"type\": \"Point\",");
                writer.WriteLine("                \"coordinates\": [");
                writer.WriteLine("                    " + longitude + ",");
                writer.WriteLine("                    " + latitude);
                writer.WriteLine("                ]");
                writer.WriteLine("            },");
                writer.WriteLine("            \"properties\": {");
                writer.WriteLine("                \"timestamp\": " + timestamp);
                writer.WriteLine("            }");
                writer.WriteLine("        },");
            }

            writer.WriteLine("    ]");
            writer.WriteLine("}");

            writer.Flush();
            writer.Close();
        }
    }
}
