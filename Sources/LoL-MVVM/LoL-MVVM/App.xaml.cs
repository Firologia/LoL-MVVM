using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Core.Extensions;
using Model;
using StubLib;
using ViewModel;

namespace LoL_MVVM;

public partial class App : Application
{

    public ObservableCollection<ChampionVM> ChampionsVM { get; set; } =
        new StubData().ChampionsMgr.GetItems(0, 5).Result.Select(x => new ChampionVM(x)).ToObservableCollection();

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}