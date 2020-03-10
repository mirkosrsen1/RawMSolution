using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSEngine.Controls
{
    public abstract class Control
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public Vector2 Size { get; set; }
        public Vector2 Position { get; set; }
        public object Value { get; set; }
        public bool HasFocus { get; set; }
        public bool Enabled { get; set; }
        public bool Visible { get; set; }
        public bool TabStop { get; set; }
        public SpriteFont SpriteFont { get; set; }
        public Color Color { get; set; }
        public string Type { get; set; }

        public event EventHandler Selected;

        public Control()
        {
            Color = Color.White;
            Enabled = true;
            Visible = true;
            SpriteFont = ControlManager.SpriteFont;
        }


        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void HandleInput(PlayerIndex playerIndex);

        protected virtual void OnSelect(EventArgs e)
        {
            if(Selected != null)
            {
                Selected(this, e);
            }
        }
    }
}
