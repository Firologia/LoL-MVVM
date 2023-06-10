using System;
using System.ComponentModel;
using ViewModel;
using Custom_Toolkit_MVVM;
using System.Windows.Input;
using System.Collections.ObjectModel;
using LoL_MVVM.Pages;
using StubLib;

namespace LoL_MVVM.ViewModel
{
	public class ApplicationVM : CustomObservableObject
	{
		public ChampionsManagerVM ChampionsManagerVM { get; }

		public INavigation Navigation
		{
			get => Application.Current.MainPage.Navigation;
		}
		
		public ICommand ChampionDetailsCommand { get; }
		public ICommand EditCommand { get; }
		public ICommand DeleteCommand { get; }

		public ApplicationVM(ChampionsManagerVM championsManagerVM)
		{
			//Set the championManagerVM
			ChampionsManagerVM = championsManagerVM;
			//Set the commands
			ChampionDetailsCommand = new Command<ChampionVM>(GoToDetailsPage);
			EditCommand = new Command<ChampionVM>(GoToEditPage);
			DeleteCommand = new Command<ChampionVM>(ChampionsManagerVM.DeleteChampion);
		}
		
        
		// Go to the details page of a champion
        private void GoToDetailsPage(ChampionVM championVM)
		{
			if (championVM == null) return;
			Navigation.PushAsync(new ChampionDetailsPage(championVM));
		}

        private void GoToEditPage(ChampionVM championVM)
        {
	        if (championVM == null) return;
	        Navigation.PushAsync(new ChampionEditPage(championVM));
        }

    }
}

