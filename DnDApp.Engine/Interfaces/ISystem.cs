using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDApp.Engine.Interfaces
{
    public interface ISystem : IDisposable
    {
        Guid Id { get; }

        void Update( TimeSpan appTime );
        void Exit( int exitCode );
    }
}
