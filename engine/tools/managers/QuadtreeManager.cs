using Microsoft.Xna.Framework;
using System.Collections.Generic;


namespace Abyss
{
    public class Region
    {
        Vector2 Center = new Vector2(0f, 0f);
        float Size = 0f;

        public Region(Vector2 center, float size)
        {
            Center = center;
            Size = size;
        }

        bool Contains(Vector2 point)
        {
            return false;
        }

        bool Intersect(Rectangle renctange)
        {
            return false;
        }
    }
    public class QuadTree
    {
        int Capacity;
        Region boundary;
        List<QuadTree> subTrees = new List<QuadTree>();

        public QuadTree(Vector2 center, float size, int capacity=4)
        {
            Capacity = capacity;
            this.boundary = new Region(center, size);
        }

        void Insert(Vector2 point)
        {

        }

        void Subdivise()
        {

        }
    }
}
