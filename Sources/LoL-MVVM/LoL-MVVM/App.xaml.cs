using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Core.Extensions;
using Model;
using StubLib;
using ViewModel;

namespace LoL_MVVM;

public partial class App : Application
{

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}