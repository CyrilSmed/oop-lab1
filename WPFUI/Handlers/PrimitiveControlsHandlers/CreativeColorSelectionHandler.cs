using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFUI.Handlers.PrimitiveControlsHandlers
{
    public class CreativeColorSelectionHandler
    {
        public Color SelectedColor { get; set; }
        public enum Color
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
            "What a nice color",
            "A lovely color indeed"
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
