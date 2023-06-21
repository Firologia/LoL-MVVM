using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using Custom_Toolkit_MVVM;
using Model;

namespace ViewModel;

public class SkinVM : ObservableObject
{
    private readonly Skin model;
    internal Skin Model => model;
    public string Name => model.Name;

    public ChampionVM ChampionVM => new ChampionVM(model.Champion);

    public string Description
    {
        get => model.Description;
        set => SetProperty(model.Description, value, EqualityComparer<string>.Default, model, (skin, s) => { skin.Description = s; });
    }

    public string Icon
    {
        get => model.Icon;
        set => SetProperty(model.Icon, value, EqualityComparer<string>.Default, model, (skin, s) => { skin.Icon = s; });
    }
    
    public string Image
    {
        get => model.Image.Base64;
        set => SetProperty(model.Image.Base64, value, EqualityComparer<string>.Default, model, (skin, s) => { skin.Image.Base64 = s; });
    }

    public float Price
    {
        get => model.Price;
        set => SetProperty(model.Price, value, EqualityComparer<float>.Default, model, (skin, f) => { skin.Price = f; });
    }

    public SkinVM(Skin model)
    {
        this.model = model;
    }

    public SkinVM(EditableSkinVM editableSkinVM)
    {
        this.model = new Skin(editableSkinVM.Name, editableSkinVM.ChampionVM.Model,
            editableSkinVM.Price, editableSkinVM.Icon, editableSkinVM.Image, editableSkinVM.Description);
    }

}