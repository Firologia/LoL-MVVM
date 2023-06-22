using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoL_MVVM.Pages;
using LoL_MVVM.Utils;
using ViewModel;

namespace LoL_MVVM.ViewModel;

public partial class EditVM : ObservableObject
{
    private ApplicationVM applicationVM => (Application.Current as App).ApplicationVM;
    public EditableChampionVM EditableChampionVM { get; set; }
    private ChampionVM championVM;

    [ObservableProperty]
    private string editedKey = "";
    
    [ObservableProperty]
    private int editedValue = 0;
    
    
    public EditVM(ChampionVM championVM)
    {
        this.championVM = championVM;
        EditableChampionVM = new EditableChampionVM(this.championVM);
    }

    #region Commands

    [RelayCommand]
    private async void EditIcon()
    {
        var icon = await EditFilePicker.PickImage();
        if(icon is not null) EditableChampionVM.Icon = icon;
    }

    [RelayCommand]
    private async void EditImage()
    {
        var image =  await EditFilePicker.PickImage();
        if(image is not null) EditableChampionVM.LargeImage = image;
    }

    [RelayCommand]
    private void AddCharacteristic()
    {
        if(EditableChampionVM.Characteristics.ContainsKey(editedKey)) 
            EditableChampionVM.UpdateCharacteristic(editedKey, editedValue);
        else EditableChampionVM.AddCharacteristic(editedKey, editedValue);
    }

    [RelayCommand]
    private void EditSkill(SkillVM skillVM)
    {
        var skillEditVM = new SkillEditVM(this, skillVM);
        ApplicationVM.Navigation.PushAsync(new SkillEditPage(skillEditVM));
    }

    [RelayCommand]
    private void AddSkill()
    {
        ApplicationVM.Navigation.PushAsync(new SkillEditPage(new SkillEditVM(this)));
    }

    [RelayCommand]
    private void Submit()
    {
        {
            championVM.Bio = EditableChampionVM.Bio;
            championVM.Class = EditableChampionVM.ChampionClass;
            championVM.Icon = EditableChampionVM.Icon;
            championVM.LargeImage = EditableChampionVM.LargeImage;
            championVM.ClearCharacteristics();
            EditableChampionVM.Characteristics.ToList().ForEach(kvp => championVM.AddCharacteristic(kvp.Key, kvp.Value));

            championVM.ClearSkills();
            foreach (var skill in EditableChampionVM.Skills.Reverse())
            {
                this.championVM.AddSkill(skill);
            }
                
                
            //The champion is added if it doesn't exist in the list
            applicationVM.ChampionsManagerVM.AddChampion(championVM);
            //We remove the page from the navigation stack
            ApplicationVM.Navigation.RemovePage(ApplicationVM.Navigation.NavigationStack[^1]);
        }
    }

    [RelayCommand]
    private void Cancel()
    {
        ApplicationVM.Navigation.RemovePage(ApplicationVM.Navigation.NavigationStack[^1]);
    }
    

    #endregion

    internal void AddSkillToEditable(SkillVM newSkill)
    {
        EditableChampionVM.AddSkill(newSkill);
    }

    internal void UpdateSkill(SkillVM oldSkill,SkillVM newSkill)
    {
        EditableChampionVM.UpdateSkill(oldSkill, newSkill);
    }

}