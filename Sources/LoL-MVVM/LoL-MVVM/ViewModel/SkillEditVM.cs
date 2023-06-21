using System.Windows.Input;
using ViewModel;

namespace LoL_MVVM.ViewModel;

public class SkillEditVM
{
    private EditVM editVM;
    public EditableSkillVM EditableSkillVM { get; set; }
    private SkillVM skillVM;
    
    public ICommand SubmitCommand { get; private init; }
    public ICommand CancelCommand { get; }

    public SkillEditVM(EditVM editVM)
    {
        this.editVM = editVM;
        EditableSkillVM = new EditableSkillVM();
        
        SubmitCommand = new Command(SubmitCommandMethod);
        CancelCommand = new Command(CancelCommandMethod);
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

    private void SubmitCommandMethod(object execute)
    {
        var oldSkill = skillVM;
        skillVM = new SkillVM(EditableSkillVM);
        if(oldSkill is null) editVM.AddSkill(skillVM);
        else editVM.UpdateSkill(oldSkill, skillVM);
        CloseEdition();
    }
    private void CancelCommandMethod(object execute)
    {
        CloseEdition();
    }

    private void CloseEdition()
    {
        ApplicationVM.Navigation.RemovePage(ApplicationVM.Navigation.NavigationStack.Last());
    }


}