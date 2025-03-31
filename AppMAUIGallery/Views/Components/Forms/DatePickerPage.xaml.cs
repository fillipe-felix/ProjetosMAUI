using System;

using Microsoft.Maui.Controls;

namespace AppMAUIGallery.Views.Components.Forms;

public partial class DatePickerPage : ContentPage
{
    // Propriedade para o DatePicker desabilitado
    private DatePicker _disabledDatePicker;

    public DatePickerPage()
    {
        InitializeComponent();

        // Inicializando o DatePicker desabilitado
        _disabledDatePicker = this.FindByName<DatePicker>("disabledDatePicker");

        // Definindo valores iniciais
        basicDatePicker.Date = DateTime.Today;
        styledDatePicker.Date = DateTime.Today;

        // Configurações para o DatePicker com binding
        this.BindingContext = new DatePickerViewModel();
    }

    // Evento para o DatePicker básico
    private void OnBasicDateSelected(object sender, DateChangedEventArgs e)
    {
        // e.OldDate contém a data anterior
        // e.NewDate contém a nova data selecionada
        basicDateSelectedLabel.Text = $"Data selecionada: {e.NewDate:dd/MM/yyyy}";
    }

    // Evento para o DatePicker com limite
    private void OnLimitedDateSelected(object sender, DateChangedEventArgs e)
    {
        limitedDateSelectedLabel.Text = $"Data selecionada: {e.NewDate:dd/MM/yyyy}";

        // Verificando se a data está dentro dos limites desejados
        if (e.NewDate < limitedDatePicker.MinimumDate || e.NewDate > limitedDatePicker.MaximumDate)
        {
            DisplayAlert("Aviso", "A data selecionada está fora do intervalo permitido.", "OK");
        }
    }

    // Evento para o DatePicker estilizado
    private void OnStyledDateSelected(object sender, DateChangedEventArgs e)
    {
        styledDateSelectedLabel.Text = $"Data selecionada: {e.NewDate:dd/MM/yyyy}";

        // Alterando alguma propriedade com base na data selecionada
        if (e.NewDate.DayOfWeek == DayOfWeek.Saturday || e.NewDate.DayOfWeek == DayOfWeek.Sunday)
        {
            styledDatePicker.TextColor = Colors.Red;
            styledDateSelectedLabel.Text += " (Fim de semana)";
        }
        else
        {
            styledDatePicker.TextColor = Color.FromArgb("#4a26fd");
        }
    }

    // Evento para o DatePicker do formulário
    private void OnFormDateSelected(object sender, DateChangedEventArgs e)
    {
        // Calculando a idade baseada na data de nascimento
        int idade = CalcularIdade(e.NewDate);
        ageLabel.Text = idade.ToString() + " anos";
    }

    private int CalcularIdade(DateTime dataNascimento)
    {
        DateTime hoje = DateTime.Today;
        int idade = hoje.Year - dataNascimento.Year;

        // Verificar se já completou aniversário este ano
        if (hoje.Month < dataNascimento.Month ||
            (hoje.Month == dataNascimento.Month && hoje.Day < dataNascimento.Day))
        {
            idade--;
        }

        return idade;
    }

    // Evento para o DatePicker com tema personalizado
    private void OnThemedDateSelected(object sender, DateChangedEventArgs e)
    {
        themedDateSelectedLabel.Text = $"Data escolhida: {e.NewDate:dddd, dd 'de' MMMM 'de' yyyy}";

        // Demonstrando como fazer algo programaticamente com a data
        DateTime dataLimite = DateTime.Today.AddYears(-18);

        if (e.NewDate > dataLimite)
        {
            themedDateSelectedLabel.TextColor = Colors.Red;
            themedDateSelectedLabel.Text += " (Menor de idade)";
        }
        else
        {
            themedDateSelectedLabel.TextColor = Colors.Green;
            themedDateSelectedLabel.Text += " (Maior de idade)";
        }
    }

    // Evento para alternar o status do DatePicker desabilitado
    private void OnToggleDisabledDatePicker(object sender, EventArgs e)
    {
        if (_disabledDatePicker != null)
        {
            _disabledDatePicker.IsEnabled = !_disabledDatePicker.IsEnabled;
            _disabledDatePicker.TextColor = _disabledDatePicker.IsEnabled ? Colors.Black : Colors.Gray;
        }
    }
}

// ViewModel para o DatePicker com data binding
public class DatePickerViewModel
{
    public DateTime SelectedDate { get; set; } = DateTime.Today;
    public DateTime MinDate { get; set; } = DateTime.Today.AddMonths(-1);
    public DateTime MaxDate { get; set; } = DateTime.Today.AddMonths(3);
}
