namespace AppNumeroDaSorte;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnGenerateLuckyNumbers(object sender, EventArgs e)
    {
        NameApp.IsVisible = false;
        ContainerLuckNumbers.IsVisible = true;
    
        var luckyNumbers = GenerateUniqueRandomNumbers();
        LuckNumber01.Text = luckyNumbers[0].ToString("D2");
        LuckNumber02.Text = luckyNumbers[1].ToString("D2");
        LuckNumber03.Text = luckyNumbers[2].ToString("D2");
        LuckNumber04.Text = luckyNumbers[3].ToString("D2");
        LuckNumber05.Text = luckyNumbers[4].ToString("D2");
        LuckNumber06.Text = luckyNumbers[5].ToString("D2");
    }
    private List<int> GenerateUniqueRandomNumbers()
    {
        var random = new Random();
        var numbers = new SortedSet<int>();

        while (numbers.Count < 6)
        {
            numbers.Add(random.Next(1, 61));
        }

        return numbers.ToList();
    }
}
