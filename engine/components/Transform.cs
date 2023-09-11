using Microsoft.Xna.Framework;


namespace Abyss
{
    public class Transform : Component
    {
        public Transform Parent;
        public Vector2 Position { get; set; } = new Vector2(0f, 0f);
        public Vector2 Velocity { get; set; } = new Vector2(0f, 0f);
        public Vector2 Acceleration { get; set; } = new Vector2(0f, 0f);
        public float Rotation { get; set; } = 0f;
    }
}