using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSEngine.TileEngine
{
    /// <summary>
    /// Holds source to all tile images/ textures.
    /// </summary>
    public class MSTileset
    {
        public Texture2D Image { get; private set; }

        public int TilesCountX { get; private set; }

        public int TilesCountY { get; private set; }

        public int TilesWidthInPixels { get; private set; }

        public int TilesHeightInPixels { get; private set; }

        private Rectangle[] sourceRectangles;
        public Rectangle[] SourceRectangles { get { return (Rectangle[])sourceRectangles.Clone(); } }

        public MSTileset(Texture2D image, int tilesCountX, int tilesCountY, int tilesWidthInPixels, int tilesHeightInPixels)
        {
            this.Image = image;
            this.TilesCountX = tilesCountX;
            this.TilesCountY = tilesCountY;
            this.TilesWidthInPixels = tilesWidthInPixels;
            this.TilesHeightInPixels = tilesHeightInPixels;

            var tiles = TilesCountY * TilesCountX;

            sourceRectangles = new Rectangle[tiles];

            var tile = 0;

            for(int y=0; y< TilesCountY; y++)
            {
                for(int x=0; x< TilesCountX; x++)
                {
                    sourceRectangles[tile] = new Rectangle(x * TilesWidthInPixels, y * TilesHeightInPixels, tilesWidthInPixels, TilesHeightInPixels);
                    tile++;
                }
            }
        }
    }
}
