using Avalonia.Controls;
using Avalonia.Interactivity;
using Driverrrrrrrrrr.Classes;
using MsBox.Avalonia;
using MsBox.Avalonia.Dto;

namespace Driverrrrrrrrrr.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        if (LoginTB.Text == "ispector" && PassTB.Text == "ispector" || LoginTB.Text == "1" && PassTB.Text == "1")
        {
            Help.CCV.Content = new DriverView();
        }
        else
        {
            MessageBoxManager.GetMessageBoxStandard("EROR!!!!!!!!!!!!!!!!!!!!!!!!!!!!!", "Вы ввели не правельный логин, попробуйте - ispector").ShowAsync();
        }
    }
}