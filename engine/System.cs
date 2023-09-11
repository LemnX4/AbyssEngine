using Abyss;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace Abyss
{
    public abstract class System
    {
        public abstract bool Requirements(Entity e);
        //public override bool Requirements(Entity e) => e.HasComponent<Example>()

        public List<Entity> EntityBucket { get; set; } = new();

        public System() 
        {
            MyGame.Systems.Add(this);
        }

        public void Update(double deltaTime)
        {
            foreach (Entity entity in EntityBucket)
                UpdateEntity(entity, deltaTime);
        }

        public virtual void UpdateEntity(Entity entity, double deltaTime)
        {

        }
        //public override void UpdateEntity(Entity entity, double deltaTime)

        public void Render(SpriteBatch spriteBatch)
        {
            foreach (Entity entity in EntityBucket)
                RenderEntity(entity, spriteBatch);
        }

        public virtual void RenderEntity(Entity entity, SpriteBatch spriteBatch)
        {

        }
        //public override void RenderEntity(Entity entity, SpriteBatch spriteBatch)
    }
}
