using Microsoft.Maui.Controls;

using System;

namespace AppMAUIGallery.Views.Cells;

public partial class TextCellPage : ContentPage
{
    public TextCellPage()
    {
        InitializeComponent();
    }

    // Evento para SwitchCell
    private void SwitchCell_OnChanged(object sender, ToggledEventArgs e)
    {
        // Manipula a mudança de estado do switch
        bool isToggled = e.Value;
        DisplayAlert("Status de Notificações",
            isToggled ? "Notificações ativadas!" : "Notificações desativadas!",
            "OK");
    }

    // Evento para EntryCell
    private void EntryCell_Completed(object sender, EventArgs e)
    {
        // Manipula quando o usuário completa a entrada de texto
        var entryCell = sender as EntryCell;

        if (!string.IsNullOrEmpty(entryCell?.Text))
        {
            DisplayAlert("E-mail Salvo", $"O e-mail {entryCell.Text} foi salvo com sucesso!", "OK");
        }
    }

    // Evento para célula personalizada com toque
    private void CustomViewCell_Tapped(object sender, EventArgs e)
    {
        // Manipula o evento de toque em uma célula personalizada
        DisplayAlert("Célula Tocada", "Você tocou na célula personalizada", "OK");
    }

    // Eventos para botões dentro de células
    private async void ProjectDetailsButton_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Detalhes do Projeto", "Aqui seriam exibidos os detalhes completos do projeto.", "Fechar");
    }

    private void IgnoreButton_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Notificação Ignorada", "A notificação foi ignorada", "OK");
    }

    private void ResolveButton_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Notificação Resolvida", "A notificação foi marcada como resolvida", "OK");
    }

    // Evento para checkbox
    private void Checkbox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        bool isChecked = e.Value;
        DisplayAlert("Status do Checkbox",
            isChecked ? "Item marcado" : "Item desmarcado",
            "OK");
    }

    // Evento para conteúdo expansível
    private void ExpandButton_Clicked(object sender, EventArgs e)
    {
        // Alterna a visibilidade do conteúdo expansível
        expandableContent.IsVisible = !expandableContent.IsVisible;

        // Atualiza o texto do botão
        if (expandButton.Text == "Expandir")
            expandButton.Text = "Recolher";
        else
            expandButton.Text = "Expandir";
    }
}
