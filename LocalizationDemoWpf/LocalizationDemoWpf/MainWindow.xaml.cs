using System;
using System.Collections.Generic;
using System.Linq;
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

namespace LocalizationDemoWpf
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

        private void OnSelectedLanguageChanged(object sender, SelectionChangedEventArgs e)
        {
            var culture = LanguageComboBox.SelectedIndex == 0 ? "zh-cn" : "en-us";
            var cultureInfo = new System.Globalization.CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = cultureInfo;


            ResourceDictionary dict = new ResourceDictionary { Source = new Uri($@"Resources\{culture}.xaml", UriKind.RelativeOrAbsolute) };
            Application.Current.Resources.MergedDictionaries[0] = dict;

            var message = TryFindResource("SwitchLanguage") as string;
            if (string.IsNullOrWhiteSpace(message) == false)
                MessageBox.Show(message);
        }
    }
}
