using Microsoft.AspNetCore.Mvc;
using SmartphoneChooseAssistant.Services;
using SmartphoneChooseAssistant.WebApp.Models;

namespace SmartphoneChooseAssistant.WebApp.Controllers
{
    public class ExpertController : Controller
    {
        public SeedRulesExremums seedRulesExtremums { get; set; }

        public ExpertController()
        {
            seedRulesExtremums = SeedRulesExremumsService.ReadSeedRulesExtremums();
        }

        public IActionResult Index()
        {
            ViewData["RomMin"] = seedRulesExtremums.seedRules.Rom.Min;
            ViewData["RomMax"] = seedRulesExtremums.seedRules.Rom.Max;
            ViewData["askRom"] = seedRulesExtremums.askRom;
            ViewData["CameraMin"] = seedRulesExtremums.seedRules.Camera.Min;
            ViewData["CameraMax"] = seedRulesExtremums.seedRules.Camera.Max;
            ViewData["askCamera"] = seedRulesExtremums.askCamera;
            ViewData["BatteryMin"] = seedRulesExtremums.seedRules.Battery.Min;
            ViewData["BatteryMax"] = seedRulesExtremums.seedRules.Battery.Max;
            ViewData["askBattery"] = seedRulesExtremums.askBattery;
            ViewData["PriceMin"] = seedRulesExtremums.seedRules.Price.Min;
            ViewData["PriceMax"] = seedRulesExtremums.seedRules.Price.Max;
            ViewData["askPrice"] = seedRulesExtremums.askPrice;
            
            return View();
        }

        public IActionResult Result(ExpertModel model)
        {
            if (seedRulesExtremums.askRom)
            {
                seedRulesExtremums.seedRules.Rom.Min = model.RomMin;
                seedRulesExtremums.seedRules.Rom.Max = model.RomMax;
            }

            if (seedRulesExtremums.askCamera)
            {
                seedRulesExtremums.seedRules.Camera.Min = model.CameraMin;
                seedRulesExtremums.seedRules.Camera.Max = model.CameraMax;
            }

            if (seedRulesExtremums.askBattery)
            {
                seedRulesExtremums.seedRules.Battery.Min = model.BatteryMin;
                seedRulesExtremums.seedRules.Battery.Max = model.BatteryMax;
            }

            if (seedRulesExtremums.askPrice)
            {
                seedRulesExtremums.seedRules.Price.Min = model.PriceMin;
                seedRulesExtremums.seedRules.Price.Max = model.PriceMax;
            }

            SeedRulesExremumsService.SaveSeedRulesExremums(seedRulesExtremums);

            return Redirect("/");
        }
    }
}
