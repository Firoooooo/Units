using UnitTExamples.AXReader;

namespace UnitTExamples.Factories
{
    public class AxElementReaderFactory
    {
        public AxElementReader GetReader(AXXMLDocument _xMLDocument)
        {
            AxElementReader xMLReader = null;
            AXType _xMLObjectType = _xMLDocument.Type;

            switch (_xMLDocument.Type)
            {
                case AXType.AxClass:
                    xMLReader = new AXClassReader(_xMLObjectType, _xMLDocument, $"{_xMLObjectType.ToString()}//Declaration");
                    break;

                case AXType.AxMacroDictionary:
                    xMLReader = new AxMacroWriter(_xMLObjectType, _xMLDocument, $"{_xMLObjectType.ToString()}//Source");
                    break;

                case AXType.AxAggregateMeasurement:
                case AXType.AxReportLayoutTemplate:
                case AXType.AxReportListStyleTemplate:
                case AXType.AxReportMatrixStyleTemplate:
                case AXType.AxReportPieDoughnutChartStyleTemplate:
                case AXType.AxReportTableStyleTemplate:
                case AXType.AxReportXYChartStyleTemplate:
                case AXType.AxServiceGroup:
                case AXType.AxTableCollection:
                case AXType.AxTableExtension:
                case AXType.AxViewExtension:
                case AXType.AxQuerySimpleExtension:
                case AXType.AxDataEntityViewExtension:
                case AXType.AxMenuItemDisplayExtension:
                case AXType.AxMenuItemOutputExtension:
                case AXType.AxMenuItemActionExtension:
                case AXType.AxWorkflowApprovalExtension:
                case AXType.AxWorkflowTaskExtension:
                case AXType.AxWorkflowTemplateExtension:
                case AXType.AxSecurityRoleExtension:
                case AXType.AxSecurityDutyExtension:
                case AXType.AxEdtExtension:
                    xMLReader = new AxRootPredecessor(_xMLObjectType, _xMLDocument, $"{_xMLObjectType.ToString()}/Name");
                    break;

                case AXType.AxReport:
                    xMLReader = new AxRootPredecessor(_xMLObjectType, _xMLDocument, $"d:{_xMLObjectType.ToString()}/d:Name");
                    break;

                case AXType.AxAggregateDataEntity:
                case AXType.AxQuery:
                case AXType.AxMap:
                case AXType.AxView:
                    xMLReader = new AxRootPredecessor(_xMLObjectType, _xMLDocument, $"{_xMLObjectType.ToString()}/SourceCode");
                    break;

                case AXType.AxForm:
                    xMLReader = new AxRootPredecessor(_xMLObjectType, _xMLDocument, $"d:{_xMLObjectType.ToString()}/d:SourceCode");
                    break;

                case AXType.AxCompositeDataEntityView:
                case AXType.AxDataEntityView:
                case AXType.AxSecurityDuty:
                case AXType.AxSecurityPrivilege:
                case AXType.AxSecurityRole:
                case AXType.AxConfigurationKey:
                    xMLReader = new AxRootPredecessor(_xMLObjectType, _xMLDocument, $"{_xMLObjectType.ToString()}/Label");
                    break;

                case AXType.AxEnum:
                case AXType.AxEdt:
                    xMLReader = new AxEdtReader(_xMLObjectType, _xMLDocument, $"{_xMLObjectType.ToString()}/ReferenceTable");
                    break;

                case AXType.AxTable:
                    xMLReader = new AxTableReader(_xMLObjectType, _xMLDocument, $"{_xMLObjectType.ToString()}/TableGroup");
                    break;

                case AXType.AxAggregateDimension:
                    xMLReader = new AxRootPredecessor(_xMLObjectType, _xMLDocument, $"{_xMLObjectType}/Table");
                    break;

                case AXType.AxConfigurationKeyGroup:
                    xMLReader = new AxRootPredecessor(_xMLObjectType, _xMLDocument, $"{_xMLObjectType}/LicenseCode");
                    break;

                case AXType.AxMenuItemDisplay:
                case AXType.AxMenuItemAction:
                case AXType.AxMenuItemOutput:
                    xMLReader = new AxMenuItemReader(_xMLObjectType, _xMLDocument, $"d:{_xMLObjectType}/d:ObjectType");
                    break;

                case AXType.AxMenuExtension:
                    xMLReader = new AxRootPredecessor(_xMLObjectType, _xMLDocument, $"d:{_xMLObjectType}/d:Name");
                    break;

                case AXType.AxKPI:
                    xMLReader = new AxRootPredecessor(_xMLObjectType, _xMLDocument, $"{_xMLObjectType}/Measurement");
                    break;

                case AXType.AxMenu:
                    xMLReader = new AxMenuReader(_xMLObjectType, _xMLDocument, $"d:{_xMLObjectType}/d:SetCompany");
                    break;

                case AXType.AxSecurityPolicy:
                    xMLReader = new AxRootPredecessor(_xMLObjectType, _xMLDocument, $"{_xMLObjectType}/Query");
                    break;

                case AXType.AxService:
                    xMLReader = new AxRootPredecessor(_xMLObjectType, _xMLDocument, $"{_xMLObjectType}/Namespace");
                    break;

                case AXType.AxTile:
                    xMLReader = new AxRootPredecessor(_xMLObjectType, _xMLDocument, $"{_xMLObjectType}/Size");
                    break;

                case AXType.AxWorkflowDueDateCalculationProvider:
                case AXType.AxWorkflowHierarchyAssignmentProvider:
                case AXType.AxWorkflowParticipantAssignmentProvider:
                case AXType.AxWorkflowQueueAssignmentProvider:
                    xMLReader = new AxRootPredecessor(_xMLObjectType, _xMLDocument, $"{_xMLObjectType}/ProviderClass");
                    break;

                case AXType.AxEnumExtension:
                    xMLReader = new AxRootPredecessor(_xMLObjectType, _xMLDocument, $"{_xMLObjectType}/EnumValues");
                    break;

                case AXType.AxAggregateCalculatedMeasureTemplateOtherPeriod:
                case AXType.AxAggregateCalculatedMeasureTemplate:
                case AXType.AxReportEmbeddedImage:
                case AXType.AxLicenseCode:
                case AXType.AxWorkflowAutomatedTask:
                case AXType.AxWorkflowCategory:
                    xMLReader = new AxLastChildReader(_xMLObjectType, _xMLDocument);
                    break;
            }

            return xMLReader;
        }

        public void GetNameTagPath(AXXMLDocument _xMLAXDocument, out string _xMLTagPath)
        {
            _xMLTagPath = null;
            switch (_xMLAXDocument.Type)
            {
                case AXType.AxMenuItemDisplay:
                case AXType.AxMenuItemAction:
                case AXType.AxMenuItemOutput:
                case AXType.AxMenu:
                case AXType.AxMenuExtension:
                case AXType.AxForm:
                case AXType.AxReport:
                    _xMLTagPath = $"d:{_xMLAXDocument.Type}/d:Tags";
                    break;

                default:
                    _xMLTagPath = $"{_xMLAXDocument.Type}/Tags";
                    break;
            }
        }
    }
}

