using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoL_MVVM.ViewModel;

namespace LoL_MVVM.Pages;

public partial class SkinEditPage : ContentPage
{
    public SkinEditVM SkinEditVM { get; set; }
    
    public SkinEditPage(SkinEditVM skinEditVM)
    {
        SkinEditVM = skinEditVM;
        InitializeComponent();
        BindingContext = SkinEditVM;
    }
}