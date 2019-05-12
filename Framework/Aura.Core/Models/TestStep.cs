using Aura.Core.Interfaces;

namespace Aura.Core.Models
{
    public class TestStep : ITestStep
    {
        private ActivityTypes _do = ActivityTypes.None;

        public TestStep()
        {
            ElementLocator = ElementLocatorMethods.None;
        }

        /// <summary>
        /// Gets or sets the argument.
        /// </summary>
        /// <value>The argument.</value>
        public string Argument { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the action to do.
        /// </summary>
        /// <value>The do.</value>
        public string Do
        {
            get
            {
                return _do.Name;
            }
            set
            {
                _do = new ActivityTypes(value);
            }
        }

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