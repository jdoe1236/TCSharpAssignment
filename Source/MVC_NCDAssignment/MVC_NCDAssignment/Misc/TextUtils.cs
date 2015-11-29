using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_NCDAssignment.Misc
{
   public static class TextUtils
    {
       public static bool IsStringEmpty(string value)
        {
            return (string.IsNullOrEmpty(value) || value.Trim().Length == 0);
        }
    }
}
