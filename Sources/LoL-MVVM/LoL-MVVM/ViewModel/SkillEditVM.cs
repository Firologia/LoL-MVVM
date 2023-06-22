using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ViewModel;

namespace LoL_MVVM.ViewModel;

public partial class SkillEditVM : ObservableObject
{
    private EditVM editVM;
    public EditableSkillVM EditableSkillVM { get; set; }
    private SkillVM skillVM;
    

    public SkillEditVM(EditVM editVM)
    {
        this.editVM = editVM;
        EditableSkillVM = new EditableSkillVM();
    }
    
    public SkillEditVM(EditVM editVM, SkillVM skillVM) : this(editVM)
    {
        this.skillVM = skillVM;
        EditableSkillVM = new EditableSkillVM()
        {
            Name = skillVM.Name,
            Type = skillVM.Type,
            Description = skillVM.Description
        };
    }

    [RelayCommand]
    private void Submit()
    {
        var oldSkill = skillVM;
        skillVM = new SkillVM(EditableSkillVM);
        if(oldSkill == null) editVM.AddSkillToEditable(skillVM);
        else editVM.UpdateSkill(oldSkill, skillVM);
        CloseEdition();
    }
    [RelayCommand]
    private void Cancel()
    {
        CloseEdition();
    }

    private void CloseEdition()
    {
        ApplicationVM.Navigation.RemovePage(ApplicationVM.Navigation.NavigationStack.Last());
    }


}