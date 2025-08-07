using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMars_Certification_Education.TestData
{
    public class Educationtestdata
    {
        public class EducationTestData
        {
            public string CollegeUniversityName { get; set; }
            public string CountryOfCollegeUniversity { get; set; }
            public string Title { get; set; }
            public string Degree { get; set; }
            public string YearOfGraduation { get; set; }
            public string NewCollegeUniversityName { get; set; }
            public string NewCountryOfCollegeUniversity { get; set; }
            public string NewTitle { get; set; }
            public string NewDegree { get; set; }
            public string NewYearOfGraduation { get; set; }
        }

        public static class TestDataReader
        {
            public static Dictionary<string, List<EducationTestData>> ReadTestData()
            {
                string projectRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", ".."));
                string testDataPath = Path.Combine(projectRoot, "Configuration", "Education.json");
                string jsonData = File.ReadAllText(testDataPath);
                var testData = JsonConvert.DeserializeObject<Dictionary<string, List<EducationTestData>>>(jsonData);
                return testData;
            }
        }
    }
}
