using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace DynamicLocalizationWithinDesignSupportDemoUwp
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public static MainPage Current { get; private set; }


        public MainPage()
        {
            this.InitializeComponent(); MenuListView.SelectionChanged += MenuListView_SelectionChanged;
            MenuListView.SelectedIndex = 0;
            Current = this;
            RootFrame.Navigated += OnRootFrameNavigated;
        }

        private void OnRootFrameNavigated(object sender, NavigationEventArgs e)
        {
            if (e.SourcePageType == typeof(MainView))
                MenuListView.SelectedIndex = 0;
            else
                MenuListView.SelectedIndex = 1;


            if (RootFrame.CanGoBack)
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            }
            else
            {
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            }
        }



        private void MenuListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MenuListView.SelectedIndex == 0)
                RootFrame.Navigate(typeof(MainView));
            else
                RootFrame.Navigate(typeof(SettingView));
        }


      
    }
}
