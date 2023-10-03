using System.ComponentModel;

namespace FirstAppGame;

public partial class ChillRoom : ContentPage, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public delegate void PlayerActionButton();
    public static event PlayerActionButton OnGamingEvent;

    public delegate void RoomSwitchButton();
    public static event RoomSwitchButton RoomButtonIsPressed;

    private ActionStateManager actionStateManager = DependencyService.Get<ActionStateManager>();
    private IDataStore<Creature> creatureDataStore = DependencyService.Get<IDataStore<Creature>>();

    public Creature LocalCreature { get; set; }


    public ChillRoom()
    {
        InitializeComponent();
    }


    private void OnNextRoomClicked(object sender, EventArgs e)
    {
        RoomButtonIsPressed?.Invoke();

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
        RoomButtonIsPressed?.Invoke();

        if (actionStateManager.CurrentState == ActionStateManager.PlayerAction.Eating)
        {
            Navigation.PushAsync(new LivingRoomP());
        }
        else
        {
            Navigation.PushAsync(new LivingRoom());
        }

    }
    private void OnImageButtonClicked(object sender, EventArgs e)
    {
        RoomButtonIsPressed?.Invoke();

        OnGamingEvent?.Invoke();
        Navigation.PushAsync(new ChillRoomP());
    }
}