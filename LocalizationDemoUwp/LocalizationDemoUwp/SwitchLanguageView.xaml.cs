using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Resources.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace LocalizationDemoUwp
{
    public sealed partial class SwitchLanguageView : UserControl
    {
        public SwitchLanguageView()
        {
            this.InitializeComponent();
            _defaultContextForCurrentView = ResourceContext.GetForCurrentView();

            _defaultContextForCurrentView.QualifierValues.MapChanged += async (s, m) =>
            {
                await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                {
                    var currentLanguage = ResourceManager.Current.MainResourceMap.GetValue("Resources/CurrentLanguage", _defaultContextForCurrentView).ValueAsString;
                    var message = ResourceManager.Current.MainResourceMap.GetValue("OtherResources/Message", _defaultContextForCurrentView).ValueAsString;
                    MessageForSwitchLanguageElement.Text = message + currentLanguage;
                });
            };

            foreach (var languageTag in ApplicationLanguages.Languages)
            {
                AddItemForLanguageTag(languageTag);
            }

            LanguageListView.Items.Add(new ListViewItem { Content = "——————", Tag = "-" });

            foreach (var languageTag in ApplicationLanguages.ManifestLanguages)
            {
                AddItemForLanguageTag(languageTag);
            }

            LanguageListView.SelectionChanged += LanguageListView_SelectionChanged;
        }

        private ResourceContext _defaultContextForCurrentView;
        private int _lastSelectedIndex;

        private void LanguageListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = LanguageListView.SelectedValue as ListViewItem;
            var languageTag = item.Tag as string;

            if (languageTag == "-")
            {
                LanguageListView.SelectedIndex = _lastSelectedIndex;
            }
            else
            {
                _lastSelectedIndex = LanguageListView.SelectedIndex;

                ApplicationLanguages.PrimaryLanguageOverride = languageTag;

                UpdateCurrentAppLanguageMessage();
            }
        }

        private void AddItemForLanguageTag(string languageTag)
        {
            var language = new Language(languageTag);
            var item = new ListViewItem { Content = language.DisplayName, Tag = languageTag };
            LanguageListView.Items.Add(item);

            if (languageTag == ApplicationLanguages.PrimaryLanguageOverride)
            {
                LanguageListView.SelectedItem = item;
            }
        }

        private void UpdateCurrentAppLanguageMessage()
        {
            AppLanguagesTextBlock.Text = "Current app language(s): " + GetAppLanguagesAsFormattedString();
        }

        private string GetAppLanguagesAsFormattedString()
        {
            return String.Join(", ", ApplicationLanguages.Languages);
        }
    }
}
