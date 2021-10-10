using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUI.ViewModels
{
    public class FancyControlsPageViewModel
    {
        public FancyControlsPageViewModel(IFancyControlsPageView view)
        {
            View = view;
            Debug.WriteLine("Info: FancyControlsPageViewModel instantiated");
        }
        public IFancyControlsPageView View { get; set; }
    }
}
