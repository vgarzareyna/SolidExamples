using SOLIDExamples.Session1.Common.Data;

namespace SOLIDExamples.Session1.OCP.Calculation
{
    public class ReportCalculator
    {
        public ReportData Calculate(List<IntakeData> intakeData)
        {
            ReportData reportData = new();
            // Logic to calculate the report data...
            Console.WriteLine($"Calculating report data from {intakeData.Count} sources.");
            return reportData;
        }
    }
}
