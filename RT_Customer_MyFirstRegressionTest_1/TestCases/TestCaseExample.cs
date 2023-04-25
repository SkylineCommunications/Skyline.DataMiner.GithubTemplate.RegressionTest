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

	public class TestCaseExample : ITestCase
	{
		public TestCaseExample(string name)
		{
			if (String.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("name");
			}

			Name = name;
		}

		public string Name { get; set; }

		public TestCaseReport TestCaseReport { get; private set; }

		public PerformanceTestCaseReport PerformanceTestCaseReport { get; private set; }

		public void Execute(IEngine engine)
		{
			// TODO: Implement your test case
			// The below is an example.
			var isSuccess = true;
			if (isSuccess)
			{
				TestCaseReport = TestCaseReport.GetSuccessTestCase(Name);
			}
			else
			{
				TestCaseReport = TestCaseReport.GetFailTestCase(Name, "Failed example");
			}
		}
	}
}
