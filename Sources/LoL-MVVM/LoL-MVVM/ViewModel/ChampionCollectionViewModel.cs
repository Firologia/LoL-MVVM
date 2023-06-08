using System;
using System.ComponentModel;
using ViewModel;
using Custom_Toolkit_MVVM;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace LoL_MVVM.ViewModel
{
	public class ChampionCollectionViewModel : CustomObservableObject
	{
		ChampionVM championEdit;
		bool isEditing;

		public bool IsEditing
		{
			get => isEditing;
			private set => SetPropertyChanged<bool>(ref isEditing, value);
		}

		public ChampionVM ChampionEdit
		{
			get => championEdit;
			set => SetPropertyChanged<ChampionVM>(ref championEdit, value);
		}

		public ICommand NewCommand { private set; get; }
		public ICommand EditCommand { private set; get; }
		public ICommand CancelCommand { private set; get; }

		public IList<ChampionVM> Champions { get; } = new ObservableCollection<ChampionVM>();

		public ChampionCollectionViewModel()
		{
			NewCommand = new Command(
				execute =>
				{
					ChampionEdit = new ChampionVM();
					IsEditing = true;
					RefreshCanExecutes();
				},
				canExecute =>
				{
					return !IsEditing;
				});
		}

        void RefreshCanExecutes()
        {
            (NewCommand as Command).ChangeCanExecute();
            (EditCommand as Command).ChangeCanExecute();
            (CancelCommand as Command).ChangeCanExecute();
        }

    }
}

