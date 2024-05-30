namespace csv_geojson {
    internal static class Program {
        private static void Main() {
            var lines = File.ReadAllLines("gps_data.csv");

            var writer = new StreamWriter("gps_data.geojson");

            writer.WriteLine("{");
            writer.WriteLine("    \"type\": \"FeatureCollection\",");
            writer.WriteLine("    \"features\": [");

            for (var i = 1; i < lines.Length; i++) {
                var columns = lines[i].Split(',');

                var latitude = Convert.ToDouble(columns[0]);
                var longitude = Convert.ToDouble(columns[1]);
                var timestamp = Convert.ToInt64(columns[2]);

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