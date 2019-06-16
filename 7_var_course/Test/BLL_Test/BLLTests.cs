using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Test
{
    [TestClass()]
    public class BLLTests
    {
        VisitorsList visitors = new VisitorsList();
        DocsList docs = new DocsList();
        Find find= new Find();

        [TestMethod()]
        public void AddV()
        {
            visitors.Add("test", "test", 117, new DocOffers());
        }
        [TestMethod()]
        public void AddV1()
        {
            Assert.ThrowsException<LibraryException>(() => visitors.Add("", "test", 117, new DocOffers()), "Empty name\\surname");
        }
        [TestMethod()]
        public void AddV2()
        {
            Assert.ThrowsException<LibraryException>(() => visitors.Add("test", "", 117, new DocOffers()), "Empty name\\surname");
        }
        [TestMethod()]
        public void AddV3()
        {
            Assert.ThrowsException<LibraryException>(() => visitors.Add("test", "test", -200, new DocOffers()),"Invalid groupe");
        }
        [TestMethod()]
        public void RemoveV()
        {
            visitors.Add("test", "test", 117, new DocOffers());
            visitors.Remove(0);
        }
        [TestMethod()]
        public void RemoveV1()
        {
            Assert.ThrowsException<LibraryException>(() => visitors.Remove(-1), "Invalid index");
        }
        [TestMethod()]
        public void EditV()
        {
            visitors.Add("test", "test", 117, new DocOffers());
            visitors.Edit(0, "new", "some", 119);
        }
        [TestMethod()]
        public void EditV1()
        {
            Assert.ThrowsException<LibraryException>(() => visitors.Edit(-1, "new", "some", 220), "InvalidIndex");
        }
        [TestMethod()]
        public void EditV2()
        {
            visitors.Add("test", "test", 117, new DocOffers());

            Assert.ThrowsException<LibraryException>(() => visitors.Edit(0, "", "some", 220), "Empty name\\surname");
        }
        [TestMethod()]
        public void EditV3()
        {
            visitors.Add("test", "test", 117, new DocOffers());

            Assert.ThrowsException<LibraryException>(() => visitors.Edit(0, "new", "", 220), "Empty name\\surname");
        }
        [TestMethod()]
        public void EditV4()
        {
            visitors.Add("test", "test", 117, new DocOffers());

            Assert.ThrowsException<LibraryException>(() => visitors.Edit(0, "new", "some", -1), "Invalid group");
        }
        [TestMethod()]
        public void SaveV()
        {
            visitors.Save();
        }
        [TestMethod()]
        public void SortByNameV()
        {
            visitors.SortByName();
        }
        [TestMethod()]
        public void SortBySurnameV()
        {
            visitors.SortBySurname();
        }
        [TestMethod()]
        public void SortByGroupV()
        {
            visitors.SortByGroup();
        }
        [TestMethod()]
        public void GetAllV()
        {
            visitors.GetAllVisitors();
        }
        [TestMethod()]
        public void AddD()
        {
            docs.Add("Author", "Book");
        }
        [TestMethod()]
        public void AddD1()
        {
            Assert.ThrowsException<LibraryException>(() => docs.Add("", "Book"),"Empty Author");
        }
        [TestMethod()]
        public void AddD2()
        {
            Assert.ThrowsException<LibraryException>(() => docs.Add("Author", ""),"Empty title");
        }
        [TestMethod()]
        public void RemoveD()
        {
            docs.Add("auit","gool");
            docs.Remove(0);
        }
        [TestMethod()]
        public void RemoveD1()
        {
            Assert.ThrowsException<LibraryException>(() => docs.Remove(-1),"Invalid index");
        }
        [TestMethod()]
        public void FindTest()
        {
            find.FindDocument(docs, "test");
        }
        [TestMethod()]
        public void FindTes1()
        {
            find.FindVisitor(visitors, "test");
        }
    }
}
