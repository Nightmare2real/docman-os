using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Linq;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Api.Tests
{
    //Test cases:
    //https://dev.azure.com/sampension-workflow/workflow-opgrade/_workitems/edit/11
    [TestClass]
    public class FieldsInFolders
    {
        //Scenario 1
        [TestMethod]
        public void Given_User_have_a_folder_when_the_user_adds_a_fields_to_the_folder_then_the_folder_should_be_able_to_read_the_value_of_the_field()
        {
            //Arrange
            Folder folder = new();
            int a = 1;
            var key = nameof(a);

            //Act
            folder[key] = a;

            //Assert
            AreEqual(a, folder[key]);            
        }

        //Scenario 2
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

        //Scenario 3
        [TestMethod]
        public void User_adds_meta_data_to_folder_a_folder_with_a_sub_folders_given_User_have_a_folder_and_the_folder_contains_sub_folders_when_the_user_adds_a_fields_to_the_folder_then_the_sub_folders_should_all_be_able_to_read_the_value_of_the_field()
        {
            //Arrange
            Folder folder = new();
            for (int i = 0; i < 3; i++)
                folder.SubFolders.Add(new(folder));

            //Act
            var fieldName = "42";
            var key = nameof(fieldName);
            folder[key] = fieldName;

            //Assert
            foreach (var subFolder in folder.SubFolders)
                AreEqual(fieldName, subFolder[key]);
        }

        //Scenario 4
        [TestMethod]
        public void Given_User_have_a_folder_with_a_parrent_folder_when_the_user_reads_a_field_that_is_not_found_in_the_folder_then_return_the_value_of_the_field_from_the_parrent_folder()
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



        //Scenario 5
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

        //Scenario 6
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
