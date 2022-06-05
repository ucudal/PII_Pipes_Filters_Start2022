using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using CognitiveCoreUCU;
using System.Drawing;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ejercicio 1
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");
            PipeNull lastPipe = new PipeNull();
            PipeSerial pipeNegative = new PipeSerial(new FilterNegative(), lastPipe);
            PipeSerial pipeGreyscale = new PipeSerial(new FilterGreyscale(), pipeNegative);
            IPicture newPicture = pipeGreyscale.Send(picture);
            provider.SavePicture(newPicture, @"NewLuke.jpg");

            // Ejercicio 2
            PipeNull lastPipe2 = new PipeNull();
            PipeSerial pipeStep2 = new PipeSerial(new FilterSave(), lastPipe2);
            PipeSerial pipeNegative2 = new PipeSerial(new FilterNegative(), pipeStep2);
            PipeSerial pipeStep1 = new PipeSerial(new FilterSave(), pipeNegative2);
            PipeSerial pipeGreyscale2 = new PipeSerial(new FilterGreyscale(), pipeStep1);
            pipeGreyscale2.Send(picture);

            // Ejercicio 3
            PipeNull lastPipe3 = new PipeNull();
            PipeSerial pipe2 = new PipeSerial(new FilterTwitter(), lastPipe3);
            PipeSerial pipeSave2 = new PipeSerial(new FilterSave(), pipe2);
            PipeSerial pipeNegative3 = new PipeSerial(new FilterNegative(), pipeSave2);
            PipeSerial pipe1 = new PipeSerial(new FilterTwitter(), pipeNegative3);
            PipeSerial pipeSave1 = new PipeSerial(new FilterSave(), pipe1);
            PipeSerial pipeGreyscale3 = new PipeSerial(new FilterGreyscale(), pipeSave1);
            pipeGreyscale3.Send(picture);

            // Ejercicio 4
            FilterConditional conditional = new FilterConditional();
            PipeNull newPipeNull = new PipeNull();
            PipeSerial twitter1 = new PipeSerial(new FilterTwitter(), newPipeNull);
            PipeSerial negative1 = new PipeSerial(new FilterNegative(), newPipeNull);
            PipeConditional pipeconditional = new PipeConditional(conditional, negative1, twitter1, conditional.Indicator);
            PipeSerial niu = new PipeSerial(new FilterGreyscale(), pipeconditional);
            niu.Send(picture);
            
        }
    }
}
