using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {
        [TestMethod]
        public void TestMethod1TestSettingJobId()
        {
            var job1 = new Job();
            var job2 = new Job();

            Assert.IsTrue(job2.Id - job1.Id == 1);

        }

        Job _testJob;

        [TestInitialize]
        public void CreateJobObject()
        {
            // "Product tester" for Name, "ACME" for EmployerName, "Desert" for JobLocation, "Quality control"
            // for JobType, and "Persistence" for JobCoreCompetency

            _testJob = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Assert.AreEqual(_testJob.Name, "Product tester");
            var testLocation = _testJob.EmployerLocation;
            Assert.AreEqual(testLocation.Value, "Desert");
            var testType = _testJob.JobType;
            Assert.AreEqual(testType.Value, "Quality control");
            var testCore = _testJob.JobCoreCompetency;
            Assert.AreEqual(testCore.Value, "Persistence");
            var testEmName = _testJob.EmployerName;
            Assert.AreEqual(testEmName.Value, "ACME");

        }

        [TestMethod]
        public void TestJobsForEquality()
        {
           var testJob2 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            Assert.IsFalse(_testJob.Equals(testJob2));
            
        }
        
        [TestMethod]
        public void TestToStringJobsMethodForBlankLineAtBeginning()
        {
            var print = _testJob.ToString();
            Assert.AreEqual(print[0], '\n');

        }

        [TestMethod]
        public void TestToStringJobsMethodForBlankLineAtEnd()
        {
            var print = _testJob.ToString();
            Assert.AreEqual(print[^1], '\n');
        }

        [TestMethod]
        public void ToStringMethodShouldPrintIdOnOwnLine()
        {
            var print = _testJob.ToString();
            var testID = _testJob.Id;
            Assert.IsTrue(print.Contains($"\nID: {testID} \n"));
        }

//        ID:  _______
//Name: _______
//Employer: _______
//Location: _______
//Position Type: _______
//Core Competency: _______

        [TestMethod]
        public void ToStringMethodShouldPrintNameOnOwnLine()
        {
            var print = _testJob.ToString();
            var testName = _testJob.Name;
            Assert.IsTrue(print.Contains($"\nName: {testName} \n"));
        }

        [TestMethod]
        public void ToStringMethodShouldPrintEmployerOnOwnLine()
        {
            var print = _testJob.ToString();
            var testEmployer = _testJob.EmployerName;
            Assert.IsTrue(print.Contains($"\nEmployer: {testEmployer}"));
        }

        [TestMethod]
        public void ToStringMethodShouldPrintPositionTypeOnOwnLine()
        {
            var print = _testJob.ToString();
            var testJobType = _testJob.JobType;
            Assert.IsTrue(print.Contains($"\nPosition Type: {testJobType} \n"));
        }

        [TestMethod]
        public void ToStringMethodShouldPrintLocationOnOwnLine()
        {
            var print = _testJob.ToString();
            var testLocation = _testJob.EmployerLocation;
            Assert.IsTrue(print.Contains($"\nLocation: {testLocation} \n"));
        }

        [TestMethod]
        public void ToStringMethodShouldPrintCoreCompetencyOnOwnLine()
        {
            var print = _testJob.ToString();
            var testCoreCompetency = _testJob.JobCoreCompetency;
            Assert.IsTrue(print.Contains($"\nCore Competency: {testCoreCompetency} \n"));
        }

        // Left off at TDD test #3
    }
}
