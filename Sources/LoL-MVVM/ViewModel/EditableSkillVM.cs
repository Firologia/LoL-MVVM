
using CommunityToolkit.Mvvm.ComponentModel;
using ViewModel.Enums;

namespace ViewModel;

public partial class EditableSkillVM : ObservableObject
{
    [ObservableProperty]
    private string _name = "";

    [ObservableProperty]
    private SkillTypeVM _type = SkillTypeVM.Unknown;

    [ObservableProperty]
    private string _description = "";
}