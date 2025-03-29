using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUIGallery.Views.Components.Forms;

public partial class EditorPage : ContentPage
{
    public EditorPage()
    {
        InitializeComponent();
    }
    
    // Método para atualizar a contagem de caracteres
    private void OnEditorTextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is Editor editor)
        {
            int count = editor.Text?.Length ?? 0;
            characterCountLabel.Text = $"{count}/200 caracteres";
            
            // Muda a cor quando está próximo ao limite
            if (count > 180)
                characterCountLabel.TextColor = Colors.Red;
            else
                characterCountLabel.TextColor = Colors.Gray;
        }
    }
    
    // Métodos para controle de foco
    private void OnEditorFocused(object sender, FocusEventArgs e)
    {
        if (sender is Editor editor)
        {
            editor.BackgroundColor = Colors.LightYellow;
        }
    }
    
    private void OnEditorUnfocused(object sender, FocusEventArgs e)
    {
        if (sender is Editor editor)
        {
            editor.BackgroundColor = Colors.White;
        }
    }
    
    // Método para validação de email
    private void OnValidateEmail(object sender, TextChangedEventArgs e)
    {
        string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        if (!string.IsNullOrEmpty(validationEditor.Text))
        {
            bool isValid = System.Text.RegularExpressions.Regex.IsMatch(validationEditor.Text, emailPattern);
            validationLabel.IsVisible = !isValid;
            validationLabel.Text = !isValid ? "E-mail inválido" : "";
            validationEditor.TextColor = isValid ? Colors.Black : Colors.Red;
        }
        else
        {
            validationLabel.IsVisible = false;
            validationEditor.TextColor = Colors.Black;
        }
    }

}

