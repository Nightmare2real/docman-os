using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Api.Tests
{
    [TestClass]
    public class TestFields
    {
        [TestMethod]
        public async Task Given_a_folder_when_setting_a_field_it_is_possible_to_read_it_again()
        {
            //Arrange
            using var ctx = DocumentManager.OpenContext();
            Folder folder = new();
            ctx.Folders.Add(folder);            
            int a = 1;
            var key = nameof(a);

            //Act
            folder[key] = a;
            await ctx.SaveChangesAsync();

            //Assert
            AreEqual(a, folder[key]);
            AreEqual(1, ctx.Folders.Count);
            AreEqual(1, DocumentManager.Folders.Count);
        }

        [TestMethod]
        public void Given_a_folder_with_a_parrent_folder_when_key_is_not_found_read_the_value_from_parrent_folder()
        {
            //Arrange
            Folder parrentFolder = new();
            Folder folder = new(parrentFolder);
            var fieldName = DateTime.Now;
            var key = nameof(fieldName);

            parrentFolder[key] = fieldName;

            //Act
            var result = folder[key];

            //Assert
            AreEqual(fieldName, result);
        }


        [TestMethod]
        public void Given_user_have_a_folder_when_the_user_adds_a_custom_field_then_then_the_document_can_read_the_value()
        {
            //Arrange
            Folder folder = new();
            folder.Documents.Add(new Document(folder));
            var fieldName = "hej med dig";
            var key = nameof(fieldName);
            folder[key] = fieldName;

            //Act   
            var valueFromDocument = folder.Documents.First()[key];

            //Assert
            AreEqual(fieldName, valueFromDocument);
        }

        [TestMethod]
        public void Given_a_document_and_a_folder_when_the_document_is_modifying_fields_from_the_folder_then_throw_exception()
        {
            //Arrange
            Folder folder = new();
            folder.Documents.Add(new Document(folder));
            var fieldName = 2f;
            var key = nameof(fieldName);
            folder[key] = fieldName;

            //Act
            var ex = ThrowsException<InvalidOperationException>(() => folder.Documents.First()[key] = 3f);

            //Assert
            AreEqual("It's not possible to edit parrents fields", ex.Message);
        }

        [TestMethod]
        public void Given_a_folder_with_a_parrent_folder_when_the_child_folder_is_modifying_fields_from_the_parrent_folder_then_throw_exception()
        {
            //Arrange
            Folder parrentFolder = new();
            Folder folder = new(parrentFolder);            
            var fieldName = 33/3;
            var key = nameof(fieldName);
            parrentFolder[key] = fieldName;

            //Act
            var ex = ThrowsException<InvalidOperationException>(() => folder[key] = 3f);

            //Assert
            AreEqual("It's not possible to edit parrents fields", ex.Message);
        }

    }
}
