using Microsoft.Xna.Framework;
using MSEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawMSSolution.GameScreens
{
    public abstract class BaseGameState : GameState
    {
        protected Game1 GameRef;

        public BaseGameState(Game game, GameStateManager manager) : base(game, manager)
        {
            this.GameRef = (Game1)game;
        }
    }
}
