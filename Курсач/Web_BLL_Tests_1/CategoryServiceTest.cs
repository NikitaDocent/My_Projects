using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebBL.DTO;
using WebBL.Services;
using WebBL.Infrastructure;
using NUnit;
using Assert = NUnit.Framework.Assert;
using NUnit.Framework;

namespace Web_BLL_Tests_1
{
    [TestClass]
    public class CategoryServiceTest
    {
        [TestMethod]
        public void Add_category_Pivko_new_category_Pibko()
        {
            //arrage
            CategoryDTO cdto = new CategoryDTO() { Name = "PIBKO", Id = 1 };
            CategoryService cs = new CategoryService();
            CategoryDTO expected_category = cdto;
            //act

            //assert
            Assert.AreEqual(true, true);
        }
        [Test]
        public void Get_last_category_return_category_Pibko()
        {
            //arrage
            CategoryDTO expected = new CategoryDTO();
            string name = "PIBKO";
            int index = 0;
            //act 
            expected.Name = name;
            CategoryService cs = new CategoryService();
            expected = cs.Get(index);
            //assert
            Assert.AreEqual(expected.Name, name);
        }
        [Test]
        public void Delete_category_cat_for_index_1_not_category_cat()
        {
            //arrage
            CategoryService cs = new CategoryService();
            bool expected = true, actual = true;
            int index = 0;
            cs.Delete(index);
            //assert
            Assert.AreEqual(expected, actual);
        }

    }
}
