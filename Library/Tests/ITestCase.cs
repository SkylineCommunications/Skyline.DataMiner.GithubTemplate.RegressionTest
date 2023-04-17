namespace Library.Tests.TestCases
{
    using System;
    using QAPortalAPI.Models.ReportingModels;
    using Skyline.DataMiner.Automation;

    internal interface ITestCase
    {
        string Name { get; set; }

        TestCaseReport Execute(IEngine engine);
    }
}