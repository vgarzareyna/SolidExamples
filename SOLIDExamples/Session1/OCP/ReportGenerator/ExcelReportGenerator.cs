using SOLIDExamples.Session1.Common.Data;
using SOLIDExamples.Session1.Common.Report;

namespace SOLIDExamples.Session1.OCP.ReportGenerator
{
    public class ExcelReportGenerator(string path) : IReportGenerator
    {
        private readonly string path = path;

        public Report GenerateReport(ReportData data)
        {
            ExcelReport report = new();
            // Logic to generate an Excel report...
            Console.WriteLine($"Generating Excel report at: {path} with {data.GetType().Name}.");
            return report;
        }
    }
}
