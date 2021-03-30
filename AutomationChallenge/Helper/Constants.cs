using System.Collections.Generic;

namespace AutomationChallenge.Helper
{
    public class Constants
    {
        public static string ChromeBrowser { get; } = "chrome";
        public static string FirefoxBrowser { get; } = "firefox";
        public static string BookTextLink { get; } = "books";
        public static string MapsTextLink { get; } = "maps";
        public static string SpecFlowNULLReference { get; } = "<null>";
        public static string CountryName { get; } = "United States";
        public static int Distance { get; } = 100;
        public static string MapsText { get; } = "Maps";
        public static int BookResultNo { get; } = 3;
        public static string column1 { get; } = "Text";
        public static string column2 { get; } = "LinkTextName";

        public static List<string> zipCodes { get; } = new List<string>
        {
            "51201","79201","99786"
        };
    }
}
