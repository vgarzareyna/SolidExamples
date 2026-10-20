using SOLIDExamples.Session1.Common.Data;
using SOLIDExamples.Session1.Common.Report;

namespace SOLIDExamples.Session1.Initial
{
    public class ReportService
    {

        private IntakeData GetDataFromCsv(string path)
        {
            IntakeData data = new();
            // Logic to get data from the CSV file...
            Console.WriteLine($"Getting data from CSV file at: {path}.");
            return data;
        }

        private ExcelReport GenerateExcelReport(string path, ReportData data)
        {
            ExcelReport report = new();
            // Logic to generate an Excel report...
            Console.WriteLine($"Generating Excel report at: {path} with {data.GetType().Name}.");
            return report;
        }

        private void SendReportViaEmail(List<string> emails, Report report)
        {
            // Logic to send the report via Email...
            Console.WriteLine($"Sending report '{report.GetType().Name}' to users: {string.Join(", ", emails)} via Email.");
        }

        private ReportData CalculateReportData(List<IntakeData> intakeData)
        {
            ReportData reportData = new();
            // Logic to calculate the report data...
            Console.WriteLine($"Calculating report data from {intakeData.Count} sources.");
            return reportData;
        }

        public void Run(string folder, List<string> emails)
        {
            List<string> paths = [$"{folder}/file1.csv", $"{folder}/file2.csv", $"{folder}/file3.csv"];
            List<IntakeData> intakeDataList = [.. paths.Select(GetDataFromCsv)];
            ReportData reportData = CalculateReportData(intakeDataList);
            Report report = GenerateExcelReport($"{folder}/out/report.xlsx", reportData);
            SendReportViaEmail(emails, report);
        }
    }
}
