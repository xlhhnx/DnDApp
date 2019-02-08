using DnDApp.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDApp.Engine.Models
{
    public class AddativeModifier : IModifier<BasicStatistic>
    {
        public BasicStatistic Target { get => _target; }
        public float Value { get => _value; }
        public bool Applied { get => _applied; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }

        protected BasicStatistic _target;
        protected int _value;
        protected bool _applied;

        public AddativeModifier( string name , string description , int value )
        {
            Name = name;
            Description = description;
            _value = value;
        }

        public void Apply( BasicStatistic target )
        {
            if ( !_applied )
            {
                _applied = true;
                _target = target;
                _target += _value;
            }
        }

        public void Reapply()
        {
            Remove();
            Apply( _target );
        }

        public void Remove()
        {
            if ( _applied )
            {
                _target -= _value;
                _applied = false;
            }
        }
    }
}
