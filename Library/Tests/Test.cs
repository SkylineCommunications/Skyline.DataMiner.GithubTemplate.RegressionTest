﻿namespace Library.Tests
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Library.Consts;
	using Library.Tests.TestCases;

	using QAPortalAPI.Models.ReportingModels;

	using Skyline.DataMiner.Automation;
	using Skyline.DataMiner.Core.DataMinerSystem.Automation;
	using Skyline.DataMiner.Net.Messages;

	internal class Test : ITest
	{
		private TestReport report;
		private readonly string name;
		private readonly string description;

		private List<ITestCase> testCases;

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
					continue;
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
				this.report.TryAddTestCase(testCase.Execute(engine));
			}

			return this.report;
		}

		public void PublishResults(IEngine engine)
		{
			var qaPortal = new QAPortal.QAPortal(engine);
			qaPortal.PublishReport(report);
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
	}
}