namespace FirstAppGame;

public partial class ChillRoom : ContentPage
{
	public ChillRoom()
	{
		InitializeComponent();
	}

    private void OnNextRoomClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new BedRoom());

    }
    private void OnPreviousRoomClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LivingRoom());
    }
}