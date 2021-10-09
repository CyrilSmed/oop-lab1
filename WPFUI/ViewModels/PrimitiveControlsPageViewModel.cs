using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFUI.ViewModels
{
    public class PrimitiveControlsPageViewModel : INotifyPropertyChanged
    {
        public PrimitiveControlsPageViewModel() 
        {
            Debug.WriteLine("Info: PrimitiveControlsPageViewModel instantiated");
        }

        private string _creativeColorOutput;
        public string CreativeColorOutput
        {
            get { return _creativeColorOutput; }
            set 
            { 
                _creativeColorOutput = value;
                RaisePropertyChanged();
            }
        }

        public enum Colors
        {
            Red,
            Green,
            Blue
        }

        private int curReactionIndex = 0;
        private List<string> positiveSelectionReactions = new List<string>
        { 
            "Good one",
            "I would have picked that one myself",
            "A very nice color",
            "Lovely indeed"
        };

        public void SelectColor(Colors color)
        {
            switch (color)
            {
                case Colors.Red:
                    CreativeColorOutput = positiveSelectionReactions[curReactionIndex];
                    curReactionIndex = (curReactionIndex + 1) % positiveSelectionReactions.Count;
                    break;
                case Colors.Blue:
                    CreativeColorOutput = positiveSelectionReactions[curReactionIndex];
                    curReactionIndex = (curReactionIndex + 1) % positiveSelectionReactions.Count;
                    break;
                case Colors.Green:
                    CreativeColorOutput = "Green is not a creative color";
                    break;
            }
        }


        #region WPF Binding
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
