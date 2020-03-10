using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MSEngine.Controls;
using RawMSSolution.Core;

namespace MSEngine.Core
{
    public abstract class BaseGameState : GameState
    {
        protected BaseGame GameRef;

        protected ControlManager ControlManager;

        protected PlayerIndex PlayerIndexInControl;

        public BaseGameState(Game game, GameStateManager manager) : base(game, manager)
        {
            this.GameRef = (BaseGame)game;

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
