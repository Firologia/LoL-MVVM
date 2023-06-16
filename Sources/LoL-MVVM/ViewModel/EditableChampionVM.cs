using System.Collections.ObjectModel;
using Custom_Toolkit_MVVM;
using ViewModel.Enums;
using ViewModel.Utils;

namespace ViewModel;

public class EditableChampionVM : CustomObservableObject
{
    public string Name
    {
        get => name;
        set => SetPropertyChanged(ref name, value, EqualityComparer<string>.Default);
    }
    private string name;

    public string Bio
    {
        get => bio;
        set => SetPropertyChanged(ref bio, value, EqualityComparer<string>.Default);
    }
    private string bio;

    public ChampionClassVM ChampionClass
    {
        get => championClass;
        set => SetPropertyChanged(ref championClass, value, EqualityComparer<ChampionClassVM>.Default);
    }
    private ChampionClassVM championClass;
    
    public string Icon
    {
        get => icon;
        set => SetPropertyChanged(ref icon, value, EqualityComparer<string>.Default);
    }
    private string icon;
    
    public string LargeImage
    {
        get => largeImage;
        set => SetPropertyChanged(ref largeImage, value, EqualityComparer<string>.Default);
    }
    private string largeImage;

    public ObservableDictionary<string, int> Characteristics { get; set; } = new();
    
    public ObservableCollection<SkillVM> Skills { get; set; } = new();
    
    public ObservableCollection<SkinVM> Skins { get; set; } = new();

    public void AddCharacteristic(string key, int value)
    {
        Characteristics.Remove(key);
        Characteristics.Add(key, value);
    }
}