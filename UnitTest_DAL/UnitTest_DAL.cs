using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;

namespace UnitTest
{
    [TestClass]
    public class UnitTest_DAL
    {
        [TestMethod]
        public void Test_TeacherFromID()
        {
            IDAL dal = new MSSQLDatabase(@"Data Source=LAPTOP-51J7J6GA\SQLEXPRESS;Initial Catalog=Skole;Integrated Security=True");
            var teacher = dal.TeacherFromID(1);
            Assert.AreEqual("Lærer1", teacher.Name, "Incorrect name");
            Assert.AreEqual(1, teacher.Id, "Incorrect ID");
            
        }
        [TestMethod]
        public void Test_TeacherFromIDWithStudents()
        {
            IDAL dal = new MSSQLDatabase(@"Data Source=LAPTOP-51J7J6GA\SQLEXPRESS;Initial Catalog=Skole;Integrated Security=True");
            var teacher = dal.TeacherFromID(1);
            Assert.AreEqual("Lærer1", teacher.Name, "Incorrect name");
            Assert.AreEqual(1, teacher.Id, "Incorrect ID");
            Assert.AreEqual(2, teacher.Students.Count, "Incorrect student amount");
            Assert.AreEqual("Elev1 - Lærer1", teacher.Students[0].Name, "Incorrect name");
            Assert.AreEqual("Elev2 - Lærer1", teacher.Students[1].Name, "Incorrect name");
        }
    }
}
