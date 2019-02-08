using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDApp.Engine.Models
{
    public class BasicStatistic
    {
        //---------- Instance ----------//
        public virtual string Name { get; protected set; }
        public virtual string Code { get; protected set; }
        public virtual int Value { get; protected set; }
        public virtual string Description { get; protected set; }

        public BasicStatistic( string name , string code , string description , int value = 0 )
        {
            Name = name;
            Code = code;
            Description = description;
            Value = value;
        }

        //---------- Operators ----------//
        public static BasicStatistic operator +( BasicStatistic statistic , int change ) =>
            new BasicStatistic( statistic.Name , statistic.Code , statistic.Description , statistic.Value + change );
                
        public static BasicStatistic operator +( BasicStatistic statistic , float change ) =>
            new BasicStatistic( statistic.Name , statistic.Code , statistic.Description , (int)(statistic.Value + change) );

        public static BasicStatistic operator +( BasicStatistic statistic , double change ) =>
            new BasicStatistic( statistic.Name , statistic.Code , statistic.Description , (int)(statistic.Value + change) );
        
        public static BasicStatistic operator ++( BasicStatistic statistic ) =>
            new BasicStatistic( statistic.Name , statistic.Code , statistic.Description , statistic.Value + 1 );
        
        public static BasicStatistic operator -( BasicStatistic statistic , int change ) =>
            new BasicStatistic( statistic.Name , statistic.Code , statistic.Description , statistic.Value - change );
        
        public static BasicStatistic operator -( BasicStatistic statistic , float change ) =>
            new BasicStatistic( statistic.Name , statistic.Code , statistic.Description , (int)(statistic.Value - change) );
        
        public static BasicStatistic operator -( BasicStatistic statistic , double change ) =>
            new BasicStatistic( statistic.Name , statistic.Code , statistic.Description , (int)(statistic.Value - change) );
        
        public static BasicStatistic operator --( BasicStatistic statistic ) =>
            new BasicStatistic( statistic.Name , statistic.Code , statistic.Description , statistic.Value - 1 );
        
        public static BasicStatistic operator /( BasicStatistic statistic , int divisor ) =>
            new BasicStatistic( statistic.Name , statistic.Code , statistic.Description , statistic.Value / divisor );
        
        public static BasicStatistic operator /( BasicStatistic statistic , float divisor ) =>
            new BasicStatistic( statistic.Name , statistic.Code , statistic.Description , (int)(statistic.Value / divisor) );
        
        public static BasicStatistic operator /( BasicStatistic statistic , double divisor ) =>
            new BasicStatistic( statistic.Name , statistic.Code , statistic.Description , (int)(statistic.Value / divisor) );
        
        public static BasicStatistic operator *( BasicStatistic statistic , int factor ) =>
            new BasicStatistic( statistic.Name , statistic.Code , statistic.Description , statistic.Value * factor );
        
        public static BasicStatistic operator *( BasicStatistic statistic , float factor ) =>
            new BasicStatistic( statistic.Name , statistic.Code , statistic.Description , (int)(statistic.Value * factor) );
        
        public static BasicStatistic operator *( BasicStatistic statistic , double factor ) =>
            new BasicStatistic( statistic.Name , statistic.Code , statistic.Description , (int)(statistic.Value * factor) );
    }
}
