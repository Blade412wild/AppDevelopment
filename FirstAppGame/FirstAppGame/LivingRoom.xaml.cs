namespace FirstAppGame;

public partial class LivingRoom : ContentPage
{
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