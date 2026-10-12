using Initial = SOLIDExamples.Session1.Initial;
using SRP = SOLIDExamples.Session1.SRP;
using OCP = SOLIDExamples.Session1.OCP;

namespace SOLIDExamples
{
    public class Program
    {
        private const string Folder = "C:/Users/User/Documents/Reports";
        private static readonly List<string> Emails = ["user1@example.com", "user2@example.com"];

        #region Initial
        private static void Example1()
        {
            Console.WriteLine("\n=== Running Example 1 (Initial) ===\n");

            Initial.ReportService reportServ = new();
            reportServ.Run(
                Folder,
                Emails,
                Initial.ReportService.ReportType.Excel,
                Initial.ReportService.SendVia.Email
            );
        }
        #endregion

        #region SRP
        private static void Example2()
        {
            Console.WriteLine("\n=== Running Example 2 (SRP) ===\n");
            SRP.ReportService reportServ = new(
                SRP.ReportService.ReportType.Excel,
                SRP.ReportService.SendVia.Email
            );
            reportServ.Run(
                Folder,
                Emails
            );
        }
        #endregion

        #region OCP
        private static void Example3()
        {
            Console.WriteLine("\n=== Running Example 3 (OCP) ===\n");
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
            Example1();

            Example2();

            Example3();
        }

        public static void Main(string[] args)
        {
            RunAll();
        }
    }
}
