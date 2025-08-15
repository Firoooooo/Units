using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTExamples
{
    public class AXPathUtility
    {
        const string FileEndingXml = ".xml";

        public static AXType GetTypeFromFileName(string filePath)
        {
            string xMLObjectPath = Path.GetDirectoryName(filePath);
            string xMLObjectType = Path.GetFileName(xMLObjectPath.TrimEnd(Path.DirectorySeparatorChar));

            if (Enum.TryParse(xMLObjectType, true, out AXType parsedType))
            {
                return parsedType;
            }
            else
            {
                return AXType.NoneOrInvalid;
            }
        }

        public static string GetModelNameFromExtensionObject(string filePath)
        {
            string ret = string.Empty;

            if (!string.IsNullOrEmpty(filePath)
                && filePath.Count(c => c == '.') >= 2
                && filePath.EndsWith(FileEndingXml))
            {
                string shortString = Path.GetFileName(filePath);

                if (shortString.Count(c => c == '.') == 2)
                {
                    shortString = shortString.Replace(FileEndingXml, string.Empty);

                    string[] splits = shortString.Split('.');

                    ret = splits[splits.Length - 1];
                }
            }

            return ret;
        }
    }
}
