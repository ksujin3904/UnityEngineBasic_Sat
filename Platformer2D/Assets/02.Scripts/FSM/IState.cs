using System;

public interface IState<T> where T : Enum
{
    // State�� ���డ������ ( ex)������ ���� ���� ����� ���� ���� )
    bool canExecute {get;}

    public enum Step
    {
        None,
        Start,
        Casting,
        OnAction,
        Finish
    }
    Step step { get; }
    T MoveNext();
    void Reset();
}
