using System.Xml;

namespace UnitTExamples.AXReader
{
    internal class AXClassReader : AxRootPredecessor
    {
        public string FillTags { get; set; }


        public AXClassReader(AXType _xMLType, AXXMLDocument _xMLDocument, string _xPath)
            : base(_xMLType, _xMLDocument, _xPath)
        {

        }

        public override XMLTagLocator FindTag()
        {
            XMLTagLocator xMLTagLocation = new XMLTagLocator()
            {
                Location = XMLTagLocation.CommentWriter
            };

            return xMLTagLocation;
        }

        public override void InsertCommentIntoSource(string _xMLValue)
        {
            XmlNode xMLChildNode = this.AxDocument.Document.SelectSingleNode(this.XPath);
            AXElementReader.InsertCommentIntoClass(xMLChildNode, _xMLValue);
        }
    }
}
