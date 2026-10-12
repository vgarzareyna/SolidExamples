using SOLIDExamples.Session1.Common.Data;
using SOLIDExamples.Session1.Common.Report;
using SOLIDExamples.Session1.SRP.Calculation;
using SOLIDExamples.Session1.SRP.DataSource;
using SOLIDExamples.Session1.SRP.ReportGenerator;
using SOLIDExamples.Session1.SRP.ReportSender;

namespace SOLIDExamples.Session1.SRP
{
    public class ReportService(ReportService.ReportType reportType, ReportService.SendVia sendVia)
    {
        private readonly ReportType reportType = reportType;
        private readonly SendVia sendVia = sendVia;

        public enum ReportType { Excel, Word }
        public enum SendVia { Email, Teams }

        // Notice the change in the method signature from receiving 4 parameters to just 2.
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
                default:
                    throw new ArgumentOutOfRangeException(nameof(reportType));
            }

            switch (sendVia)
            {
                case SendVia.Email:
                    new EmailSender(emails).SendReport(report); break;
                case SendVia.Teams:
                    new TeamsSender(emails).SendReport(report); break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(sendVia));
            }
        }
    }
}
