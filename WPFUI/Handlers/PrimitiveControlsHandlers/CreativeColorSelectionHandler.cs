using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUI.Handlers.PrimitiveControlsHandlers
{
    public class CreativeColorSelectionHandler
    {
        public CreativeColorSelectionHandler()
        {
            Random rand = new Random();
            int curReactionIndex = rand.Next() % positiveSelectionReactions.Count;
        }
        public Color SelectedColor { get; set; }
        public enum Color
        {
            Undefined,
            Red,
            Green,
            Blue
        }

        private int curReactionIndex;
        private List<string> positiveSelectionReactions = new List<string>
        {
            "Good one",
            "Sharp one",
            "What a nice color",
            "Lovely color",
            "Vibrant indeed"
        };

        public string SelectColorReturnResponse(Color color)
        {
            switch (color)
            {
                case Color.Red:
                    SelectedColor = Color.Red;
                    curReactionIndex = (curReactionIndex + 1) % positiveSelectionReactions.Count;
                    return positiveSelectionReactions[curReactionIndex];

                case Color.Blue:
                    SelectedColor = Color.Blue;
                    curReactionIndex = (curReactionIndex + 1) % positiveSelectionReactions.Count;
                    return positiveSelectionReactions[curReactionIndex];

                case Color.Green:
                    return "Green is not a creative color";

                default:
                    return "";
            }
        }
    }
}
