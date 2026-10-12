using SOLIDExamples.Session1.Common.Data;
using SOLIDExamples.Session1.Common.Report;
using SOLIDExamples.Session1.OCP.Calculation;
using SOLIDExamples.Session1.OCP.DataSource;
using SOLIDExamples.Session1.OCP.ReportGenerator;
using SOLIDExamples.Session1.OCP.ReportSender;

namespace SOLIDExamples.Session1.OCP
{
    public class ReportService(List<IDataSource> dataSources, IReportGenerator reportGenerator, IReportSender reportSender)
    {
        private readonly List<IDataSource> dataSources = dataSources;
        private readonly IReportGenerator reportGenerator = reportGenerator;
        private readonly IReportSender reportSender = reportSender;

        public void Run()
        {
            List<IntakeData> intakeDataList = [.. dataSources.Select(dataSource => dataSource.GetData())];
            ReportData reportData = new ReportCalculator().Calculate(intakeDataList);
            Report report = reportGenerator.GenerateReport(reportData);
            reportSender.SendReport(report);
        }
    }
}
