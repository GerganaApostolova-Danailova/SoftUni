using System;

namespace MXGP
{
    using Models.Motorcycles;
    using MXGP.Core.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var engine = new IEngine();
            engine.Run();
        }
    }
}
