namespace UnitTExamples.AXReader
{
    internal class AXLastChildReader : AXElementReader
    {
        public AXLastChildReader(AXType _xMLType, AXXMLDocument _xMLDocument)
            : base(_xMLType, _xMLDocument, String.Empty)
        {

        }

        public override XMLTagLocator FindTag()
        {
            XMLTagLocator xMLTagLoc;

            xMLTagLoc = new XMLTagLocator()
            {
                Location = XMLTagLocation.LastChild
            };

            return xMLTagLoc;
        }
    }
}
