namespace UnitTExamples.AXReader
{
    internal class AxRootPredecessor : AxElementReader
    {
        public AxRootPredecessor(AXType _xMLType, AXXMLDocument _xMLDocument, string _xPath)
            : base(_xMLType, _xMLDocument, _xPath)
        {

        }

        public override XMLTagLocator FindTag()
        {
            XMLTagLocator xMLTagLocation = new XMLTagLocator()
            {
                Location = XMLTagLocation.XPathOfPredecessor,
                XPath = this.XPath
            };

            return xMLTagLocation;
        }


    }
}
