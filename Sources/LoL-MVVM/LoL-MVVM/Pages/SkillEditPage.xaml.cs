using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoL_MVVM.ViewModel;

namespace LoL_MVVM.Pages;

public partial class SkillEditPage : ContentPage
{
    public SkillEditVM SkillEditVM { get; set; }
    public SkillEditPage(SkillEditVM skillEditVM)
    {
        SkillEditVM = skillEditVM;
        InitializeComponent();
        BindingContext = skillEditVM;
    }
}