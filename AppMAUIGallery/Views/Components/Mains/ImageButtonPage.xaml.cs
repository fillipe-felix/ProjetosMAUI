using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUIGallery.Views.Components.Mains;

public partial class ImageButtonPage : ContentPage
{
    private bool buttonState = false;
    
    public ImageButtonPage()
    {
        InitializeComponent();
    }

    private void ImageButton_OnClicked(object? sender, EventArgs e)
    {
        buttonState = !buttonState;
        
        var poweroff = "poweroff.png";
        var poweron = "poweron.png";

        var button = (ImageButton)sender;
        
        button.Source = (buttonState == false) ? ImageSource.FromFile(poweron) : ImageSource.FromFile(poweroff);
    }
}

