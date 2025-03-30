using Microsoft.Maui.Controls;

namespace AppMAUIGallery.Views.Components.Forms;

public partial class StepperPage : ContentPage
{
    private Stepper _dynamicStepper;
    
    public StepperPage()
    {
        InitializeComponent();
    }

    private void OnDefaultStepperValueChanged(object sender, ValueChangedEventArgs e)
    {
        defaultStepperValue.Text = $"Valor: {e.NewValue}";
    }

    private void OnCustomIncrementStepperValueChanged(object sender, ValueChangedEventArgs e)
    {
        customIncrementValue.Text = $"Valor: {e.NewValue}";
    }

    private void OnColorStepperValueChanged(object sender, ValueChangedEventArgs e)
    {
        colorStepperValue.Text = $"Valor: {e.NewValue}";
    }

    private void OnGraphicStepperValueChanged(object sender, ValueChangedEventArgs e)
    {
        UpdateGraphicDisplay((int)e.NewValue);
    }

    private void OnSliderStepperValueChanged(object sender, ValueChangedEventArgs e)
    {
        double progress = e.NewValue / 10.0;
        stepperProgress.Progress = progress;
        sliderStepperValue.Text = $"{e.NewValue}/10";
    }

    private void OnFormattedStepperValueChanged(object sender, ValueChangedEventArgs e)
    {
        formattedValue.Text = $"{e.NewValue}%";
    }

    private void OnDynamicStepperValueChanged(object sender, ValueChangedEventArgs e)
    {
        dynamicStepperValue.Text = $"Valor: {e.NewValue}";
    }

    private void OnIncrementSliderValueChanged(object sender, ValueChangedEventArgs e)
    {
        double increment = Math.Round(e.NewValue);
        if (sender is Slider slider)
        {
            // Armazenar referência ao stepper para atualizações
            _dynamicStepper = ((Element)slider).Parent?.FindByName<Stepper>("dynamicStepper");
            if (_dynamicStepper != null)
            {
                _dynamicStepper.Increment = increment;
            }
        }
        incrementValue.Text = $"Incremento: {increment}";
    }

    private void OnCustomDecreaseButtonClicked(object sender, EventArgs e)
    {
        int value = int.Parse(customButtonValue.Text);

        if (value > 0)
        {
            value--;
            customButtonValue.Text = value.ToString();
        }
    }

    private void OnCustomIncreaseButtonClicked(object sender, EventArgs e)
    {
        int value = int.Parse(customButtonValue.Text);

        if (value < 10)
        {
            value++;
            customButtonValue.Text = value.ToString();
        }
    }

    private void UpdateGraphicDisplay(int value)
    {
        // Atualiza a visualização gráfica baseada no valor do stepper
        for (int i = 0; i < graphicDisplay.Children.Count; i++)
        {
            if (graphicDisplay.Children[i] is BoxView boxView)
            {
                boxView.Color = i < value ? Color.FromArgb("#3498db") : Colors.LightGray;
            }
        }
    }
}