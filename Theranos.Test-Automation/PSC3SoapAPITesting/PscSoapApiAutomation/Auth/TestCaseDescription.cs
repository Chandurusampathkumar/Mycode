namespace ServiceTests.Auth
{
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class TestCaseDescription : System.Attribute
    {
        public string TestCaseId;
        public string TestDescription;
        public bool IsNegativeCase;
        public string MethodDescription;

        public TestCaseDescription(string testCaseId, string testDescription, bool isNegativeCase, string methodDescription)
        {
            this.TestCaseId = testCaseId;
            this.TestDescription = testDescription;
            this.IsNegativeCase = isNegativeCase;
            this.MethodDescription = methodDescription;
        }
    }
}