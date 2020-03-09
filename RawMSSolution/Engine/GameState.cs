using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSEngine
{
    public abstract class GameState : DrawableGameComponent
    {
        public List<GameComponent> ChildComponents { get; private set; }

        public GameState Tag { get; private set; }

        protected GameStateManager StateManager;

        public GameState(Game game, GameStateManager manager) : base(game)
        {
            this.StateManager = manager;
            ChildComponents = new List<GameComponent>();
            Tag = this;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            for(int i=0; i< ChildComponents.Count; i++)
            {
                if(ChildComponents[i].Enabled)
                {
                    ChildComponents[i].Update(gameTime);
                }
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            DrawableGameComponent drawComponent;
            for(int i=0; i<ChildComponents.Count; i++)
            {
                drawComponent = ChildComponents[i] as DrawableGameComponent;

                if(drawComponent != null)
                {
                    if(drawComponent.Visible)
                    {
                        drawComponent.Draw(gameTime);
                    }
                }
            }
            base.Draw(gameTime);
        }

        internal protected virtual void StateChange(object sender, EventArgs e)
        {
            if(StateManager.CurrentState == Tag)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

        public virtual void Show()
        {
            Visible = true;
            Enabled = true;

            DrawableGameComponent drawComponent;
            for (int i=0; i< ChildComponents.Count;i++)
            {
                ChildComponents[i].Enabled = true;
                drawComponent = ChildComponents[i] as DrawableGameComponent;

                if (drawComponent != null)
                {
                    drawComponent.Visible = true;
                }
            }
        }

        public virtual void Hide()
        {
            Visible = false;
            Enabled = false;

            DrawableGameComponent drawComponent;
            for (int i = 0; i < ChildComponents.Count; i++)
            {
                ChildComponents[i].Enabled = false;
                drawComponent = ChildComponents[i] as DrawableGameComponent;

                if (drawComponent != null)
                {
                    drawComponent.Visible = false;
                }
            }
        }

    }
}
