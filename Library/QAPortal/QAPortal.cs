﻿namespace Library.QAPortal
{
	using System;

	using QAPortalAPI.APIHelper;
	using QAPortalAPI.Models.ReportingModels;

	using Skyline.DataMiner.Automation;

	internal class QAPortal
	{
		private readonly IEngine engine;
		private readonly QaPortalConfiguration configuration;

		public QAPortal(IEngine engine)
		{
			this.engine = engine;
			configuration = QaPortalConfiguration.GetConfiguration(out var e);
			if (e != null)
			{
				throw e;
			}
		}

		public void PublishReport(TestReport report)
		{
			QaPortalApiHelper helper;
			if (configuration.ClientId == null)
			{
				helper = new QaPortalApiHelper(engine.GenerateInformation, configuration.Path, string.Empty, string.Empty);
			}
			else
			{
				helper = new QaPortalApiHelper(
				  engine.GenerateInformation,
				  configuration.Path,
				  configuration.ClientId,
				  configuration.ApiKey,
				  PlainBodyEmail);
			}

			helper.PostResult(report);
		}

		private void PlainBodyEmail(string message, string subject, string to)
		{
			to = "qaportal@skyline.be";
			EmailOptions emailOptions = new EmailOptions(message, subject, to)
			{
				SendAsPlainText = true,
			};

			engine.SendEmail(emailOptions);
		}
	}
}
