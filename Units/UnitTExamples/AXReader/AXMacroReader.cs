using System.Xml;

namespace UnitTExamples.AXReader
{
    internal class AxMacroWriter : AxRootPredecessor
    {
        public AxMacroWriter(AXType _xMLType, AXXMLDocument _xMLDocument, string _xPath)
            : base(_xMLType, _xMLDocument, _xPath)
        {

        }

        public override XMLTagLocator FindTag()
        {
            XMLTagLocator xMLTagLocation = new XMLTagLocator()
            {
                Location = XMLTagLocation.MacroWriter
            };

            return xMLTagLocation;
        }

        public override void InsertCommentIntoSource(string _xMLFillTagsValue)
        {
            XmlNode xMLChildNode = this.AxDocument.Document.SelectSingleNode(this.XPath);

            if (xMLChildNode != null
                && !xMLChildNode.InnerText.Contains($"// {_xMLFillTagsValue}"))
            {
                string xMLValue = xMLChildNode.InnerText;
                var xMLSplittedValue = xMLValue.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList();
                xMLSplittedValue.Insert(0, $"// {_xMLFillTagsValue}");
                xMLValue = string.Join("\r\n", xMLSplittedValue);
                xMLChildNode.InnerText = xMLValue;
            }

        }
    }
}
