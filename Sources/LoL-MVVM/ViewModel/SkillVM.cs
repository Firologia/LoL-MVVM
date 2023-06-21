using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Custom_Toolkit_MVVM;
using Model;
using ViewModel.Enums;

namespace ViewModel;
public class SkillVM : GenericClassVM<Skill>
{
    internal Skill Model => model;
    public string Name => model.Name;

    public SkillTypeVM Type => (SkillTypeVM) model.Type;

    public string Description
    {
        get => model.Description;
        set => SetModelPropertyChanged(model.Description, value, EqualityComparer<string>.Default, model, (skill, s) => { skill.Description = s; });
        }

    public SkillVM(Skill model) : base(model)
    {
    }

    public SkillVM(EditableSkillVM editableSkillVM) : base(new Skill(editableSkillVM.Name, editableSkillVM.Type.ToModel(), editableSkillVM.Description))
    {
        
    }
    
    public bool Equals(SkillVM? other)
        => Name.Equals(other?.Name) && Type == other.Type;

    public override int GetHashCode()
        => Name.GetHashCode() % 281;

        
}
