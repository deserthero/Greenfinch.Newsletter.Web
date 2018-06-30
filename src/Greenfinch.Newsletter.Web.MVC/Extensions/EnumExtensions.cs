using Greenfinch.Newsletter.Web.MVC.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;

namespace Greenfinch.Newsletter.Web.MVC
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum e)
        {
            var rm = new ResourceManager(typeof(SharedResource));
            var resourceDisplayName = rm.GetString(e.GetType().Name + "_" + e);
            return string.IsNullOrWhiteSpace(resourceDisplayName) ? string.Format("[[{0}]]", e) : resourceDisplayName;
        }
    }
}
