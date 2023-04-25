namespace RT_Customer_MyFirstRegressionTest_1.Tests
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using Moq;

	using Skyline.DataMiner.Automation;

	[TestClass]
	public class TestCaseExampleTests
	{
		[TestMethod]
		public void TestCaseExampleNameNull()
		{
			Assert.ThrowsException<ArgumentNullException>(() => new TestCaseExample(null));
		}

		[TestMethod]
		public void TestCaseExampleNameEmpty()
		{
			Assert.ThrowsException<ArgumentNullException>(() => new TestCaseExample(String.Empty));
		}

		[TestMethod]
		public void ExecuteTest()
		{
			// Arrange
			TestCaseExample tce = new TestCaseExample("example");
			Mock<IEngine> engine = new Mock<IEngine>();

			// Act
			tce.Execute(engine.Object);

			// Assert
			Assert.IsTrue(tce.TestCaseReport != null || tce.PerformanceTestCaseReport != null, "At least one Test Case Report should be assigned (TestCaseReport or PerformanceTestCaseReport)");
		}
	}
}