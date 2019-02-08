using DnDApp.Engine.Interfaces;
using DnDApp.Engine.Logic.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDApp.Engine.Models
{
    public class Character
    {
        public string Name { get; set; }

        Dictionary<string , BasicStatistic> _statistics;
        Dictionary<string , IModifier<BasicStatistic>> _statModifiers;

        public Character( string name , params BasicStatistic[] statistics )
        {
            Name = name;

            _statModifiers = new Dictionary<string , IModifier<BasicStatistic>>();
            _statistics = new Dictionary<string , BasicStatistic>();
            foreach ( var s in statistics )
                _statistics.Add( s.Code.ToUpper() , s );

        }
        
        /// <param name="staticsticCodes">Item1 should be a statistic code, while Item2 describes if the parameter is a resource statistic</param>
        public Character( string name , params Tuple<string,bool>[] staticsticCodes )
        {
            Name = name;

            _statModifiers = new Dictionary<string , IModifier<BasicStatistic>>();
            _statistics = new Dictionary<string , BasicStatistic>();
            foreach ( var sc in staticsticCodes )
                _statistics.Add(sc.Item1 , StatisticsFactory.Instance.CreateStatisticOrDefault( sc.Item1 , sc.Item2 ) );
        }
    }
}
