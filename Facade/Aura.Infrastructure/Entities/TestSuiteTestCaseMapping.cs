namespace Aura.Infrastructure.Entities
{
    /// <summary>
    /// </summary>
    public class TestSuiteTestCaseMapping
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the test suite identifier.
        /// </summary>
        /// <value>The test suite identifier.</value>
        public int TestSuiteId { get; set; }

        /// <summary>
        /// Gets or sets the test case identifier.
        /// </summary>
        /// <value>The test case identifier.</value>
        public int TestCaseId { get; set; }
    }
}