
using ViewModel.Enums;

namespace ViewModel;

public class EditableSkillVM
{
    public string Name { get; set; }
    public SkillTypeVM Type { get; set; }
    public string Description { get; set; }
}