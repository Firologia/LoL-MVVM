using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Core.Extensions;
using Model;
using StubLib;

namespace LoL_MVVM;

public partial class App : Application
{

    public ObservableCollection<Champion> Champions { get; set; } =
        new StubData().ChampionsMgr.GetItems(0, 5).Result.ToObservableCollection();

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
