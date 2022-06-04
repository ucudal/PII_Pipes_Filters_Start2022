using CognitiveCoreUCU;
using System.Drawing;

namespace CompAndDel.Filters
{
    public class FilterConditional : IFilter
    {
        private CognitiveFace cognitiveFace = new CognitiveFace(true, Color.GreenYellow);
        private static int counter = 0;
        private bool indicator;
        public bool Indicator
        {
            get
            {
                return this.indicator;
            }
        }
        public IPicture Filter(IPicture image)
        {
            counter++;
            cognitiveFace.Recognize($@"..\..\Program\LukeStep{counter}.jpg");
            this.indicator = cognitiveFace.FaceFound;
            return image;
        }   
    }
}