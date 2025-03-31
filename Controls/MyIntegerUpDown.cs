using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xceed.Wpf.Toolkit;

namespace TileEditorWPF.Controls
{
    class MyIntegerUpDown : IntegerUpDown
    {
        public static readonly DependencyProperty UnitsProperty = DependencyProperty.Register(
            nameof(Units), typeof(string), typeof(MyIntegerUpDown), new PropertyMetadata(default(string)));

        public string Units
        {
            get => (string)GetValue(UnitsProperty);
            set => SetValue(UnitsProperty, value);
        }

        protected override int? ConvertTextToValue(string text)
        {
            text = text.Replace(Units, "").Trim();
            return base.ConvertTextToValue(text);
        }

        protected override string ConvertValueToText()
        {
            return base.ConvertValueToText() + " " + Units;
        }
    }
}
