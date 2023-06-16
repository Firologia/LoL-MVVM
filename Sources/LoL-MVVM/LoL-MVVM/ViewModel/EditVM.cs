using System.Windows.Input;
using CommunityToolkit.Maui.Core.Extensions;
using Custom_Toolkit_MVVM;
using LoL_MVVM.Pages;
using LoL_MVVM.Utils;
using ViewModel;

namespace LoL_MVVM.ViewModel;

public class EditVM : CustomObservableObject
{
    private ApplicationVM applicationVM => (Application.Current as App).ApplicationVM;
    public EditableChampionVM EditableChampionVM { get; set; }
    private ChampionVM championVM;

    public string EditedKey
    {
        get => editedKey;
        set => SetPropertyChanged(ref editedKey, value, EqualityComparer<string>.Default);
    }
    private string editedKey = "";
    public int EditedValue
    {
        get => editedValue;
        set => SetPropertyChanged(ref editedValue, value, EqualityComparer<int>.Default);
    }
    private int editedValue = 0;
    
    public ICommand EditIconCommand { get; }
    public ICommand EditImageCommand { get; }

    public ICommand AddCharacteristicCommand { get; }
    
    public ICommand EditSkillCommand { get; }
    public ICommand AddSkillCommand { get; }
    
    //Principals commands
    public ICommand SubmitCommand { get; }
    public ICommand CancelCommand { get; }
    
    public EditVM(ChampionVM championVM)
    {
        this.championVM = championVM;
        EditableChampionVM = new EditableChampionVM()
        {
            Name = championVM.Name,
            Bio = championVM.Bio,
            ChampionClass = championVM.Class,
            Icon = championVM.Icon,
            LargeImage = championVM.LargeImage,
            Characteristics = championVM.Characteristics.ToObservableDictionary(),
            Skills = championVM.Skills.ToObservableCollection(),
            Skins = championVM.Skins.ToObservableCollection()
        };
        
        EditIconCommand = new Command(async execute =>
            {
                var icon = await PickImage();
                if(icon is not null) EditableChampionVM.Icon = icon;
                
            });
        
        EditImageCommand = new Command(
            async execute =>
            {
                var image =  await PickImage();
                if(image is not null) EditableChampionVM.LargeImage = image;
            
            });
        AddCharacteristicCommand = new Command(
            execute =>
            {
                if(EditableChampionVM.Characteristics.ContainsKey(editedKey)) EditableChampionVM.UpdateCharacteristic(new Tuple<string, int>(editedKey, editedValue));
                else EditableChampionVM.AddCharacteristic(new Tuple<string, int>(editedKey, editedValue));
            });

        EditSkillCommand = new Command<SkillVM>(ToEditSkillPage);
        AddSkillCommand = new Command(ToAddSkillPage);


        SubmitCommand = new Command(
        execute =>
            {
                championVM.Bio = EditableChampionVM.Bio;
                championVM.Class = EditableChampionVM.ChampionClass;
                championVM.Icon = EditableChampionVM.Icon;
                championVM.LargeImage = EditableChampionVM.LargeImage;

                championVM.ClearCharacteristics();
                foreach (var keyValuePair in EditableChampionVM.Characteristics.Reverse())
                {
                    championVM.AddCharacteristic(keyValuePair.Key, keyValuePair.Value);

                }

                championVM.ClearSkills();
                foreach (var skill in EditableChampionVM.Skills.Reverse())
                {
                    this.championVM.AddSkill(skill);
                }
                
                
                //The champion is added if it doesn't exist in the list
                applicationVM.ChampionsManagerVM.AddChampion(championVM);
                //We remove the page from the navigation stack
                ApplicationVM.Navigation.RemovePage(ApplicationVM.Navigation.NavigationStack[^1]);
            });
        
        CancelCommand = new Command(
            execute =>
            {
                ApplicationVM.Navigation.RemovePage(ApplicationVM.Navigation.NavigationStack[^1]);
            });
    }
    
    private async Task<FileResult> PickAFile(PickOptions options)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(options);
            if (result != null)
            {
                if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                    result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                {
                    using var stream = await result.OpenReadAsync();
                    var image = ImageSource.FromStream(() => stream);
                }
            }

            return result;
        }
        catch (Exception)
        {
            // The user canceled or something went wrong
        }

        return null;
    }

    private async Task<string> PickImage()
    {
        var result = await PickAFile(new PickOptions
        {
            PickerTitle = "Pick an icon",
            FileTypes = FilePickerFileType.Images
        });

        if(result != null) return await result.ToBase64();
        return null;
    }

    public void ToEditSkillPage(SkillVM skillVM)
    {
        var skillEditVM = new SkillEditVM(this, skillVM);
        ApplicationVM.Navigation.PushAsync(new SkillEditPage(skillEditVM));
    }

    public void ToAddSkillPage()
    {
        ApplicationVM.Navigation.PushAsync(new SkillEditPage(new SkillEditVM(this)));
    }
    
    public void AddSkill(SkillVM oldSkill,SkillVM skillVM)
    {
        if(oldSkill is null) EditableChampionVM.Skills.Add(skillVM);
        else UpdateSkill(oldSkill,skillVM);
    }

    public void UpdateSkill(SkillVM oldSkill,SkillVM skillVM)
    {
        var index = EditableChampionVM.Skills.IndexOf(oldSkill);
        if(index != -1) EditableChampionVM.Skills[index] = skillVM;
    }






}