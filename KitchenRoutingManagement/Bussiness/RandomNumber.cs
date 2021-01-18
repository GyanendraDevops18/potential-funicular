using System;
using System.Text;

namespace KitchenRoutingManagement.Bussiness
{
    public static class RandomNumber
    {
        public static string getRandomCode()
        {
            const string src = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int length = 10;

            var sb = new StringBuilder();
            Random RNG = new Random();
            for (var i = 0; i < length; i++)
            {
                var c = src[RNG.Next(0, src.Length)];
                sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
