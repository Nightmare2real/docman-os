using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Linq;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Api.Tests.FileTransfers
{
    //Test cases:
    //https://dev.azure.com/sampension-workflow/workflow-opgrade/_workitems/edit/14
    [TestClass]
    public class UploadingOfDocuments
    {

        //Scenario 1
        [TestMethod]
        public void Given_a_user_who_uploads_a_document_store_the_document_in_the_document_queue()
        {
            //Arrange
            Document document = new();
            var value = 2;
            var key = nameof(value);
            document[key] = value;

            //Act
            DocumentManager.Add(document);

            //Assert
            AreEqual(1, DocumentManager.Documents.Count);
            AreEqual(value, DocumentManager.Documents.First()[key]);    
        }

    }
}
