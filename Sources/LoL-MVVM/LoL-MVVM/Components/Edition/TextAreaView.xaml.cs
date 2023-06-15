using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoL_MVVM.Components.Edition;

public partial class TextAreaView : ContentView
{
    public string TextValue
    {
        get => (string) GetValue(TextValueProperty);
        set => SetValue(TextValueProperty, value);
    }
    
    public static readonly BindableProperty TextValueProperty =
        BindableProperty.Create(nameof(TextValue), typeof(string), typeof(ReadOnlyTextAreaView), null, BindingMode.TwoWay);

    public string Hint
    {
        get => (string)GetValue(HintProperty);
        set => SetValue(HintProperty, value);
    }

    public static readonly BindableProperty HintProperty =
        BindableProperty.Create(nameof(Hint), typeof(string), typeof(ReadOnlyTextAreaView), null, BindingMode.TwoWay);


    public TextAreaView()
    {
        InitializeComponent();
    }
}