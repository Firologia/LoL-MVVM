using System.Collections.ObjectModel;
using System.Reflection.PortableExecutable;
using CommunityToolkit.Mvvm.ComponentModel;
using Custom_Toolkit_MVVM;
using ViewModel.Enums;
using ViewModel.Utils;

namespace ViewModel;

public partial class EditableChampionVM : ObservableObject
{

    [ObservableProperty]
    private string name = "";
    
    [ObservableProperty]
    private string bio = "";
    
    [ObservableProperty]
    private ChampionClassVM championClass;
    
    [ObservableProperty]
    private string icon = Base64Constants.DEFAULT_ICON;
    
    [ObservableProperty]
    private string largeImage = Base64Constants.DEFAULT_IMAGE;

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