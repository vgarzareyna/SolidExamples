using SOLIDExamples.Session1.Common.Data;
using SOLIDExamples.Session1.Common.Report;

namespace SOLIDExamples.Session1.Initial
{
    public class ReportService
    {
        public enum ReportType { Excel, Word }
        public enum SendVia { Email, Teams }

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

        private WordReport GenerateWordReport(string path, ReportData data)
        {
            WordReport report = new();
            // Logic to generate a Word report...
            Console.WriteLine($"Generating Word report at: {path} with {data.GetType().Name}.");
            return report;
        }

        private void SendReportViaEmail(List<string> emails, Report report)
        {
            // Logic to send the report via Email...
            Console.WriteLine($"Sending report '{report.GetType().Name}' to users: {string.Join(", ", emails)} via Email.");
        }

        private void SendReportViaTeams(List<string> users, Report report)
        {
            // Logic to send the report via Teams...
            Console.WriteLine($"Sending report '{report.GetType().Name}' to users: {string.Join(", ", users)} via Teams.");
        }

        private ReportData CalculateReportData(List<IntakeData> intakeData)
        {
            ReportData reportData = new();
            // Logic to calculate the report data...
            Console.WriteLine($"Calculating report data from {intakeData.Count} sources.");
            return reportData;
        }

        public void Run(string folder, List<string> emails, ReportType reportType, SendVia sendVia)
        {
            List<string> paths = [$"{folder}/file1.csv", $"{folder}/file2.csv", $"{folder}/file3.csv"];
            List<IntakeData> intakeDataList = [.. paths.Select(GetDataFromCsv)];

            ReportData reportData = CalculateReportData(intakeDataList);

            Report report;
            switch (reportType)
            {
                case ReportType.Excel:
                    report = GenerateExcelReport($"{folder}/out/report.xlsx", reportData); break;
                case ReportType.Word:
                    report = GenerateWordReport($"{folder}/out/report.docx", reportData); break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(reportType));
            }

            switch (sendVia)
            {
                case SendVia.Email:
                    SendReportViaEmail(emails, report); break;
                case SendVia.Teams:
                    List<string> users = [.. emails.Select(email => $"@{email.Split('@')[0]}")];
                    SendReportViaTeams(users, report); break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(sendVia));
            }
        }
    }
}
