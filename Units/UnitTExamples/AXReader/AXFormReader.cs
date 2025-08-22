namespace UnitTExamples.AXReader
{
    internal class AXFormReader : AXRootPredecessor
    {
        public AXFormReader(AXType _xMLType, AXXMLDocument _xMLDocument, string _xPath)
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
                    $"d:{Type}/d:Design/PatternVersion",
                    $"d:{Type}/d:Design/Pattern",
                    $"d:{Type}/d:Design/HideIfEmpty",
                    $"d:{Type}/d:Design/Caption",
                }
            };

            return xMLTagLocation;
        }
    }
}
