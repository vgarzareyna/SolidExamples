using SOLIDExamples.Session1.Common.Data;
using SOLIDExamples.Session1.Common.Report;

namespace SOLIDExamples.Session1.OCP.ReportGenerator
{
    public interface IReportGenerator
    {
        Report GenerateReport(ReportData data);
    }
}
