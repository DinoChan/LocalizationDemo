using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace LocalizationDemoUwp
{
    public class ButtonEx
    {
        /// <summary>
        //  从指定元素获取 Content 依赖项属性的值。
        /// </summary>
        /// <param name="obj">The element from which the property value is read.</param>
        /// <returns>Content 依赖项属性的值</returns>
        public static object GetContent(DependencyObject obj)
        {
            return (object)obj.GetValue(ContentProperty);
        }

        /// <summary>
        /// 将 Content 依赖项属性的值设置为指定元素。
        /// </summary>
        /// <param name="obj">The element on which to set the property value.</param>
        /// <param name="value">The property value to set.</param>
        public static void SetContent(DependencyObject obj, object value)
        {
            obj.SetValue(ContentProperty, value);
        }

        /// <summary>
        /// 标识 Content 依赖项属性。
        /// </summary>
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.RegisterAttached("Content", typeof(object), typeof(ButtonEx), new PropertyMetadata(null, OnContentChanged));


        private static void OnContentChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            Button target = obj as Button;
            if (target == null)
                return;

            object oldValue = (object)args.OldValue;
            object newValue = (object)args.NewValue;
            if (oldValue == newValue)
                return;

            target.Content = newValue;
        }




    }
}
