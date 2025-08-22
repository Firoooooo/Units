using System.Xml;

namespace UnitTExamples
{
    public abstract class AXElementReader
    {
        public AXType Type { get; }
        public AXXMLDocument AxDocument { get; }
        public string XPath { get; set; }


        protected AXElementReader(AXType _xMLType, AXXMLDocument _xMLDocument, string _xPath)
        {
            AxDocument = _xMLDocument;
            Type = _xMLType;
            XPath = _xPath;
        }

        public abstract XMLTagLocator FindTag();

        public virtual void InsertCommentIntoSource(string _xMlFillTagsValue)
        {
        }

        public static void InsertCommentIntoClass(XmlNode _xMLChildNode, string _xMLValue)
        {
            if (_xMLChildNode != null
                && _xMLChildNode.FirstChild is XmlCDataSection XMLCData
                && !XMLCData.InnerText.Trim().Contains(_xMLValue.Trim()))
            {
                string xMLCDATAValue = XMLCData.Value;
                var xMLCDataSplitted = xMLCDATAValue.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList();
                xMLCDataSplitted.Insert(0, $"// {_xMLValue}");
                xMLCDATAValue = string.Join("\r\n", xMLCDataSplitted);
                XMLCData.Value = xMLCDATAValue;
            }
        }
    }
}

