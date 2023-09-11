using System.Collections.Generic;


namespace Abyss
{
    public class Entity
    {
        public List<Component> Components { get; protected set; } = new List<Component>();
        public void AddComponent(Component component)
        {
            component.HostEntity = this;
            Components.Add(component);

            foreach (System system in MyGame.Systems)
            {
                if (system.Requirements(this) && !system.EntityBucket.Contains(this))
                    system.EntityBucket.Add(this);
            }
        }

        public void RemoveComponent<T>() where T : Component
        {
            var toRemove = Components.Find(component => component is T);

            if (!(toRemove is null))
                Components.Remove(toRemove);

            foreach (System system in MyGame.Systems)
            {
                if (!system.Requirements(this) && system.EntityBucket.Contains(this))
                    system.EntityBucket.Remove(this);
            }
        }

        public void RemoveFromAllSystems()
        {
            foreach (System system in MyGame.Systems)
                system.EntityBucket.Remove(this);
        }

        public bool HasComponent<T>() where T : Component
        {
            return Components.Find(component => component is T) != null;
        }

        public T GetComponent<T>() where T : Component
        {
            return (T)Components.Find(component => component is T);
        }
    }
}