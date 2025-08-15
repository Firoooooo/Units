using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTExamples
{
    public class AXNamespace
    {
        public static string GetNamespaceForType(AXType _xMLType)
        {
            string ret = string.Empty;

            switch (_xMLType)
            {
                case AXType.AxMenuItemDisplay:
                case AXType.AxMenuItemAction:
                case AXType.AxMenuItemOutput:
                case AXType.AxMenu:
                case AXType.AxMenuExtension:
                    ret = "Microsoft.Dynamics.AX.Metadata.V1";
                    break;

                case AXType.AxForm:
                    ret = "Microsoft.Dynamics.AX.Metadata.V6";
                    break;

                case AXType.AxReport:
                    ret = "Microsoft.Dynamics.AX.Metadata.V2";
                    break;

                default:
                    ret = String.Empty;
                    break;
            }

            return ret;
        }
    }
}
