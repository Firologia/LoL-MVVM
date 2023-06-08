using System.Collections.ObjectModel;
using Model;

namespace ViewModel;

public class ChampionsManagerVM
{
    public ReadOnlyObservableCollection<ChampionVM> Champions { get; }

    private readonly ObservableCollection<ChampionVM> champions = new();

    private readonly IDataManager dataManager;

    public ChampionsManagerVM(IDataManager dataManager)
    {
        this.dataManager = dataManager;
        LoadChampions();
        Champions = new ReadOnlyObservableCollection<ChampionVM>(champions);
        

    }
    private void LoadChampions()
    {
        champions.Clear();
        foreach (var champion in dataManager.ChampionsMgr.GetItems(0, 10).Result)
        {
            champions.Add(new ChampionVM(champion!));
        }
    }

}