using ViewModel;

namespace LoL_MVVM.Pages;

public partial class ChampionEditPage : ContentPage
{
	public ChampionVM ChampionVM { get; set; }
	public ChampionEditPage(ChampionVM championVm)
    {
        ChampionVM = championVm;
		InitializeComponent();
		BindingContext = ChampionVM;
	}
}