using System.Collections.ObjectModel;
using System.Reflection.PortableExecutable;
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
    private string name = "";

    public string Bio
    {
        get => bio;
        set => SetPropertyChanged(ref bio, value, EqualityComparer<string>.Default);
    }
    private string bio = "";

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
    private string icon = "";
    
    public string LargeImage
    {
        get => largeImage;
        set => SetPropertyChanged(ref largeImage, value, EqualityComparer<string>.Default);
    }
    private string largeImage = "";

    public ReadOnlyObservableDictionary<string, int> Characteristics { get; }
    private readonly ObservableDictionary<string, int> characteristics  = new();
    
    public ReadOnlyObservableCollection<SkillVM> Skills { get; }
    private readonly ObservableCollection<SkillVM> skills = new();
    

    public EditableChampionVM(ChampionVM championVM)
    {
        Name = championVM.Name;
        Bio = championVM.Bio;
        ChampionClass = championVM.Class;
        Icon = championVM.Icon;
        LargeImage = championVM.LargeImage;
        
        Characteristics = new ReadOnlyObservableDictionary<string, int>(characteristics);
        Skills = new ReadOnlyObservableCollection<SkillVM>(skills);
        
        
        foreach (var c in championVM.Characteristics)
        {
            characteristics.Add(c.Key, c.Value);
        }

        foreach (var skill in championVM.Skills)
        {
            skills.Add(skill);
        }
    }

    public void AddCharacteristic(string key, int value)
    {
        characteristics.Add(key, value);
    }
    
    public void UpdateCharacteristic(string key, int value)
    {
        characteristics[key] = value;
    }

    public void AddSkill(SkillVM skill)
    {
        skills.Add(skill);
    }

    public void UpdateSkill(SkillVM oldSkill, SkillVM newSkill)
    {
        var index = skills.IndexOf(oldSkill);
        if(index != -1) skills[index] = newSkill;
    }
}