namespace AppMAUIGallery.Views.Components.Forms;

public partial class CheckBoxPage : ContentPage
{
    public CheckBoxPage()
    {
        InitializeComponent();
        //BindingContext = new CheckBoxViewModel();
    }
    
    private void OnLabelTapped(object sender, EventArgs e)
    {
        // Inverte o estado do CheckBox quando o Label é tocado
        termsCheckBox.IsChecked = !termsCheckBox.IsChecked;
    }

    private void OnCheckChanged(object sender, CheckedChangedEventArgs e)
    {
        // Atualiza o texto do Label com base no estado do CheckBox
        statusLabel.Text = e.Value ? "Status: Marcado" : "Status: Não marcado";
    }

    private void CheckBox_OnCheckedChanged(object? sender, CheckedChangedEventArgs e)
    {
        if (sender is CheckBox checkBox && e.Value)
        {
            var parent = (checkBox.Parent as HorizontalStackLayout);
            if (parent != null)
            {
                var associatedLabel = parent.Children.OfType<Label>().FirstOrDefault();
                if (associatedLabel != null)
                {
                    LblInteresse.Text = associatedLabel.Text;
                }
            }
        }
    }
}

public class CheckBoxViewModel
{
    public bool IsAccepted { get; set; } = true;
}


