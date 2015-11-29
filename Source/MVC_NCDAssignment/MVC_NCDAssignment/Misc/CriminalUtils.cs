using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace MVC_NCDAssignment.Misc
{
    static class CriminalUtils
    {
        public const string RELATIVE_PDF_DIR_PATH = "\\Generated PDF\\";
        internal static string MapFileName(string fileName)
        {
            return HostingEnvironment.MapPath(RELATIVE_PDF_DIR_PATH + fileName);//avoid Path.Combine in web apps
        }
    }
}
