using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MSEngine;
using MSEngine.Controls;

namespace RawMSSolution.GameScreens
{
    public class TitleScreen : BaseGameState
    {
        Texture2D backgroundImage { get; set; }

        LinkLabel startLabel { get; set; }

        public TitleScreen(Game game, GameStateManager manager) : base(game, manager)
        {
        }

        protected override void LoadContent()
        {
            var content = GameRef.Content;

            backgroundImage = content.Load<Texture2D>(@"Background\Logo");
            
            base.LoadContent();

            startLabel = new LinkLabel();
            startLabel.Position = new Vector2(350, 600);
            startLabel.Text = "Press ENTER to begin";
            startLabel.Color = Color.White;
            startLabel.TabStop = true;
            startLabel.HasFocus = true;
            startLabel.Selected += new EventHandler(startLabel_Selected);

            ControlManager.Add(startLabel);
        }

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, PlayerIndex.One);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin();
            base.Draw(gameTime);

            GameRef.SpriteBatch.Draw(backgroundImage, GameRef.ScreenRectangle, Color.White);

            ControlManager.Draw(GameRef.SpriteBatch);

            GameRef.SpriteBatch.End();
        }

        private void startLabel_Selected(object sender, EventArgs e)
        {
            StateManager.PushState(GameRef.startMenuScreens);
        }
    }
}
