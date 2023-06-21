using Model;

namespace ViewModel;

public class SkinsManagerVM
{
    private readonly IDataManager dataManager;

    public SkinsManagerVM(IDataManager dataManager)
    {
        this.dataManager = dataManager;
    }

    public async void AddSkin(SkinVM skinVM)
    {
        var skin = await dataManager.SkinsMgr.AddItem(skinVM.Model);
        if (skin != null) skinVM.ChampionVM.AddSkin(new SkinVM(skin));
    }

    public async void UpdateSkin(SkinVM oldSkin, SkinVM newSkin)
    {
        var oldSkinModel = oldSkin.Model;
        var newSkinModel = newSkin.Model;
        var skin = await dataManager.SkinsMgr.UpdateItem(oldSkinModel, newSkinModel);
        if(skin != null) oldSkin.ChampionVM.UpdateSkin(oldSkin, new SkinVM(skin));
        
    }

    public async Task DeleteSkin(SkinVM skinVM)
    {
        var result = await dataManager.SkinsMgr.DeleteItem(skinVM.Model);
        if (result) skinVM.ChampionVM.RemoveSkin(skinVM);
    }
}