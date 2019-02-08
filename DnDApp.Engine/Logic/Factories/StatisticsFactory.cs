using DnDApp.Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDApp.Engine.Logic.Factories
{
    public class StatisticsFactory
    {
        //---------- Instance ----------//
        public BasicStatistic this[ string statCode ]
        {
            get => _statistics[ statCode ];
            protected set => _statistics[ statCode ] = value;
        }

        protected Dictionary<string , BasicStatistic> _statistics;

        protected StatisticsFactory()
        {
            _statistics = new Dictionary<string , BasicStatistic>();
        }

        public void Load( string filePath )
        {
            // TODO : Load in default statistics;
        }

        public bool Contains( string statCode ) =>
            _statistics.ContainsKey( statCode );

        public BasicStatistic CreateStatisticOrDefault( string statCode , bool resource = false )
        {
            BasicStatistic stat;
            if ( _statistics.Keys.Contains( statCode ) )
            {
                var def = _statistics[ statCode ];
                if ( def is ResourceStatistic )
                    stat = CreateStatistic( def );
                else
                    stat = new BasicStatistic( def.Name , def.Code , def.Description , def.Value );
            }
            else
            {
                stat = resource ?
                    new ResourceStatistic( statCode , statCode.ToUpper() , string.Empty ) :
                    new BasicStatistic( statCode , statCode.ToUpper() , string.Empty );
            }
            return stat;
        }

        protected ResourceStatistic CreateStatistic( BasicStatistic definition )
        {
            var def = definition as ResourceStatistic;
            return new ResourceStatistic( def.Name , def.Code , def.Description , def.Value , def.Current );
        }

        
        //---------- Static ----------//
        public static StatisticsFactory Instance
        {
            get
            {
                if ( _instance is null )
                    throw new NullReferenceException( "StatisticsFactory has not been initialized. It must be initialized before it can be used." );
                else
                    return _instance;
            }
        }

        private static StatisticsFactory _instance;

        public static void Initialize()
        {
            _instance = new StatisticsFactory();
        }
    }
}
