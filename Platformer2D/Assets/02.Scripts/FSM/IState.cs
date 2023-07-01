using System;

public interface IState<T> where T : Enum
{
    // State가 실행가는한지 ( ex)점프는 땅에 발이 닿았을 때만 실행 )
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
