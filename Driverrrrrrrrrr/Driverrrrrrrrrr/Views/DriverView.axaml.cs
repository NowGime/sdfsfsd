using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Driverrrrrrrrrr.Classes;
using Driverrrrrrrrrr.Data;
using Microsoft.EntityFrameworkCore;
using MsBox.Avalonia;

namespace Driverrrrrrrrrr.Views;

public partial class DriverView : UserControl
{
    public DriverView()
    {
        InitializeComponent();
        Help.DB.Drivers.Load();
        MainDG.ItemsSource = Help.DB.Drivers.ToList();
    }

    private void AddBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Help.CCV.Content = new AddView();
    }

    private void DelBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var user = MainDG.SelectedItem as Driver;
        if (user != null)
        {
            Help.DB.Drivers.Remove(user);
            Help.DB.SaveChanges();
            Help.CCV.Content = new DriverView();
        }
        else
        {
            MessageBoxManager.GetMessageBoxStandard("EROR!!!!!!!!!!!!", "ВЫ НЕ ВЫБРАЛИ ПОЛЬЗОВАТЕЛЯ").ShowAsync();
        }
    }

    private void Shows_OnClick(object? sender, RoutedEventArgs e)
    {
        var usr = MainDG.SelectedItem as Driver;
        if (usr != null)
        {
            Help.CCV.Content = new AddView(usr.Id);
        }
        else
        {
            MessageBoxManager.GetMessageBoxStandard("EROR!!!!!!!!!!!!!!", "Вы не выбрали пользователя").ShowAsync();
        }
        
    }
}