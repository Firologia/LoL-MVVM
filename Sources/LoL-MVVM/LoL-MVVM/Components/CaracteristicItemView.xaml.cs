namespace LoL_MVVM.Components;

public partial class CaracteristicItemView : ContentView
{
	public string CaracteristicName { 
		get => (string) GetValue(CaracteristicNameProperty);
		set => SetValue(CaracteristicNameProperty, value);
	}

	public static readonly BindableProperty CaracteristicNameProperty =
		BindableProperty.Create(nameof(CaracteristicName), typeof(string), typeof(CaracteristicItemView), null, BindingMode.OneTime);

	public int CaracteristicValue { 
		get => (int) GetValue(CaracteristicValueProperty);
		set => SetValue(CaracteristicValueProperty, value);
	}

    public static readonly BindableProperty CaracteristicValueProperty =
    BindableProperty.Create(nameof(CaracteristicValue), typeof(int), typeof(CaracteristicItemView), null, BindingMode.OneTime);

    public CaracteristicItemView()
	{
		InitializeComponent();
	}
}