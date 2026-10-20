using SOLIDExamples.Session1.Common.Report;

namespace SOLIDExamples.Session1.SRP_NewReqs.ReportSender
{
    public class EmailSender(List<string> emails)
    {
        private readonly List<string> emails = emails;

        public void SendReport(Report report)
        {
            // Logic to send the report via Email...
            Console.WriteLine($"Sending report '{report.GetType().Name}' to users: {string.Join(", ", emails)} via Email.");
        }
    }
}
