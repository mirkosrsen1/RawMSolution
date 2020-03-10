using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSEngine.Core
{
    public class GameStateManager : GameComponent
    {
        /// <summary>
        /// Event on state change.
        /// </summary>
        public event EventHandler OnStateChange;

        /// <summary>
        /// Collection of all game states.
        /// </summary>
        Stack<GameState> gameStates { get; set; }

        /// <summary>
        /// Defines magin number that will be used to set priority of Game States
        /// </summary>
        private const int startDrawOrder = 5000;

        /// <summary>
        /// Every new state will have bigger priority than the last one.
        /// </summary>
        private const int drawOrderInc = 100;

        /// <summary>
        /// Current state priority
        /// </summary>
        int drawOrder;

        /// <summary>
        /// Returns current active state.
        /// </summary>
        public GameState CurrentState
        {
            get { return this.gameStates.Peek(); }
        }

        /// <summary>
        /// Initializes new instance of <see cref="GameStateManager"/>.
        /// </summary>
        /// <param name="game">The current game.</param>
        public GameStateManager(Game game)
            : base(game)
        {
            this.gameStates = new Stack<GameState>();
            this.drawOrder = startDrawOrder;
        }

        /// <inheritdoc />
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <inheritdoc />
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Pops the state at the top of the stack. Adjustes <see cref="drawOrder"/> and triggers <see cref="OnStateChange"/> event
        /// </summary>
        public void PopState()
        {
            if(gameStates.Count > 0)
            {
                RemoveState();
                drawOrder -= drawOrderInc;

                if(OnStateChange != null)
                {
                    OnStateChange(this, null);
                }
            }
        }

        /// <summary>
        /// Removes state from the <see cref="gameStates"/>.
        /// </summary>
        private void RemoveState()
        {
            var state = gameStates.Pop();
            OnStateChange -= state.StateChange;
            Game.Components.Remove(state);
        }

        /// <summary>
        /// Pushes new state to the <see cref="gameStates"/>.
        /// </summary>
        /// <param name="newState">The new state.</param>
        public void PushState(GameState newState)
        {
            drawOrder = +drawOrderInc;
            newState.DrawOrder += drawOrder;

            AddState(newState);

            if(OnStateChange != null)
            {
                OnStateChange(this, null);
            }
        }

        /// <summary>
        /// Adds new state to <see cref="gameStates"/> and adds states event handler to <see cref="OnStateChange"/>.
        /// </summary>
        /// <param name="newState">The new state.</param>
        private void AddState(GameState newState)
        {
            gameStates.Push(newState);
            Game.Components.Add(newState);
            OnStateChange += newState.StateChange;
        }

        /// <summary>
        /// Removes all states then ads new state to it.
        /// </summary>
        /// <param name="newState">State to be added.</param>
        public void ChangeState(GameState newState)
        {
            while(gameStates.Count > 0)
            {
                RemoveState();
            }

            newState.DrawOrder = startDrawOrder;
            drawOrder = startDrawOrder;

            AddState(newState);

            if(OnStateChange != null)
            {
                OnStateChange(this, null);
            }
        }
    }
}
