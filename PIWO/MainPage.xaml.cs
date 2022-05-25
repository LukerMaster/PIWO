namespace PIWO
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Owalone {count} piwero";
            else
                CounterBtn.Text = $"Owalone {count} piwera";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}