using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSEngine.Controls
{
    public class ControlManager : List<Control>
    {
        public static SpriteFont SpriteFont { get; private set; }

        private int selectedControl { get; set; }

        public event EventHandler FocusChange;

        public ControlManager(SpriteFont spriteFont)
        {
            SpriteFont = spriteFont;
        }

        public ControlManager(SpriteFont spriteFont, int capacity)
            : base(capacity)
        {
            SpriteFont = SpriteFont;
        }

        public ControlManager(SpriteFont spriteFont, IEnumerable<Control> collection)
            : base(collection)
        {
            SpriteFont = spriteFont;
        }

        public void Update(GameTime gameTime, PlayerIndex playerIndex)
        {
            if (Count == 0)
            {
                return;
            }

            foreach (var c in this)
            {
                if (c.Enabled)
                {
                    c.Update(gameTime);
                }
                if (c.HasFocus)
                {
                    c.HandleInput(playerIndex);
                }
            }

            if (InputHandler.ButtonPressed(Buttons.LeftThumbstickUp, playerIndex)
                || InputHandler.ButtonPressed(Buttons.DPadUp, playerIndex)
                || InputHandler.KeyPressed(Keys.Up))
            {
                PreviousControl();
            }

            if (InputHandler.ButtonPressed(Buttons.LeftThumbstickDown, playerIndex)
            || InputHandler.ButtonPressed(Buttons.DPadDown, playerIndex)
            || InputHandler.KeyPressed(Keys.Down))
            {
                NextControl();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var c in this)
            {
                if (c.Visible)
                {
                    c.Draw(spriteBatch);
                }
            }
        }

        public void NextControl()
        {
            if (Count == 0)
            {
                return;
            }

            var currentControl = selectedControl;

            this[selectedControl].HasFocus = false;

            do
            {
                selectedControl++;

                if (selectedControl == Count)
                {
                    selectedControl = 0;
                }

                if (this[selectedControl].TabStop && this[selectedControl].Enabled)
                {
                    if(FocusChange != null)
                    {
                        FocusChange(this[selectedControl], null);
                    }

                    break;
                }

            } while (currentControl != selectedControl);

            this[selectedControl].HasFocus = true;
        }

        public void PreviousControl()
        {
            if (Count == 0)
            {
                return;
            }

            var currentControl = selectedControl;

            this[selectedControl].HasFocus = false;

            do
            {
                selectedControl--;

                if (selectedControl < 0)
                {
                    selectedControl = this.Count-1;
                }

                if (this[selectedControl].TabStop && this[selectedControl].Enabled)
                {
                    if(FocusChange != null)
                    {
                        FocusChange(this[selectedControl], null);
                    }

                    break;
                }

            } while (currentControl != selectedControl);

            this[selectedControl].HasFocus = true;
        }
    }
}
