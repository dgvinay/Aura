using Aura.Core.Enums;
using System;

namespace Aura.Core.Interfaces
{
    public interface IActivityExecutionResult
    {
        ActivityExecutionStatus Status { get; set; }

        Exception Exception { get; set; }
    }
}