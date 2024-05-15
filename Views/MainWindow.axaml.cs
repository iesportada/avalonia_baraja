using Avalonia.Controls;
using Avalonia.Interactivity;

namespace MVVM_Baraja.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void BtnSalir_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}