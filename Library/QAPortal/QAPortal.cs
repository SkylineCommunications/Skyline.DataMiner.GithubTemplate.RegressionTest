﻿namespace Library.QAPortal
{
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
                engine.Log($"Exception retrieving QAPortal configuration: {e}");
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
            EmailOptions emailOptions = new EmailOptions(message, subject, to)
            {
                SendAsPlainText = true,
            };

            engine.SendEmail(emailOptions);
        }
    }
}