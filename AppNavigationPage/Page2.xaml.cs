using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNavigationPage;

public partial class Page2 : ContentPage
{
    public Page2()
    {
        InitializeComponent();
    }

    private void ProsseguirPagina(object? sender, EventArgs e)
    {
        Navigation.PushAsync(new Page3());
    }

    private void VoltarPagina(object? sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}
