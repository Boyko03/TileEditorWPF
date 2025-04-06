using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
using TileEditorWPF.Model;

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

        public Tileset? Tileset { get; private set; }

        private void NewTileset_OnClosing(object? sender, CancelEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void SaveAsButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;

            var image = new BitmapImage(new Uri(SourceFile.Text));
            var margin = TileMargin.Value!.Value;
            var spacing = TileSpacing.Value!.Value;
            var tileWidth = TileWidth.Value!.Value;
            var tileHeight = TileHeight.Value!.Value;
            var columns = (image.PixelWidth - 2 * margin + spacing) / (tileWidth + spacing);
            var rows = (image.PixelHeight - 2 * margin + spacing) / (tileHeight + spacing);

            Tileset = new Tileset
            {
                Name = FileName.Text,
                Image = SourceFile.Text,
                TileWidth = tileWidth,
                TileHeight = TileHeight.Value!.Value,
                Margin = margin,
                Spacing = spacing,
                ImageWidth = image.PixelWidth,
                ImageHeight = image.PixelHeight,
                Columns = columns,
                TileCount = columns * rows
            };

            var dialog = new SaveFileDialog
            {
                FileName = FileName.Text,
                DefaultExt = ".jsx",
                Filter = "JSON tileset files (*.tsj *.json)|*.tsj;*.json"
            };

            // Show save file dialog box
            var result = dialog.ShowDialog();

            // Process save file dialog box results
            if (result != true) return;

            // Save document
            var path = dialog.FileName;

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true
            };

            File.WriteAllText(path, JsonSerializer.Serialize(Tileset, options));
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

            string? selectedValue = value.ToString();

            // Make element visible only if "Show" is selected
            return selectedValue == "Based on Tileset Image" ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
