namespace FirstAppGame;

public partial class ChillRoom : ContentPage
{
    public delegate void PlayerActionButton();
    public static event PlayerActionButton OnGamingEvent;

    public delegate void RoomSwitchButton(int _room);
    public static event RoomSwitchButton RoomButtonIsPressed;
    public ChillRoom()
	{
		InitializeComponent();
	}


    private void OnNextRoomClicked(object sender, EventArgs e)
    {
        RoomButtonIsPressed?.Invoke(1);
    }
    private void OnPreviousRoomClicked(object sender, EventArgs e)
    {
        RoomButtonIsPressed?.Invoke(3);
    }
}