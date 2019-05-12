using Aura.Core.Enums;
using Aura.Core.Interfaces;
using System;

namespace Aura.Core.Activities
{
    public class ActivityExecutionResult : IActivityExecutionResult
    {
        public ActivityExecutionResult()
        {
            Status = ActivityExecutionStatus.Successful;
        }

        public ActivityExecutionStatus Status { get; set; }

        public Exception Exception { get; set; }
    }
}