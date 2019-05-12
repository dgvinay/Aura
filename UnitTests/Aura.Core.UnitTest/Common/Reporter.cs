using Aura.Common.Extensions;
using Aura.Core.TestReport.ExtentReports;
using System.IO;

namespace Aura.Core.UnitTest.Common
{
    public class Reporter
    {
        public static ExtentReportReporter GetReporter(string fileName)
        {
            return new ExtentReportReporter(GetOptions(fileName));
        }

        private static ExtentReporterOptions GetOptions(string fileName)
        {
            var fileNameWithExt = Path.GetExtension(fileName).HasValue() ? fileName : Path.ChangeExtension(fileName, "html");
            return new ExtentReporterOptions
            {
                ReportFilePath = Path.Combine(Constants.REPORTS_PATH, fileNameWithExt)
            };
        }
    }
}