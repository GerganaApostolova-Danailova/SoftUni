namespace PersonInfo
{

using System;

    public class Smartphone : ICalling, IBrowsing
    {
        public string GetCalling(string number)
        {
            foreach (var item in number)
            {
                if (!char.IsDigit(item))
                {
                    throw new Exception("Invalid number!");
                }
            }

            return $"Calling... {number}";
        }

        public string GetBrowse(string webSite)
        {
            foreach (var item in webSite)
            {
                if (char.IsDigit(item))
                {
                    throw new Exception("Invalid URL!");
                }
            }

            return $"Browsing: {webSite}!";
        }
    }
}
