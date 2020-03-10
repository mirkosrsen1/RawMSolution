namespace MSEngine.TileEngine
{
    /// <summary>
    /// Holds index of tile from <see cref="MSTileset.SourceRectangles"/> and what specific image does it target <see cref="MSTile.Tileset"/>.
    /// </summary>
    public class MSTile
    {
        public int TileIndex { get; private set; }

        public int Tileset { get; private set; }

        public MSTile(int tileIndex, int tileset)
        {
            this.TileIndex = tileIndex;
            this.Tileset = tileset;
        }
    }
}
