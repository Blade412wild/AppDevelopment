namespace FirstAppGame;

public partial class Corridor : ContentPage
{
    public Corridor()
    {
        InitializeComponent();
    }

    private void OnNextRoomClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LivingRoom());

    }
    private void OnPreviousRoomClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new BedRoom());
    }
}