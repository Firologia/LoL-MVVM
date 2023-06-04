namespace LoL_MVVM.Components;

public partial class CharacteristicItemView : ContentView
{
	public string CharacteristicName { 
		get => (string) GetValue(CharacteristicNameProperty);
		set => SetValue(CharacteristicNameProperty, value);
	}

	public static readonly BindableProperty CharacteristicNameProperty =
		BindableProperty.Create(nameof(CharacteristicName), typeof(string), typeof(CharacteristicItemView), null, BindingMode.OneTime);

	public int CharacteristicValue { 
		get => (int) GetValue(CharacteristicValueProperty);
		set => SetValue(CharacteristicValueProperty, value);
	}

	public static readonly BindableProperty CharacteristicValueProperty =
		BindableProperty.Create(nameof(CharacteristicValue), typeof(int), typeof(CharacteristicItemView), null, BindingMode.OneTime);

	public CharacteristicItemView()
	{
		InitializeComponent();
	}
}