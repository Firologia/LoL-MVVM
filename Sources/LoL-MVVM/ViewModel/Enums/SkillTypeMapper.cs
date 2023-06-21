using Model;

namespace ViewModel.Enums;

public static class SkillTypeMapper
{
    public static SkillTypeVM ToViewModel(this SkillType skillType)
    {
        switch (skillType)
        {
            case SkillType.Basic:
                return SkillTypeVM.Basic;
            case SkillType.Passive:
                return SkillTypeVM.Passive;
            case SkillType.Ultimate:
                return SkillTypeVM.Ultimate;
            default:
                throw new ArgumentOutOfRangeException(nameof(skillType), skillType, "Unsupported SkillType value");
        }
    }

    public static SkillType ToModel(this SkillTypeVM skillTypeVM)
    {
        switch (skillTypeVM)
        {
            case SkillTypeVM.Unknown:
                return SkillType.Unknown;
            case SkillTypeVM.Basic:
                return SkillType.Basic;
            case SkillTypeVM.Passive:
                return SkillType.Passive;
            case SkillTypeVM.Ultimate:
                return SkillType.Ultimate;
            default:
                throw new ArgumentOutOfRangeException(nameof(skillTypeVM), skillTypeVM, "Unsupported SkillTypeVM value");
        }
    }
}