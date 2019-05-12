using System.Collections.Generic;

namespace Aurigo.Aura.Entities
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Object" />
    public class TestSuite
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the test cases.
        /// </summary>
        /// <value>
        /// The test cases.
        /// </value>
        public IEnumerable<TestCase> TestCases { get; set; }
    }
}