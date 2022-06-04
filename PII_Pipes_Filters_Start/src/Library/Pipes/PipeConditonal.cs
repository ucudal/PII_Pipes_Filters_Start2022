using CompAndDel.Filters;

namespace CompAndDel.Pipes
{
    public class PipeConditional : IPipe
    {
        private bool indicator;
        private IFilter filter;
        private IPipe next2Pipe;
        private IPipe nextPipe;
        public PipeConditional(IFilter filter, IPipe nextPipe, IPipe next2Pipe, bool indicator)
        {
            this.indicator = indicator;
            this.filter = filter;
            this.next2Pipe = next2Pipe;
            this.nextPipe = nextPipe;
        }
        public IPicture Send(IPicture picture)
        {
            if (this.indicator)
            {
                return next2Pipe.Send(picture);
            }
            else
            {
                return this.nextPipe.Send(picture);
            }
        }
    }
}
