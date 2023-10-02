namespace FirstAppGame;

public partial class App : Application
{
	public App()
	{
		DependencyService.RegisterSingleton<IDataStore<Creature>>(new CreatureDataStore());

        InitializeComponent();

		MainPage = new NavigationPage(new MainPage());
		//MainPage = new AppShell();
	}
}
