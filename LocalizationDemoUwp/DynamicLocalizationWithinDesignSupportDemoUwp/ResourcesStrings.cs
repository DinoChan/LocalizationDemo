using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace DynamicLocalizationWithinDesignSupportDemoUwp
{
    public class ResourcesStrings
    {
        public string this[string key]
        {
            get
            {
                return ResourceLoader.GetForViewIndependentUse().GetString(key);
            }
        }
    }
}
