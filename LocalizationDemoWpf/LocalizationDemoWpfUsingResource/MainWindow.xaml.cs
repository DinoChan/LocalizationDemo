using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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
using LocalizationDemoWpfUsingResource.Annotations;


namespace LocalizationDemoWpfUsingResource
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LanguageComboBox.SelectionChanged += OnSelectedLanguageChanged;
        }

        private int _totalReplace;
        private ExtendResource _extendResourcce;

        private void OnSelectedLanguageChanged(object sender, SelectionChangedEventArgs e)
        {
            var culture = LanguageComboBox.SelectedIndex == 0 ? "zh-cn" : "en-us";
            var cultureInfo = new System.Globalization.CultureInfo(culture);
            ApplicationResources.ChangeCulture(cultureInfo);
            MessageBox.Show(Resource.SwitchLanguage);
        }

        private void OnReplaceString(object sender, RoutedEventArgs e)
        {
            _totalReplace++;
            string content = Resource.StringToReplace + " " + _totalReplace;
            if (_extendResourcce == null)
                _extendResourcce = new ExtendResource();

            _extendResourcce.StringToReplace = content;
            ApplicationResources.Current.Resource = _extendResourcce;
            ApplicationResources.Current.RaiseProoertyChanged();
        }
    }

    public class ExtendResource : Resource
    {
        /// <summary>
        /// 获取或设置 StringToReplace 的值
        /// </summary>
        public new string StringToReplace { get; set; }
    }
}
