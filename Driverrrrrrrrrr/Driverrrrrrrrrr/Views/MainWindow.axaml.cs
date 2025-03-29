using Avalonia;
using Avalonia.Controls;
using Driverrrrrrrrrr.Classes;

namespace Driverrrrrrrrrr.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Help.CCV = MainCC;
        Help.CCV.Content = new MainView();
    }
}