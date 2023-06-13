using System.Windows.Input;
using LoL_MVVM.Pages;
using LoL_MVVM.Utils;
using Model;
using ViewModel;

namespace LoL_MVVM.ViewModel;

public class EditVM
{
    public EditableChampionVM EditableChampionVM { get; set; }
    private ChampionVM championVM;
    
    public ICommand EditIconCommand { get; }
    public ICommand EditImageCommand { get; }
    
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
            LargeImage = championVM.LargeImage
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
        
        SubmitCommand = new Command(
        execute =>
            {
                championVM.Bio = EditableChampionVM.Bio;
                championVM.Class = EditableChampionVM.ChampionClass;
                championVM.Icon = EditableChampionVM.Icon;
                championVM.LargeImage = EditableChampionVM.LargeImage;
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
    
    
    
    
}