# Skyline.DataMiner.GithubTemplate.RegressionTest

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=SkylineCommunications_Skyline.DataMiner.GithubTemplate.RegressionTest&metric=alert_status&token=29f9cdf6df4a18b09c66e7cae2ba628ae472f17b)](https://sonarcloud.io/summary/new_code?id=SkylineCommunications_Skyline.DataMiner.GithubTemplate.RegressionTest)

This repository is a template to get you started as quickly and easily as possible!  
Each regression test is implemented as a separate Automation Script that consumes the [QAPortalAPI NuGet package](https://github.com/SkylineCommunications/Skyline.DataMiner.Utils.QAPortalAPI).

## How to get started

1. Follow the steps described at: [Creating a repository from a template](https://docs.github.com/en/repositories/creating-and-managing-repositories/creating-a-repository-from-a-template#creating-a-repository-from-a-template)
2. While creating the new repository, take into account the [GitHub Repository Guidelines](https://docs.dataminer.services/develop/CICD/Skyline%20Communications/Github/Use_Github_Guidelines.html) described in the DataMiner Docs:  
    - Suggested Naming Convention: `{customerAcronym}-T-RegressionTests`  
    - Add/Change the license according to what is agreed with the customer  
    - Add GitHub repository topics: `dataminer-automation-script`, `dataminer-regression-test`  
3. In GitHub Actions, update your workflow:
    - Change `SonarCloudProjectName` to the new SonarCloud project by registering it here:  
      https://sonarcloud.io/projects/create  
4. Clone the repository locally.
5. Open the solution in Visual Studio and rebuild it to restore NuGet packages.
6. Update constants in `Library\Consts\TestInfoConsts.cs` based on the customer/project:
    - The `Contact` field must be your squad or domain e-mail.
    - The `ProjectIds` should reference the delivery project, or the M&S project for general tests.
7. A sample Automation Script is included:
   - `RT_Customer_MyFirstRegressionTest`: To adjust the name, open the file `RT_Customer_MyFirstRegressionTest.xml` in DIS.  
     Click the dropdown arrow next to the **Name** field at the top, then select **Change Script Name...**.  
     Enter the new name (replace `Customer` with the customer abbreviation).  
     This will automatically update the `<Name>` tag in the XML as well as all related project references and files.
8. Add more Automation Script projects if needed using the same structure.
9. Rename the solution and folder to follow the same naming convention:  
    - Example: `{customerAcronym}-T-RegressionTests`

## Deploy and configure

1. Deploy your test scripts to the DataMiner system.
2. Configure `C:\Skyline DataMiner\QAPortal\QaPortalConfiguration.json`
    - An example is available in `Documentation/Examples/QaPortalConfiguration.json`
    - Contact Skyline to receive a valid `ClientID` and `API key`
    - Supported endpoints:
        - **Internal system**
            - API: `http://qaportal.skyline.local/api/public/results/addresult`
            - Email: `qaportal@skyline.be` *(note: SMTP settings must be added in `DataMiner.xml`)*
        - **External system**
            - API: `https://qaportal.skyline.be/forward/save`
            - Email: `qaportal@skyline.be` *(note: SMTP settings must be added in `DataMiner.xml`)*

> **Optional Tooling**  
> After deploying your regression test package, you may also deploy the [Regression Test Management solution](https://catalog.dataminer.services/details/27636bb4-e3ce-4a2a-bd28-fe514a4ac5e7).  
> This solution enables you to manage and visualize regression test results directly within your DataMiner System. It serves as a suitable alternative for teams that prefer not to use the QA Portal or are unable to do so

## Important notes

- NuGet packages are included via [PackageReference](https://learn.microsoft.com/en-us/nuget/consume-packages/package-references-in-project-files) — already configured in the template.
- A [Shared Project](https://learn.microsoft.com/en-us/xamarin/cross-platform/app-fundamentals/shared-projects?tabs=windows#what-is-a-shared-project) is used to share code across Automation Script projects.
- Don’t forget to configure `QaPortalConfiguration.json` as described above.

> **Note:** This template is a [Skyline DataMiner Package Project](https://docs.dataminer.services/develop/CICD/Skyline%20DataMiner%20Software%20Development%20Kit/skyline_dataminer_sdk_dataminer_package_project.html).  
> Every time you build the solution, it generates a `.dmapp` package that can be directly copied and deployed to a DataMiner Agent (DMA).

## Regression Tests

Following use cases are currently automatically tested:

### RT_Customer_MyFirstRegressionTest

Please use a table as shown below to document the different test cases.

| Name | Description |
|--|--|
|Test 1|My first test|
|Test 2|My second test|
