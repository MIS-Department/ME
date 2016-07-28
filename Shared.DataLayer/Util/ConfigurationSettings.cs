using System.Configuration;

namespace Shared.DataLayer.Util
{
    public class ConfigurationSettings
    {
        private static string _connetionString;

        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(_connetionString))
            {
                _connetionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            }
            return _connetionString;
        }
    }
}
