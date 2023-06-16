using LoL_MVVM.ViewModel;
using ViewModel;

namespace LoL_MVVM.Pages;

public partial class ChampionDetailsPage : ContentPage
{
	public ApplicationVM ApplicationVM => (Application.Current as App).ApplicationVM;
	public ChampionVM ChampionVM { get; set; }

	public ChampionDetailsPage(ChampionVM championVM)
	{
		ChampionVM = championVM;
        InitializeComponent();
		BindingContext = ChampionVM;

	}
}