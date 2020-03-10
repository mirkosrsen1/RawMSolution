using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MSEngine;
using MSEngine.Controls;
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

        protected ControlManager ControlManager;

        protected PlayerIndex PlayerIndexInControl;

        public BaseGameState(Game game, GameStateManager manager) : base(game, manager)
        {
            this.GameRef = (Game1)game;

            PlayerIndexInControl = PlayerIndex.One;
        }

        protected override void LoadContent()
        {
            var content = Game.Content;

            SpriteFont menuFont = content.Load<SpriteFont>(@"Fonts\ControlFont");
            ControlManager = new ControlManager(menuFont);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
