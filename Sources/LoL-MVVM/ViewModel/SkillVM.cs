using CommunityToolkit.Mvvm.ComponentModel;
using Model;
using ViewModel.Enums;

namespace ViewModel;
public class SkillVM : ObservableObject
{
    private readonly Skill model;
    internal Skill Model => model;
    public string Name => model.Name;

    public SkillTypeVM Type => (SkillTypeVM) model.Type;

    public string Description
    {
        get => model.Description;
        set => SetProperty(model.Description, value, EqualityComparer<string>.Default, model, (skill, s) => { skill.Description = s; });
        }

    public SkillVM(Skill model)
    {
        this.model = model;
    }

    public SkillVM(EditableSkillVM editableSkillVM)
    {
        this.model = new Skill(editableSkillVM.Name, editableSkillVM.Type.ToModel(), editableSkillVM.Description);
    }
    
    public bool Equals(SkillVM? other)
        => Name.Equals(other?.Name) && Type == other.Type;

    public override int GetHashCode()
        => Name.GetHashCode() % 281;

        
}
