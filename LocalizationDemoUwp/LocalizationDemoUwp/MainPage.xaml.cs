using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace LocalizationDemoUwp
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            var list = new List<string> {"One", "Two", "Three"};
            Source = list;

            //var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
            //var str = loader.GetString("CurrentLanguadge");

        }


        public IEnumerable<string> Source { get; private set; }

        private void OnShowMessage(object sender, RoutedEventArgs e)
        {
          var  loader = ResourceLoader.GetForCurrentView(); 
           
           var str = loader.GetString("M");
             loader = new Windows.ApplicationModel.Resources.ResourceLoader();
             str = loader.GetString("CusrrsentLnguage");
        }
    }
}
