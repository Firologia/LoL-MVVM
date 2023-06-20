using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoL_MVVM.ViewModel;
using ViewModel;

namespace LoL_MVVM.Pages;

public partial class SkinDetailsPage : ContentPage
{
    public ApplicationVM ApplicationVM { get;} = (Application.Current as App).ApplicationVM;
    public SkinVM SkinVM { get; }
    
    public SkinDetailsPage(SkinVM skinVM)
    {
        SkinVM = skinVM;
        InitializeComponent();
        BindingContext = SkinVM;
    }
}