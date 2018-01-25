namespace NetStudy.InDepth.Variant
{
    public class Animal
    {
        public string Name { get; set; }
        public int Power { get; set; }
        public Animal(string name, int power)
        {
            Name = name;
            Power = power;
        }
    }

    public class Lion : Animal
    {
        public Lion(string name, int power) : base(name, power)
        {
        }
    }
}