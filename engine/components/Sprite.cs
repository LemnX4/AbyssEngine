using Microsoft.Xna.Framework;


namespace Abyss
{
    public class Sprite : Component
    {
        public SpriteSheet SpriteSheet { get; set; }
        public Point Coordinate { get; set; } = new(0, 0);
    }
}