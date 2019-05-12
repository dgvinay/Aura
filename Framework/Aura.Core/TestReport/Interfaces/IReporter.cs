using Aura.Core.TestReport.Enums;
using System;

namespace Aura.Core.TestReport.Interfaces
{
    public interface IReporter
    {
        /// <summary>
        /// Ends this instance.
        /// </summary>
        /// <returns></returns>
        IReporter End();

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <returns></returns>
        IReporter Initialize();

        /// <summary>
        /// News the child test case.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        IReporter NewChildTestCase(string name, string description);

        /// <summary>
        /// News the test case.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        IReporter NewTestCase(string name, string description);

        /// <summary>
        /// News the test suite.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        IReporter NewTestSuite(string name);

        #region Logs

        /// <summary>
        /// Adds the screen shot.
        /// </summary>
        /// <param name="screenshotPath">The screenshot path.</param>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        IReporter AddScreenShot(string screenshotPath, string title = "");

        /// <summary>
        /// Debugs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="screenshotPath">The screenshot path.</param>
        /// <returns></returns>
        IReporter Debug(string message, string screenshotPath = "");

        /// <summary>
        /// Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="screenshotPath">The screenshot path.</param>
        /// <returns></returns>
        IReporter Error(string message, string screenshotPath = "");

        /// <summary>
        /// Exceptions the specified e.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <param name="screenshotPath">The screenshot path.</param>
        /// <returns></returns>
        IReporter Exception(Exception e, string screenshotPath = "");

        /// <summary>
        /// Fails the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="screenshotPath">The screenshot path.</param>
        /// <returns></returns>
        IReporter Fail(string message, string screenshotPath = "");

        /// <summary>
        /// Fatals the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="screenshotPath">The screenshot path.</param>
        /// <returns></returns>
        IReporter Fatal(string message, string screenshotPath = "");

        /// <summary>
        /// Informations the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="screenshotPath">The screenshot path.</param>
        /// <returns></returns>
        IReporter Info(string message, string screenshotPath = "");

        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="status">The status.</param>
        /// <param name="screenshotPath">The screenshot path.</param>
        /// <returns></returns>
        IReporter Log(string message, TestReportLogStatus status, string screenshotPath = "");

        /// <summary>
        /// Passes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="screenshotPath">The screenshot path.</param>
        /// <returns></returns>
        IReporter Pass(string message, string screenshotPath = "");

        /// <summary>
        /// Skips the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="screenshotPath">The screenshot path.</param>
        /// <returns></returns>
        IReporter Skip(string message, string screenshotPath = "");

        /// <summary>
        /// Warnings the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="screenshotPath">The screenshot path.</param>
        /// <returns></returns>
        IReporter Warning(string message, string screenshotPath = "");

        #endregion Logs
    }
}