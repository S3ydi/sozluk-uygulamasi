using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using System;
using System.Threading.Tasks;

namespace HashSozlukGUI_Fix.Views
{
    public partial class MainWindow : Window
    {
        private HashTable table = new HashTable();

        public MainWindow()
        {
            InitializeComponent();

            AddButton.Click += (_, _) =>
            {
                if (!string.IsNullOrWhiteSpace(KeyInput.Text) && !string.IsNullOrWhiteSpace(ValueInput.Text))
                {
                    table.Add(KeyInput.Text, ValueInput.Text);
                    UpdateUI($"✅ Eklendi: {KeyInput.Text} → {ValueInput.Text}");
                }
            };

            SearchButton.Click += (_, _) =>
            {
                if (!string.IsNullOrWhiteSpace(KeyInput.Text))
                {
                    var result = table.Search(KeyInput.Text);
                    UpdateUI(result != null ? $"🔍 Bulundu: {result}" : "❌ Bulunamadı.");
                }
            };

            DeleteButton.Click += (_, _) =>
            {
                if (!string.IsNullOrWhiteSpace(KeyInput.Text))
                {
                    table.Delete(KeyInput.Text);
                    UpdateUI($"🗑️ Silme işlemi denendi: {KeyInput.Text}");
                }
            };
        }

        private async void UpdateUI(string message)
        {
            TablePanel.Children.Clear();

    LogBlock.Text = "🔄 Hash tablosu güncelleniyor...";
    await Task.Delay(300);

    var cells = table.DumpDetailed();

    foreach (var cell in cells)
    {
        var border = new Border
        {
            Width = 100,
            Height = 100,
            Margin = new Thickness(6),
            Padding = new Thickness(4),
            CornerRadius = new CornerRadius(5),
            BorderThickness = new Thickness(1),
            Background = cell.Status switch
            {
                "dolu" => Brushes.LightGreen,
                "silinmiş" => Brushes.Orange,
                _ => Brushes.LightGray
            },
            Child = new TextBlock
                {
                Text = cell.DisplayText,
                FontSize = 12,
                TextWrapping = TextWrapping.Wrap,
                TextAlignment = TextAlignment.Center,
                HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center,
                Foreground = cell.Status == "dolu" ? Brushes.Red : Brushes.Black
                }
            };

            TablePanel.Children.Add(border);
            await Task.Delay(80);
            }

            LogBlock.Text = message;
        }
    }
}
