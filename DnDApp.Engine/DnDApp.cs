using DnDApp.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDApp.Engine
{
    public class DnDApp
    {
        //---------- Instance ----------//
        public event Action OnRun;
        public event Action<TimeSpan> OnUpdate;
        public event Action<int> OnExit;

        protected DateTime _lastTime;
        protected TimeSpan _appTime;
        protected bool _exit;
        protected int _exitCode;

        protected DnDApp()
        {
            // Initialize Events
            OnRun = delegate
            {
                StartTime();
            };
            OnUpdate = delegate
            { };
            OnExit = delegate
            { };
        }

        public int Run()
        {
            OnRun();
            while ( !_exit )
            {
                // Update AppTime
                var now = DateTime.Now;
                _appTime += new TimeSpan( now.Ticks - _lastTime.Ticks );
                _lastTime = now;

                // Do Stuff
                OnUpdate( _appTime );
            }
            OnExit(_exitCode);
            return _exitCode;
        }

        public void Exit( int exitCode = 0 , bool force = false )
        {
            _exitCode = exitCode;
            _exit = true;

            if ( force )
            {
                OnUpdate = delegate
                { };
            }
        }

        protected void StartTime()
        {
            _appTime = new TimeSpan();
            _lastTime = DateTime.Now;
        }
        
        //---------- Static ----------//
        public static DnDApp Instance
        {
            get
            {
                if ( _instance is null )
                    throw new NullReferenceException( "DnDApp has not been initialized. It must be initialized before it can be used." );
                else
                    return _instance;
            }
            protected set => _instance = value;
        }

        private static DnDApp _instance;

        public static void Initialize()
        {
            Instance = new DnDApp();
        }
    }
}
