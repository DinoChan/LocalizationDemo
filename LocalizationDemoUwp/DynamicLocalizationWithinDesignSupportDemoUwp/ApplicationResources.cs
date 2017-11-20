using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Resources.Core;
using Windows.Globalization;
using Windows.UI.Core;
using DynamicLocalizationWithinDesignSupportDemoUwp.Annotations;

namespace DynamicLocalizationWithinDesignSupportDemoUwp
{
    public class ApplicationResources : INotifyPropertyChanged
    {
        public ApplicationResources()
        {
            DynamicResources = new DynamicResourcesStrings();
            Resources = new ResourcesStrings();
            Current = this;
        }

        public static ApplicationResources Current { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public DynamicResourcesStrings DynamicResources { get; }

        public ResourcesStrings Resources { get; }


        public string Language
        {
            get
            {
                return ApplicationLanguages.PrimaryLanguageOverride;
            }
            set
            {

                if (ApplicationLanguages.PrimaryLanguageOverride == value)
                    return;

                ApplicationLanguages.PrimaryLanguageOverride = value;
                if (MainPage.Current != null )
                    MainPage.Current.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => { OnPropertyChanged(""); });
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}