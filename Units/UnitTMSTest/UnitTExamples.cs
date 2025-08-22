using System.Xml;
using UnitTExamples;
using UnitTExamples.Factories;

namespace UnitTMSTest
{
    [TestClass]
    public class UnitTExamples
    {
        [TestMethod]
        public void AXEDTGetPredecessor()
        {
            string xMLPath = @"C:\Users\localadmin\Documents\Visual Studio 2022\Units\Model\AXExtendedDataT\AXExtendedDataT.xml";
            AXXMLDocument xMLDocument = new AXXMLDocument(xMLPath, AXType.AxEdt);
            AxElementReaderFactory xMLReaderFactory = new AxElementReaderFactory();

            AXElementReader xMLReader = xMLReaderFactory.GetReader(xMLDocument);
            XMLTagLocator xMLTagLocator = xMLReader.FindTag();

            XmlNode xMLNodePre = TagHelper.FindPredecessor(xMLDocument, xMLTagLocator);
            Assert.IsNotNull(xMLNodePre);
        }

        [TestMethod]
        public void InsertTagInAXClass()
        {
            string xMLPath = @"C:\Users\localadmin\Documents\Visual Studio 2022\Units\Model\AXClass\AXClass.xml";
            AXXMLDocument xMLDocument = new AXXMLDocument(xMLPath, AXType.AxClass);
            AxElementReaderFactory xMLReaderFactory = new AxElementReaderFactory();

            AXElementReader xMLReader = xMLReaderFactory.GetReader(xMLDocument);
            string xMLComment = "Moinsen";
            xMLReader.InsertCommentIntoSource(xMLComment);

            Assert.IsTrue(xMLDocument.Document
                .InnerText.Contains(xMLComment));
        }

        [TestMethod]
        public void AXMIOutputGetPredecessor()
        {
            string xMLPath = @"C:\Users\localadmin\Documents\Visual Studio 2022\Units\Model\AXOutput\AXOutput.xml";
            AXXMLDocument xMLDocument = new AXXMLDocument(xMLPath, AXType.AxMenuItemOutput);
            AxElementReaderFactory xMLReaderFactory = new AxElementReaderFactory();

            AXElementReader xMLReader = xMLReaderFactory.GetReader(xMLDocument);
            XMLTagLocator xMLTagLocator = xMLReader.FindTag();

            XmlNode xMLNodePre = TagHelper.FindPredecessor(xMLDocument, xMLTagLocator);
            Assert.IsNotNull(xMLNodePre);
        }

        [TestMethod]
        public void AXMIDisplayGetPredecessor()
        {
            string xMLPath = @"C:\Users\localadmin\Documents\Visual Studio 2022\Units\Model\AXDisplay\AXDisplay.xml";
            AXXMLDocument xMLDocument = new AXXMLDocument(xMLPath, AXType.AxMenuItemDisplay);
            AxElementReaderFactory xMLReaderFactory = new AxElementReaderFactory();

            AXElementReader xMLReader = xMLReaderFactory.GetReader(xMLDocument);
            XMLTagLocator xMLTagLocator = xMLReader.FindTag();

            XmlNode xMLNodePre = TagHelper.FindPredecessor(xMLDocument, xMLTagLocator);
            Assert.IsNotNull(xMLNodePre);
        }

        [TestMethod]
        public void AXMIActionGetPredecessor()
        {
            string xMLPath = @"C:\Users\localadmin\Documents\Visual Studio 2022\Units\Model\AXAction\AXAction.xml";
            AXXMLDocument xMLDocument = new AXXMLDocument(xMLPath, AXType.AxMenuItemAction);
            AxElementReaderFactory xMLReaderFactory = new AxElementReaderFactory();

            AXElementReader xMLReader = xMLReaderFactory.GetReader(xMLDocument);
            XMLTagLocator xMLTagLocator = xMLReader.FindTag();

            XmlNode xMLNodePre = TagHelper.FindPredecessor(xMLDocument, xMLTagLocator);
            Assert.IsNotNull(xMLNodePre);
        }

        [TestMethod]
        public void AXTableGetPredecessor()
        {
            string xMLPath = @"C:\Users\localadmin\Documents\Visual Studio 2022\Units\Model\AXTable\AXTable.xml";
            AXXMLDocument xMLDocument = new AXXMLDocument(xMLPath, AXType.AxTable);
            AxElementReaderFactory xMLReaderFactory = new AxElementReaderFactory();

            AXElementReader xMLReader = xMLReaderFactory.GetReader(xMLDocument);
            XMLTagLocator xMLTagLocator = xMLReader.FindTag();

            XmlNode xMLNodePre = TagHelper.FindPredecessor(xMLDocument, xMLTagLocator);
            Assert.IsNotNull(xMLNodePre);
        }

        [TestMethod]
        public void AXFormGetPredecessor()
        {
            string xMLPath = @"C:\Users\localadmin\Documents\Visual Studio 2022\Units\Model\AXForm\AXForm.xml";
            AXXMLDocument xMLDocument = new AXXMLDocument(xMLPath, AXType.AxForm);
            AxElementReaderFactory xMLReaderFactory = new AxElementReaderFactory();

            AXElementReader xMLReader = xMLReaderFactory.GetReader(xMLDocument);
            XMLTagLocator xMLTagLocator = xMLReader.FindTag();

            XmlNode xMLNodePre = TagHelper.FindPredecessor(xMLDocument, xMLTagLocator);
            Assert.IsNotNull(xMLNodePre);
        }

        [TestMethod]
        public void AXMenuGetPredecessor()
        {
            string xMLPath = @"C:\Users\localadmin\Documents\Visual Studio 2022\Units\Model\AXMenu\AXMenu.xml";
            AXXMLDocument xMLDocument = new AXXMLDocument(xMLPath, AXType.AxMenu);
            AxElementReaderFactory xMLReaderFactory = new AxElementReaderFactory();

            AXElementReader xMLReader = xMLReaderFactory.GetReader(xMLDocument);
            XMLTagLocator xMLTagLocator = xMLReader.FindTag();

            XmlNode xMLNodePre = TagHelper.FindPredecessor(xMLDocument, xMLTagLocator);
            Assert.IsNotNull(xMLNodePre);
        }
    }
} 
