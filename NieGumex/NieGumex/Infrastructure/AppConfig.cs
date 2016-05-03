using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace NieGumex.Infrastructure
{
    public class AppConfig
    {
        private static string _oponyFotoFolderRelative = ConfigurationManager.AppSettings["OponyFoto"];

        public static string OponyFotoFolderRelative
        {
            get
            {
                return _oponyFotoFolderRelative;
            }
        }
    }
}