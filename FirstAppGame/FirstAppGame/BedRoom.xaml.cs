namespace FirstAppGame;

public partial class BedRoom : ContentPage
{
	public BedRoom()
	{
		InitializeComponent();
	}

    private void OnNextRoomClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Corridor());

    }
    private void OnPreviousRoomClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ChillRoom());
    }
}