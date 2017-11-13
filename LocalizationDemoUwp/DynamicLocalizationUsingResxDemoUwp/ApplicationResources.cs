using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace DynamicLocalizationUsingResxDemoUwp
{
    public class ApplicationResources : INotifyPropertyChanged
    {
        public static ApplicationResources Current { get; private set; }

        public ApplicationResources()
        {
            Current = this;
            DynamicResources = new DynamicResources();
        }

        public DynamicResources DynamicResources { get; set; }
     

        public event PropertyChangedEventHandler PropertyChanged;

        public void ChangeCulture(System.Globalization.CultureInfo cultureInfo)
        {
            
            //Thread.CurrentThread.CurrentUICulture = cultureInfo;
            //Thread.CurrentThread.CurrentCulture = cultureInfo;
            DynamicResources.Culture = cultureInfo;

            if (Current != null)
                Current.RaiseProoertyChanged();
        }

        public void RaiseProoertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
        }
    }
}
