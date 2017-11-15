using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using DynamicLocalizationWithinDesignSupportDemoUwp.Annotations;

namespace DynamicLocalizationWithinDesignSupportDemoUwp
{
    public class DynamicResourcesStrings : INotifyPropertyChanged
    {
        public string this[string key]
        {
            get
            {
                return ResourceLoader.GetForViewIndependentUse("DynamicResources").GetString(key);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        public  virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
