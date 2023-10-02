namespace FirstAppGame;

public partial class LivingRoom : ContentPage
{
    public delegate void PlayerActionButton();
    public static event PlayerActionButton OnEatEvent;

    public delegate void RoomSwitchButton(int _room);
    public static event RoomSwitchButton RoomButtonIsPressed;


    public LivingRoom()
	{
		InitializeComponent();
	}

    private void OnNextRoomClicked(object sender, EventArgs e)
    {
        RoomButtonIsPressed?.Invoke(0);
    }
    private void OnPreviousRoomClicked(object sender, EventArgs e)
    {
        RoomButtonIsPressed?.Invoke(2);
    }

    private void Checkroom(int _room)
    {

    }
}