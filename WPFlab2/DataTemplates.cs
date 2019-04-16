using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFlab2
{
    public class MyDataTemplates : DataTemplateSelector
    {
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            DataTemplate dt = null;
            if (item == null) return null;

            if ((Role)item is Role.CEO)
                dt = App.Current.MainWindow.FindResource("CEOtemplate") as DataTemplate;
            else
                dt = App.Current.MainWindow.FindResource("OthersTemplate") as DataTemplate;

            return dt;
        }
    }
}
