# Command pattern
요청을 객체형태로 캡슐화하여 사용자가 보낸 요청을 나중에 사용할 수 있도록 매서드 이름, 매개변수등 요청에 필요한 정보를 저장 또는 로깅, undo, redo 할 수 있게 하는 패턴

도무지 스타에 Command pattern을 적용할만한게 없어서 또 http://hongjinhyeon.tistory.com/49 에서 아이디어 가져옴.
차이점은 해당 블로그에서는 UML에는 Invoker(MapEditor) 에서 Receiver를 참조하지 않지만, 실제 코드에서는 참조(커플링)이 있길래 해당 커플링을 없애다 보니 코드가 조금 다름.

<b>Client</b> : Invoker에게 Command(명령)를 전달하는 객체
<b>Command</b> : Client가 요청한 명령
```cs
public interface ICommand
{
    void Execute();
    void Undo();
}
```
<b>Invoker</b> : Client가 요청한 명령을 Receiver로 전달하는 매체(리모콘, 스위치 등등)
```cs
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
    .
    .
    .
}
```
<b>Receiver</b> : Client가 내린 명령을 최종적으로 받는 오브젝트 (TV, Radio, Air conditional 등등)
```cs
public class UnitController : IUnitController
{
    public void CreateUnit(Unit unit, int x, int y)
    {
        Console.WriteLine($"{unit.GetType().Name} is careated at x:{x} , y:{y}");
    }

    public void DeleteUnit(Unit unit, int x, int y)
    {
        Console.WriteLine($"{unit.GetType().Name} at x:{x} , y:{y} is deleted");
    }
}

```
Client가 명령을 내리면, 
```cs
//Commands
Unit marin = new StupidMarine();
ICommand createCommand = new CreateUnitCommand(unitController, marin, 100, 200);
```
Invoker가 이 명령을 받아서,
```cs
//Invoker
MapEditor useMapEditor = new MapEditor();
useMapEditor.SetCommand(createCommand);
```
명령이 실행될때,
```cs
useMapEditor.ExecuteCommand();
```
그 명령을 리스트에 저장하고, 
```cs
public void ExecuteCommand()
{
    _commands.Add(_currentCommand);
    _currentCommand.Execute();
}

```
해당 리스트에서 명령을 꺼내서 다시 undo, redo를 실행 할 수있음.
```cs
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

```
