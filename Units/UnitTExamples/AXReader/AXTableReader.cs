namespace UnitTExamples.AXReader
{
    internal class AXTableReader : AXRootPredecessor
    {
        public AXTableReader(AXType _xMLType, AXXMLDocument _xMLDocument, string _xPath)
            : base(_xMLType, _xMLDocument, _xPath)
        {

        }

        public override XMLTagLocator FindTag()
        {
            XMLTagLocator xMLTagLocation = new XMLTagLocator()
            {
                Location = XMLTagLocation.XPathOfPredecessor,
                XPath = this.XPath,
                FallBacks = new System.Collections.Generic.List<string>()
                {
                    $"/{Type}/Label",
                    $"/{Type}/SourceCode"
                }
            };

            return xMLTagLocation;
        }
    }
}
