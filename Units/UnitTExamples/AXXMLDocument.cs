using System.Xml;

namespace UnitTExamples
{
    public class AXXMLDocument
    {
        public string Path { get; }
        public AXType Type { get; }
        public XmlDocument Document { get; }
        public string DefaultNamespace { get; }
        public string OriginalContent { get; }


        public AXXMLDocument(string _xMLPath, bool _xMLPreserveWhitespaces = true)
            : this(
                  _xMLPath,
                  AXPathUtility.GetTypeFromFileName(_xMLPath),
                  _xMLPreserveWhitespaces)
        {
            
        }

        public AXXMLDocument(
                            string _xMLPath,
                            AXType xMLType,
                            bool _xMLPreserveWhitespaces = true)
        {
            Path = _xMLPath;
            Type = xMLType;

            DefaultNamespace = AXNamespace.GetNamespaceForType(xMLType);

            if (!String.IsNullOrEmpty(_xMLPath))
            {
                if (File.Exists(_xMLPath))
                {
                    Document = new XmlDocument()
                    {
                        PreserveWhitespace = _xMLPreserveWhitespaces,
                    };
                    Document.Load(_xMLPath);
                    OriginalContent = Document.InnerXml;
                }
                else
                {
                    throw new FileNotFoundException($"File '{_xMLPath}'");
                }
            }
        }

        public static AXXMLDocument Load(string _xMLPath, bool _xMLWhitesspaces = true)
        {
            AXType xMLParsedObjectType = AXPathUtility.GetTypeFromFileName(_xMLPath);
            var XMLDoc = new AXXMLDocument(_xMLPath, xMLParsedObjectType, _xMLWhitesspaces);

            return XMLDoc;
        }

        public XmlNamespaceManager CreateNamespaceManager()
        {
            XmlNamespaceManager xMLNamespaceManager = new XmlNamespaceManager(Document.NameTable);
            xMLNamespaceManager.AddNamespace(string.Empty, DefaultNamespace);
            xMLNamespaceManager.AddNamespace("d", DefaultNamespace);

            return xMLNamespaceManager;
        }

        public void Close()
        {
            if (IsUpdated())
            {
                XmlWriterSettings xMLSettings = new XmlWriterSettings()
                {
                    Indent = true
                };

                using (var xMLStream = new FileStream(Path, FileMode.Truncate, FileAccess.Write, FileShare.Read))
                {
                    using (XmlWriter xMLWriter = XmlWriter.Create(xMLStream, xMLSettings))
                    {
                        Document.Save(xMLWriter);
                    }
                }
            }
        }

        public bool IsUpdated()
        {
            bool cHanged = false;
            StringComparer cOmp = StringComparer.Ordinal;
            if (!cOmp.Equals(OriginalContent, Document.InnerXml))
            {
                cHanged = true;
            }

            return cHanged;
        }
    }
}
