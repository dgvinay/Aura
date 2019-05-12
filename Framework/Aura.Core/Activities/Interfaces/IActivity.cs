using Aura.Core.Models;

namespace Aura.Core.Interfaces
{
    /// <summary>
    /// </summary>
    public interface IActivity
    {
        /// <summary>
        /// Gets the action.
        /// </summary>
        /// <value>The action.</value>
        ActivityTypes Action { get; }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        IActivityExecutionResult Execute();
    }
}