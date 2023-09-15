using Microsoft.Xna.Framework;
using System.Collections.Generic;


namespace Abyss
{
    public class Region
    {
        public Vector2 Center { get; set; } = new Vector2(0f, 0f);
        public float Size { get; set; } = 0f;

        public Region(Vector2 center, float size)
        {
            Center = center;
            Size = size;
        }

        bool Contains(Vector2 point)
        {
            return false;
        }

        bool Intersect(Rectangle rectange)
        {
            return false;
        }
    }
    public class QuadTree
    {
        public int Capacity { get; set; }
        public Region Boundary { get; set; }
        public List<QuadTree> SubTrees { get; set; } = new List<QuadTree>();

        public QuadTree(Vector2 center, float size, int capacity=4)
        {
            Capacity = capacity;
            Boundary = new Region(center, size);
        }

        void Insert(Vector2 point)
        {

        }

        void Subdivise()
        {

        }
    }
}
