using SOLIDExamples.Session1.Common.Data;
using SOLIDExamples.Session1.Common.Report;

namespace SOLIDExamples.Session1.SRP_NewReqs.ReportGenerator
{
    public class WordReportGenerator(string path)
    {
        private readonly string path = path;

        public WordReport GenerateReport(ReportData data)
        {
            WordReport report = new();
            // Logic to generate a Word report...
            Console.WriteLine($"Generating Word report at: {path} with {data.GetType().Name}.");
            return report;
        }
    }
}
