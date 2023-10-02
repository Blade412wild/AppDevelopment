namespace FirstAppGame;

public partial class CorridorP : ContentPage
{

    public delegate void RoomSwitchButton(int _room);
    public static event RoomSwitchButton RoomButtonIsPressed;

    private ActionStateManager actionStateManager = DependencyService.Get<ActionStateManager>();



    public CorridorP()
    {
        InitializeComponent();
    }

    private void OnNextRoomClicked(object sender, EventArgs e)
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
    private void OnPreviousRoomClicked(object sender, EventArgs e)
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
}