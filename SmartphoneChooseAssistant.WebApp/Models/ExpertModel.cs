namespace SmartphoneChooseAssistant.WebApp.Models
{
    public class ExpertModel
    {
        public bool askPrice { get; set; }
        public double PriceMin { get; set; }
        public double PriceMax { get; set; }

        public bool askRom { get; set; }
        public double RomMin { get; set; }
        public double RomMax { get; set; }

        public bool askBattery { get; set; }
        public double BatteryMin { get; set; }
        public double BatteryMax { get; set; }

        public bool askCamera { get; set; }
        public double CameraMin { get; set; }
        public double CameraMax { get; set; }
    }
}
