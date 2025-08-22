namespace UnitTExamples
{
    public class AXPathUtility
    {
        const string FileEndingXml = ".xml";

        public static AXType GetTypeFromFileName(string _pAth)
        {
            string xMLPath = Path.GetDirectoryName(_pAth);
            string xMLObjectType = Path.GetFileName(xMLPath.TrimEnd(Path.DirectorySeparatorChar));

            if (Enum.TryParse(xMLObjectType, true, out AXType xMLType))
            {
                return xMLType;
            }
            else
            {
                return AXType.NoneOrInvalid;
            }
        }

        public static string GetModelNameFromExtensionObject(string xMLPath)
        {
            string xMLModelName = String.Empty;

            if (!string.IsNullOrEmpty(xMLPath)
                && xMLPath.Count(c => c == '.') >= 2
                && xMLPath.EndsWith(FileEndingXml))
            {
                string sHort = Path.GetFileName(xMLPath);

                if (sHort.Count(c => c == '.') == 2)
                {
                    sHort = sHort.Replace(FileEndingXml, String.Empty);

                    string[] xMLSplittedValue = sHort.Split('.');

                    xMLModelName = xMLSplittedValue[xMLSplittedValue.Length - 1];
                }
            }

            return xMLModelName;
        }
    }
}
