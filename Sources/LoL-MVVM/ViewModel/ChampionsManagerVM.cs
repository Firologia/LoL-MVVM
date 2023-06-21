using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Model;

namespace ViewModel;

public class ChampionsManagerVM : INotifyPropertyChanged
{
    private int page = 1;
    private int totalItems = 0;
    private int totalPages;
    private int pageSize = 5;

    public int PageSize
    {
        get => pageSize;
        set
        {
            if (value < 0) return;
            pageSize = value;
            OnPropertyChanged();
        } 
    }
    
    public int TotalPages
    {
        get => totalPages;
        set
        {
            if (value < 0) return;
            totalPages = value;
            OnPropertyChanged();
        }
    }

    public int Page
    {
        get => page;
        set
        {
            if (value < 1) return;
            page = value;
            OnPropertyChanged();
            (NextPageCommand as Command).ChangeCanExecute();
            (PreviousPageCommand as Command).ChangeCanExecute();
        }
    }

    #region Commands

    // Go to next page of champions command
    public ICommand NextPageCommand {  get; private set; }
    
    //Go to previous page of champions command
    public ICommand PreviousPageCommand { get; private set; }
    
    //Load champions command
    public ICommand LoadCommand { get; private set; }

    #endregion

    
    public ReadOnlyObservableCollection<ChampionVM> Champions { get; }
    private readonly ObservableCollection<ChampionVM> champions = new();

    private readonly IDataManager dataManager;

    public ChampionsManagerVM(IDataManager dataManager)
    {
        this.dataManager = dataManager;
        Champions = new ReadOnlyObservableCollection<ChampionVM>(champions);
        UpdatePagination();
        
        #pragma warning disable CA1416
        
        LoadCommand = new Command(LoadChampions);

        NextPageCommand = new Command(
            execute: () =>
            {
                Page++;
                LoadChampions();
            },
            canExecute: () => Page < TotalPages);
        
        PreviousPageCommand = new Command(
            execute: () =>
            {
                Page--;
                LoadChampions();
            },
            canExecute: () => Page > 1);
        
        #pragma warning restore CA1416

    }
    private void LoadChampions()
    {
        champions.Clear();
        foreach (var champion in dataManager.ChampionsMgr.GetItems(Page-1, pageSize).Result)
        {
            champions.Add(new ChampionVM(champion!));
        }
    }
    
    private void UpdatePagination() {
        totalItems = dataManager.ChampionsMgr.GetNbItems().Result;
        TotalPages = (int) Math.Ceiling((double) totalItems / pageSize);
    }

    public void DeleteChampion(ChampionVM championVM)
    {
        dataManager.ChampionsMgr.DeleteItem(championVM.Model);
        LoadChampions();
        UpdatePagination();
        //Refresh next page
        (NextPageCommand as Command).ChangeCanExecute();
    }

    public void AddChampion(ChampionVM championVM)
    {
        dataManager.ChampionsMgr.AddItem(championVM.Model);
        //Update the pagination
        UpdatePagination();
        //Load the champions
        LoadChampions();
        //Refresh next page
        (NextPageCommand as Command).ChangeCanExecute();
    }

    public ChampionVM CreateChampion(string name)
    {
        return new ChampionVM(new Champion(name, ChampionClass.Assassin));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void AddSkin(SkinVM skinVM)
    {
        var skin = skinVM.Model;
        dataManager.SkinsMgr.AddItem(skin);
        LoadChampions();
    }

    public async void UpdateSkin(SkinVM oldSkin, SkinVM newSkin)
    {
        var oldSkinModel = oldSkin.Model;
        var newSkinModel = newSkin.Model;
        var skin = await dataManager.SkinsMgr.UpdateItem(oldSkinModel, newSkinModel);
        LoadChampions();
    }

    public async Task DeleteSkin(SkinVM skinVM)
    {
        await dataManager.SkinsMgr.DeleteItem(skinVM.Model);
        LoadChampions();
    }
}