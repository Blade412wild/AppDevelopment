namespace FirstAppGame;

public partial class LivingRoom : ContentPage
{
    public delegate void PlayerActionButton();
    public static event PlayerActionButton OnEatEvent;

    public delegate void RoomSwitchButton(int _room);
    public static event RoomSwitchButton RoomButtonIsPressed;

    private ActionStateManager actionStateManager = DependencyService.Get<ActionStateManager>();



    public LivingRoom()
	{
		InitializeComponent();
	}

    private void OnNextRoomClicked(object sender, EventArgs e)
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
    private void OnPreviousRoomClicked(object sender, EventArgs e)
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
    private void OnImageButtonClicked(object sender, EventArgs e)
    {
        OnEatEvent?.Invoke();
        Navigation.PushAsync(new LivingRoomP());
    }
}