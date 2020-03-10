using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MSEngine;

namespace RawMSSolution.GameScreens
{
    public class StartMenuScreens : BaseGameState
    {
        public StartMenuScreens(Game game, GameStateManager manager) : base(game, manager)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if(InputHandler.KeyReleased(Keys.Escape))
            {
                Game.Exit();
            }

            base.Draw(gameTime);
        }
    }
}
