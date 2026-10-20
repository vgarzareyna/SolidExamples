using Initial = SOLIDExamples.Session1.Initial;
using SRP = SOLIDExamples.Session1.SRP;
using SRP_NewReqs = SOLIDExamples.Session1.SRP_NewReqs;
using OCP = SOLIDExamples.Session1.OCP;

namespace SOLIDExamples
{
    public class Program
    {
        private const string Folder = "C:/Users/User/Documents/Reports";
        private static readonly List<string> Emails = ["user1@example.com", "user2@example.com"];

        #region Initial
        private static void Example1_InitialDesign()
        {
            Console.WriteLine("\n=== Running Example 1 (Initial) ===\n");

            Initial.ReportService reportServ = new();
            reportServ.Run(
                Folder,
                Emails
            );
        }
        #endregion

        #region SRP
        private static void Example2_ApplySRP()
        {
            Console.WriteLine("\n=== Running Example 2 (SRP) ===\n");
            SRP.ReportService reportServ = new();
            reportServ.Run(
                Folder,
                Emails
            );
        }
        #endregion

        #region SRP + New Requirements
        private static void Example3_IntroduceNewRequirements()
        {
            Console.WriteLine("\n=== Running Example 3 (SRP + New Requirements) ===\n");
            SRP_NewReqs.ReportService reportServ = new(
                SRP_NewReqs.ReportService.ReportType.Excel,
                SRP_NewReqs.ReportService.SendVia.Email
            );
            reportServ.Run(
                Folder,
                Emails
            );
        }
        #endregion

        #region OCP
        private static void Example4_ApplyOCP()
        {
            Console.WriteLine("\n=== Running Example 4 (OCP) ===\n");
            OCP.ReportService reportServ = OCP.ReportServiceFactory.Create(
                Folder,
                Emails,
                OCP.ReportType.Excel,
                OCP.SendVia.Email
            );
            reportServ.Run();
        }
        #endregion

        private static void RunAll()
        {
            Example1_InitialDesign();

            Example2_ApplySRP();

            Example3_IntroduceNewRequirements();

            Example4_ApplyOCP();
        }

        public static void Main(string[] args)
        {
            RunAll();
        }
    }
}
