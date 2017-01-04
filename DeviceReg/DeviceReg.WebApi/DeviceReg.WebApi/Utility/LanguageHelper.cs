using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceReg.WebApi.Utility
{
    public class LanguageHelper
    {
        public enum Langs
        {
            De = 1,
            En = 2
        }


        public static string GetLangCode(int lang)
        {
            var langEnum = (Langs)lang;
            switch (langEnum)
            {
                case Langs.De:
                    return "De";
                case Langs.En:
                    return "En";
            }

            throw new Exception("invalid lang code");
        }

    }
}