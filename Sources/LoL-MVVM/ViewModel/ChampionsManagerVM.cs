using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Model;

namespace ViewModel;

public partial class ChampionsManagerVM : ObservableObject
{
    
    public ReadOnlyObservableCollection<ChampionVM> Champions { get; }
    private readonly ObservableCollection<ChampionVM> champions = new();
    
    #region Fields

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(PreviousPageCommand))]
    [NotifyCanExecuteChangedFor(nameof(NextPageCommand))]
    private int page = 1;
    

    public int TotalPages
    {
        get {
        var totalItems = dataManager.ChampionsMgr.GetNbItems().Result;
        return (int) Math.Ceiling((double) totalItems / pageSize);
        }

    }

    [ObservableProperty]
    private int pageSize = 5;
    
        
    #endregion
    
    private readonly IDataManager dataManager;

    public ChampionsManagerVM(IDataManager dataManager)
    {
        this.dataManager = dataManager;
        Champions = new ReadOnlyObservableCollection<ChampionVM>(champions);
    }

    #region Commands

    [RelayCommand(CanExecute = nameof(CanNextPage))]
    private void NextPage()
    {
        Page++;
        LoadChampions();
    }
    
    [RelayCommand(CanExecute = nameof(CanPreviousPage))]
    private void PreviousPage()
    {
        Page--;
        LoadChampions();
    }
    
    [RelayCommand]
    private void LoadChampions()
    {
        champions.Clear();
        foreach (var champion in dataManager.ChampionsMgr.GetItems(Page-1, pageSize).Result)
        {
            champions.Add(new ChampionVM(champion!));
        }
    }

    #endregion
    
    #region CanExecute

    private bool CanNextPage() => Page < TotalPages;
    private bool CanPreviousPage() => Page > 1;

    #endregion

    #region ManageChampions
    
    public async Task DeleteChampion(ChampionVM championVM)
    {
        var result = await dataManager.ChampionsMgr.DeleteItem(championVM.Model);
        if (!result) return;
        
        OnPropertyChanged(nameof(TotalPages));
        NextPageCommand.NotifyCanExecuteChanged();
        
        LoadChampions();

        //Refresh next page

    }
    
    public async Task AddChampion(ChampionVM championVM)
    {
        var result = await dataManager.ChampionsMgr.AddItem(championVM.Model);
        if (result == null) return;
        //Update the pagination
        OnPropertyChanged(nameof(TotalPages));
        NextPageCommand.NotifyCanExecuteChanged();
        //Load the champions
        LoadChampions();
    }
    
    public ChampionVM CreateChampion(string name)
    {
        return new ChampionVM(new Champion(name, ChampionClass.Assassin));
    }
    #endregion

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