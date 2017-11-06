using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalizationDemoWpf.Resource
{
   public static class Resources
   {
       public static  Uri EnglishResourceUri { get; } =
           new Uri("/LocalizationDemoWpf.Resource;component/Resource.en-us.xaml", UriKind.RelativeOrAbsolute);

       public static  Uri ChineseResourceUri { get; } =
           new Uri("/LocalizationDemoWpf.Resource;component/Resource.zh-cn.xaml", UriKind.RelativeOrAbsolute);
    }
}
