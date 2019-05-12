using System;
using System.Runtime.Serialization;

namespace Aura.Core.Exceptions
{
    public class ElementNotFoundException : Exception
    {
        public ElementNotFoundException()
        {
        }

        public ElementNotFoundException(string elementName)
            : base($"Element [{elementName}] was not found on the page.")
        {
        }

        public ElementNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ElementNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}