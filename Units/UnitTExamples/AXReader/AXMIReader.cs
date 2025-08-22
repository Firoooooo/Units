namespace UnitTExamples.AXReader
{
    internal class AXMenuItemReader : AXRootPredecessor
    {
        public AXMenuItemReader(AXType _xMLType, AXXMLDocument _xMLDocument, string _xPath)
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
                    $"d:{Type}/d:Object",
                    $"d:{Type}/d:NormalResource",
                    $"d:{Type}/d:HelpText",
                    $"d:{Type}/d:DisabledResource",
                    $"d:{Type}/d:Name"
                }
            };

            return xMLTagLocation;
        }
    }
}
