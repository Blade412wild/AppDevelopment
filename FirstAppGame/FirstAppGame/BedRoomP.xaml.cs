namespace FirstAppGame;

public partial class BedRoomP : ContentPage
{

    public delegate void PlayerActionButton();
    public static event PlayerActionButton OnGamingEvent;

    public delegate void RoomSwitchButton();
    public static event RoomSwitchButton RoomButtonIsPressed;

    private ActionStateManager actionStateManager = DependencyService.Get<ActionStateManager>();

    public BedRoomP()
    {
        InitializeComponent();
    }

    private void OnNextRoomClicked(object sender, EventArgs e)
    {
        RoomButtonIsPressed?.Invoke();

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
        RoomButtonIsPressed?.Invoke();

        if (actionStateManager.CurrentState == ActionStateManager.PlayerAction.Gaming)
        {
            Navigation.PushAsync(new ChillRoomP());
        }
        else
        {
            Navigation.PushAsync(new ChillRoom());
        }
    }
}