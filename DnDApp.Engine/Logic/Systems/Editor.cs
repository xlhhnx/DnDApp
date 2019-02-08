using DnDApp.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDApp.Engine.Logic.Systems
{
    public class Editor : ISystem
    {
        //---------- Instance ----------//
        public Guid Id { get; private set; }
        public IEditorState State { get; set; }

        protected Stack<IEditorState> _states;

        public Editor()
        {
            Id = Guid.NewGuid();

            _states = new Stack<IEditorState>();
            DnDApp.Instance.OnExit += Exit;
            DnDApp.Instance.OnUpdate += Update;
            // TODO : Create editor frontend
        }

        public void Push( IEditorState state )
        {
            _states.Push( State );
            State = state;
        }

        public void Pop()
        {
            if ( _states.Any() )
                State = _states.Pop();
            else
                throw new NullReferenceException( $"Editor {Id} does not have a state on it's stack. It cannot pop the current state." );
        }

        public void Dispose()
        {
            DnDApp.Instance.OnExit -= Exit;
            DnDApp.Instance.OnUpdate -= Update;
            // TODO : Remove editor frontend
        }

        public void Exit( int exitCode )
        {
            State.Exit( exitCode );
            Dispose();
        }

        public void Update( TimeSpan appTime )
        {
            State.Update( appTime );
        }

        public void ReturnToMenu()
        {
            // TODO : Return to the Main Menu
        }

        public void Quit()
        {
            // TODO : Ask to save game setup
            DnDApp.Instance.Exit( 0 );
        }

        //---------- Static ----------//
        public static Editor LoadEditor( string filePath )
        {
            // TODO : Load saved game setup
            return null;
        }
    }
}
