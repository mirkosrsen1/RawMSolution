using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MSEngine;

namespace RawMSSolution.GameScreens
{
    public class TitleScreen : BaseGameState
    {
        Texture2D backgroundImage { get; set; }

        public TitleScreen(Game game, GameStateManager manager) : base(game, manager)
        {
        }

        protected override void LoadContent()
        {
            var content = GameRef.Content;

            backgroundImage = content.Load<Texture2D>(@"Background\Logo");
            
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin();
            base.Draw(gameTime);

            GameRef.SpriteBatch.Draw(backgroundImage, GameRef.ScreenRectangle, Color.White);

            GameRef.SpriteBatch.End();
        }
    }
}
