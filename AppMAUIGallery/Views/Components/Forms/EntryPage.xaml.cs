using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUIGallery.Views.Components.Forms;

public partial class EntryPage : ContentPage
{
    public EntryPage()
    {
        InitializeComponent();
    }

    private void InputView_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        LblText.Text = $"Antigo: {e.OldTextValue} - Novo: {e.NewTextValue}";
    }

    private void Entry_OnCompleted(object? sender, EventArgs e)
    {
        LblText.Text = $"Concluido!";
    }
}

