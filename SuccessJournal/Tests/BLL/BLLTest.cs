using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL.Student;
using BLL.Group;
using BLL.Exeption;
using BLL.Success;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.BLL
{
    [TestClass()]
    public class BLLTest
    {
        StudentService students = new StudentService();
        GroupService groups = new GroupService();

        [TestMethod()]
        public void AddStudentTest()
        {
            students.Add("lkkkn", "kkj");
        }
        [TestMethod()]
        public void AddStudentTest_Empty_Name()
        {
            Assert.ThrowsException<SuccessExeption>(() => students.Add("", "kkj"), "Empty name\\surname");
        }
        [TestMethod()]
        public void AddStudentTest_Empty_surname()
        {
            Assert.ThrowsException<SuccessExeption>(() => students.Add("lkkkn", ""), "Empty name\\surname");
        }
        [TestMethod()]
        public void RemoveStudentTest()
        {
            students.Add("lkkkn", "kkj");
            students.Remove(0);
        }
        [TestMethod()]
        public void AddSubjectTest()
        {
            students.Add("lkkkn", "kkj");
            students.AddSubject(0, new Journal("lol", 65));
        }
        [TestMethod()]
        public void RemoveSubjectTest()
        {
            students.Add("lkkkn", "kkj");
            students.AddSubject(0, new Journal("lol", 65));
            students.RemoveSubject(0, 0);
        }
        [TestMethod()]
        public void RemoveStudentTest_IndexERROR()
        {
            students.Add("lkkkn", "kkj");
            Assert.ThrowsException<SuccessExeption>(() => students.Remove(-1), "Invalid index");
        }
        [TestMethod()]
        public void EditStudent()
        {
            students.Add("lkkkn", "kkj");
            students.Edit(0, "new", "some");
        }
        [TestMethod()]
        public void EditStudent_IndexERROR()
        {
            students.Add("lkkkn", "kkj");
            Assert.ThrowsException<SuccessExeption>(() => students.Edit(-1, "new", "some"), "Invalid index");
        }
        [TestMethod()]
        public void StudentSave()
        {
            students.Save();
        }
        [TestMethod()]
        public void GroupSave()
        {
            groups.Save();
        }
        [TestMethod()]
        public void GroupAdd()
        {
            groups.Add(121);
        }
        [TestMethod()]
        public void GroupAdd_IndexErorr()
        {
            Assert.ThrowsException<SuccessExeption>(() => groups.Add(-1), "Invalid index");
        }
        [TestMethod()]
        public void GroupRemove()
        {
            groups.Add(121);
        }
        [TestMethod()]
        public void GroupRemove_IndexERORR()
        {
            Assert.ThrowsException<SuccessExeption>(() => groups.Add(-1), "Invalid index");
        }
        [TestMethod()]
        public void StudentGetInfo()
        {
            students.Add("dfdf", "dfdf");
            students.GetInfo(0);
        }

    }
}