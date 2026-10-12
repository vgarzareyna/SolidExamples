using SOLIDExamples.Session1.Common.Report;

namespace SOLIDExamples.Session1.OCP.ReportSender
{
    public interface IReportSender
    {
        void SendReport(Report report);
    }
}
