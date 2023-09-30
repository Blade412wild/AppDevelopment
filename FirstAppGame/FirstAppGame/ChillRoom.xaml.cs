namespace FirstAppGame;

public partial class ChillRoom : ContentPage
{
    public delegate void ButtonPressed();
    public static event ButtonPressed OnGamingEvent;
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