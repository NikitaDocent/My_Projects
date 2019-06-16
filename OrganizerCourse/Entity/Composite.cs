using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    [Table("Component")]
    public class Composite : Component
    {
        private List<Component> children = new List<Component>();

        // Constructor
        public Composite(string name)
        {
        }

        public void Add(Component component)
        {
            children.Add(component);
        }

        public void Remove(Component component)
        {
            children.Remove(component);
        }

        public override int GetSomeData()
        {
            return children.Count;
        }

        public override string Display(int depth)
        {
            string result = new String('-', depth) + name + '\n';

            // Recursively display child nodes
            foreach (Component component in children)
            {
                result += component.Display(depth + 2) + '\n';
            }

            return result;
        }
    }
}
