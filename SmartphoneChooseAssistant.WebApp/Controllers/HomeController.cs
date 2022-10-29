using FuzzyLogicController;
using FuzzyLogicController.Interfaces;
using FuzzyLogicController.Logic;
using Microsoft.AspNetCore.Mvc;
using SmartphoneChooseAssistant.Services;
using SmartphoneChooseAssistant.WebApp.Models;
using System.Diagnostics;

namespace SmartphoneChooseAssistant.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() => View();

        public IActionResult Privacy() => View();



        public IActionResult Result(UserPreferencesModel model)
        {
            /*var seedRules = new SeedRules();

            //GetNewDates(ram)
            seedRules.Rom.Min = 16;
            seedRules.Rom.Max = 1024;

            seedRules.Camera.Min = 8;
            seedRules.Camera.Max = 108;

            seedRules.Battery.Min = 1400;
            seedRules.Battery.Max = 7_000;

            seedRules.Price.Min = 5_000;
            seedRules.Price.Max = 70_000;*/

             SeedRules seedRules = SeedRulesExremumsService.GetSeedRulesWithExtremums();

            // Define Rules
            var fuzzyRuleCollection = seedRules.GetRulesBase();

            // Set Input values to LinguisticVariables and Normilize it
            seedRules.Rom.InputValue = model.Rom;
            seedRules.Camera.InputValue = model.Camera;
            seedRules.Battery.InputValue = model.Battery;
            seedRules.Price.InputValue = model.Price;

            // Create FuzzyLogicController and start processing
            IFuzzyLogicService fuzzyLogicService = new FuzzyLogicService(
                fuzzyRuleCollection,
                new Defuzzification(),
                new FuzzyRuleEvaluator());

            var result = fuzzyLogicService.StartProcess();

            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }  
    }
}