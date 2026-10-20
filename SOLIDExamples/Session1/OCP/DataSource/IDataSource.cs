using SOLIDExamples.Session1.Common.Data;

namespace SOLIDExamples.Session1.OCP.DataSource
{
    // Only one implementation (CsvDataSource), and no requirement has asked for another source.
    // This interface is premature on purpose: compare with ReportCalculator, which has none.
    // It would pay off the day a second source (a database, an API) shows up.
    public interface IDataSource
    {
        IntakeData GetData();
    }
}
