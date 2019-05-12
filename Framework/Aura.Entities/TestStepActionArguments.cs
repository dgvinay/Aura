namespace Aurigo.Aura.Entities
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TestStepActionArguments<T> where T : class
    {
        /// <summary>
        /// Gets or sets the element.
        /// </summary>
        /// <value>
        /// The element.
        /// </value>
        public string Element { get; set; }

        /// <summary>
        /// Gets or sets the find element by.
        /// </summary>
        /// <value>
        /// The find element by.
        /// </value>
        public ElementLocatorMethods FindElementBy { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public T Value { get; set; }
    }
}