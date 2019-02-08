using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDApp.Engine.Interfaces;

namespace DnDApp.Engine.Logic.Systems
{
    public class Menu : ISystem
    {
        public Guid Id { get; private set; }
        public IMenuState State { get; protected set; }
        public int SavedState { get => _states.Count; }
        
        protected Stack<IMenuState> _states;

        public Menu(IMenuState state)
        {
            Id = Guid.NewGuid();
            State = state;

            _states = new Stack<IMenuState>();
            DnDApp.Instance.OnExit += Exit;
            DnDApp.Instance.OnUpdate += Update;
            // TODO : Create menu frontend
        }

        public void Push( IMenuState state )
        {
            _states.Push( State );
            State = state;
        }

        public void Pop()
        {
            if ( _states.Any() )
                State = _states.Pop();
            else
                throw new NullReferenceException( $"Menu {Id} does not have a state on it's stack. It cannot pop the current state." );
        }

        public void NewGame()
        {
            // TODO : Create a new game
        }

        public void LoadGame()
        {
            // TODO : Load a saved game
        }

        public void NewEditor()
        {
            // TODO : Open the editor with no game setup
        }

        public void LoadEditor()
        {
            // TODO : Open the editor with a saved game setup
        }

        public void Exit( int exitCode )
        {
            State.Exit( exitCode );
            Dispose();
        }

        public void Quit()
        {
            DnDApp.Instance.Exit( 0 );
        }

        public void Update( TimeSpan appTime )
        {
            State.Update( appTime );
        }

        public void Dispose()
        {
            DnDApp.Instance.OnExit -= Exit;
            DnDApp.Instance.OnUpdate -= Update;
            // Remove menu frontend
        }
    }
}
