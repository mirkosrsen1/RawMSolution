using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSEngine.Controls
{
    public class PictureBox : Control
    {
        public Texture2D Image { get; private set; }

        /// <summary>
        /// Gets original size of the <see cref="Image"/>.
        /// </summary>
        public Rectangle SourceRectangle { get; private set; }

        /// <summary>
        /// Gets destination size of <see cref="Image"/>.
        /// </summary>
        public Rectangle DestinationRectangle { get; private set; }

        public PictureBox(Texture2D image, Rectangle destination)
        {
            this.Image = image;
            this.DestinationRectangle = destination;
            this.SourceRectangle = new Rectangle(0, 0, image.Width, image.Height);
            Color = Color.White;
        }

        public PictureBox(Texture2D image, Rectangle destination, Rectangle source)
        {
            this.Image = image;
            this.DestinationRectangle = destination;
            this.SourceRectangle = source;
            Color = Color.White;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Image, DestinationRectangle, SourceRectangle, Color);
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {
        }

        public override void Update(GameTime gameTime)
        {
        }

        /// <summary>
        /// Sets position of the <see cref="DestinationRectangle"/>
        /// </summary>
        /// <param name="newPosition">New position to set.</param>
        public void SetPosition(Vector2 newPosition)
        {
            DestinationRectangle = new Rectangle((int)newPosition.X, (int)newPosition.Y, DestinationRectangle.Width, DestinationRectangle.Height);
        }
    }
}
