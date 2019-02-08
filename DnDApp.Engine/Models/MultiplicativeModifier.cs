using DnDApp.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDApp.Engine.Models
{
    class MultiplicativeModifier : IModifier<BasicStatistic>
    {
        public BasicStatistic Target { get => _target; }
        public float Value { get => _value; }
        public bool Applied { get => _applied; }
        public int AppliedValue { get => _appliedValue; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }

        protected BasicStatistic _target;
        protected float _value;
        protected bool _applied;
        protected int _appliedValue;

        public MultiplicativeModifier( string name , string description , float value )
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
                var initialValue = _target is ResourceStatistic ? 
                    (_target as ResourceStatistic).Current : 
                    _target.Value;
                _target *= _value;
                _appliedValue = _target is ResourceStatistic ?
                    (_target as ResourceStatistic).Current - initialValue :
                    _target.Value - initialValue;
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
                _target -= _appliedValue;
                _applied = false;
            }
        }
    }
}
