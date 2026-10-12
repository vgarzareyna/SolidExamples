using SOLIDExamples.Session1.Common.Report;

namespace SOLIDExamples.Session1.SRP.ReportSender
{
    public class TeamsSender(List<string> emails)
    {
        private readonly List<string> emails = emails;

        private static string EmailToUser(string email)
        {
            return $"@{email.Split('@')[0]}";
        }

        public void SendReport(Report report)
        {
            List<string> users = [.. emails.Select(EmailToUser)];

            // Logic to send the report via Teams...
            Console.WriteLine($"Sending report '{report.GetType().Name}' to users: {string.Join(", ", users)} via Teams.");
        }
    }
}
