using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckAnagram;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Program.IsAnagram("Tom Marvolo Riddle", "I am Lord Voldemort!");
            Program.IsAnagram("Dave Barry", "Ray Adverb");
        }
    }
}
