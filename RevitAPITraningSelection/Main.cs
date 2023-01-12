using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITraningSelection
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            Reference selectedElementRef = uidoc.Selection.PickObject(ObjectType.Element, "Выберете элемент");
            Element element = doc.GetElement(selectedElementRef);

            TaskDialog.Show("Selection", $"Имя: {element.Name}{Environment.NewLine}Id: {element.Id}");
            return Result.Succeeded;
        }
    }
}
