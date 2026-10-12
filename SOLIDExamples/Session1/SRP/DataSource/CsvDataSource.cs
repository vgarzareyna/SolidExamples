using SOLIDExamples.Session1.Common.Data;

namespace SOLIDExamples.Session1.SRP.DataSource
{
    public class CsvDataSource(string path)
    {
        private readonly string path = path;

        public IntakeData GetData()
        {
            IntakeData data = new();
            // Logic to get data from the CSV file...
            Console.WriteLine($"Getting data from CSV file at: {path}.");
            return data;
        }
    }
}
