namespace csv_geojson {
    internal static class Program {
        private static void Main() {
            var lines = File.ReadAllLines("gps_data.csv");

            var writer = new StreamWriter("gps_data.geojson");

            writer.WriteLine("{");
            writer.WriteLine("\t\"type\": \"FeatureCollection\",");
            writer.WriteLine("\t\"features\": [");

            for (var i = 1; i < lines.Length; i++)
            {
                var columns = lines[i].Split(',');

                var latitude = Convert.ToDouble(columns[0]);
                var longitude = Convert.ToDouble(columns[1]);
                var altitude = Convert.ToDecimal(columns[2]);
                var timestamp = Convert.ToInt64(columns[3]);

                writer.WriteLine("\t\t{");
                writer.WriteLine("\t\t\t\"type\": \"Feature\",");
                writer.WriteLine("\t\t\t\"geometry\": {");
                writer.WriteLine("\t\t\t\t\"type\": \"Point\",");
                writer.WriteLine("\t\t\t\t\"coordinates\": [");
                writer.WriteLine("\t\t\t\t\t" + longitude + ",");
                writer.WriteLine("\t\t\t\t\t" + latitude);
                writer.WriteLine("\t\t\t\t]");
                writer.WriteLine("\t\t\t},");
                writer.WriteLine("\t\t\t\"properties\": {");
                writer.WriteLine("\t\t\t\t\"altitude\": " + altitude + ",");
                writer.WriteLine("\t\t\t\t\"timestamp\": " + timestamp);
                writer.WriteLine("\t\t\t}");

                if (i != lines.Length - 1) {
                    writer.WriteLine("\t\t},");
                } else {
                    writer.WriteLine("\t\t}");
                }
            }

            writer.WriteLine("\t]");
            writer.WriteLine("}");

            writer.Flush();
            writer.Close();
        }
    }
}