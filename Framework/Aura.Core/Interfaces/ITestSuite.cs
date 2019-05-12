using System.Collections.Generic;

namespace Aura.Core.Interfaces
{
    public interface ITestSuite
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the test cases.
        /// </summary>
        /// <value>The test cases.</value>
        List<ITestCase> TestCases { get; set; }
    }
}