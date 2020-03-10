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
    /// Draws tiles for each layer on screen.
    /// </summary>
    public class MSTileMap
    {
        private List<MSTileset> tilesets { get; set; }

        private List<MSMapLayer> mapLayers { get; set; }

        public MSTileMap(List<MSTileset> tilesets, List<MSMapLayer> mapLayers)
        {
            this.tilesets = tilesets;
            this.mapLayers = mapLayers;
        }

        public MSTileMap(MSTileset tileset, MSMapLayer layer)
        {
            this.tilesets = new List<MSTileset>() { tileset };
            this.mapLayers = new List<MSMapLayer>() { layer };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var destination = new Rectangle(0, 0, MSTileEngine.TileWidth, MSTileEngine.TileHeight);
            MSTile tile;

            foreach(var layer in this.mapLayers)
            {
                for(int y=0; y<layer.Height; y++)
                {
                    destination.Y = y * MSTileEngine.TileHeight;
                    for (int x=0; x<layer.Width; x++)
                    {
                        tile = layer.GetTile(x, y);

                        destination.X = x * MSTileEngine.TileWidth;

                        spriteBatch.Draw(
                            tilesets[tile.Tileset].Image,
                            destination,
                            tilesets[tile.Tileset].SourceRectangles[tile.TileIndex],
                            Color.White);
                    }
                }
            }
        }
    }
}
