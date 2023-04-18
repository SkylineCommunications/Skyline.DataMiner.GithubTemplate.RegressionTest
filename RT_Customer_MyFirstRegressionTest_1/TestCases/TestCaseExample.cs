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
			// The below is an example.
			var isSuccess = true;
			if (isSuccess) 
			{
				return TestCaseReport.GetSuccessTestCase(Name);
			}
			else
			{
				return TestCaseReport.GetFailTestCase(Name, "Failed example");
			}
		}

		public PerformanceTestCaseReport ExecutePerformance(IEngine engine) => throw new NotImplementedException();
	}
}
