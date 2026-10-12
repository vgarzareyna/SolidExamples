using SOLIDExamples.Session1.Common.Data;

namespace SOLIDExamples.Session1.OCP.DataSource
{
    public interface IDataSource
    {
        IntakeData GetData();
    }
}
