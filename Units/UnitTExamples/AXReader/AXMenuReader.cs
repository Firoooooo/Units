namespace UnitTExamples.AXReader
{
    internal class AXMenuReader : AXRootPredecessor
    {
        public AXMenuReader(AXType _xMLType, AXXMLDocument _xMLDocument, string _xPath)
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
                    $"d:{Type}/d:Label",
                    $"d:{Type}/d:ConfigurationKey",
                    $"d:{Type}/d:Name"
                }
            };

            return xMLTagLocation;
        }
    }
}
