using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUIGallery.Views.Components.Mains;

public partial class ButtonPage : ContentPage
{
    public ButtonPage()
    {
        InitializeComponent();
    }

    private void Button_OnPressed(object? sender, EventArgs e)
    {
        LblLog.Text += $"\n Pressionado: {DateTime.Now}";
    }

    private void Button_OnReleased(object? sender, EventArgs e)
    {
        LblLog.Text += $"\n Liberado: {DateTime.Now}";
    }

    private void Button_OnClicked(object? sender, EventArgs e)
    {
        LblLog.Text += $"\n Clicado: {DateTime.Now}";
    }
}

