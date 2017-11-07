using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LocalizationDemoWpfUsingResource
{
    /// <summary>
    /// UsingDllView.xaml 的交互逻辑
    /// </summary>
    public partial class UsingDllView : UserControl
    {

        private bool _isEnglish;

        public UsingDllView()
        {
            InitializeComponent();
        }

        private void OnSwitchLanguage(object sender, RoutedEventArgs e)
        {
            _isEnglish = !_isEnglish;

            var culture = _isEnglish ? "en-us" : "zh-cn";
            var cultureInfo = new System.Globalization.CultureInfo(culture);
            LocalizationDemoWpfUsingResource.Resource.ApplicationResources.Current.ChangeCulture(cultureInfo);
        }
    }
}
