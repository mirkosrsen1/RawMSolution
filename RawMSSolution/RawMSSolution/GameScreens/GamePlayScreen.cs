using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MSEngine.Core;
using MSEngine.TileEngine;
using RawMSSolution.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawMSSolution.GameScreens
{
    public class GamePlayScreen : BaseGameState
    {
        MSTileEngine tileEngine = new MSTileEngine(32, 32);
        MSTileset tileset;
        MSTileMap map;

        public GamePlayScreen(BaseGame game, GameStateManager manager)
            :base(game, manager)
        {
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Texture2D tilesetTexture = Game.Content.Load<Texture2D>(@"Tilesets\tilesetTest");
            tileset = new MSTileset(tilesetTexture, 32, 32, 16, 16);

            var layer = new MSMapLayer(40, 40);

            for(int y = 0; y< layer.Height; y++)
            {
                for(int x =0; x<layer.Width; x++)
                {
                    var tile = new MSTile(0, 0);

                    layer.SetTile(x, y, tile);
                }
            }
            map = new MSTileMap(tileset, layer);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            // Parameter Explanation
            // SpriteSortMode: gives the way sprites are sorted. As soon as image is created it is send to graphic card (doesn't wait for end)
            // BlendState : set to alpha blending because we dont want transparency
            // Defines way textures are mapped to output. Point clamp sets sampling to points of the texture (keeps blending when scaled)
            // Matrix : defines scaling scrolling rotation etc of the objects.
            GameRef.SpriteBatch.Begin(
                SpriteSortMode.Immediate,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                null,
                null,
                null,
                Matrix.Identity);

            map.Draw(GameRef.SpriteBatch);

            base.Draw(gameTime);

            GameRef.SpriteBatch.End();
        }
    }
}
