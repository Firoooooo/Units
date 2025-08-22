namespace UnitTExamples
{
    public class XMLTagLocator
    {
        public XMLTagLocation Location { get; set; }
        public string XPath { get; set; }
        public List<string> FallBacks { get; set; }
            = new List<string>();
    }
}

