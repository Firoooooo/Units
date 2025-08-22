namespace UnitTExamples
{
    public class AXNamespace
    {
        public static string GetNamespaceForType(AXType _xMLType)
        {
            string xMLNamespace = String.Empty;

            switch (_xMLType)
            {
                case AXType.AxMenuItemDisplay:
                case AXType.AxMenuItemAction:
                case AXType.AxMenuItemOutput:
                case AXType.AxMenu:
                case AXType.AxMenuExtension:
                    xMLNamespace = "Microsoft.Dynamics.AX.Metadata.V1";
                    break;

                case AXType.AxForm:
                    xMLNamespace = "Microsoft.Dynamics.AX.Metadata.V6";
                    break;

                case AXType.AxReport:
                    xMLNamespace = "Microsoft.Dynamics.AX.Metadata.V2";
                    break;

                default:
                    xMLNamespace = String.Empty;
                    break;
            }

            return xMLNamespace;
        }
    }
}
