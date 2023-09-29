using System.ComponentModel;

namespace FirstAppGame;

public partial class StatsShower : ContentPage, INotifyPropertyChanged
{

    public string MySecondText = "Nathan";

    public string MyCreatureName;
    public StatsShower()
    {
       // MyCreatureName = _creatureName;
        BindingContext = this;

        InitializeComponent();

	}
}