namespace RT_VOO_Seram_Offload_CheckFileCreation_1
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	using Library.Tests.TestCases;

	using QAPortalAPI.Models.ReportingModels;

	using Skyline.DataMiner.Automation;

	internal class TestCaseOffloadCheckFileCreation : ITestCase
	{
		public TestCaseOffloadCheckFileCreation(string name)
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
