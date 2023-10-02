namespace FirstAppGame;

public partial class BedRoom : ContentPage
{
    public delegate void PlayerActionButton();
    public static event PlayerActionButton OnSleepEvent;

    public delegate void RoomSwitchButton(int _room);
    public static event RoomSwitchButton RoomButtonIsPressed;


    public BedRoom()
	{
		InitializeComponent();
	}


    private void OnNextRoomClicked(object sender, EventArgs e)
    {
        RoomButtonIsPressed?.Invoke(2);
    }
    private void OnPreviousRoomClicked(object sender, EventArgs e)
    {
        RoomButtonIsPressed?.Invoke(0);
    }
}