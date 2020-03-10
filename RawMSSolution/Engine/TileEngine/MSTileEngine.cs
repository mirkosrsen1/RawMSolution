using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSEngine.TileEngine
{
    /// <summary>
    /// Holds data about width and height of single tile.
    /// </summary>
    public class MSTileEngine
    {
        public static int TileWidth { get; private set; }

        public static int TileHeight { get; private set; }

        public MSTileEngine(int tileWidth, int tileHeight)
        {
            TileWidth = tileWidth;
            TileHeight = tileHeight;
        }

        public static Point VectorToCell(Vector2 position)
        {
            return new Point((int)position.X / TileWidth, (int)position.Y / TileHeight);
        }
    }
}
