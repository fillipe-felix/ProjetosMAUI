using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUIGallery.Views.Components.Forms;

public partial class SwitchPage : ContentPage
{
    public SwitchPage()
    {
        InitializeComponent();
    }

    private void OnSwitchToggled(object? sender, ToggledEventArgs e)
    {
        switchStateLabel.Text = e.Value ? "Ativadas" : "Desativadas";
        
        // Demonstração de como você poderia mostrar um alerta quando o valor muda
        if (e.Value)
        {
            // Em um aplicativo real, você pode usar essa lógica para registrar
            // o usuário para notificações push ou realizar outras ações
            DisplayAlert("Notificações", "As notificações foram ativadas!", "OK");
        }

    }
}

