using System;

public interface ICommand
{
    public event Action<ICommand> End;
}