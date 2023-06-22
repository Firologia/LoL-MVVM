using ViewModel;
using Custom_Toolkit_MVVM;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoL_MVVM.Pages;

namespace LoL_MVVM.ViewModel
{
	public partial class ApplicationVM : ObservableObject
	{
		public ChampionsManagerVM ChampionsManagerVM { get; }

		public static INavigation Navigation
		{
			get => Application.Current.MainPage.Navigation;
		}

		public ApplicationVM(ChampionsManagerVM championsManagerVM)
		{
			//Set the championManagerVM
			ChampionsManagerVM = championsManagerVM;

		}

		#region Commands

		/// <summary>
		/// Go the details page of a champion
		/// </summary>
		/// <param name="championVM">Champion we want to see details</param>
		[RelayCommand]
		private void ChampionDetails(ChampionVM championVM)
		{
			if (championVM == null) return;
			Navigation.PushAsync(new ChampionDetailsPage(championVM));
		}
		
		/// <summary>
		/// Go to the edit of a champion
		/// </summary>
		/// <param name="championVM">Champion we edit</param>
		[RelayCommand]
		private async void ChampionEdit(ChampionVM championVM)
		{
			if (championVM == null) return;
			await Navigation.PushAsync(new ChampionEditPage(new EditVM(championVM)));
		}
		
		/// <summary>
		/// Create a champion command
		/// </summary>
		[RelayCommand]
		private async void CreateChampion()
		{
			//Ask the user for the name of the champion
			string result = await Shell.Current.DisplayPromptAsync("Create Champion", "Enter the name of the champion"); 
			//If the user cancels the prompt, the result will be null
			if (result == null) return;
			//Create the champion and go to the edit page
			await Navigation.PushAsync(new ChampionEditPage(new EditVM(ChampionsManagerVM.CreateChampion(result))));
		}

		/// <summary>
		/// Delete a champion
		/// </summary>
		/// <param name="championVm">Champion we want to delete</param>
		[RelayCommand]
		private void DeleteChampion(ChampionVM championVm)
		{
			ChampionsManagerVM.DeleteChampion(championVm);
		}
		
		/// <summary>
		/// See skin details
		/// </summary>
		/// <param name="skinVM">Skin we want to see</param>
		[RelayCommand]
		private async void SkinDetails(SkinVM skinVM)
		{
			if (skinVM == null) return;
			await Navigation.PushAsync(new SkinDetailsPage(skinVM));
	        
		}
		
		/// <summary>
		/// Add a skin
		/// </summary>
		/// <param name="championVM">Champion who have the skin</param>
		[RelayCommand]
		private async void AddSkin(ChampionVM championVM)
		{
			if(championVM == null) return;
			await Navigation.PushAsync(new SkinEditPage(new SkinEditVM(championVM)));
		}

		/// <summary>
		/// Edit a skin
		/// </summary>
		/// <param name="skinVM">The skin we want to edit</param>
		[RelayCommand]
		private async void EditSkin(SkinVM skinVM)
		{
			if (skinVM == null || skinVM.ChampionVM == null) return;
			await Navigation.PushAsync(new SkinEditPage(new SkinEditVM(skinVM)));
		}

		/// <summary>
		/// Delete a skin
		/// </summary>
		/// <param name="skinVM">The skin we want to delete</param>
		[RelayCommand]
		private async void DeleteSkin(SkinVM skinVM)
		{
			if (skinVM == null) return;
			await ChampionsManagerVM.DeleteSkin(skinVM);
		}

		#endregion









    }
}

