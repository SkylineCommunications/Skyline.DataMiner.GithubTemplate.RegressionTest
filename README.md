# Skyline.DataMiner.GithubTemplate.RegressionTest

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=SkylineCommunications_Skyline.DataMiner.GithubTemplate.RegressionTest&metric=alert_status&token=29f9cdf6df4a18b09c66e7cae2ba628ae472f17b)](https://sonarcloud.io/summary/new_code?id=SkylineCommunications_Skyline.DataMiner.GithubTemplate.RegressionTest)

This repository is a template to get you started as quickly and easy as possible!
This repository is built to have per regression test one Automation scriput that consumes the [QAPortalAPI NuGet package](https://github.com/SkylineCommunications/Skyline.DataMiner.Utils.QAPortalAPI).

## How to get started

1. Follow the steps described at: [Creating a repository from a template](https://docs.github.com/en/repositories/creating-and-managing-repositories/creating-a-repository-from-a-template#creating-a-repository-from-a-template)
2. While creating the new repository, take into account the [GitHub Repository Guidelines](https://docs.dataminer.services/develop/CICD/Skyline%20Communications/Github/Use_Github_Guidelines.html) described in the DataMiner Docs. 
    1. Suggested Naming Convention: {customerAcronym}-AS-RegressionTests
    2. Add/Change the license according to what is aggreed with the customer
    3. Add Github repository topics: dataminer-automation-script, dataminer-regression-test
3. In GitHub Actions, change your workflow:
    1. Change SonarCloudProjectName to a new Sonar Project, by registering your project here:
        1. https://sonarcloud.io/projects/create
        2. Search your GitHub repository
        3. Configure project with GitHub Actions
        4. You will be presented your SONAR_TOKEN
        5. Note! When specifying this information and commit the changes, your GitHub Action will run and link/register it to SonarCloud. The GitHub Action will fail because of this, but feel free to rerun your GitHub action and it should be working.
    3. Add Secrets in the GitHub settings of your repository (SONAR_TOKEN, DATAMINER_DEPLOY_KEY)
       1. DATAMINER_DEPLOY_KEY can be created for you on admin.dataminer.service if your system is connected to dataminer.services (This repository only includes CI, so the key is not used for deploying the artificat). **Important**: This is required at this moment to get the GitHub Action to work.
5. Clone your repository onto your local machine
6. Open the AutomationScript.sln Visual Studio Solution
7. Rebuild the solution to register correctly all pre-installed NuGet packages
8. Change the constant values dependent on your project/customer at: Library\Consts\TestInfoConsts.cs
    1. The 'Contact' field must be your squad or domain e-mail. This field is only used for apointing the test to the right squad or domain. The QAPortal can be configured to notify your on regression test reports.
    2. The Project IDs is typically the project where you are working on delivering a solution. If it's for testing purpose, please specify the M&S project of the customer.
10. There is an Automation Script automatically added
    1. RT_Customer_MyFirstRegressionTest: This is your first regression test script. In the script you should change the TestName, TestDescription and add all test cases that want to test. A test case is typically a dedicated class file stored in the the TestCases folder of your project. Here you define the actual test logic.
11. Rename the Automation Script (_Customer_ should have the right abbreviation)
    1. Required: Change Script XML file : DMSScript.Name tag
    2. Optional: Rename VS Project
    3. Optional: Rename Script XML file 
    4. Optional: Rename CS file
    5. Optional: Edit afterwards the csproj and sln files of your repository (search all)
12. Implement your test in the Execute method of your testcase!
13. Deploy your test + Configure C:\Skyline DataMiner\QAPortal\QaPortalConfiguration.json
    1. An example can be found under this repository Documentation/Examples/QaPortalConfiguration.json
    2. The ClientID and API key will be provided by the contact at Skyline Communications by registering the External Cluster on our internal QAPortal
    3. The Path is dependent on how you want to post results
        1. 	Internal system
            1. 	API = http://qaportal.skyline.local/api/public/results/addresult
            2. 	e-mail = qaportal@skyline.be (note: SMTP settings have to be added in DataMiner.xml)
        3. 	External system
            1. API = https://qaportal.skyline.be/forward/save
            2. e-mail = qaportal@skyline.be (note: SMTP settings have to be added in DataMiner.xml)
    
## Important to know

1. Makes sure to include a NuGet package through [PackageReference](https://learn.microsoft.com/en-us/nuget/consume-packages/package-references-in-project-files). This is already configured in this template, so nothing to change.
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
