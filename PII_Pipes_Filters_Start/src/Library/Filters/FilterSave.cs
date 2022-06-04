namespace CompAndDel.Filters
{
    public class FilterSave : IFilter
    {
        private static int counter = 0;

        public static int Counter
        {
            get
            { 
                return counter;
            }
        }
        
        public IPicture Filter(IPicture image)
        {
            counter++;
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image, $@"LukeStep{counter}.jpg");
            return image;
        }
    }
}