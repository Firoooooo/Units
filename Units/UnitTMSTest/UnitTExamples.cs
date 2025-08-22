using UnitTExamples;
using UnitTExamples.Factories;

namespace UnitTMSTest
{
    [TestClass]
    public class UnitTExamples
    {
        [TestMethod]
        public void AXGetPredecessor()
        {
            string xMLPath = @"";
            AXXMLDocument xMLDocument = new AXXMLDocument(xMLPath);
            AxElementReaderFactory xMLReaderFactory = new AxElementReaderFactory();
            AXElementReader xMLReader = xMLReaderFactory.GetReader(xMLDocument);
            
        }
    }
} 
