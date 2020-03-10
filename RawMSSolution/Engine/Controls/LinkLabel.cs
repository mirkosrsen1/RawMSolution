using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MSEngine.Controls
{
    public class LinkLabel : Control
    {
        public Color selectedColor { get; private set; }

        public LinkLabel()
        {
            TabStop = true;
            HasFocus = false;
            Position = Vector2.Zero;

            selectedColor = Color.Red;
        }

        public LinkLabel(Color selecColor)
        {
            TabStop = true;
            HasFocus = false;
            Position = Vector2.Zero;

            Color selectedColor = selecColor;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if(this.HasFocus)
            {
                spriteBatch.DrawString(SpriteFont, Text, this.Position, selectedColor);
            }
            else
            {
                spriteBatch.DrawString(SpriteFont, Text, Position, Color);
            }
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {
            if (!HasFocus)
                return;

            if(InputHandler.KeyReleased(Keys.Enter)
                || InputHandler.ButtonReleased(Buttons.A, playerIndex))
            {
                base.OnSelect(null);
            }
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
