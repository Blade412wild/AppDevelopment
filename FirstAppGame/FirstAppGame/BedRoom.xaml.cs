namespace FirstAppGame;

public partial class BedRoom : ContentPage
{
    public delegate void PlayerActionButton();
    public static event PlayerActionButton OnSleepEvent;

    public delegate void RoomSwitchButton(int _room);
    public static event RoomSwitchButton RoomButtonIsPressed;

    private ActionStateManager actionStateManager = DependencyService.Get<ActionStateManager>();


    public BedRoom()
	{
		InitializeComponent();
	}


    private void OnNextRoomClicked(object sender, EventArgs e)
    {
        if (actionStateManager.CurrentState == ActionStateManager.PlayerAction.Working)
        {
            Console.WriteLine("Changed To CorridorP");
            Navigation.PushAsync(new CorridorP());
        }
        else
        {
            Console.WriteLine("Changed To Corridor");
            Navigation.PushAsync(new Corridor());
        }
    }
    private void OnPreviousRoomClicked(object sender, EventArgs e)
    {
        if (actionStateManager.CurrentState == ActionStateManager.PlayerAction.Gaming)
        {
            Navigation.PushAsync(new ChillRoomP());
        }
        else
        {
            Navigation.PushAsync(new ChillRoom());
        }
    }
    private void OnImageButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new BedRoomP());
    }
}