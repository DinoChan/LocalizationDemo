using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace DynamicLocalizationDemoUwp
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SettingView : Page
    {
        private static bool _hasChangedLanguage;

        public SettingView()
        {
            this.InitializeComponent();
          
            Loaded += OnLoaded;
        }


        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in LanguageListView.Items.OfType<ListViewItem>())
            {
                if (item.Tag as string == ApplicationLanguages.PrimaryLanguageOverride)
                    item.IsSelected = true;
            }
            LanguageListView.SelectionChanged += OnLanguageListViewSelectionChanged;
            if (_hasChangedLanguage)
                ShowNoteElement();
        }

        private async void OnLanguageListViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = LanguageListView.SelectedItem as ListViewItem;
            if (item == null)
                return;

            ApplicationLanguages.PrimaryLanguageOverride = item.Tag as string;
            _hasChangedLanguage = true;
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                ShowNoteElement();
            });
        }

        private void ShowNoteElement()
        {
            var resourceLoader = ResourceLoader.GetForCurrentView("DynamicResources");
            NoteElement.Text = resourceLoader.GetString("RestartNote");
            NoteElement.Visibility = Visibility.Visible;
        }
    }
}
