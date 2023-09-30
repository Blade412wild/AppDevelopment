namespace FirstAppGame;

public partial class LivingRoom : ContentPage
{
    public delegate void ButtonPressed();
    public static event ButtonPressed OnEatEvent;
    public LivingRoom()
	{
		InitializeComponent();
	}
    private void OnNextRoomClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ChillRoom());

    }
    private void OnPreviousRoomClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Corridor());
    }
}