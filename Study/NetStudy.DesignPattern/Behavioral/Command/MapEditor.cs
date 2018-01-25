using System;
using System.Collections.Generic;
using System.Linq;

namespace NetSutdy.DesignPattern.Behavioral.Command
{
    public class MapEditor
    {
        private readonly IList<ICommand> _commands;
        private readonly IList<ICommand> _redoCommands;
        private ICommand _currentCommand;

        public MapEditor()
        {
            _commands = new List<ICommand>();
            _redoCommands = new List<ICommand>();
        }

        public void SetCommand(ICommand command)
        {
            _currentCommand = command;
        }

        public void ExecuteCommand()
        {
            _commands.Add(_currentCommand);
            _currentCommand.Execute();
        }

        public void UndoCommand()
        {
            if (_commands.Any())
            {
                var lastCommand = _commands.Last();
                lastCommand.Undo();
                _redoCommands.Add(lastCommand);
                _commands.Remove(lastCommand);
            }
            else
            {
                Console.WriteLine("No more command to undo");
            }
        }

        public void RedoCommand()
        {
            if (_redoCommands.Any())
            {
                var lastCommand = _redoCommands.Last();
                lastCommand.Execute();
                _commands.Add(lastCommand);
                _redoCommands.Remove(lastCommand);
            }
            else
            {
                Console.WriteLine("No more command to Redo");
            }
        }
    }
}
