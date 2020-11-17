using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

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
    }
}
