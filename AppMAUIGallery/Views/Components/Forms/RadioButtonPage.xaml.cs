using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUIGallery.Views.Components.Forms;

public partial class RadioButtonPage : ContentPage
{
    public RadioButtonPage()
    {
        InitializeComponent();
    }
    
    private void OnRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            eventResultLabel.Text = "Status: Selected!";
            eventResultLabel.TextColor = Colors.Green;
        }
        else
        {
            eventResultLabel.Text = "Status: Not selected";
            eventResultLabel.TextColor = Colors.Black;
        }
    }

}

