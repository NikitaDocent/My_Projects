using System;

namespace Entity
{
    public class Leaf : Component
    {
        // Constructor
        public Leaf(string name)
        {
        }
        public override int GetSomeData()
        {
            return 0;
        }

        public override string Display(int depth)
        {
            return new String('-', depth) + name;
        }
    }
}
