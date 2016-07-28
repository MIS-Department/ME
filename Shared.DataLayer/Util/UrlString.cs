namespace Shared.DataLayer.Util
{
    public static class UrlString
    {
        private static string _url;

        public static string BaseAddress()
        {
            if (string.IsNullOrEmpty(_url))
            {
                _url = "http://localhost:8081";
            }
            return _url;
        }
    }
}
