using System;

namespace DigiKala.Razor.Common.CodeHelper
{
    public class CodeHelper
    {

        public static string ActiveCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        public static string FactorCode()
        {
            Random random = new Random();
            return random.Next(10000000, 999999999).ToString();
        }

        public static string FileCode()
        {
            return Guid.NewGuid().ToString().Replace("-","");
        }
    }
}