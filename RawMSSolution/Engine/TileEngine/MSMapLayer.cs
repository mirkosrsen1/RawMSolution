using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSEngine.TileEngine
{
    /// <summary>
    /// Defines how big map is and what tiles are used on what position.
    /// </summary>
    public class MSMapLayer
    {
        private MSTile[,] map { get; set; }

        public int Width
        {
            get { return map.GetLength(1); }
        }
        public int Height
        {
            get { return map.GetLength(0); }
        }
        public MSMapLayer(MSTile[,] map)
        {
            this.map = (MSTile[,])map.Clone();
        }

        public MSMapLayer(int width, int height)
        {
            map = new MSTile[height, width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    map[y, x] = new MSTile(0, 0);
                }
            }
        }

        public MSTile GetTile(int x, int y)
        {
            return map[x, y];
        }

        public void SetTile(int x, int y, MSTile tile)
        {
            map[y, x] = tile;
        }

        public void SetTile(int x, int y, int tileIndex, int tileset)
        {
            map[y, x] = new MSTile(tileIndex, tileset);
        }
    }
}
