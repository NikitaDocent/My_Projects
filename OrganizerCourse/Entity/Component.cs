namespace Entity
{
    public abstract class Component
    {
        public string name { get; set; }

        public abstract string Display(int depth);

        public abstract int GetSomeData();

        public  void TemplateMethod(int depth)
        {
            GetSomeData();
            Display(depth);
        }
    }
}
