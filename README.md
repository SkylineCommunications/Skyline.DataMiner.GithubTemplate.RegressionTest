# Customer-AS-RegressionTests

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=SkylineCommunications_Skyline.DataMiner.GithubTemplate.RegressionTest&metric=alert_status&token=29f9cdf6df4a18b09c66e7cae2ba628ae472f17b)](https://sonarcloud.io/summary/new_code?id=SkylineCommunications_Skyline.DataMiner.GithubTemplate.RegressionTest)

This repository is a template to get you started as quickly and easy as possible!
This repository is built to have per regression test one Automation scriput that consumes the [QAPortalAPI nugget package](https://github.com/SkylineCommunications/Skyline.DataMiner.Utils.QAPortalAPI).

## How to get started

1. Follow the steps described at: [Creating a repository from a template](https://docs.github.com/en/repositories/creating-and-managing-repositories/creating-a-repository-from-a-template#creating-a-repository-from-a-template)
2. While creating the new repository, take into account the [GitHub Repository Guidelines](https://docs.dataminer.services/develop/CICD/Skyline%20Communications/Github/Use_Github_Guidelines.html) described in the DataMiner Docs. 
    1. Suggested Naming Convention: {customerAcronym}-AS-RegressionTests
    2. Add/Change the license according to what is aggreed with the customer
    3. Add Github repository topics: dataminer-automation-script, dataminer-regression-test
3. In GitHub Actions, change your workflow:
    1. Change SonarCloudProjectName to a new Sonar Project
    2. Add Secrets in the GitHub settings of your repository (SONAR_TOKEN, DATAMINER_DEPLOY_KEY)
5. Clone your repository onto your local machine
6. Open the AutomationScript.sln Visual Studio Solution
7. Rebuild the solution to register correctly all pre-installed nugget packages
8. Change the constant values dependent on your project/customer at: Library\Consts\TestInfoConsts.cs
9. There is an Automation Script automatically added
    1. RT_Customer_MyFirstRegressionTest: This is your first regression test script. In the script you should change the TestName, TestDescription and add all test cases that want to test. A test case is typically a dedicated class file stored in the the TestCases folder of your project. Here you define the actual test logic.
10. Rename the Automation Script (_Customer_ should have the right abbreviation)
    1. Required: Change Script XML file : DMSScript.Name tag
    2. Optional: Rename VS Project
    3. Optional: Rename Script XML file 
    4. Optional: Rename CS file
    5. Optional: Edit afterwards the csproj and sln files of your repository (search all)
11. Implement your test!
12. Deploy your test + Configure C:\Skyline DataMiner\QAPortal\QaPortalConfiguration.json
    1. An example can be found under this repository Documentation/Examples/QaPortalConfiguration.json
    2. The ClientID and API key will be provided by the contact at Skyline Communications by registering the External Cluster on our internal QAPortal
    
## Important to know

1. Makes sure to include a nugget package through [PackageReference](https://learn.microsoft.com/en-us/nuget/consume-packages/package-references-in-project-files). This is already configured in this template, so nothing to change.
2. A [Shared Project Library](https://learn.microsoft.com/en-us/xamarin/cross-platform/app-fundamentals/shared-projects?tabs=windows#what-is-a-shared-project) is used to use the same code accross multiple VS Projects (= Regression Tests = Automation Scripts).
3. Don't forget to configure C:\Skyline DataMiner\QAPortal\QaPortalConfiguration.json (See How to get started).

## Regression Tests

Following use cases are currently automatically tested:

### RT_Customer_MyFirstRegressionTest

Please use a table as shown below to document the different test cases.

| Name | Description |
|--|--|
|Test 1|My first test|
|Test 2|My second test|
