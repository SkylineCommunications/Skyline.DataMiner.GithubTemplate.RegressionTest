# Skyline.DataMiner.Utils.QAPortalAPI

[![DataMiner CICD NuGet Solution](https://github.com/SkylineCommunications/Skyline.DataMiner.Utils.QAPortalAPI/actions/workflows/main.yml/badge.svg)](https://github.com/SkylineCommunications/Skyline.DataMiner.Utils.QAPortalAPI/actions/workflows/main.yml)

## About

### Skyline.DataMiner.Utils.QAPortalAPI
Skyline.DataMiner.Utils.QAPortalAPI was created to easily push test results in a standardized way to the QAPortal. This portal contains all test information and results.

### About DataMiner

DataMiner is a transformational platform that provides vendor-independent control and monitoring of devices and services. Out of the box and by design, it addresses key challenges such as security, complexity, multi-cloud, and much more. It has a pronounced open architecture and powerful capabilities enabling users to evolve easily and continuously.

The foundation of DataMiner is its powerful and versatile data acquisition and control layer. With DataMiner, there are no restrictions to what data users can access. Data sources may reside on premises, in the cloud, or in a hybrid setup.

A unique catalog of 7000+ connectors already exist. In addition, you can leverage DataMiner Development Packages to build you own connectors (also known as "protocols" or "drivers").

> **Note**
> See also: [About DataMiner](https://aka.dataminer.services/about-dataminer)

### About Skyline Communications
At Skyline Communications, we deal in world-class solutions that are deployed by leading companies around the globe. Check out [our proven track record](https://aka.dataminer.services/about-skyline) and see how we make our customers' lives easier by empowering them to take their operations to the next level.


## Getting Started

Include the nuget package in your project, and deploy the Skyline.Dataminer.Utils.QAPortalAPI.dll on the Dataminer system (In the future the Dataminer deployment action will be automated).

Add the following using statements to your code
````csharp
using QAPortalAPI.APIHelper;
using QAPortalAPI.Enums;
using QAPortalAPI.Models.ReportingModels;
````

The first thing that needs to happen in the script/test is to initialize the TestReport object. This object will contain all information about the test and the system, this will be sent to the portal. 

The Dataminer version can be automatically retrieved via this structure
````csharp
TestReport testReport = new TestReport(
    new TestInfo("AUniqueTestName", "ASkylineDomainOrEmail", new List<int> {99999}, "The description of a Test"),
    new TestSystemInfo("[AgentNameOnThePortal]"));
````

>- The TestInfo object contains all information about the test, this information will be used on the portal.
>- The portal will automatically add the customer abbreviation to the testname, this to make sure individual tests are unique over all customers. 
>- The TestSystemInfo object contains information about the system where the test was executed on. This is used to link the results to the correct system and dataminer version. 
>- Make sure to provide the name of the Agent where the test is running on, not the clusterName.

Now the actual script/test can start running, each time a testcase is completed the result has to be added to the report object. 

````csharp
//Add a success testcase to the result
testReport.TryAddTestCase(new TestCaseReport("AUniqueTestCaseName", Result.Success, string.Empty), out _);

//Add a failure testcase to the result
testReport.TryAddTestCase(new TestCaseReport("AUniqueTestCaseName2", Result.Failure, "The Fail message"), out _);
````

Once all testcases are executed and saved in the report we have to send it to the QAPortal. 

This can be done via 2 ways
- Directly to the API (internet access needed)
- By email (an action has to be provided that can send an email)

````csharp
//The url or email to the portal provided when the system is added to the QAPortal. 
string portalUrl = "publicPortalUrlOrEmail";
QAPortalAPIHelper reportHelperViaAPI = new QAPortalAPIHelper(engine.GenerateInformation, portalUrl, "SafelyStoredClientID", "SafelyStorredAPIKey");
reportHelperViaAPI.PostResult(testReport);

QAPortalAPIHelper reportHelperViaAPIAndProxy = new QAPortalAPIHelper(engine.GenerateInformation, portalUrl, "SafelyStoredClientID", "SafelyStorredAPIKey", "[AProxy]");
reportHelperViaAPI.PostResult(testReport);

QAPortalAPIHelper reportHelperViaEmail = new QAPortalAPIHelper(engine.GenerateInformation, portalUrl, "SafelyStoredClientID", "SafelyStorredAPIKey", engine.SendEmail);
reportHelperViaEmail.PostResult(testReport);    
````     

See also the full Dataminer script examples: via [API](Examples/TheAPITestScript.md) or via [Email](Examples/TheEmailTestScript.md)

> **Warning**
> When using the Skyline.DataMiner.Utils.QAPortalAPI on versions lower than 10.1.11 or 10.2.0.0, add the *netstandard.dll* reference to your script. 

> **Note**
> The portalUrl, ClientID and API key will be provided by the contact at Skyline Communications.

## Performance Results

Via the API it is also possible to publish performance results to the portal. This can be done by adding the performance results to your test report

````csharp
//Performance results
testReport.PerformanceTestCases.Add(new PerformanceTestCaseReport("APerfName1", Result.Success, "SomeInfo About the test case and the value", ResultUnit.Second, 99));

testReport.PerformanceTestCases.Add(new PerformanceTestCaseReport("AUniqueTestCaseName1", Result.Failure, "SomeInfo About the test case and the value", ResultUnit.Second, 9));
````

You can either have dedicated performance test cases or functional tests cases that also push a performance result.


## Debugging and Diagnostic

### No test-case results error
**Issue**: When posting to the portal you get an error message: *No test-case results are present on the test report*.  
**Fix**: The report always expects at least 1 testcase result (success or failure). 
