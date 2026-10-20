using SOLIDExamples.Session1.Common.Data;
using SOLIDExamples.Session1.Common.Report;
using SOLIDExamples.Session1.SRP_NewReqs.Calculation;
using SOLIDExamples.Session1.SRP_NewReqs.DataSource;
using SOLIDExamples.Session1.SRP_NewReqs.ReportGenerator;
using SOLIDExamples.Session1.SRP_NewReqs.ReportSender;

namespace SOLIDExamples.Session1.SRP_NewReqs
{
    public class ReportService(ReportService.ReportType reportType, ReportService.SendVia sendVia)
    {
        private readonly ReportType reportType = reportType;
        private readonly SendVia sendVia = sendVia;

        public enum ReportType { Excel, Word }
        public enum SendVia { Email, Teams }

        // New requirements: two constructor parameters and two switches.
        // If we were to add PDF reports, it would mean updating this class again.
        public void Run(string folder, List<string> emails)
        {
            List<string> paths = [$"{folder}/file1.csv", $"{folder}/file2.csv", $"{folder}/file3.csv"];
            List<IntakeData> intakeDataList = [.. paths.Select(path => new CsvDataSource(path).GetData())];

            ReportData reportData = new ReportCalculator().Calculate(intakeDataList);

            Report report;
            switch (reportType)
            {
                case ReportType.Excel:
                    report = new ExcelReportGenerator($"{folder}/out/report.xlsx").GenerateReport(reportData); break;
                case ReportType.Word:
                    report = new WordReportGenerator($"{folder}/out/report.docx").GenerateReport(reportData); break;
                default: throw new ArgumentOutOfRangeException(nameof(reportType));
            }

            switch (sendVia)
            {
                case SendVia.Email:
                    new EmailSender(emails).SendReport(report); break;
                case SendVia.Teams:
                    new TeamsSender(emails).SendReport(report); break;
                default: throw new ArgumentOutOfRangeException(nameof(sendVia));
            }
        }
    }
}
