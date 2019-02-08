using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDApp.Engine.Models
{
    public class ResourceStatistic : BasicStatistic
    {
        //---------- Instance ----------//
        public int Current { get; protected set; }

        public ResourceStatistic( string name , string code , string description , int value = 0 , int startingValue = int.MinValue ) 
            : base( name , description , code , value )
        {
            if ( startingValue == int.MinValue )
                Current = Value;
            else
                Current = startingValue;
        }

        //---------- Operators ----------//
        public static ResourceStatistic operator +( ResourceStatistic statistic , int change ) =>
            new ResourceStatistic( statistic.Name , statistic.Code , statistic.Description ,  statistic.Value , statistic.Current + change );
        
        public static ResourceStatistic operator +( ResourceStatistic statistic , float change ) =>
            new ResourceStatistic( statistic.Name , statistic.Code , statistic.Description ,  statistic.Value , (int)(statistic.Current + change) );
        
        public static ResourceStatistic operator +( ResourceStatistic statistic , double change ) =>
            new ResourceStatistic( statistic.Name , statistic.Code , statistic.Description ,  statistic.Value , (int)(statistic.Current + change) );
        
        public static ResourceStatistic operator ++( ResourceStatistic statistic ) =>
            new ResourceStatistic( statistic.Name , statistic.Code , statistic.Description ,  statistic.Value , statistic.Current + 1 );
        
        public static ResourceStatistic operator -( ResourceStatistic statistic , int change ) =>
            new ResourceStatistic( statistic.Name , statistic.Code , statistic.Description ,  statistic.Value , statistic.Current - change );
        
        public static ResourceStatistic operator -( ResourceStatistic statistic , float change ) =>
            new ResourceStatistic( statistic.Name , statistic.Code , statistic.Description ,  statistic.Value , (int)(statistic.Current - change) );
        
        public static ResourceStatistic operator -( ResourceStatistic statistic , double change ) =>
            new ResourceStatistic( statistic.Name , statistic.Code , statistic.Description ,  statistic.Value , (int)(statistic.Current - change) );
        
        public static ResourceStatistic operator --( ResourceStatistic statistic ) =>
            new ResourceStatistic( statistic.Name , statistic.Code , statistic.Description ,  statistic.Value , statistic.Current - 1 );
        
        public static ResourceStatistic operator /( ResourceStatistic statistic , int divisor ) =>
            new ResourceStatistic( statistic.Name , statistic.Code , statistic.Description ,  statistic.Value , statistic.Current / divisor );
        
        public static ResourceStatistic operator /( ResourceStatistic statistic , float divisor ) =>
            new ResourceStatistic( statistic.Name , statistic.Code , statistic.Description ,  statistic.Value , (int)(statistic.Current / divisor) );
        
        public static ResourceStatistic operator /( ResourceStatistic statistic , double divisor ) =>
            new ResourceStatistic( statistic.Name , statistic.Code , statistic.Description ,  statistic.Value , (int)(statistic.Current / divisor) );
        
        public static ResourceStatistic operator *( ResourceStatistic statistic , int factor ) =>
            new ResourceStatistic( statistic.Name , statistic.Code , statistic.Description ,  statistic.Value , statistic.Current * factor );
        
        public static ResourceStatistic operator *( ResourceStatistic statistic , float factor ) =>
            new ResourceStatistic( statistic.Name , statistic.Code , statistic.Description ,  statistic.Value , (int)(statistic.Current * factor) );

        public static ResourceStatistic operator *( ResourceStatistic statistic , double factor ) =>
            new ResourceStatistic( statistic.Name , statistic.Code , statistic.Description ,  statistic.Value , (int)(statistic.Current * factor) );
    }
}
