using ViewModel;
using Custom_Toolkit_MVVM;
using System.Windows.Input;
using LoL_MVVM.Pages;

namespace LoL_MVVM.ViewModel
{
	public class ApplicationVM : CustomObservableObject
	{
		public ChampionsManagerVM ChampionsManagerVM { get; }
		public SkinsManagerVM SkinsManagerVM { get; }

		public static INavigation Navigation
		{
			get => Application.Current.MainPage.Navigation;
		}
		
		public ICommand ChampionDetailsCommand { get; }
		public ICommand SkinDetailsCommand { get; }
		public ICommand EditCommand { get; }
		
		public ICommand EditSkinCommand { get; }
		public ICommand DeleteCommand { get; }
		public ICommand AddCommand { get; }
		public ICommand AddSkinCommand { get; }
		public ICommand CreateCommand { get; }

		public ICommand DeleteSkinCommand { get; }

		public ApplicationVM(ChampionsManagerVM championsManagerVM, SkinsManagerVM skinsManagerVM)
		{
			//Set the championManagerVM
			SkinsManagerVM = skinsManagerVM;
			ChampionsManagerVM = championsManagerVM;
			//Set the commands
			ChampionDetailsCommand = new Command<ChampionVM>(GoToChampionDetailsPage);
			EditCommand = new Command<ChampionVM>(GoToChampionEditPage);
			DeleteCommand = new Command<ChampionVM>(ChampionsManagerVM.DeleteChampion);
			CreateCommand = new Command(CreateChampion);
			//AddCommand = new Command<ChampionVM>(ChampionsManagerVM.AddChampion);
			
			SkinDetailsCommand = new Command<SkinVM>(GoToSkinDetailsPage);
			EditSkinCommand = new Command<SkinVM>(EditSkinCommandMethod);
			AddSkinCommand = new Command<ChampionVM>(AddSkinCommandMethod);

			DeleteSkinCommand = new Command<SkinVM>(DeleteSkinCommandMethod);

		}
		
        
		// Go to the details page of a champion
        private void GoToChampionDetailsPage(ChampionVM championVM)
		{
			if (championVM == null) return;
			Navigation.PushAsync(new ChampionDetailsPage(championVM));
		}

        private async void GoToChampionEditPage(ChampionVM championVM)
        {
	        if (championVM == null) return;
	        await Navigation.PushAsync(new ChampionEditPage(new EditVM(championVM)));
        }
        private async void CreateChampion()
        {
	        //Ask the user for the name of the champion
	        string result = await Shell.Current.DisplayPromptAsync("Create Champion", "Enter the name of the champion"); 
	        //If the user cancels the prompt, the result will be null
	        if (result == null) return;
	        //Create the champion and go to the edit page
	        await Navigation.PushAsync(new ChampionEditPage(new EditVM(ChampionsManagerVM.CreateChampion(result))));
        }

        private async void GoToSkinDetailsPage(SkinVM skinVM)
        {
	        if (skinVM == null) return;
	        await Navigation.PushAsync(new SkinDetailsPage(skinVM));
	        
        }

        private async void AddSkinCommandMethod(ChampionVM championVM)
        {
	        if(championVM == null) return;
	        await Navigation.PushAsync(new SkinEditPage(new SkinEditVM(championVM)));
        }

        private async void EditSkinCommandMethod(SkinVM skinVM)
        {
	        if (skinVM == null || skinVM.ChampionVM == null) return;
	        await Navigation.PushAsync(new SkinEditPage(new SkinEditVM(skinVM)));
        }

		private async void DeleteSkinCommandMethod(SkinVM skinVM)
		{
			if (skinVM == null) return;
			await SkinsManagerVM.DeleteSkin(skinVM);
		}
    }
}

