using Microsoft.Maui.Controls;

using System;

namespace AppMAUIGallery.Views.Components.Forms;

public partial class PickerPage : ContentPage
{
    public PickerPage()
    {
        InitializeComponent();
    }

    private void BasicPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;

        if (picker.SelectedIndex != -1)
        {
            DisplayAlert("Seleção Básica", $"Item selecionado: {picker.SelectedItem}", "OK");
        }
    }

    private void ShadowPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;

        if (picker.SelectedIndex != -1)
        {
            // Lógica para quando uma opção for selecionada
            Console.WriteLine($"Opção selecionada: {picker.SelectedItem}");
        }
    }

    private void CountryPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;

        if (picker.SelectedIndex != -1)
        {
            // Você pode adicionar lógica específica baseada no país selecionado
            string selectedCountry = picker.SelectedItem.ToString();
            Console.WriteLine($"País selecionado: {selectedCountry}");

            // Exemplo de lógica condicional baseada na seleção
            switch (selectedCountry)
            {
                case "Brasil":
                    // Carregar informações específicas do Brasil
                    break;
                case "Estados Unidos":
                    // Carregar informações específicas dos EUA
                    break;
                // etc.
            }
        }
    }

    private void GradientPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;

        if (picker.SelectedIndex != -1)
        {
            // Exemplo: mudar a cor de fundo baseado na cor selecionada
            string selectedColor = picker.SelectedItem.ToString();

            switch (selectedColor)
            {
                case "Vermelho":
                    picker.TextColor = Colors.Red;
                    break;
                case "Azul":
                    picker.TextColor = Colors.Blue;
                    break;
                case "Verde":
                    picker.TextColor = Colors.Green;
                    break;
                case "Roxo":
                    picker.TextColor = Colors.Purple;
                    break;
                case "Laranja":
                    picker.TextColor = Colors.Orange;
                    break;
            }
        }
    }

    private void CategoryPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;

        if (picker.SelectedIndex != -1)
        {
            // Mostrar o label flutuante quando um item é selecionado
            FloatingLabel.IsVisible = true;
        }
    }

    private void CategoryPicker_Focused(object sender, FocusEventArgs e)
    {
        // Mostrar o label flutuante quando o picker ganha foco
        FloatingLabel.IsVisible = true;
    }

    private void CategoryPicker_Unfocused(object sender, FocusEventArgs e)
    {
        // Esconder o label flutuante quando o picker perde foco e nada está selecionado
        if (CategoryPicker.SelectedIndex == -1)
        {
            FloatingLabel.IsVisible = false;
        }
    }

    private void AnimatedPicker_Focused(object sender, FocusEventArgs e)
    {
        // Animar a borda quando o picker ganha foco
        AnimatedBorder.StrokeThickness = 2;
        AnimatedBorder.Stroke = Color.FromArgb("#512BD4");

        // Você pode adicionar animações mais complexas usando a API de animação do MAUI
        // Por exemplo:
        var animation = new Animation(v => AnimatedBorder.Scale = v, 1.0, 1.02);
        animation.Commit(this, "ScaleAnimation", 16, 300, Easing.SinInOut);
    }

    private void AnimatedPicker_Unfocused(object sender, FocusEventArgs e)
    {
        // Restaurar o estado original quando o picker perde o foco
        AnimatedBorder.StrokeThickness = 1;
        AnimatedBorder.Stroke = Color.FromArgb("#CCCCCC");

        // Animar de volta à escala original
        var animation = new Animation(v => AnimatedBorder.Scale = v, 1.02, 1.0);
        animation.Commit(this, "ScaleAnimation", 16, 300, Easing.SinInOut);
    }

    private void AnimatedPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;

        if (picker.SelectedIndex != -1)
        {
            // Animar uma mudança de cor de fundo quando um item é selecionado
            AnimatedBorder.BackgroundColor = Color.FromArgb("#F0F7FF");

            // Você pode criar uma animação mais avançada:
            var animation = new Animation();
            animation.Add(0, 0.5, new Animation(v => AnimatedBorder.Opacity = v, 0.8, 1.0));
            animation.Add(0.5, 1, new Animation(v => AnimatedBorder.Scale = v, 0.98, 1.0));
            animation.Commit(this, "SelectionAnimation", 16, 300, Easing.SpringOut);
        }
    }
}
