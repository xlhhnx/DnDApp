using DnDApp.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDApp.Engine.Logic.Systems
{
    public class Game : ISystem
    {
        //---------- Instance ----------//
        public Guid Id { get; private set; }
        public IGameState State { get; set; }

        protected Stack<IGameState> _states;

        public Game(IGameState state)
        {
            Id = Guid.NewGuid();
            State = state;

            _states = new Stack<IGameState>();
            DnDApp.Instance.OnExit += Exit;
            DnDApp.Instance.OnUpdate += Update;
            // TODO : Create game frontend
        }

        public void Push( IGameState state )
        {
            _states.Push( State );
            State = state;
        }

        public void Pop()
        {
            if ( _states.Any() )
                State = _states.Pop();
            else
                throw new NullReferenceException( $"Game {Id} does not have a state on it's stack. It cannot pop the current state." );
        }

        public void Update( TimeSpan appTime )
        {
            State.Update( appTime );
        }

        public void SaveGame()
        {
            // TODO : Save the current game state
        }

        public void Exit( int exitCode )
        {
            State.Exit( exitCode );
            Dispose();
        }

        public void ReturnToMenu()
        {
            // TODO : Return to the Main Menu
        }
        public void Quit()
        {
            // TODO : Ask to save game
            DnDApp.Instance.Exit( 0 );
        }

        public void Dispose()
        {
            DnDApp.Instance.OnExit -= Exit;
            DnDApp.Instance.OnUpdate -= Update;
            // TODO : Remove game frontend
        }

        //---------- Static ----------//
        public static Game LoadGame( string filePath )
        {
            // TODO : Load saved game
            return null;
        }
    }
}
