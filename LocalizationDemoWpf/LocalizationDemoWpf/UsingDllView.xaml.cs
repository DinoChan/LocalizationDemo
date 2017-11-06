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

namespace LocalizationDemoWpf
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
            OnSwitchLanguage(null,null);
        }

        private void OnSwitchLanguage(object sender, RoutedEventArgs e)
        {

            var resourceDictionary = new ResourceDictionary();
            _isEnglish = !_isEnglish;
            if (_isEnglish)
                resourceDictionary.Source = Resource.Resources.EnglishResourceUri;
            else
                resourceDictionary.Source = Resource.Resources.ChineseResourceUri;

            this.Resources.MergedDictionaries.Add(resourceDictionary);
        }
    }

  
}
