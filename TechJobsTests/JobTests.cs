using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
            Assert.IsTrue(print.IndexOf(Environment.NewLine) == 0);

        }

        [TestMethod]
        public void TestToStringJobsMethodForBlankLineAtEnd()
        {
            string print = _testJob.ToString();
            Assert.IsTrue(print.LastIndexOf(Environment.NewLine) == print.Length - 2);
        } 

        [TestMethod]
        public void TestToStringPrintsEachProperyCorrectAndOnANewLine()
        {
            string print = _testJob.ToString();
            Assert.IsTrue(print.Contains($"Id: {_testJob.Id}{Environment.NewLine}"));
            Assert.IsTrue(print.Contains($"Employer: {_testJob.EmployerName}{Environment.NewLine}"));
            Assert.IsTrue(print.Contains($"Location: {_testJob.EmployerLocation}{Environment.NewLine}"));
            Assert.IsTrue(print.Contains($"Poistion Type: {_testJob.JobType}{Environment.NewLine}"));
            Assert.IsTrue(print.Contains($"Core Competency: {_testJob.JobCoreCompetency}{Environment.NewLine}"));
            Assert.IsTrue(print.Contains($"Name: {_testJob.Name}{Environment.NewLine}"));
        }

        [TestMethod]
        public void ToStringMethodShouldPrintDataNotAvailableIfFieldIsEmpty()
        {
            Job _testJob2 = new Job("Product tester", new Employer(""), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
           string result = _testJob2.ToString();
            Assert.IsTrue(result.Contains("Employer: Data not available"));
        }

    }
}
