using Microsoft.Maui.Controls;

namespace AppMAUIGallery.Views.Components.Forms
{
    public partial class SliderPage : ContentPage
    {
        public SliderPage()
        {
            InitializeComponent();
            
            // Configurar os manipuladores de eventos para os sliders
            var basicSlider = this.FindByName<Slider>("BasicSlider");
            if (basicSlider != null)
            {
                basicSlider.ValueChanged += (s, e) =>
                {
                    BasicValueLabel.Text = $"Valor: {e.NewValue:F0}";
                };
            }

            RealTimeSlider.ValueChanged += (s, e) =>
            {
                RealTimeLabel.Text = $"Opacidade: {e.NewValue * 100:F0}%";
            };

            MinValueSlider.ValueChanged += (s, e) =>
            {
                if (e.NewValue > MaxValueSlider.Value)
                    MinValueSlider.Value = MaxValueSlider.Value;
                
                UpdateRangeLabel();
            };

            MaxValueSlider.ValueChanged += (s, e) =>
            {
                if (e.NewValue < MinValueSlider.Value)
                    MaxValueSlider.Value = MinValueSlider.Value;
                
                UpdateRangeLabel();
            };
        }

        private void UpdateRangeLabel()
        {
            RangeLabel.Text = $"Intervalo selecionado: {MinValueSlider.Value:F0} - {MaxValueSlider.Value:F0}";
        }
    }
}
