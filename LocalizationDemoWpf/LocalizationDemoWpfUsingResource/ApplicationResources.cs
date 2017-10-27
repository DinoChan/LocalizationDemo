using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Globalization;

namespace LocalizationDemoWpfUsingResource
{
    public class ApplicationResources : INotifyPropertyChanged
    {
        public static ApplicationResources Current { get; private set; }

        public ApplicationResources()
        {
            Current = this;
            Resource = new Resource();
        }

        public Resource Resource { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;

        public static void ChangeCulture(System.Globalization.CultureInfo cultureInfo)
        {
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Resource.Culture = cultureInfo;

            if (Current != null)
                Current.RaiseProoertyChanged();
        }

        public void RaiseProoertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
        }


        private bool _useEnglish;

        public bool UseEnglish
        {
            get { return _useEnglish; }
            set
            {
                if (_useEnglish == value)
                    return;

                _useEnglish = value;
                ChangeCulture(value ? new CultureInfo("en-US") : new CultureInfo("zh-CN"));
            }
        }


    }
}
