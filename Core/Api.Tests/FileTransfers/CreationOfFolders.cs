using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Linq;

namespace Api.Tests.FileTransfers
{
    //Test cases:
    //https://dev.azure.com/sampension-workflow/workflow-opgrade/_workitems/edit/14
    [TestClass]
    public class CreationOfFolders
    {
        public string Path { get; private set; }

        //Scenario 1
        [TestMethod]
        public void Given_a_user_who_creates_a_folder_when_the_folder_is_empty_then_the_create_the_folder()
        {
            //Arrange
            var folderName = "TopLevel";
            Folder folder = new() {Name=folderName};

            //Act
            DocumentManager.Add(folder);

            //Assert
            Assert.AreEqual(1, DocumentManager.Folders.Count);
            Assert.AreEqual(folderName, DocumentManager.Folders.First(f => f.Name == folderName).Name);
        }

    }
}
