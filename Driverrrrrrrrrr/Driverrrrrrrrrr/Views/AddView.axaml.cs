using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using Driverrrrrrrrrr.Classes;
using Driverrrrrrrrrr.Data;
using MsBox.Avalonia;

namespace Driverrrrrrrrrr.Views;
public partial class AddView : UserControl
{
    private int _id;
    public AddView(int id = -1)
    {
        InitializeComponent();
        _id = id;

        if (_id == -1)
        {
            MainSP.DataContext = new Driver() {Photo = new Photo()};
        }
        else
        {
            var usr = Help.DB.Drivers.FirstOrDefault(el => el.Id == _id);
            MainSP.DataContext = usr;
        }

        if (_id == -1)
        {
            MainSP.IsEnabled = true;
        }
        else
        {
            MainSP.IsEnabled = false;
        }
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            Regex regiPhone = new Regex(@"\+7\(\d\d\d\)\d\d\d-\d\d\d\d");
            if (!regiPhone.IsMatch(PhoneTB.Text))
            {
                MessageBoxManager.GetMessageBoxStandard("EROR!!!!!!!!!!!!!!!!!", "VEOM").ShowAsync();
                return;
            }
            Regex regiMail = new Regex("[^@]+@[^@]+");
            if (!regiPhone.IsMatch(EmailTB.Text))
            {
                MessageBoxManager.GetMessageBoxStandard("EROR!!!!!!!!!!!!!!!!!", "VEOM").ShowAsync();
                return;
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
        if (_id == -1)
        {
            Help.DB.Drivers.Add(MainSP.DataContext as Driver);
        }
        Help.DB.SaveChanges();
        Help.CCV.Content = new DriverView();
    }

    private void Back_OnClick(object? sender, RoutedEventArgs e)
    {
        Help.CCV.Content = new DriverView();
    }

    private async void Show_OnClick(object? sender, RoutedEventArgs e)
    {
        var toplvl = TopLevel.GetTopLevel(this);
        var file = await toplvl.StorageProvider.OpenFilePickerAsync(new Avalonia.Platform.Storage.FilePickerOpenOptions()
        {
            Title = "Open image file",
            AllowMultiple = false,
            FileTypeFilter = new[] { FilePickerFileTypes.ImageAll }
        });

        if (file.Count() > 0)
        {
            var drv = MainSP.DataContext as Driver;
            drv.Photo.Photo1 = File.ReadAllBytes(file[0].Path.LocalPath);
            DriverPhoto.Source = new Bitmap(file[0].Path.LocalPath);
        }
    }
}