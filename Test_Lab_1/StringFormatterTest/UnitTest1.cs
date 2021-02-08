using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringFormatterTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void StringFormatterTest()
        {
            // arrange
            string pathWithExt = @"C:\User\Desktop\MyFile.txt", pathNoExt = @"C:\User\Desktop\MyFile";
            string expected_1 = "MYFILE.TMP", expected_2 = "MYFILE.TMP";

            // act
            string actual_1 = ExerciseClasses.StringFormatter.ShortFileString(pathWithExt);
            string actual_2 = ExerciseClasses.StringFormatter.ShortFileString(pathNoExt);

            // assert
            Assert.AreEqual(expected_1, actual_1);
            Assert.AreEqual(expected_2, actual_2);
        }
    }
}
