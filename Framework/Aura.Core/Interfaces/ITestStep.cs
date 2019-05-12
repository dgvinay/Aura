using Aura.Core.Models;

namespace Aura.Core.Interfaces
{
    public interface ITestStep
    {
        /// <summary>
        /// Gets or sets the argument.
        /// </summary>
        /// <value>The argument.</value>
        string Argument { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the action to do.
        /// </summary>
        /// <value>The do.</value>
        string Do { get; set; }

        /// <summary>
        /// Gets or sets the element.
        /// </summary>
        /// <value>The element.</value>
        string Element { get; set; }

        /// <summary>
        /// Gets or sets the element locator.
        /// </summary>
        /// <value>The element locator.</value>
        ElementLocatorMethods ElementLocator { get; set; }
    }
}