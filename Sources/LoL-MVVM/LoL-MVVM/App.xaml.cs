using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Core.Extensions;
using LoL_MVVM.ViewModel;
using Model;
using StubLib;
using ViewModel;

namespace LoL_MVVM;

public partial class App : Application
{
	public ApplicationVM ApplicationVM { get; }
    public App(ApplicationVM applicationVM)
	{
		ApplicationVM = applicationVM;
		InitializeComponent();

		MainPage = new AppShell();
	}
}