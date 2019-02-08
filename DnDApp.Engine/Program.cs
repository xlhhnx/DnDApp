using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDApp.Engine
{
    class Program
    {
        static int Main(string[] args)
        {
            HandleArgs( args );
            DnDApp.Initialize();
            var exitCode = DnDApp.Instance.Run();
            return exitCode;
        }

        static void HandleArgs( string[] args )
        {
            // TODO : Handle Args
        }
    }
}
