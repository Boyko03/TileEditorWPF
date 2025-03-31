using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
using System.Windows.Shapes;
using Microsoft.Win32;

namespace TileEditorWPF.Modals
{
    /// <summary>
    /// Interaction logic for NewTileset.xaml
    /// </summary>
    public partial class NewTileset : Window
    {
        public NewTileset()
        {
            InitializeComponent();
        }

        private void NewTileset_OnClosing(object? sender, CancelEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void OkButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void NewTileset_OnLoaded(object sender, RoutedEventArgs e)
        {
            MinWidth = ActualWidth;
            MinHeight = ActualHeight;
            MaxHeight = ActualHeight;
        }

        private void ButtonBrowse_OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Multiselect = false,
                Filter = "Image files (*.bmp, *.jpg, *.png)|*.bmp;*.jpg;*.jpeg;*.png"
            };
            dialog.ShowDialog();

            SourceFile.Text = dialog.FileName;
        }
    }

    public class ComboBoxValueToVisibilityConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null) return Visibility.Collapsed;

            string selectedValue = value.ToString();

            // Make element visible only if "Show" is selected
            return selectedValue == "Based on Tileset Image" ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
