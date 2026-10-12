using SOLIDExamples.Session1.OCP.DataSource;
using SOLIDExamples.Session1.OCP.ReportGenerator;
using SOLIDExamples.Session1.OCP.ReportSender;

namespace SOLIDExamples.Session1.OCP
{
    public enum ReportType { Excel, Word }
    public enum SendVia { Email, Teams }

    public static class ReportServiceFactory
    {
        public static ReportService Create(string folder, List<string> emails, ReportType reportType, SendVia sendVia)
        {
            List<IDataSource> dataSources =
            [
                new CsvDataSource($"{folder}/file1.csv"),
                new CsvDataSource($"{folder}/file2.csv"),
                new CsvDataSource($"{folder}/file3.csv"),
            ];

            IReportGenerator reportGenerator = reportType switch
            {
                ReportType.Excel => new ExcelReportGenerator($"{folder}/out/report.xlsx"),
                ReportType.Word => new WordReportGenerator($"{folder}/out/report.docx"),
                _ => throw new ArgumentOutOfRangeException(nameof(reportType)),
            };

            IReportSender reportSender = sendVia switch
            {
                SendVia.Email => new EmailSender(emails),
                SendVia.Teams => new TeamsSender(emails),
                _ => throw new ArgumentOutOfRangeException(nameof(sendVia)),
            };

            return new ReportService(dataSources, reportGenerator, reportSender);
        }
    }
}
