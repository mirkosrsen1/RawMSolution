using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MSEngine;
using MSEngine.Controls;
using MSEngine.Core;
using System;

namespace RawMSSolution.GameScreens
{
    public class StartMenuScreens : BaseGameState
    {
        private PictureBox backgroundImage;
        private PictureBox arrowImage;
        private LinkLabel startGame;
        private LinkLabel loadGame;
        private LinkLabel exitGame;

        float maxItemWidth = 0f;

        public StartMenuScreens(Game game, GameStateManager manager) : base(game, manager)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            var content = Game.Content;

            backgroundImage = new PictureBox(content.Load<Texture2D>(@"Background\logo"), GameRef.ScreenRectangle);

            var arrowTexture = content.Load<Texture2D>(@"GUI\leftArrow");

            arrowImage = new PictureBox(arrowTexture, new Rectangle(0, 0, 25, 25));
            ControlManager.Add(arrowImage);

            startGame = new LinkLabel();
            startGame.Text = "Start Game";
            startGame.Size = startGame.SpriteFont.MeasureString(startGame.Text);
            startGame.Selected += menuItem_Selected;

            ControlManager.Add(startGame);

            loadGame = new LinkLabel();
            loadGame.Text = "Load Game";
            loadGame.Size = loadGame.SpriteFont.MeasureString(loadGame.Text);
            loadGame.Selected += menuItem_Selected;
            ControlManager.Add(loadGame);

            exitGame = new LinkLabel();
            exitGame.Text = "Quit";
            exitGame.Size = exitGame.SpriteFont.MeasureString(exitGame.Text);
            exitGame.Selected += menuItem_Selected;

            ControlManager.Add(exitGame);

            ControlManager.NextControl();

            ControlManager.FocusChange += new EventHandler(ControlManager_FocusChange);
            var position = new Vector2(350, 500);

            foreach(var c in ControlManager)
            {
                if(c.Size.X > maxItemWidth)
                {
                    maxItemWidth = c.Size.X;
                }

                c.Position = position;
                position.Y += c.Size.Y + 5f;
            }

            ControlManager_FocusChange(startGame, null);
        }

        private void ControlManager_FocusChange(object sender, EventArgs e)
        {
            var control = sender as Control;
            var position = new Vector2(control.Position.X - maxItemWidth/3, control.Position.Y);

            arrowImage.SetPosition(position);
        }

        private void menuItem_Selected(object sender, EventArgs e)
        {
            if(sender == startGame)
            {
                StateManager.PushState(Game1.GamePlayScreen);
            }
            else if(sender == loadGame)
            {
                StateManager.PushState(Game1.GamePlayScreen);
            }
            else if(sender == exitGame)
            {
                GameRef.Exit();
            }
        }

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, PlayerIndexInControl);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin();

            base.Draw(gameTime);

            ControlManager.Draw(GameRef.SpriteBatch);

            GameRef.SpriteBatch.End();
        }
    }
}
