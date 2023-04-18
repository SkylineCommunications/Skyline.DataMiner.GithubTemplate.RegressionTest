# Customer-AS-RegressionTests


[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=SkylineCommunications_YLE-AS-RegressionTests&metric=alert_status&token=22a547c07150f6ec9c7e326e72ab3061e2b69a0b)](https://sonarcloud.io/summary/new_code?id=SkylineCommunications_YLE-AS-RegressionTests)

This repository is a template to get you started as quickly and easy as possible!
This repository is built to have per regression test one Automation scriput that consumes the [QAPortalAPI nugget package](https://github.com/SkylineCommunications/Skyline.DataMiner.Utils.QAPortalAPI).

## How to get started

1. Follow the steps described at: [Creating a repository from a template](https://docs.github.com/en/repositories/creating-and-managing-repositories/creating-a-repository-from-a-template#creating-a-repository-from-a-template)
2. While creating the new repository, take into account the [GitHub Repository Guidelines](https://docs.dataminer.services/develop/CICD/Skyline%20Communications/Github/Use_Github_Guidelines.html) described in the DataMiner Docs. 
    1. Suggested Naming Convention: {customerAcronym}-AS-RegressionTests
    2. Add/Change the license according to what is aggreed with the customer
    3. Add Github repository topics: dataminer-automation-script, dataminer-regression-test
3. Clone your repository onto your local machine
4. Open the AutomationScript.sln Visual Studio Solution
5. Change the constant values dependent on your project/customer at: Library\Consts\TestInfoConsts.cs
6. There are two Automation Scripts automatically added
    1. Ziine-AS-RegressionTests: This optional script can be used to automatically run all Regression Tests on your system. You should add the names of the regression tests scripts on here
    2. RT_Ziine_MyFirstRegressionTest: This is your first regression test script. In the script you should change the TestName, TestDescription and add all test cases that want to test. A test case is typically a dedicated class file stored in the the TestCases folder of your project. Here you define the actual test logic.
7. Rename all Automation Scripts (_Customer_ should have the right abbreviation)
    1. Rename VS Project
    2. Rename XML file and its Name tag
    3. Rename CS file
    4. Edit afterwards the csproj and sln files of your repository (search all)

## Important to know

1. Makes sure to include a nugget package through [PackageReference](https://learn.microsoft.com/en-us/nuget/consume-packages/package-references-in-project-files). This is already configured in this template, so nothing to change.
2. A [Shared Project Library](https://learn.microsoft.com/en-us/xamarin/cross-platform/app-fundamentals/shared-projects?tabs=windows#what-is-a-shared-project) is used to use the same code accross multiple VS Projects (= Regression Tests = Automation Scripts).

## Regression Tests

Following use cases are currently automatically tested:

### RT_Customer_MyFirstRegressionTest

| Name | Description |
|--|--|
|Test 1|My first test|
|Test 2|My second test|
