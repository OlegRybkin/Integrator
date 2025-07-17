using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Integrator
{
    public class App : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            string ribbonTabName = "A101 Mod";
            string ribbonPanelModName = "Армирование";

            application.CreateRibbonTab(ribbonTabName);

            RibbonPanel ribbonPanelMod = application.CreateRibbonPanel(ribbonTabName, ribbonPanelModName);

            string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            //Каркасы продавливания в фундаментной плите
            string punchingRebarAsseblyName = Path.Combine(directoryName, "PunchingFoundRebarModule.dll");

            PushButtonData punchingRebarButtonData = new PushButtonData("PunchingFoundRebar", "Каркасы в фундаменте", punchingRebarAsseblyName, "PunchingFoundRebarModule.Model.PunchingFoundRebar");
            PushButton punchingRebarButton = ribbonPanelMod.AddItem(punchingRebarButtonData) as PushButton;

            BitmapImage punchingRebarLogo = new BitmapImage(new Uri("pack://application:,,,/Integrator;component/Images/PunchingRebarPic.ico"));

            punchingRebarButton.LargeImage = punchingRebarLogo;

            return Result.Succeeded;
        }
    }
}
