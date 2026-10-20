using SOLIDExamples.Session1.Common.Data;
using SOLIDExamples.Session1.Common.Report;

namespace SOLIDExamples.Session1.SRP
{
    public class ExcelReportGenerator(string path)
    {
        private readonly string path = path;

        public ExcelReport GenerateReport(ReportData data)
        {
            ExcelReport report = new();
            // Logic to generate an Excel report...
            Console.WriteLine($"Generating Excel report at: {path} with {data.GetType().Name}.");
            return report;
        }
    }
}
