using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;

namespace NieGumex.Infrastructure
{
    public static class UrlHelpers
    {
        public static string OponaFotoPath(this UrlHelper helper, string oponaFilename)
        {
            var oponyCoverFolder = AppConfig.OponyFotoFolderRelative;
            var path = Path.Combine(oponyCoverFolder, oponaFilename);
            var absolutePath = helper.Content(path);
            return absolutePath;
        }
    }
}