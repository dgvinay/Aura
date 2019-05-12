using System;
using System.Collections.Generic;

namespace Aura.Core.Models
{
    /// <summary>
    /// </summary>
    public class ActivityTypes
    {
        private Dictionary<string, string> _actionTypes;
        private static ActivityTypes _instance = new ActivityTypes();

        private ActivityTypes()
        {
            _actionTypes = new Dictionary<string, string>
            {
                { "Navigate", "Navigate" },
                { "SetValue", "SetValue" },
                { "Click", "Click" },
                { "Select", "Select" },
                { "OpenBrowser", "OpenBrowser" },
                { "CloseBrowser", "CloseBrowser" }
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityTypes" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public ActivityTypes(string name)
        {
            if (!string.IsNullOrEmpty(name) && !_instance._actionTypes.ContainsKey(name))
            {
                throw new ArgumentException("Invalid activity type.", nameof(name));
            }

            Name = name;
        }

        /// <summary>
        /// Gets the navigate.
        /// </summary>
        /// <value>The navigate.</value>
        public static ActivityTypes Navigate { get { return new ActivityTypes("Navigate"); } }

        /// <summary>
        /// Gets the set value.
        /// </summary>
        /// <value>The set value.</value>
        public static ActivityTypes SetValue { get { return new ActivityTypes("SetValue"); } }

        /// <summary>
        /// Gets the click.
        /// </summary>
        /// <value>The click.</value>
        public static ActivityTypes Click { get { return new ActivityTypes("Click"); } }

        /// <summary>
        /// Gets the select.
        /// </summary>
        /// <value>The select.</value>
        public static ActivityTypes Select { get { return new ActivityTypes("Select"); } }

        /// <summary>
        /// Gets the none.
        /// </summary>
        /// <value>The none.</value>
        public static ActivityTypes None { get { return new ActivityTypes(string.Empty); } }

        /// <summary>
        /// Gets the close browser.
        /// </summary>
        /// <value>The close browser.</value>
        public static ActivityTypes CloseBrowser { get { return new ActivityTypes("CloseBrowser"); } }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Registers the type of the action.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public static void RegisterActionType(string key, string value)
        {
            if (!_instance._actionTypes.ContainsKey(key))
            {
                _instance._actionTypes.Add(key, value);
            }
        }
    }
}