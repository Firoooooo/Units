using System.Xml;

namespace UnitTExamples
{
    public class TagHelper
    {
        public static XmlNode FindPredecessor(AXXMLDocument _xMLDoc, XMLTagLocator _xMLTagLocation)
        {
            XmlNamespaceManager xMLNamespace = _xMLDoc.CreateNamespaceManager();
            XmlNode xMLTagPredecessor = _xMLDoc.Document.SelectSingleNode(_xMLTagLocation.XPath, xMLNamespace);

            if (xMLTagPredecessor == null && _xMLTagLocation.FallBacks.Count() > 0)
            {
                foreach (string xMLFallbacks in _xMLTagLocation.FallBacks)
                {
                    xMLTagPredecessor = _xMLDoc.Document
                        .SelectSingleNode(xMLFallbacks, xMLNamespace);

                    if (xMLTagPredecessor != null)
                    {
                        break;
                    }
                }
            }

            return xMLTagPredecessor;
        }
    }
}
