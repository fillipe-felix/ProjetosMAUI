using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNavigationPage;

public partial class Page1 : ContentPage
{
    public Page1()
    {
        InitializeComponent();
    }

    private void ProsseguirPagina(object? sender, EventArgs e)
    {
        Navigation.PushAsync(new Page2());
    }
}

