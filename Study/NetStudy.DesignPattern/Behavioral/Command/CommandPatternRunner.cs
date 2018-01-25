using System;
using NetStudy.Core;
using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Behavioral.Command
{
    public class CommandPatternRunner : IRunner
    {
        public void Run()
        {
            //Receiver
            IUnitController unitController = new UnitController();

            //Commands
            Unit marin = new StupidMarine();
            ICommand createCommand = new CreateUnitCommand(unitController, marin, 100, 200);

            //Invoker
            MapEditor useMapEditor = new MapEditor();
            useMapEditor.SetCommand(createCommand);
            useMapEditor.ExecuteCommand();

            Unit firebat = new FireBat();
            createCommand = new CreateUnitCommand(unitController, firebat, 300, 400);
            useMapEditor.SetCommand(createCommand);
            useMapEditor.ExecuteCommand();

            Unit smartMarin = new SmartMarine();
            createCommand = new CreateUnitCommand(unitController, smartMarin, 500, 600);
            useMapEditor.SetCommand(createCommand);
            useMapEditor.ExecuteCommand();
            Console.WriteLine();

            useMapEditor.UndoCommand();
            useMapEditor.UndoCommand();
            useMapEditor.UndoCommand();
            Console.WriteLine();

            useMapEditor.RedoCommand();
            useMapEditor.RedoCommand();
            Console.WriteLine();

            useMapEditor.UndoCommand();
            useMapEditor.UndoCommand();
            useMapEditor.UndoCommand();
        }
    }
}
