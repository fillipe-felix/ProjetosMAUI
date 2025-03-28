using AppJogoForca.Models;
using AppJogoForca.Repositories;

namespace AppJogoForca;

public partial class MainPage : ContentPage
{
    private Word _currentWord;
    private int _errors;

    public MainPage()
    {
        InitializeComponent();

        ResetScreen();
    }

    private async void OnButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        button.IsEnabled = false;
        var clickedLetter = button.Text;
        var updatedText = LblText.Text.ToCharArray();
        bool found = false;

        for (int i = 0; i < _currentWord.Text.Length; i++)
        {
            if (_currentWord.Text[i].ToString().Equals(clickedLetter, StringComparison.OrdinalIgnoreCase))
            {
                updatedText[i] = _currentWord.Text[i];
                found = true;
                button.Style = (Style)Application.Current.Resources["Success"];
            }
        }

        if (!found)
        {
            button.Style = (Style)Application.Current.Resources["Fail"];
            _errors++;
            var nameImage = $"forca{_errors + 1}.png";
            ImgMain.Source = ImageSource.FromFile(nameImage);
         
            if (_errors == 6)
            {
                await DisplayAlert("Perdeu", "Você foi enforcado!", "Novo jogo");
                ResetScreen();
            }
            
            return;
        }

        LblText.Text = new string(updatedText);
    }

    private void ResetScreen()
    {
        var repository = new WordRepository();
        _currentWord = repository.GetRandomWord();
    
        ResetErrors();
        GenerateNewWord();
        EnableAllVirtualButtons();
    }

    private void GenerateNewWord()
    {
        LblTips.Text = _currentWord.Tips;
        LblText.Text = new string('_', _currentWord.Text.Length);
    }

    private void ResetErrors()
    {
        _errors = 0;
        ImgMain.Source = ImageSource.FromFile("forca1.png");
    }

    private void EnableAllVirtualButtons()
    {
        // Percorre todos os layouts horizontais dentro do KeyBoardContainer
        foreach (var layout in KeyBoardContainer.Children)
        {
            if (layout is HorizontalStackLayout horizontalLayout)
            {
                // Percorre todos os botões dentro de cada layout horizontal
                foreach (var control in horizontalLayout.Children)
                {
                    if (control is Button button)
                    {
                        // Reativa o botão
                        button.IsEnabled = true;
                        button.Style = null;
                    }
                }
            }
        }

    }
}
