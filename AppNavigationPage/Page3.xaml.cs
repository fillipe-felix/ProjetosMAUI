using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNavigationPage;

public partial class Page3 : ContentPage
{
    public Page3()
    {
        InitializeComponent();
    }

    private void VoltarPagina(object? sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}

