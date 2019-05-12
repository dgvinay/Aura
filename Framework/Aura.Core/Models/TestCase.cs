using Aura.Core.Interfaces;
using System.Collections.Generic;

namespace Aura.Core.Models
{
    /// <summary>
    /// </summary>
    public class TestCase : ITestCase
    {
        /// <summary>
        /// Sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the steps.
        /// </summary>
        /// <value>The steps.</value>
        public List<ITestStep> Steps { get; set; }
    }
}