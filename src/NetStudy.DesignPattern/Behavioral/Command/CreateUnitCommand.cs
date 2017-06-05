using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Behavioral.Command
{
    public class CreateUnitCommand : ICommand
    {
        private Unit _unit;
        private int _x;
        private int _y;

        private IUnitController _unitController;

        public CreateUnitCommand(IUnitController unitController, Unit unit, int x, int y)
        {
            _unitController = unitController;
            _unit = unit;
            _x = x;
            _y = y;
        }

        public void Execute()
        {
            _unitController.CreateUnit(_unit, _x, _y);
        }

        public void Undo()
        {
            _unitController.DeleteUnit(_unit, _x, _y);
        }
    }
}