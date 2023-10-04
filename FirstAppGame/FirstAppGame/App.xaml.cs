namespace FirstAppGame;

public partial class App : Application
{
	public App()
	{
		DependencyService.RegisterSingleton<IDataStore<Creature>>(new CreatureDataStore());
        DependencyService.RegisterSingleton<IDataStore<OwnTime>>(new PastTimeDataStore());

        DependencyService.RegisterSingleton<ActionStateManager>(new ActionStateManager());

        InitializeComponent();

		MainPage = new NavigationPage(new StartMenu());
		//MainPage = new AppShell();
	}
}
