namespace SmartphoneChooseAssistant.WebApp.ViewChooser
{
    public class ViewSelector
    {
        public static string SelectView(double result)
        {
            if (0 < result && result < 0.4)
            {
                return "Bad choiсe";
            }
            else if (0.4 < result && result < 0.6)
            {
                return "Suitable choiсe";
            }
            else if (0.5 < result && result < 0.8)
            {
                return "Very good choiсe";
            }
            else
            {
                return "Excellent choiсe";
            }
        }
    }
}
