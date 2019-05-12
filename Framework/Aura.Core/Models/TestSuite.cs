using Aura.Core.Interfaces;
using System.Collections.Generic;

namespace Aura.Core.Models
{
    /// <summary>
    /// </summary>
    /// <seealso cref="Object" />
    public class TestSuite : ITestSuite
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the test cases.
        /// </summary>
        /// <value>The test cases.</value>
        public List<ITestCase> TestCases { get; set; }
    }
}