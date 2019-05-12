using Aura.Core.Models;
using Aura.Core.UnitTest.Common;
using Aura.Core.UnitTest.FlowTests.TestCases;
using System.Collections.Generic;
using Xunit;

namespace Aura.Core.UnitTest.FlowTests
{
    public class FlowTest
    {
        [Fact]
        public void OpenGoogle()
        {
            var engine = Engine.GetEngine("OpenGoogle");
            var testCase = new OpenGoogleWebsite();
            var testSuite = new TestSuite
            {
                Name = "Open google website.",
                TestCases = new List<Interfaces.ITestCase>
                {
                    testCase
                }
            };

            engine.AddTestCase(testCase);
            engine.Fire();
        }

        [Fact]
        public void OpenGoogleAndTypeAndSearch()
        {
            var engine = Engine.GetEngine("OpenGoogleAndTypeAndSearch");
            var testCase = new OpenGoogleTypeAndSearch("Automation");
            engine.AddTestCase(testCase);
            engine.Fire();
        }

        [Fact]
        public void OpenGoogleAndTypeAutomation()
        {
            var engine = Engine.GetEngine("OpenGoogleAndTypeAutomation");
            var testCase = new OpenGoogleAndType("Automation");

            engine.AddTestCase(testCase);
            engine.Fire();
        }
    }
}