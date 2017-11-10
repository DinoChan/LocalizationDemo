﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using Windows.ApplicationModel.Resources.Core;
using DynamicLocalizationDemoUwp.Annotations;

namespace DynamicLocalizationDemoUwp
{
    public class DynamicResources : INotifyPropertyChanged
    {
        public DynamicResources()
        {
            _defaultContextForCurrentView = ResourceContext.GetForCurrentView();

            _defaultContextForCurrentView.QualifierValues.MapChanged += async (s, m) =>
            {
                OnPropertyChanged("");
                //await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                //{
                //    var currentLanguage = ResourceManager.Current.MainResourceMap.GetValue("Resources/CurrentLanguage", _defaultContextForCurrentView).ValueAsString;
                //    var message = ResourceManager.Current.MainResourceMap.GetValue("Resources1/Message", _defaultContextForCurrentView).ValueAsString;
                //    MessageForSwitchLanguageElement.Text = message + currentLanguage;
                //});
            };
            _resourceLoader = ResourceLoader.GetForCurrentView("DynamicResources");
        }

        private ResourceContext _defaultContextForCurrentView;

        private ResourceLoader _resourceLoader;

        public string Main
        {
            get { return ResourceManager.Current.MainResourceMap.GetValue("DynamicResources/Main", _defaultContextForCurrentView).ValueAsString; }
        }

        public string Settings
        {

            get { return ResourceManager.Current.MainResourceMap.GetValue("DynamicResources/Settings", _defaultContextForCurrentView).ValueAsString; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
