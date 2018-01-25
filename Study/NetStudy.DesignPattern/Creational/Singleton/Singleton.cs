namespace NetSutdy.DesignPattern.Creational.Singleton
{
    public sealed class Singleton
    {
        public static Singleton Instance { get; } = new Singleton();
        static Singleton()
        {
        }

        private Singleton()
        {
        }

        public string Name { get; set; }
    }
}
