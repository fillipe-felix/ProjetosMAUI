using System;

using Microsoft.Maui.Controls;

namespace AppMAUIGallery.Views.Components.Forms;

public partial class SearchBarPage : ContentPage
{
    private DateTime _minDate;
    private DateTime _maxDate;
    private DateTime _ageLimit;

    public DateTime MinDate
    {
        get => _minDate;
        set => _minDate = value;
    }

    public DateTime MaxDate
    {
        get => _maxDate;
        set => _maxDate = value;
    }

    public DateTime AgeLimit
    {
        get => _ageLimit;
        set => _ageLimit = value;
    }

    public SearchBarPage()
    {
        InitializeComponent();

        // Configurando datas mínima e máxima para demonstração
        MinDate = DateTime.Now.AddYears(-1);
        MaxDate = DateTime.Now.AddYears(1);

        // Limite de idade (18 anos atrás)
        AgeLimit = DateTime.Now.AddYears(-18);

        BindingContext = this;

        // Configuração inicial de alguns DatePickers
        basicDatePicker.Date = DateTime.Now;
        materialDatePicker.MinimumDate = new DateTime(1900, 1, 1);
    }

    private void OnDateSelected(object sender, DateChangedEventArgs e)
    {
        // Manipula a seleção da data para qualquer DatePicker comum
        var datePicker = sender as DatePicker;
        Console.WriteLine($"Data selecionada: {e.NewDate.ToShortDateString()}");

        // Você pode implementar lógica específica baseada no controle que gerou o evento
        if (datePicker == basicDatePicker)
        {
            // Lógica específica para basicDatePicker
        }
    }

    private void OnValidationDateSelected(object sender, DateChangedEventArgs e)
    {
        // Exemplo de validação simples (não permitir datas futuras)
        if (e.NewDate > DateTime.Now)
        {
            validationMessage.Text = "A data não pode ser no futuro!";
            validationMessage.IsVisible = true;
            validationBorder.Stroke = Colors.Red;
        }
        else
        {
            validationMessage.IsVisible = false;
            validationBorder.Stroke = Colors.Gray;
        }
    }

    private async void OnCustomPickerClicked(object sender, EventArgs e)
    {
        // Implementando uma experiência de DatePicker personalizada
        var date = await DisplayPromptAsync(
            "Selecione uma data",
            "Formato: DD/MM/AAAA",
            "OK",
            "Cancelar",
            placeholder: "DD/MM/AAAA");

        if (date != null && DateTime.TryParse(date, out DateTime result))
        {
            customPickerLabel.Text = result.ToString("dd/MM/yyyy");
        }
    }

    private void OnAgeLimitDateSelected(object sender, DateChangedEventArgs e)
    {
        // Verificar se a pessoa tem pelo menos 18 anos
        int age = CalculateAge(e.NewDate);

        if (age < 18)
        {
            ageMessage.Text = $"Você tem apenas {age} anos. É necessário ter pelo menos 18 anos.";
            ageMessage.IsVisible = true;
        }
        else
        {
            ageMessage.Text = $"Idade confirmada: {age} anos.";
            ageMessage.IsVisible = true;
            ageMessage.TextColor = Colors.Green;
        }
    }

    private int CalculateAge(DateTime birthDate)
    {
        DateTime today = DateTime.Today;
        int age = today.Year - birthDate.Year;

        // Verificar se o aniversário já passou este ano
        if (birthDate.Date > today.AddYears(-age))
            age--;

        return age;
    }
}
