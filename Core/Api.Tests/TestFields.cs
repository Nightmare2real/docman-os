using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;

namespace Api.Tests
{
    [TestClass]
    public class TestFields
    {
        [TestMethod]
        public void It_is_possible_to_store_a_value_in_a_field()
        {
            var doc = new Document();

            doc.Fields["a"] = 1;

            Assert.AreEqual(1, doc.Fields["a"]);
        }

        [TestMethod]
        public void Given_a_doc_when_retriving_a_key_not_found_in_doc_then_look_it_up_from_folder()
        {
            var folder = new Folder();
            folder.Fields["a"] = 2;
            var doc = new Document(folder);

            var res = doc.Fields["a"];

            Assert.AreEqual(2, res);
        }

        [TestMethod]
        public void Given_a_doc_with_a_documenttype_retrive_fields_from_doc_type()
        {
            //Arrange
            var expectedValue = "docType";
            var type = new DynamicItem();
            
            type.Fields["b"] = expectedValue;
            var doc = new Document(documentType: type);
            //Act
            var res = doc.Fields["b"];

            //Assert
            Assert.AreEqual(expectedValue, res);
        }

        [TestMethod]
        public void Given_a_folder_with_a_folder_type_retrive_fields_from_folder_type()
        {
            var expectedValue = DateTime.Now;
            var type = new DynamicItem();
            type.Fields["c"] = expectedValue;

            var folder = new Folder(type);

            //Act
            var res = folder.Fields["c"];

            //Arrange
            Assert.AreEqual(expectedValue, res);            
        }

    }
}
