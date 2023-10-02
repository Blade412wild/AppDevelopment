namespace FirstAppGame;

public partial class ChillRoomP : ContentPage
{
    public delegate void PlayerActionButton();
    public static event PlayerActionButton OnGamingEvent;

    public delegate void RoomSwitchButton(int _room);
    public static event RoomSwitchButton RoomButtonIsPressed;

    private ActionStateManager actionStateManager = DependencyService.Get<ActionStateManager>();

    public ChillRoomP()
    {
        InitializeComponent();
    }

    private void OnNextRoomClicked(object sender, EventArgs e)
    {
        if (actionStateManager.CurrentState == ActionStateManager.PlayerAction.Sleeping)
        {
            Navigation.PushAsync(new BedRoomP());
        }
        else
        {
            Navigation.PushAsync(new BedRoom());
        }
    }
    private void OnPreviousRoomClicked(object sender, EventArgs e)
    {
        if (actionStateManager.CurrentState == ActionStateManager.PlayerAction.Eating)
        {
            Navigation.PushAsync(new LivingRoomP());
        }
        else
        {
            Navigation.PushAsync(new LivingRoom());
        }
    }

}