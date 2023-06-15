namespace LoL_MVVM.Components.Edition;

public partial class CaracteristicEditItemView : ContentView
{

    public string Name
    {
        get => (string)GetValue(NameProperty);
        set => SetValue(NameProperty, value);
    }

    public static readonly BindableProperty NameProperty =
        BindableProperty.Create(nameof(Name), typeof(string), typeof(ReadOnlyTextAreaView), null, BindingMode.TwoWay);

    public int Value
    {
        get => (int)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public static readonly BindableProperty ValueProperty =
        BindableProperty.Create(nameof(Value), typeof(int), typeof(ReadOnlyTextAreaView),0,BindingMode.TwoWay);


    public CaracteristicEditItemView()
	{
		InitializeComponent();
	}
}