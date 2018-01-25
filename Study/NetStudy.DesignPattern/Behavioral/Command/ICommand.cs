namespace NetSutdy.DesignPattern.Behavioral.Command
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}