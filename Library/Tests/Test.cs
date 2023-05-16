namespace Library.Tests
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	using Library.Consts;
	using Library.Tests.TestCases;

	using QAPortalAPI.Models.ReportingModels;

	using Skyline.DataMiner.Automation;
	using Skyline.DataMiner.Net.Messages;

	internal class Test : ITest
	{
		private readonly string name;
		private readonly string description;
		private readonly List<ITestCase> testCases;
		private TestReport report;

		public Test(string name, string description)
		{
			this.name = name;
			this.description = description;

			this.testCases = new List<ITestCase>();
		}

		public void AddTestCase(params ITestCase[] newTestCases)
		{
			foreach (var testCase in newTestCases)
			{
				if (testCase == null || String.IsNullOrWhiteSpace(testCase.Name))
				{
					// We should not do anything
				}
				else if (this.testCases.FirstOrDefault(x => x.Name.Equals(testCase.Name)) != null)
				{
					// Name has to be unique
					testCase.Name += " - copy";
					AddTestCase(testCase);
				}
				else
				{
					this.testCases.Add(testCase);
				}
			}
		}

		public TestReport Execute(IEngine engine)
		{
			this.report = new TestReport(
				new TestInfo(name, TestInfoConsts.Contact, TestInfoConsts.ProjectIds, description),
				new TestSystemInfo(GetAgentWhereScriptIsRunning(engine)));

			foreach (var testCase in testCases)
			{
				try
				{
					testCase.Execute(engine);
					if (testCase.TestCaseReport != null && !this.report.TryAddTestCase(testCase.TestCaseReport, out string errorMessage))
					{
						engine.ExitFail(errorMessage);
					}

					if (testCase.PerformanceTestCaseReport != null)
					{
						if (!testCase.PerformanceTestCaseReport.IsValid(out string validationInfo))
						{
							engine.ExitFail(validationInfo);
						}
						else
						{
							this.report.PerformanceTestCases.Add(testCase.PerformanceTestCaseReport);
						}
					}
				}
				catch (Exception e)
				{
					engine.ExitFail(e.ToString());
				}
			}

			return this.report;
		}

		public void PublishResults(IEngine engine)
		{
			try
			{
				var portal = new QAPortal.QAPortal(engine);
				portal.PublishReport(report);
			}
			catch (Exception e)
			{
				engine.Log($"Reporting results for {report.TestInfo.TestName} to QAPortal failed: {e}");
			}

			var isSuccessful = report.TestResult == QAPortalAPI.Enums.Result.Success;
			var reason = GenerateReason();
			engine.Log($"{report.TestInfo.TestName} {report.TestResult}: {reason}");

			engine.AddScriptOutput("Success", isSuccessful.ToString());
			engine.AddScriptOutput("Reason", reason);
		}

		private string GetAgentWhereScriptIsRunning(IEngine engine)
		{
			string agentName = null;
			try
			{
				var message = new GetInfoMessage(-1, InfoType.LocalDataMinerInfo);
				var response = (GetDataMinerInfoResponseMessage)engine.SendSLNetSingleResponseMessage(message);
				agentName = response?.AgentName ?? throw new NullReferenceException("No valid agent name was returned by SLNET.");
			}
			catch (Exception e)
			{
				engine.ExitFail("RT Exception - Could not retrieve local agent name: " + e);
			}

			return agentName;
		}

		private string GenerateReason()
		{
			var reason = new StringBuilder();
			reason.AppendLine(report.TestInfo.TestDescription);

			foreach (var testCaseReport in report.TestCases)
			{
				reason.AppendLine($"{testCaseReport.TestCaseName}|{testCaseReport.TestCaseResult}|{testCaseReport.TestCaseResultInfo}");
			}

			return reason.ToString();
		}
	}
}