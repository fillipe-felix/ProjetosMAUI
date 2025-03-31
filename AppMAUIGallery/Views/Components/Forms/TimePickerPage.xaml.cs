using System;

using Microsoft.Maui.Controls;

namespace AppMAUIGallery.Views.Components.Forms;

public partial class TimePickerPage : ContentPage
{
    public TimeSpan SelectedTime { get; set; } = TimeSpan.FromHours(14);
    public string FormattedTime => $"Hora selecionada: {SelectedTime:hh\\:mm}";

    public TimePickerPage()
    {
        InitializeComponent();
    }


}
