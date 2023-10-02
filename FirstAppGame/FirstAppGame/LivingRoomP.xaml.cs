namespace FirstAppGame;

public partial class LivingRoomP : ContentPage
{
    public delegate void RoomSwitchButton(int _room);
    public static event RoomSwitchButton RoomButtonIsPressed;


    public LivingRoomP()
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
}