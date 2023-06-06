namespace ViewModel.Utils;

public class EnumsUtil<TEnum> where TEnum : struct, System.Enum
{
    public IEnumerable<TEnum> Values => Enum.GetValues<TEnum>();
}