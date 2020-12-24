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

        // Stopped here need to test the Equals() method
    }
}
