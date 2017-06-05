using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Behavioral.Command
{
    public class DeleteUnitCommand : ICommand
    {
        private IUnitController _unitController;

        private Unit _unit;
        private int _x;
        private int _y;

        public DeleteUnitCommand(IUnitController unitController, Unit unit, int x, int y)
        {
            _unitController = unitController;
            _unit = unit;
            _x = x;
            _y = y;
        }

        public void Execute()
        {
            _unitController.DeleteUnit(_unit, _x, _y);
        }

        public void Undo()
        {
            _unitController.CreateUnit(_unit, _x, _y);
        }
    }
}