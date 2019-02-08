using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDApp.Engine.Interfaces
{
    public interface IModifier<T>
    {
        T Target { get; }
        float Value { get; }
        bool Applied { get; }
        string Name { get; }
        string Description { get; }

        void Apply( T target );
        void Reapply();
        void Remove();
    }
}
