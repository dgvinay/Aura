namespace Aura.Entities
{
    public class TestStep : ITestStep
    {
        /// <summary>
        /// Gets or sets the action to do.
        /// </summary>
        /// <value>The do.</value>
        public ActionTypes Do { get; set; }

        /// <summary>
        /// Gets or sets the argument.
        /// </summary>
        /// <value>The argument.</value>
        public string Argument { get; set; }

        /// <summary>
        /// Gets or sets the element.
        /// </summary>
        /// <value>The element.</value>
        public string Element { get; set; }

        /// <summary>
        /// Gets or sets the element locator.
        /// </summary>
        /// <value>The element locator.</value>
        public ElementLocatorMethods ElementLocator { get; set; }
    }
}