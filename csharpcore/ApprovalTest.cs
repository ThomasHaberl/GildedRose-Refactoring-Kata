using Xunit;
using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using ApprovalTests.Reporters.Windows;

namespace csharpcore
{
    [UseReporter(typeof(VisualStudioReporter))]
    public class ApprovalTest
    {
        [Fact]
        public void ThirtyDays()
        {
            // Redirect console output and input
            var fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            // Run application
            Program.Main();

            // Fetch console output
            var output = fakeoutput.ToString();

            Approvals.Verify(output);
        }
    }
}
