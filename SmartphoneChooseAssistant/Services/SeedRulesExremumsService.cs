using FuzzyLogicController;
using HtmlAgilityPack;
using System.Net;

namespace SmartphoneChooseAssistant.Services
{

    public class SeedRulesExremums
    {
        public SeedRules seedRules { get; set; }

        public bool askRom { get; set; }
        public bool askCamera { get; set; }
        public bool askBattery { get; set; }
        public bool askPrice { get; set; }
    }

    public static class SeedRulesExremumsService
    {
        public static void InitSeedRulesExtremums()
        {
            SeedRules seedRules = new SeedRules();
            seedRules = FillDataFromApi(seedRules);
            SeedRulesExremumsService.SaveInitialSeedRulesExremums(seedRules);
        }

        static SeedRules FillDataFromApi(SeedRules seedRules)
        {
            try
            {
                HtmlDocument doc = OnGet();

                List<HtmlAttributeCollection> priceItemList = doc.DocumentNode.SelectNodes("//input[@id='range-field-from']")//this xpath selects all span tag having its class as hidden first
                                      .Select(p => p.Attributes)
                                      .ToList();

                seedRules.Price.Min = int.Parse(priceItemList[0].Where(a => a.Name.Equals("min")).ToList().FirstOrDefault().Value);
                seedRules.Price.Max = int.Parse(priceItemList[0].Where(a => a.Name.Equals("max")).ToList().FirstOrDefault().Value);

                //TODO: Get camera, ROM and Battery from external sources too.
            }
            catch (Exception ex)
            {
                // Do nothing
            }

            return seedRules;
        }

        static HtmlDocument OnGet()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.foxtrot.com.ua/uk/shop/mobilnye_telefony_smartfon.html");
            request.Headers.Add("user-agent", "Other");
            request.Headers.Add("content-type", "application/json; charset=UTF-8");
            request.Headers.Add("method", "GET");

            request.Method = "GET";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            {
                HtmlDocument doc = new HtmlDocument();
                doc.Load(stream);
                return doc;
            }
        }


        public static void SaveInitialSeedRulesExremums(SeedRules seedRules)
        {
            using (StreamWriter writetext = new StreamWriter("seedRulesExtremums.txt", false))
            {
                if (seedRules.Rom.Min == 0 || seedRules.Rom.Max == 0)
                {
                    writetext.WriteLine("16,1024,0");
                }
                else
                {
                    writetext.WriteLine($"{seedRules.Rom.Min},{seedRules.Rom.Max},1");
                }

                if (seedRules.Camera.Min == 0 || seedRules.Camera.Max == 0)
                {
                    writetext.WriteLine("8,108,0");
                }
                else
                {
                    writetext.WriteLine($"{seedRules.Camera.Min},{seedRules.Camera.Max},1");
                }

                if (seedRules.Battery.Min == 0 || seedRules.Battery.Max == 0)
                {
                    writetext.WriteLine("1400,7000,0");
                }
                else
                {
                    writetext.WriteLine($"{seedRules.Battery.Min},{seedRules.Battery.Max},1");
                }

                if (seedRules.Price.Min == 0 || seedRules.Price.Max == 0)
                {
                    writetext.WriteLine("5000,70000,0");
                }
                else
                {
                    writetext.WriteLine($"{seedRules.Price.Min},{seedRules.Price.Max},1");
                }
            }
        }

        public static void SaveSeedRulesExremums(SeedRulesExremums seedRulesExtremums)
        {
            using (StreamWriter writetext = new StreamWriter("seedRulesExtremums.txt", false))
            {
                writetext.WriteLine($"{seedRulesExtremums.seedRules.Rom.Min},{seedRulesExtremums.seedRules.Rom.Max},{(seedRulesExtremums.askRom ? "0" : "1")}");
                writetext.WriteLine($"{seedRulesExtremums.seedRules.Camera.Min},{seedRulesExtremums.seedRules.Camera.Max},{(seedRulesExtremums.askCamera ? "0" : "1")}");
                writetext.WriteLine($"{seedRulesExtremums.seedRules.Battery.Min},{seedRulesExtremums.seedRules.Battery.Max},{(seedRulesExtremums.askBattery ? "0" : "1")}");
                writetext.WriteLine($"{seedRulesExtremums.seedRules.Price.Min},{seedRulesExtremums.seedRules.Price.Max},{(seedRulesExtremums.askPrice ? "0" : "1")}");
            }
        }

        public static SeedRules GetSeedRulesWithExtremums()
        {
            return ReadSeedRulesExtremums().seedRules;
        }
        public static SeedRulesExremums ReadSeedRulesExtremums()
        {
            SeedRules seedRules = new SeedRules();
            SeedRulesExremums seedRulesExremums = new SeedRulesExremums();

            using (StreamReader readtext = new StreamReader("seedRulesExtremums.txt"))
            {
                string readText = readtext.ReadLine();
                seedRules.Rom.Min = int.Parse(readText.Split(",")[0]);
                seedRules.Rom.Max = int.Parse(readText.Split(",")[1]);
                seedRulesExremums.askRom = int.Parse(readText.Split(",")[2]) == 0;

                readText = readtext.ReadLine();
                seedRules.Camera.Min = int.Parse(readText.Split(",")[0]);
                seedRules.Camera.Max = int.Parse(readText.Split(",")[1]);
                seedRulesExremums.askCamera = int.Parse(readText.Split(",")[2]) == 0;

                readText = readtext.ReadLine();
                seedRules.Battery.Min = int.Parse(readText.Split(",")[0]);
                seedRules.Battery.Max = int.Parse(readText.Split(",")[1]);
                seedRulesExremums.askBattery = int.Parse(readText.Split(",")[2]) == 0;

                readText = readtext.ReadLine();
                seedRules.Price.Min = int.Parse(readText.Split(",")[0]);
                seedRules.Price.Max = int.Parse(readText.Split(",")[1]);
                seedRulesExremums.askPrice = int.Parse(readText.Split(",")[2]) == 0;
            }

            seedRulesExremums.seedRules = seedRules;
            return seedRulesExremums;
        }
    }
}
