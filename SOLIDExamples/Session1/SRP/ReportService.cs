using SOLIDExamples.Session1.Common.Data;
using SOLIDExamples.Session1.Common.Report;

namespace SOLIDExamples.Session1.SRP
{
    public class ReportService
    {
        public void Run(string folder, List<string> emails)
        {
            List<string> paths = [$"{folder}/file1.csv", $"{folder}/file2.csv", $"{folder}/file3.csv"];
            List<IntakeData> intakeDataList = [.. paths.Select(path => new CsvDataSource(path).GetData())];

            ReportData reportData = new ReportCalculator().Calculate(intakeDataList);

            Report report = new ExcelReportGenerator($"{folder}/out/report.xlsx").GenerateReport(reportData);
            new EmailSender(emails).SendReport(report);
        }
    }
}
