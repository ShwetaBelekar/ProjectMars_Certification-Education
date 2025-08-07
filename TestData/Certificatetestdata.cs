using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMars_Certification_Education.TestData
{
    public class Certificatetestdata
    {
        public class CertificationTestData
        {
            public string CertificateAward { get; set; }
            public string CertificateFrom { get; set; }
            public string Year { get; set; }
            public string NewCertificateAward { get; set; }
            public string NewCertificateFrom { get; set; }
            public string NewYear { get; set; }
            public string UpdatedCertificateAward { get; set; }
        }
        public static class TestDataReader
        {
            public static Dictionary<string, List<CertificationTestData>> ReadTestData()
            {
                string projectRoot = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", ".."));
                string testDataPath = Path.Combine(projectRoot, "Configuration", "CertificationTestData.json");
                string jsonData = File.ReadAllText(testDataPath);
                var testData = JsonConvert.DeserializeObject<Dictionary<string, List<CertificationTestData>>>(jsonData);
                return testData;
            }
        }

        
    }
}
