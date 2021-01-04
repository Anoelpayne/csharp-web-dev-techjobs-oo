using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TechJobsOO
{
    public class Job
    {
        public int Id { get; }
        private static int nextId = 1;

        public string Name { get; set; }
        public Employer EmployerName { get; set; }
        public Location EmployerLocation { get; set; }
        public PositionType JobType { get; set; }
        public CoreCompetency JobCoreCompetency { get; set; }

        private PropertyInfo[] _PropertyInfos = null;
        

        // TODO: Add the two necessary constructors.
        public Job ()
        {
            Id = nextId;
            nextId++;
        }

        public Job (string name, Employer employerName, Location employerLocation, PositionType jobType, CoreCompetency jobCoreCompetency) : this()
        {
            Name = name;
            EmployerName = employerName;
            EmployerLocation = employerLocation;
            JobType = jobType;
            JobCoreCompetency = jobCoreCompetency;
        }

        public override bool Equals(object obj)
        {
            return obj is Job job &&
                   Id == job.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
        // TODO: Generate Equals() and GetHashCode() methods.




        public override string ToString()
        {
            List<string> labels = new List<string>() { "Id", "Name", "Employer", "Location", "Poistion Type", "Core Competency" };
            if (_PropertyInfos == null)
            {
                _PropertyInfos = GetType().GetProperties();
            }
            var sb = new StringBuilder();
                for (var i =0; i < labels.Count; i++)
                {
                    object value = _PropertyInfos[i].GetValue(this, null) ?? "(null)";
                    if (value.ToString() == "")
                    {
                    value = "Data not available";
                    }


                _ = sb.AppendLine(labels[i] + ": " + value.ToString());
                
                }
            return $"{Environment.NewLine}{sb}{Environment.NewLine}";
        }
    }
}

