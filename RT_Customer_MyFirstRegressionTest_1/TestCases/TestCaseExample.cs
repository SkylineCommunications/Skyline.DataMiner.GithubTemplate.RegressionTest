namespace RT_Customer_MyFirstRegressionTest_1
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	using Library.Tests.TestCases;

	using QAPortalAPI.Models.ReportingModels;

	using Skyline.DataMiner.Automation;

	internal class TestCaseExample : ITestCase
	{
		public TestCaseExample(string name)
		{
			Name = name;
		}

		public string Name { get; set; }

		public TestCaseReport Execute(IEngine engine)
		{
			// TODO: Implement your test case
			return TestCaseReport.GetSuccessTestCase(Name);
		}
	}
}
