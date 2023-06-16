using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace LoL_MVVM.Pages;

public partial class SkinDetailsPage : ContentPage
{
    public SkinVM SkinVM { get; set; }
    
    public SkinDetailsPage(SkinVM skinVM)
    {
        SkinVM = skinVM;
        InitializeComponent();
        BindingContext = SkinVM;
    }
}